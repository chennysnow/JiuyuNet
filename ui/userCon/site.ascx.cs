using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class userCon_site : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBin.dataBin databin = new dataBin.dataBin();
            liSite.Text = databin.getSite(Request.Url.AbsolutePath.ToLower().Replace("/testsite/",""), Request.QueryString["id"], Request.QueryString["typ"]);
        }
    }
}