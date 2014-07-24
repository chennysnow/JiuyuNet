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
using System.Xml.Linq;

public partial class userCon_userMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImgBtnAout_Click(object sender, ImageClickEventArgs e)
    {
        Session.Remove("user");
        op.staValue.MessageShow(this.Page, "Login  Out!", "index.aspx");
    }
}
