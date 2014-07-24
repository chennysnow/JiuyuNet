using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_contact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        if (!IsPostBack)
        {
            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            string contact= news.getString("aboutC", "where typS='contact'");
            liContact.Text = ope.removeHtml(contact);
        }
    }
}