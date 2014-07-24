using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        mo.news model = news.getModel("where typS='contact'");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<dt>{0}</dt>",model.nameC);
        sb.AppendFormat("<dd>{0}</dd>", model.contentC);
        Page.Title = "Contact Us";
        liNews.Text = sb.ToString();
    }
}
