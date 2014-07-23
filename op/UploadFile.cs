using System;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing;
namespace op
{
    /// <summary>
    ///UploadFile 的摘要说明
    /// </summary>
    public class UploadFile
    {
        private string _savePath; //保存图片文件路径
        private string _fileType; //允许使用的文件类型
        private int _maxSize; //最大允许上传的图片大小(单位KB)
        private int _maxWidth; //生成小图的最大宽度
        private bool _state; //上传状态(根据这个判断文件是否上传成功)
        private string _message; //上传失败时返回的消息
        private string _fileName; //日期 即文件夹的名称
        //private string _yuanName;//现在的名字 原图的后缀
        private string _proName;//上传到服务器的名字
        private int _maxHeight;//最大高度 也就是画布高度
        private bool _isMadeShuiYin;
        public UploadFile()
        {
            _fileType = "jpg|gif|bmp|png";
            _maxSize = 51200;
            _maxWidth = staValue.imgWidth;
            _maxHeight = staValue.imgHeight;
            _state = true;
            _isMadeShuiYin = true;
            _message = "";
            _proName = System.DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            _fileName = "/images/";
            _savePath = op.staValue.path + "uploadFile";
        }

        #region 属性定义
        /// <summary>
        /// 设置上传路径
        /// <summary>
        public string SavePath
        {
            set
            {
                _savePath = value;
            }
            get
            {
                return _savePath;
            }
        }
        /// <summary>
        /// 最大高度 也就是画布高度
        /// <summary>
        public int maxHeight
        {
            set
            {
                _maxHeight = value;
            }
            get { return _maxHeight; }
        }
        public int maxWidth
        {
            set
            {
                _maxWidth = value;
            }
            get { return _maxWidth; }
        }
        ///<summary>
        /// 设置上传文件的类型,如:jpg|gif|bmp
        ///</summary>
        public string FileType
        {
            set
            {
                _fileType = value.ToLower();
            }
        }
        ///<summary>
        /// 设置上传文件大小,单位为KB 
        ///</summary> 
        public int MaxSize
        {
            set
            {
                _maxSize = value;
            }
            get
            {
                return _maxSize * 1024;
            }
        }
        ///<summary>
        /// 设置是否生成水印
        ///</summary>
        public bool IsMadeShuiYin
        {
            set
            {
                _isMadeShuiYin = value;
            }
        }
        public bool State
        {
            get
            {
                return _state;
            }
        }
        public string Message
        {
            get { return _message; }
        }
        /// <summary>
        /// 上传到服务的文件名
        /// </summary>
        public string proName
        {
            set { _proName = value; }
            get { return _proName; }
        }
        /// <summary>
        /// 上传到服务器的文件夹名字
        /// </summary>
        public string fileName
        {
            set { _fileName = value; }
            get { return _fileName; }
        }
        #endregion
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file">上传控件名称</param>
        public void fileSaveAs(System.Web.HttpPostedFile file)
        {
            try
            {
                if (file != null && file.FileName != "")
                {
                    //获得文件的上传的路径
                    string sourceFilePath = file.FileName;
                    if (sourceFilePath == "" || sourceFilePath == null)
                    {
                        _message = "没有选择要上传的文件!";
                        _state = false;
                        return;
                    }

                    //获得文件扩展名
                    string sEx = System.IO.Path.GetExtension(file.FileName).Replace(".", "");
                    //获得上传文件的大小
                    long postFileSize = file.ContentLength;
                    //分解允许上传文件的格式
                    string[] temp = _fileType.Split('|');
                    //设置上传的文件是否是允许的格式
                    bool flag = false;
                    //判断上传文件大小
                    if (postFileSize >= MaxSize)
                    {
                        _message = "上传的文件不能大于" + _maxSize + "KB";
                        _state = false;
                        return;
                    }
                    foreach (string data in temp)
                    {
                        if (data == sEx.ToLower())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        _message = "目前本系统支持的格式为:" + _fileType;
                        _state = false;
                        return;
                    }
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(SavePath);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    if (proName.IndexOf('.') < 0)
                        proName = proName + "." + sEx;//存数据库的图片名称 products
                    proName = fileName + proName;//图片都在images文件夹下
                    if (!Directory.Exists(SavePath + "/sImg/y" + fileName))
                    {
                        Directory.CreateDirectory(SavePath + "/sImg/y" + fileName);
                    }
                    if (_isMadeShuiYin)
                    {
                        file.SaveAs(SavePath + "/sImg/y" + proName);
                        makeShui(SavePath + "/sImg/y", proName);
                        MakeThumbnail(SavePath + proName, SavePath + "/sImg" + proName);
                    }
                    else
                    {
                        file.SaveAs(SavePath + "/sImg/y" + proName);
                        File.Copy(SavePath + "/sImg/y" + proName, SavePath + proName);
                        MakeThumbnail(SavePath + proName, SavePath + "/sImg" + proName);
                    }
                    Thread.Sleep(15);
                }
                return;
            }
            catch
            {
                _message = "出现未知错误";
                _state = false;
                return;
            }
        }
        public void makeShui(string imgPath, string imgName)
        {
            Image originalImage = Image.FromFile(imgPath + imgName);
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(ow, oh);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            // g.Clear(Color.Transparent);
            g.Clear(Color.White);
            g.DrawImage(originalImage, new Rectangle(0, 0, ow, oh),
                       new Rectangle(x, y, ow, oh),
                       GraphicsUnit.Pixel);
            try
            {
                Image logo = Image.FromFile(staValue.path + "/images/" + "shuiYin.png");
                int logoWidth = logo.Width;
                int logoHeight = logo.Height;
                g = Graphics.FromImage(bitmap);         //画布起点。与区域大小                                                                  图片缩放的大小，大于选择区域不显示
                g.DrawImage(logo, new Rectangle(bitmap.Width - logoWidth, bitmap.Height - logoHeight, logoWidth, logoHeight), new Rectangle(0, 0, logo.Width, logo.Height), GraphicsUnit.Pixel);
                //以jpg格式保存缩略图
                bitmap.Save(SavePath + imgName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
                // System.IO.File.Delete(imgPath + "y" + imgName);//删除原文件
            }

        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式 "HW"指定高宽缩放（可能变形）"W"指定宽，高按比例 "H"指定高，宽按比例  "Cut"指定高宽裁减（不变形）</param>    
        public void MakeThumbnail(string originalImagePath, string thumbnailPath)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            string mode = "";
            int width = _maxWidth, height = _maxHeight;
            int towidth = _maxWidth;
            int toheight = _maxHeight;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            if (ow < oh)
                mode = "H";
            else
                mode = "W";
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(width, height);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            // g.Clear(Color.Transparent);
            g.Clear(Color.White);
            int yy = 0;
            //在指定位置并且按指定大小绘制原图片的指定部分
            //计算高度  不够 从Y轴开始画   达到居中效果
            if (toheight < height)
            {
                yy = (height - toheight) / 2;
            }
            g.DrawImage(originalImage, new Rectangle(0, yy, towidth, toheight),
                       new Rectangle(x, y, ow, oh),
                       GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                //op.xml xml = new xml();
                //string txt = xml.getStr("shui");
                //Font f = new Font("Arial", 12);
                //Brush b = new SolidBrush(Color.FromArgb(153, 131, 5, 20));
                //SizeF strSize = new SizeF();
                //strSize = g.MeasureString(txt, f);
                //float xPos = (width - strSize.Width);//让文字居右下角
                //float yPost = (height - strSize.Height);
                //g.DrawString(txt, f, b, xPos, yPost);
                string dir = thumbnailPath.Substring(0, thumbnailPath.LastIndexOf('/'));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();

            }
        }
    }
}