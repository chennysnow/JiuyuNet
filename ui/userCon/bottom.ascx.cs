using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_bottom : System.Web.UI.UserControl
{
    //dal.news news = new dal.news();
    dal.NewsDB news = new dal.NewsDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string bottom = news.getString("contentC", "where typS='bottom'");
            libottom.Text = bottom;
        }
    }
   
    
}
