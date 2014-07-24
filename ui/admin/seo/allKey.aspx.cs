using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
public partial class admin_seo_allKey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "关键词管理";
        if (!IsPostBack)
        {
            op.xml xml = new op.xml("allKey");
            txtAllKey.Text = xml.getAllKey("allKey");
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        op.xml xml = new op.xml("allKey");
        xml.setAllKey(txtAllKey.Text,"allKey");
        op.staValue.divAlert(Page, "修改成功!");
    }
}