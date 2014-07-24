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

public partial class admin_HtUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "系统帐户设置";
        if (!IsPostBack)
        {
            txtUserid.Text = "admin";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //dal.adminUser adminUser = new dal.adminUser();
        MySqlDal.adminUserDB adminUser = new MySqlDal.adminUserDB();
        mo.adminUser model = adminUser.getModel("where userName='admin'");
        if (txtPassword.Text == model.passwordC)
        {
            model.passwordC = txtNewPassword.Text;
            adminUser.UpdateModel(model);
            op.staValue.divAlert(Page, "修改成功!");
        }
        else
        {
            op.staValue.divAlert(Page, "密码错误!");
        }

    }
}
