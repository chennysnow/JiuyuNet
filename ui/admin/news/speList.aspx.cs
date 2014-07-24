using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class admin_news_speList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "特殊文章:包含关于我们,联系我们,网站底部等...";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        List<mo.news> modelList = news.getModelListWhere("", "and typS<>'0'");
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    public string getUrl(string typ)
    {
        switch (typ)
        {
            case "online":
            case "bottom": return "content.aspx";
            case "contact":
            case "about": 
            default: return "noHtmlName.aspx";
        }
    }
}
