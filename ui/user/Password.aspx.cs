using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.userJudge();
    }
    protected void btn_edit_password_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        dal.UserDB user = new dal.UserDB();
        op.tipsMessage tips = new op.tipsMessage();
        string passWord = ope.StrEncode(txtOldPass.Text), userName = cook.userJudge();
        string flg = user.getString("id", "where userName='" + userName + "' and passwordC='" + passWord + "'");
        if (flg != null)
        {
            user.UpdateString("passwordC='" + ope.StrEncode(txtPass1.Text) + "'", " where userName='" + userName + "'");
            op.staValue.divAlert(Page, tips.opSuccess, "user.aspx");
        }
        else
            op.staValue.divAlert(Page, tips.userPassError);
    }
}