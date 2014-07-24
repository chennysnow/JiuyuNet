<%@ WebHandler Language="C#" Class="validate" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
public class validate : IHttpHandler, IRequiresSessionState
{
    HttpContext context_1;
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context_1 = context;
        if (context.Request.Form["count"] != null)
            Validate(Convert.ToInt32(context.Request.Form["count"]));
        else
            Validate(5);
    }
    /// <summary>
    /// 生成随机验证码
    /// </summary>
    /// <param name="count">生成几位的验证码</param>
    /// <returns>返回生成的数字</returns>
    public string Validate(int count)
    {
        string validateNum = CreateRandomNum(count);//生成4位随机字符串
        context_1.Session["Validate"] = validateNum.ToLower();
        CreateImage(validateNum);               //将生成的随机字符串绘成图片
        return validateNum;
    }
    //生成随机字符串
    private string CreateRandomNum(int NumCount)
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";  //A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z, 如果要将小写字母叫上去把t.i的值加上就行
        string[] allCharArray = allChar.Split(',');  //拆分成数组
        string randomNum = "";
        //  int temp = -1;         //记录上次随机数的数值，尽量避免产生几个相同的随机数
        Random rand = new Random();
        for (int i = 0; i < NumCount; i++)
        {
            int t = rand.Next(36);
            randomNum += allCharArray[t];
        }
        return randomNum;
    }
    //生成图片
    private void CreateImage(string validateNum)
    {
        if (validateNum == null || validateNum.Trim() == string.Empty)
            return;
        //生成Bitmap图像
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(validateNum.Length * 12 + 10, 22);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随机生成器
            Random random = new Random();
            //清空图片背景色
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 100; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Green, Color.DarkRed, 1.2f, true);//改变此处的green可以改变字体的颜色
            g.DrawString(validateNum, font, brush, 2, 2);
            //画图的前景噪音点
            for (int i = 0; i < 25; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);//改变此处的参数可以改变图片的边框
            //将图像保存到指定的流
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context_1.Response.Buffer = true;
            context_1.Response.Expires = -1;
            context_1.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context_1.Response.Expires = 0;
            context_1.Response.CacheControl = "no-cache";
            context_1.Response.ClearContent();
            context_1.Response.ContentType = "image/Jpeg";
            context_1.Response.BinaryWrite(ms.ToArray());
        }
        catch
        {

        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}