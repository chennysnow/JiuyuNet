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
using System.Collections.Generic;
public partial class admin_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null && Request.QueryString["type"] == "LoginOut")
            {
                cook.AdminLogout();
            }

        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string usr = txtUserName.Text;
        string pass = txtPassword.Text;
        op.Operation ope = new op.Operation();
        cook cookie = new cook();
        if (ope.validate(txtCode.Text))
        {
            if (cookie.ValidataLogin(usr, pass))
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                op.staValue.divAlert(this.Page, "用户密码错误!");
            }
        }
        else
            op.staValue.divAlert(this.Page, "验证码错误!");
    }
}
