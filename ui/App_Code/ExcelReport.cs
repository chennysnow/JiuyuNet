using System;
using Excel = Microsoft.Office.Interop.Excel;

    public class InsertPictureToExcel
    {
        /// &lt;summary&gt;
        /// 打开没有模板的操作。
        /// &lt;/summary&gt;
        public void Open()
        {
            this.Open(String.Empty);
        }

        /// &lt;summary&gt;
        /// 功能：实现Excel应用程序的打开
        /// &lt;/summary&gt;
        /// &lt;param name="TemplateFilePath"&gt;模板文件物理路径&lt;/param&gt;
        public void Open(string TemplateFilePath)
        {
            //打开对象
            m_objExcel = new Excel.Application();
   

            if (m_objExcel.Version != "11.0")
            {
              //  MessageBox.Show("您的 Excel 版本不是 11.0 （Office 2003），操作可能会出现问题。");
                m_objExcel.Quit();
                return;
            }

            m_objBooks = (Excel.Workbooks)m_objExcel.Workbooks;
            if (TemplateFilePath.Equals(String.Empty))
            {
                m_objBook = (Excel._Workbook)(m_objBooks.Add(m_objOpt));
            }
            else
            {
                m_objBook = m_objBooks.Open(TemplateFilePath, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                  m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            }
            m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
            m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            m_objExcel.UserControl = true;
            //m_objExcel.Visible = false;
            //m_objExcel.DisplayAlerts = false;

            for (int i = 0; i < m_objSheet.UsedRange.Rows.Count; i++)
            {
                //取单元格值；
                for (int col = 1; col <= m_objSheet.UsedRange.Columns.Count; col++)
                {
                    Excel.Range range = m_objSheet.Cells[i, col] as Excel.Range;
                    sb.Append("," + col.ToString() + ":" + range.Text);
                }

            }

            if (m_objSheet.Shapes.Count >0)
            {
                Excel.Shape s = m_objSheet.Shapes.Item(1) as Excel.Shape;
                //s.CopyPicture(Appearance.Button, Excel.XlCopyPictureFormat.xlBitmap);　//COPY到内存。
                //IDataObject iData = Clipboard.GetDataObject();
                //if (iData.GetDataPresent(DataFormats.Bitmap))
                //{
                //    pictureBox1.Image = (Bitmap)iData.GetData(DataFormats.Bitmap);    //从内存取值；
                //    pictureBox1.Image.Save(string.Format(@"D:\{0}.jpg", row));        //保存。
                //}
                //else
                //{
                //    pictureBox1.Image = null;
                //}
            }






            m_objExcel.WorkbookBeforeClose += new Excel.AppEvents_WorkbookBeforeCloseEventHandler(m_objExcel_WorkbookBeforeClose);
        }

        private void m_objExcel_WorkbookBeforeClose(Excel.Workbook m_objBooks, ref bool _Cancel)
        {
           // MessageBox.Show("保存完毕！");
        }

        /// &lt;summary&gt;
        /// 将图片插入到指定的单元格位置。
        /// 注意：图片必须是绝对物理路径
        /// &lt;/summary&gt;
        /// &lt;param name="RangeName"&gt;单元格名称，例如：B4&lt;/param&gt;
        /// &lt;param name="PicturePath"&gt;要插入图片的绝对路径。&lt;/param&gt;
        public void InsertPicture(string RangeName, string PicturePath)
        {
            m_objRange = m_objSheet.get_Range(RangeName, m_objOpt);
            m_objRange.Select();
            Excel.Pictures pics = (Excel.Pictures)m_objSheet.Pictures(m_objOpt);
            pics.Insert(PicturePath, m_objOpt);
        }

        /// &lt;summary&gt;
        /// 将图片插入到指定的单元格位置，并设置图片的宽度和高度。
        /// 注意：图片必须是绝对物理路径
        /// &lt;/summary&gt;
        /// &lt;param name="RangeName"&gt;单元格名称，例如：B4&lt;/param&gt;
        /// &lt;param name="PicturePath"&gt;要插入图片的绝对路径。&lt;/param&gt;
        /// &lt;param name="PictuteWidth"&gt;插入后，图片在Excel中显示的宽度。&lt;/param&gt;
        /// &lt;param name="PictureHeight"&gt;插入后，图片在Excel中显示的高度。&lt;/param&gt;
        public void InsertPicture(string RangeName, string PicturePath, float PictuteWidth,

    float PictureHeight)
        {
            m_objRange = m_objSheet.get_Range(RangeName, m_objOpt);
            m_objRange.Select();
            float PicLeft, PicTop;
            PicLeft = Convert.ToSingle(m_objRange.Left);
            PicTop = Convert.ToSingle(m_objRange.Top);
            //参数含义：
            //图片路径
            //是否链接到文件
            //图片插入时是否随文档一起保存
            //图片在文档中的坐标位置（单位：points）
            //图片显示的宽度和高度（单位：points）
            //参数详细信息参见：http://msdn2.microsoft.com/zh-cn/library/aa221765(office.11).aspx
            m_objSheet.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse,
              Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, PictuteWidth, PictureHeight);
        }

        /// &lt;summary&gt;
        /// 将Excel文件保存到指定的目录，目录必须事先存在，文件名称不一定要存在。
        /// &lt;/summary&gt;
        /// &lt;param name="OutputFilePath"&gt;要保存成的文件的全路径。&lt;/param&gt;
        public void SaveFile(string OutputFilePath)
        {
            m_objBook.SaveAs(OutputFilePath, m_objOpt, m_objOpt,
              m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
              m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);

            this.Close();
        }
        /// &lt;summary&gt;
        /// 关闭应用程序
        /// &lt;/summary&gt;
        private void Close()
        {
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();
        }

        /// &lt;summary&gt;
        /// 释放所引用的COM对象。注意：这个过程一定要执行。
        /// &lt;/summary&gt;
        public void Dispose()
        {
            ReleaseObj(m_objSheets);
            ReleaseObj(m_objBook);
            ReleaseObj(m_objBooks);
            ReleaseObj(m_objExcel);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
        /// &lt;summary&gt;
        /// 释放对象，内部调用
        /// &lt;/summary&gt;
        /// &lt;param name="o"&gt;&lt;/param&gt;
        private void ReleaseObj(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally { o = null; }
        }

        private Excel.Application m_objExcel = null;
        private Excel.Workbooks m_objBooks = null;
        private Excel._Workbook m_objBook = null;
        private Excel.Sheets m_objSheets = null;
        private Excel._Worksheet m_objSheet = null;
        private Excel.Range m_objRange = null;
        private object m_objOpt = System.Reflection.Missing.Value;
    }
