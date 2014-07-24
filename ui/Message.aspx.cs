using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
public partial class Message : System.Web.UI.Page
{
    public string product = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            email.Value = Request.QueryString["mail"];
            op.staValue.setMeta(Page, "message");
            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            liContact.Text = news.getString("contentC", "where typS='contact'");
        }
    }
    protected void BtClear_Click(object sender, EventArgs e)
    {

    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        //string vv = Session["Validate"].ToString().ToLower();
        op.tipsMessage tips = new op.tipsMessage();
        op.Operation ope = new op.Operation();
        if (ope.validate(Request.Form["chknumber"]))
        {
            if (MessageWrite())
            {
                op.staValue.divAlert(Page, tips.opSuccess);
            }
            else
            {
                op.staValue.divAlert(Page, tips.opFailed);
            }
        }
        else
        {
            op.staValue.divAlert(Page, tips.codeError);
        }
    }
    private bool MessageWrite()
    {

        try
        {
            //dal.message message = new dal.message();
            MySqlDal.MessageDB message = new MySqlDal.MessageDB();
            mo.message model = new mo.message();
            model.nameC = Request.Form["lname"] + " " + Request.Form["fname"] + " " + Request.Form["gender"];
            model.addressC = Request.Form["country"];
            model.mailC = email.Value;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("<p>Company Name:{0}</p>", Request.Form["cname"]);
            model.telC = Request.Form["tel"];
         
           // sb.AppendFormat("<p>What kind of products do you want to import? {0}</p>", Request.Form["wkp"]);
            sb.AppendFormat("<p>Other Message :{0}</p>", Request.Form["comment"]);
            model.contentC = sb.ToString();
            model.timeC = DateTime.Now.ToString("yyyy/MM/dd");
            model.typ = 0;
            model.ipC = Request.UserHostAddress;
            op.Operation ope = new op.Operation();
            message.InsertModel(model);
            op.mail mail = new op.mail();
            mail.title = model.nameC;
            mail.content = model.contentC + "<p>E-mail:"+model.mailC+"</p><p>Ip:"+model.ipC+"</p>";
            mail.Recipient = op.staValue.mail;
            mail.send();
            return true;
        }
        catch
        {
            return false;
        }

    }
}
