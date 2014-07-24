using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_siteMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setWeb sta = new setWeb();
            sta.webSite();
            op.staValue.divAlert(Page, "生成成功!", "index.aspx");
        }
    }
}