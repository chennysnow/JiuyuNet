using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        op.Operation ope=new op.Operation();
        if (ope.validate(txtCode.Text))
        {
            cook cook = new cook();
            if (cook.login(txtUserName.Text, txtPassword.Text))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["url"]))
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
                else
                    Response.Redirect("~/user/user.aspx");
            }
            else
                op.staValue.divAlert(Page, "Error: Sorry, there is no match for that email address and/or password.!");
        }
        else
            op.staValue.divAlert(Page, "Verification code error!");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        if (ope.validate(txtCode_r.Text))
        {
            dal.UserDB user = new dal.UserDB();
            if (user.getString("id", "where userName='" + ope.StrEncode(txtUserName_r.Text) + "'") == null)
            {
                mo.user model = new mo.user();
                model.userName = ope.StrEncode(txtUserName_r.Text);
                model.passwordC = ope.StrEncode(txtPassword_r.Text);
                //model.mailC = ope.StrEncode(txtMail.Text);
                //model.nameC = ope.StrEncode(txtName.Text);
                //model.telC = ope.StrEncode(txtTel.Text);
                //model.addressC = ope.StrEncode(txtCountry.Text);
                model.timeC = DateTime.Now.ToString();
                //model.levelC = "100";
               user.InsertModel(model);

                cook cook = new cook();
                cook.login(model.userName, model.passwordC);
                op.staValue.divAlert(Page, "Registration is successful!", "/user/user.aspx");

            }
            else
            {
                op.staValue.divAlert(Page, "Our system already has a record of that email address - please try logging in with that email address.!");
            }
        }
        else
            op.staValue.divAlert(Page, "Verification code error!");
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        if (ope.validate(txtCode_find.Text))
        {
            if (ope.IsEmail(txtFindPassword.Text))
            {
                dal.UserDB user = new dal.UserDB();
                string userName = user.getString("userName", "where userName='" + ope.StrEncode(txtFindPassword.Text) + "'");
                if (!string.IsNullOrEmpty(userName))
                {
                    string password = ope.NameRndOnly();
                    user.UpdateString("passwordC='" + password + "'", "where userName='" + userName + "'");
                    op.mail mail = new op.mail();
                    mail.title = "Find Password------" + op.staValue.companyName;
                    mail.companyName = op.staValue.companyName;
                    mail.content = "Your new password:" + password;
                    mail.content += "<p>Edit password <a href='" + op.staValue.siteUrl + "/user/password.aspx'>Click here</a></p>";
                    mail.Recipient = userName;
                    mail.send();
                    op.staValue.divAlert(Page, "A new password has been sent to your email address.!");
                }
                else
                {
                    op.staValue.divAlert(Page, "Our system does not have this e-mail!");
                }
            }
            else
            {
                op.staValue.divAlert(Page, "E-mail address format error!");
            }
        }
        else
        {
            op.staValue.divAlert(Page, "Verification code error!");
        }

    }
}