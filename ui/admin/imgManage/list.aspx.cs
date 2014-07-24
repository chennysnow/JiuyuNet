using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class admin_imgManage_list : System.Web.UI.Page
{
    string path = op.staValue.path + "uploadFile/";
    public string num = "2";
    protected void Page_Load(object sender, EventArgs e)
    {
       num=string.IsNullOrEmpty(Request.QueryString["ckNum"])?"2":Request.QueryString["ckNum"];
        if (!IsPostBack)
        {
            bin();
            binDir(); 
        }
    }
    private void binDir()
    {
        string[] strDr = Directory.GetDirectories(path);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < strDr.Length; i++)
        {
            dropList.Items.Add(new ListItem(strDr[i].Substring(strDr[i].LastIndexOf("/") + 1)));
        }
        dropList.Items.Remove("sImg");
    }
    private void bin()
    {
        string fileName = "",seaKey="*";
        if (Request.QueryString["file"] != null)
        {
            fileName = Request.QueryString["file"];
        }
        if (Request.QueryString["seaKey"] != null)
        {
            seaKey = "*" + Request.QueryString["seaKey"] + "*";
        }
        string[] strFile = Directory.GetFiles(path+fileName,seaKey, SearchOption.TopDirectoryOnly);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        List<imgModel> modelList = new List<imgModel>();
        for (int i = 0; i < strFile.Length; i++)
        {
            imgModel model = new imgModel();
            model.pathC=strFile[i].Substring(strFile[i].LastIndexOf("/") + 1).Replace('\\','/');
            model.allPath="/uploadFile/sImg/" +model.pathC;
            model.nameC=strFile[i].Substring(strFile[i].LastIndexOf("\\") + 1);
            modelList.Add(model);
        }
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        int index = op.staValue.RequestInt(Request.QueryString["p"]);
        pds.CurrentPageIndex = (index > 0 ? index : 1) - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        repList.DataSource = pds;
        repList.DataBind();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        string[] fileName = Request.Form.GetValues("check");
        for (int i = 0; i < fileName.Length; i++)
        {
            string file = path + fileName[i];
            if (File.Exists(file))//水印图
            {
                File.Delete(file);
            }
            if (File.Exists(path + "sImg/y/" + fileName[i]))//原图
            {
                File.Delete(path + "sImg/y/" + fileName[i]);
            }
            if (File.Exists(path + "sImg/" + fileName[i]))//缩略图
            {
                File.Delete(path + "sImg/" + fileName[i]);
            }
        }
        MessageShow("删除成功!");
    }
    private void MessageShow(string msg)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript'>alert('" + msg.ToString() + "');window.location.href=window.location.href;</script>");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string fileName = path+Request.Form["editFile"];
        if (File.Exists(fileName))
        {
            string newFile = fileName.Substring(0, fileName.LastIndexOf('/') + 1) + Request.Form["editFileName"];
            if (File.Exists(newFile))
            {
                MessageShow("文件名已存在!");
            }
            else
                File.Move(fileName, newFile);
            Response.Redirect(Request.RawUrl);
        }
    }
    protected void lbtnEditDir_Click(object sender, EventArgs e)
    {
        try
        {
            string[] fileName = Request.Form.GetValues("check");
            for (int i = 0; i < fileName.Length; i++)
            {
                string file = path + fileName[i];
                if (File.Exists(file))
                {
                    string newFile = dropList.SelectedValue + fileName[i].Substring(fileName[i].IndexOf('/'));
                    File.Move(file, path + newFile);
                    File.Move(path + "sImg/y/" + fileName[i], path + "sImg/y/" + newFile);
                    File.Move(path + "sImg/" + fileName[i], path + "sImg/" + newFile);
                }
            }
            MessageShow("转移成功!");
        }
        catch (IOException xe)
        {
            MessageShow(xe.Message);
        }
    }
    protected void lbtnMakeShui_Click(object sender, EventArgs e)
    {
        string[] fileName = Request.Form.GetValues("check");
        op.UploadFile file = new op.UploadFile();
        for (int i = 0; i < fileName.Length; i++)
        {
            string filePath = path + "sImg/y/"+fileName[i];
            if (File.Exists(filePath))
            {
                file.makeShui(path + "/sImg/y", "/"+fileName[i]);//原图在sImg/y里,水印图片则在自己目录下
                file.MakeThumbnail(path + fileName[i], path + "sImg/" + fileName[i]);
            }
        }
    }
}
class imgModel {
    public imgModel() { }
    public string allPath { get; set; }
    public string pathC { get; set; }
    public string nameC { get; set; }
    
}