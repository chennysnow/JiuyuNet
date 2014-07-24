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

public partial class userCon_leftImg : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            dal.FlashDB flash = new dal.FlashDB();
            List<mo.flash> modelList = flash.getModelListWhere("where typS='left'");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < modelList.Count; i++)
            {
                sb.AppendFormat("<li style='margin-bottom:5px'><a href='{0}'><img src='{1}' alt='{2}' width='190px' /></a></li>",modelList[i].urlC,modelList[i].imgC,modelList[i].nameC);
            }
            liImg.Text = sb.ToString();
        }
    }
}
