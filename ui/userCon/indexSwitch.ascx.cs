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

public partial class userCon_indexSwitch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder sbBig = new System.Text.StringBuilder();
            System.Text.StringBuilder sbSmoll = new System.Text.StringBuilder();
            //dal.flash flash = new dal.flash();
            dal.FlashDB flash = new dal.FlashDB();
            List<mo.flash> modelList = flash.getModelListWhere("where typS='index'");
            if (modelList.Count > 0)
            {
                string[] arr = modelList[0].imgC.Split('@');
                sbBig.AppendFormat("<div class='switchOpen'><a href='{0}'><img src='{1}' alt='{2}' /></a></div>", modelList[0].urlC,arr[0], modelList[0].nameC);
                sbSmoll.AppendFormat("<div class='switchOpen'><a href='{0}'><img src='{1}' alt='{2}' width='145px' height='80px' /></a></div>", modelList[0].urlC, arr[1], modelList[0].nameC);
            }
            for (int i = 1; i < modelList.Count; i++)
            {
                string[] arr = modelList[i].imgC.Split('@');
                sbBig.AppendFormat("<div><a href='{0}'><img src='{1}' alt='{2}' /></a></div>",modelList[i].urlC,arr[0],modelList[i].nameC);
                sbSmoll.AppendFormat("<div><a href='{0}'><img src='{1}' alt='{2}' width='145px' height='80px' /></a></div>", modelList[i].urlC, arr[1], modelList[i].nameC);
            }
            liBig.Text = sbBig.ToString();
            liSmoll.Text = sbSmoll.ToString();
        }
    }
}
