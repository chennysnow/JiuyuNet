<%@ WebHandler Language="C#" Class="Ajax_New" %>

using System;
using System.Web;
using System.Collections.Generic;
public class Ajax_New : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        setWeb sw = new setWeb();
        context.Response.ContentType = "text/plain";
        //sw.Create("CopyNew.aspx", "mastNew.html");//缓存要用的数据
        //string strMaster=null;
        //if(context.Cache.Get("master")==null)
        //{
        //    strMaster = sw.ReadMaster("mastNew.html");
        //  context.Cache.Insert("master", strMaster, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        //}
        //else
        //{
        //    strMaster=context.Cache.Get("master").ToString();
        //}
        //if (string.IsNullOrEmpty(strMaster))
        //{
        //    context.Response.Write("生成出错！");
        //    context.Response.End();
        //}
        //dal.news news = new dal.news();
        MySqlDal.NewsDB news = new MySqlDal.NewsDB();
        List<mo.news> modelList = news.getModelListAll();
        for (int i = 0; i < modelList.Count; i++)//得到所有的
        {
            //string str = strMaster;
            //str = str.Replace("$title$", modelList[i].title);
            //str = str.Replace("$keyWords$", modelList[i].keyWords);
            //str = str.Replace("$description$", modelList[i].description);
            //str = str.Replace("$content$", modelList[i].content);
            //str = str.Replace("$time$", modelList[i].time);
            //dal.menuDb menu = new dal.menuDb();
            //mo.menuModel modelMenu = menu.getModel("where id=" + modelList[i].type);
            //if (modelMenu != null)
            //    str=str.Replace("$siteHtml$","<a href='" + modelMenu.staname + "'>" + modelMenu.menu + "</a>><a href='#'>" + modelList[i].title + "</a>");
            //else
            //    str = str.Replace("$siteHtml$", "<a href='#'>" + modelList[i].title + "</a>");
            //sw.WriterPage(str,modelList[i].staticName);
            //if(modelList[i].typ==3)
            //    sw.Create("About.aspx?id=" + modelList[i].id, modelList[i].htmlName);
            //else
                sw.Create("NewShow.aspx?id=" + modelList[i].id, "news/"+modelList[i].htmlName);
        }
        context.Response.Write("<font style='color:red'>生成成功！</font>");
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}