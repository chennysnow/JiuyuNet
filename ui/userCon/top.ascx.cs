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
public partial class userCon_top : System.Web.UI.UserControl
{
    public string topKey { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.link link = new dal.link();
            dal.LinkDB link = new dal.LinkDB();
            List<mo.link> modelLink = link.getModelListWhere("where typS='top'");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < modelLink.Count; i++)
            {
                sb.AppendFormat("<a href='{0}'>{1}</a>&nbsp;&nbsp;", modelLink[i].urlC, modelLink[i].nameC);
            }
            likeywords.Text = sb.ToString();
            List<mo.link> topLink = link.getModelListWhere("where typS='Rec'");
            System.Text.StringBuilder sbtop = new System.Text.StringBuilder();
            for (int i = 0; i < topLink.Count; i++)
            {
                sbtop.AppendFormat("<a href='{0}'>{1}</a>&nbsp;&nbsp;", topLink[i].urlC, topLink[i].nameC);
            }
            liTopKeyword.Text = sbtop.ToString(); ;
            //dal.news news = new dal.news();
            dal.NewsDB news = new dal.NewsDB();
            String contact = news.getString("aboutC", "where typS='contact'");
            liContact.Text = contact;
        }
    }
}