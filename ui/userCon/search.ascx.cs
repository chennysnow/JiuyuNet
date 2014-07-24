using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_search : System.Web.UI.UserControl
{
    public List<mo.menu> modelList = new List<mo.menu>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            op.staValue sta = new op.staValue();
            modelList = sta.getMenuList(1);
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //for (int i = 0; i < modelList.Count; i++)
            //{
            //    if (modelList[i].typ == 1)
            //    {
            //        sb.AppendFormat("<a href=\"proList.aspx?typ={0}\">{1}</a>|", modelList[i].id, modelList[i].nameC);
            //    }
            //}
            //liTopMenu.Text = sb.ToString();
        }
    }
}