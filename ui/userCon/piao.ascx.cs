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

public partial class userCon_piao : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            string strContent = news.getString("contentC", "where typS='onLine'");
            op.Operation ope = new op.Operation();
            liContent.Text = ope.StrDecode(strContent);
        }
    }
}
