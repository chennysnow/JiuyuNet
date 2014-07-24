using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_sendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "邮件推广";
        if (!IsPostBack)
        {
            string proId = Request.QueryString["proId"];
            if (!string.IsNullOrEmpty(proId))
            {
                //dal.products pro = new dal.products();
                MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
                List<mo.products> modelList = pro.getModelListWhere("and id in(" + proId.TrimEnd(',') + ")");
                repProDisplay.DataSource = modelList;
                repProDisplay.DataBind();
            }
            txtRecipient.Text = Request.QueryString["mail"];
            txtCompanyName.Text = op.staValue.companyName;

            MySqlDal.UserDB user = new MySqlDal.UserDB();
            List<mo.user> userList = user.getModelListWhere("");
            Repeater1.DataSource = userList;
            Repeater1.DataBind();
        }
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        op.mail mail = new op.mail();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        repProDisplay.RenderControl(htw);
        mail.companyName = txtCompanyName.Text;
        mail.title = txtTitle.Text;
        mail.content = sw.ToString() + txtContent.Text;
        mail.Recipient = txtRecipient.Text;
        op.staValue.divAlert(Page, mail.send());
    }
}