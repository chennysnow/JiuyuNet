using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class admin_imgManage_left : System.Web.UI.Page
{
    string path = op.staValue.path + "uploadFile/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["del"] != null)
            {
                if(Directory.Exists(path+Request.QueryString["del"]))
                {
                    if (Directory.GetFiles(path + Request.QueryString["del"]).Length > 0)
                    {
                        MessageShow("请删除文件夹里面的文件，再删除文件夹!");

                    }
                    else
                    {
                        Directory.Delete(path + Request.QueryString["del"]);
                        MessageShow("删除成功!");
                    }
                }
            }
            binDir();
        }
    }
    private void binDir()
    {
        string[] strDr = Directory.GetDirectories(path);
        string[] systemDir = new string[] { "flash", "files", "images", "menu" };
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        for (int i = 0; i < strDr.Length; i++)
        {
            bool flg = false;
            string dirName = strDr[i].Substring(strDr[i].LastIndexOf("/") + 1);
            if (dirName == "sImg" || dirName == "Report")
                continue;
            for (int j = 0; j < systemDir.Length; j++)
            {
                if (dirName == systemDir[j])
                {
                    flg = true;
                    break;
                }
            }
            if (flg)
            {
                sb.AppendFormat("<li><a href='list.aspx?file={0}&ckNum={1}' target='list' title='查看此文件夹的文件'>{0}</a> <font color='red'>系统文件</font> <span onclick=\"del('{0}')\">删除</span></li>", dirName, Request.QueryString["ckNum"]);
            }
            else
            {
                sb.AppendFormat("<li><a href='list.aspx?file={0}&ckNum={1}' target='list' title='查看此文件夹的文件'>{0}</a> <span onclick=\"del('{0}')\">删除</span></li>", dirName, Request.QueryString["ckNum"]);
            }
            sb1.AppendFormat("<option value='{0}'>{0}</option>", dirName);
        }
        liDropList.Text = sb1.ToString();
        liFileUpload.Text = sb1.ToString();
        liDir.Text = sb.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(path + txtDir.Text))
        {
            Directory.CreateDirectory(path + txtDir.Text);
            binDir();
        }
        else
        {
            MessageShow("目录已存在");
        }
    }
    /// <summary>
    /// 显示消息提示对话框
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="msg">提示信息</param>
    private void MessageShow(string msg)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript'>alert('" + msg.ToString() + "');</script>");
    }
    protected void btnFile_Click(object sender, EventArgs e)
    {
        //图片有三处:分别是uploadFile-水印图,sImg-缩略图,sImg/y-原图
        op.UploadFile file = new op.UploadFile();
        if (fileAdd.HasFile)
        {
            string dir = "/" + Request.Form["dropFileUpload"] + "/" + fileAdd.FileName;
            if (File.Exists(path + "sImg/y" + dir))
            {
                op.Operation ope = new op.Operation();
                string sEx = System.IO.Path.GetExtension(fileAdd.FileName);
                dir = "/" + Request.Form["dropFileUpload"] + "/" + ope.NameRndOnly() + sEx;
            }
            if (!Directory.Exists(path + "sImg/y/" + Request.Form["dropFileUpload"]))
            {
                Directory.CreateDirectory(path + "sImg/y/" + Request.Form["dropFileUpload"]);
            }
            fileAdd.SaveAs(path + "sImg/y" + dir);
            if (Request.Form["check"] != null)
            {
                file.makeShui(path + "/sImg/y", dir);//原图在sImg/y里,水印图片则在自己目录下
            }
            else
            {
                File.Copy(path + "sImg/y" + dir, path + dir);//移动不打水印的图片
            }
            file.MakeThumbnail(path + dir, path + "/sImg" + dir);
        }
    }
}