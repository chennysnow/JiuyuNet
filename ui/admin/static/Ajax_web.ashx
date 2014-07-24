<%@ WebHandler Language="C#" Class="Ajax_web" %>

using System;
using System.Web;
using System.Collections.Generic;
public class Ajax_web : IHttpHandler {
    setWeb sw = new setWeb();
    HttpContext context=null;
    public void ProcessRequest(HttpContext context1)
    {
        context1.Response.ContentType = "text/plain";
        context = context1;
        if (context.Request.Form["typStatic"] != null)
        {
            string typ = context.Request.Form["typStatic"].ToString();
            switch (typ)
            {
                case "sitmap":
                     Random rand=new Random();
                        sw.clBuffer=rand.Next(1,100).ToString();
                    if (context.Request.Cookies["buffer"] != null)
                        context.Response.Cookies["buffer"].Value = sw.clBuffer;
                    else
                    {
                        HttpCookie cookie;
                        cookie = new HttpCookie("buffer", sw.clBuffer);
                        cookie.Expires = DateTime.Now.AddDays(3);
                        cookie.Path = "/";
                        HttpContext.Current.Response.Cookies.Add(cookie); 
                    }
                    sw.webSite(); sw.updateContainId(); sw.updateCount(1); sw.updateCacheFile();
                    context.Response.Write("<font color='red'><b>更新成功</b></font>");
                    break;
                case "NewMenuCount": NewMenuCount(); break;
                case "CreatNewList": CreatNewList(int.Parse(context1.Request.Form["menu"])); break;
                case "ProMenuCount": ProMenuCount(); break;
                case "CreatProList": CreatProList(int.Parse(context1.Request.Form["menu"].ToString())); break;
                case "index": web("index.aspx", "index.html", "<b>首页:</b>"); break;
                case "contact": web("NewShow.aspx?id=2", "Contact.html", "<b>联系我们:</b>"); break;
                case "about": web("About.aspx", "About.html", "<b>关于我们:</b>"); break;
                case "type": web("proCategory.aspx", "proCategory.html", "<b>产品类别:</b>"); break;
                
            }
        }
    }
    private void web(string aspName,string htmlName,string info)
    {
        sw.Create(aspName,htmlName);
        context.Response.Write("<font style='color:red'>"+info+"生成成功！</font>");
        context.Response.End();
    }
    private void ProMenuCount()
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        string count = menu.getString("count(*)", "where typ=1");
        context.Response.Write(count);
        context.Response.End();
    }
    private void NewMenuCount()
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        string count = menu.getString("count(*)", "where typ=2");
        context.Response.Write(count);
        context.Response.End();
    }
    private void CreatNewList(int menuCount)
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        List<mo.menu> modelList = menu.getModelListWhere("where typ=2");
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        List<mo.news> modelNews = news.getModelListWhere("", "and typ=" + modelList[menuCount].id);
        int pageSize = op.staValue.newsSize;
        int pageCount = 1;
        if (modelNews.Count > 0)
        {
            if (modelNews.Count % pageSize == 0)
            {
                pageCount = modelNews.Count / pageSize;
            }
            else
            {
                pageCount = modelNews.Count / pageSize + 1;
            }
        }
        //sw.Create("CompanyNewList.aspx?typeid=" + modelList[menuCount].id, modelList[menuCount].staname);
        sw.Create("NewList.aspx?typ="+modelList[menuCount].id, modelList[menuCount].htmlName);
        for (int i = 1; i <= pageCount; i++)
        {
            sw.Create("NewList.aspx?p=" + i+"&typ="+modelList[menuCount].id, i+"_"+modelList[menuCount].htmlName);
        }
        if (menuCount != modelList.Count - 1)
            context.Response.Write("正在生成&nbsp;" + modelList[menuCount].nameC + "&nbsp;菜单..请稍后..");
        else
            context.Response.Write("<font style='color:red'>生成成功！</font><br/>正在生成&nbsp;" + modelList[menuCount].nameC + "&nbsp;菜单..请稍后");
        context.Response.End();
    }
    private void CreatProList(int menuCount)
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        List<mo.menu> modelList = menu.getModelListWhere("where typ=1");
        //dal.products pro = new dal.products();
        dal.ProductsDB pro = new dal.ProductsDB();
        int pageSize = op.staValue.pageSize;
        int pageCount = 1;
        if (menuCount == 0)//在第一次调用时把products页面生成下
        {
            int co = int.Parse(pro.getString("count(*)", ""));
            if (co > 0)
            {
                if (co % pageSize == 0)
                {
                    pageCount = co / pageSize;
                }
                else
                {
                    pageCount = co / pageSize + 1;
                }
            }
            //要生成的静态页面
            sw.Create("ProList.aspx", "ProList.html");
            for (int j = 1; j <= pageCount; j++)
            {
                sw.Create("ProList.aspx?p=" + j, "ProList_" + j + ".html");//首先生成不传参数的产品页
            }
        }
       // string allId = "";//一级包含的ID
        //int count = 0;
        //count = Convert.ToInt32(pro.getString("count(*)", "where addType like '%," + modelList[menuCount].id + ",%'"));
        ProMenu(modelList[menuCount], modelList[menuCount].countC, "ProList.aspx");//生成一级菜单
        List<mo.menu> modelMenu_2 = menu.getModelListWhere("where typ=" + modelList[menuCount].id);//查询二级菜单
        for (int i = 0; i < modelMenu_2.Count; i++)//生成二级菜单
        {
            //List<mo.menu> modelMenu_3 = menu.getModelListWhere("where typ=" + modelMenu_2[i].id);//三级菜单
            //for (int j = 0; j < modelMenu_3.Count; j++)
            //{
            //    count = int.Parse(pro.getString("count(*)", "where typ=" + modelMenu_3[j].id));
            //    ProMenu(modelMenu_3[j], count, "ProList.aspx");
            //    twoId += modelMenu_3[j].id + ",";
            //}
            //twoId += modelMenu_2[i].id;
            //count = Convert.ToInt32(pro.getString("count(*)", "where addType like '%," + modelMenu_2[i].id + ",%'"));
            ProMenu(modelMenu_2[i], modelMenu_2[i].countC, "ProList.aspx");//生成二级菜单
            //allId += twoId + ",";
        }
       // allId += modelList[menuCount].id;
       
        if (menuCount != modelList.Count - 1)
            context.Response.Write("" + modelList[menuCount].nameC + "&nbsp;菜单<font>生成完成</font>..请稍后..&nbsp; 还有" + (modelList.Count - menuCount - 1) + "个菜单");
        else
            context.Response.Write("<font style='color:red'>生成完成！</font><br/>" + modelList[menuCount].nameC + "&nbsp;菜单<font>生成完成</font>");
        context.Response.End();
    }
    /// <summary>
    /// 根据传的菜单集合 生成页
    /// </summary>
    /// <param name="model">主要是id,menu</param>
    /// <param name="Count">属于这个菜单下记录的总数</param>
    /// <param name="strURL">要生成的动态页</param>
    private void ProMenu(mo.menu model, int Count, string strURL)
    {
        int pageSize = op.staValue.pageSize;//一页显示的项数
        int pageCount = 1;//总页数
        //得到每页显示新闻的条数
        sw.Create(strURL + "?typ=" + model.id, model.htmlName);
        //根据新闻总条数计算分页的要生成的页面
        if (Count > 0)
        {
            if (Count % pageSize == 0)
            {
                pageCount = Count / pageSize;
            }
            else
            {
                pageCount = Count / pageSize + 1;
            }
            //要生成的静态页面
            for (int j = 1; j <= pageCount; j++)
            {
                sw.Create(strURL + "?typ=" + model.id + "&p=" + j,j+"_" + model.htmlName);
                //Thread.Sleep(30);
            }
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}