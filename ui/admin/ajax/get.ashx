<%@ WebHandler Language="C#" Class="get" %>

using System;
using System.Web;

public class get : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string typ = context.Request.Form["typ"];
        string str = "";
        switch (typ)
        {
            case "getAllKey": str = getAllKey(); break;
            case "htmlName": str = htmlName(context.Request.Form["htmlName"]); break;
            default: break;
        }
        context.Response.Write(str);
        context.Response.End();
    }
    private string getAllKey()
    {
        op.xml xml = new op.xml("allKey");
        return xml.getAllKey("allKey");
    }
    private string htmlName(string htmlName)
    {
        if(htmlName.IndexOf(".html")<0)
        {
            htmlName=op.staValue.RexSpecial(htmlName)+".html";
        }
        if (System.IO.File.Exists(op.staValue.path + htmlName))
        {
            return "已存在";
        }
        else
        {
            return "<font color='red'>不存在</font>"; 
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}