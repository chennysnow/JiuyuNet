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

public partial class userCon_Notice : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.news news = new dal.news();
            dal.NewsDB news = new dal.NewsDB();
            List<mo.news> modelList = news.getModelListWhere("where typ=9");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < modelList.Count; i++)
            {
                sb.AppendFormat("<li><a href='{0}' title='{1}'>{2}</a></li>",modelList[i].htmlName,modelList[i].aboutC,modelList[i].nameC);
            }
            liNotice.Text = sb.ToString();
        }
    }
}
