<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;
using System.IO;
public class ajax : IHttpHandler {
    HttpContext context1;
    string path = op.staValue.path + "uploadFile/";
    string msg = "";
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context1 = context;
        switch (context.Request.QueryString["action"])
        {
            case "delFile": delFile(); break;
            case "makeThu": makeThu(); break;
            case "batch": batch(); break;
            case "uploadFile": uploadFile(); break;
            default: break; 
        }
        context.Response.Write(msg);
        context.Response.End();
    }
    private void delFile()
    {
        string file = context1.Request.QueryString["path"];
        if (!string.IsNullOrEmpty(file))
        {
            file = path+file;
            if (File.Exists(file))
            {
                File.Delete(file);
                msg = "删除成功!";
            }
            else
                msg = "删除失败!";
        }
        else
        {
            msg = "文件名不能为空!";
        }
    }
    private void makeThu()
    {
        string file = context1.Request.QueryString["path"];
        op.UploadFile upload = new op.UploadFile();
        upload.MakeThumbnail(path+ file, path+"sImg/" + file);
    }
    private void batch()
    {
        try
        {
            HttpPostedFile file;
            op.UploadFile upload = new op.UploadFile();
            string fileName = context1.Request["file"].ToString();
            string shui = context1.Request["shui"].ToString();
            op.Operation ope = new op.Operation();
            if (!Directory.Exists(path + "sImg/y/" + fileName))
            {
                Directory.CreateDirectory(path + "sImg/y/" + fileName);
            }
            for (int i = 0; i < context1.Request.Files.Count; ++i)
            {
                file = context1.Request.Files[i];
                if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                string dir = "/" + fileName + "/" + file.FileName;
                if (File.Exists(path + "sImg/y" + dir))
                {
                    string sEx = System.IO.Path.GetExtension(file.FileName);
                    dir = "/" + fileName + "/" + ope.NameRndOnly() + sEx;
                }
                file.SaveAs(path + "sImg/y" + dir);
                if (shui == "1")
                {
                    upload.makeShui(path + "/sImg/y", dir);//原图在sImg/y里,水印图片则在自己目录下
                }
                else
                {
                    File.Copy(path + "sImg/y" + dir, path + dir);//移动不打水印的图片
                }
                upload.MakeThumbnail(path + dir, path + "/sImg" + dir);
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }
    }
    private void uploadFile()
    {
        HttpPostedFile file = context1.Request.Files[0];
        op.Operation ope = new op.Operation();
        string fileName = "images";
        string fileSubName = "";
        if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) 
            return;
        if (file.FileName.LastIndexOf('\\') > 0)
        {
             fileSubName= file.FileName.Substring(file.FileName.LastIndexOf('\\'), file.FileName.Length - file.FileName.LastIndexOf('\\'));
        }
        string dir = "";
        if (fileSubName != "")
            dir = "/" + fileName + "/" + fileSubName;
        else
            dir = "/" + fileName + "/" + file.FileName;
        if (File.Exists(path + "sImg/y" + dir))
        {
            string sEx = System.IO.Path.GetExtension(file.FileName);
            dir = "/" + fileName + "/" + ope.NameRndOnly() + sEx;
        }
        file.SaveAs(path + "sImg/y" + dir);
        File.Copy(path + "sImg/y" + dir, path + dir);//移动不打水印的图片
        op.UploadFile upload = new op.UploadFile();
        upload.MakeThumbnail(path + dir, path + "/sImg" + dir);
        context1.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + context1.Request.QueryString["CKEditorFuncNum"] + ",'/uploadFile" + dir + "', '上传成功');</script>");
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}