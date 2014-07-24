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

public partial class userCon_rightImg : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            dal.FlashDB flash = new dal.FlashDB();
            List<mo.flash> modelFlash = flash.getModelListWhere("where typS='right'");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < modelFlash.Count; i++)
            {
                sb.AppendFormat("<a href='{0}' title='{2}'><img src='{1}' alt='{2}'/></a>", modelFlash[i].urlC, modelFlash[i].imgC, modelFlash[i].nameC);
            }
            liSwitchBottom.Text = sb.ToString();
        }
    }
}
