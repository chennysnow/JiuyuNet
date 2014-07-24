using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
public partial class MasterPage : System.Web.UI.MasterPage
{
    public string topKey { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(topKey))
            {
                //dal.link link = new dal.link();
                dal.LinkDB link = new dal.LinkDB();
                List<mo.link> modelLink = link.getModelListWhere("where typS='top'");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < modelLink.Count; i++)
                {
                    sb.AppendFormat("<a href='{0}'>{1}</a>&nbsp;|&nbsp;", modelLink[i].urlC, modelLink[i].nameC);
                }
                topKey = sb.ToString();
            }
        }
    }
}
