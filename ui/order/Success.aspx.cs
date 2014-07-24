using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string order = Request.QueryString["order"];
            string userName = Request.QueryString["name"];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            dal.UserDB user = new dal.UserDB();
            op.Operation ope=new op.Operation();
            userName = ope.StrEncode(userName);
            string id = user.getString("id", "where userName='" + userName + "'");
            sb.AppendFormat("<div>Order Num:{0}</div>",order);
            if (!string.IsNullOrEmpty(id))
            {
                sb.AppendFormat("<div><a href='/user/order.aspx'><font color='red'>Click Here</font></a> Check order information!</div>");
            }
            else
            {
                ViewState["userName"] = userName;
                if (ViewState["password"] == null)
                {
                    mo.user model = new mo.user();
                    model.userName = userName;
                    Random rand = new Random();
                    model.passwordC = rand.Next(100000, 999999).ToString();
         
                    model.levelC = "100";
                    model.Status = true;
                    model.CreateDate = DateTime.Now;

                    user.InsertModel(model);
                    ViewState["password"] =  model.passwordC;
                    send(userName, model.passwordC);
                    sb.AppendFormat("<div>You are a new member ,the password send to {0},please note that check!!</div>", userName);
                    lbtnSend.Visible = true;
                }
            }
            liInfo.Text = sb.ToString();
        }
    }
    public void send(string userName,string password)
    {
        op.mail mail = new op.mail();
        mail.title = "Register--------"+op.staValue.companyName;
        mail.content = "<p>" + op.staValue.siteUrl + "</p>";
        mail.content += "<p>UserName:" + userName + "&nbsp;&nbsp;Passowrd:" + password+"</p>";
        mail.content += "<p>Change your password, <a href=\"" + op.staValue.siteUrl + "/user/Password.aspx\">click here</a></p>";
        mail.Recipient = userName;
        mail.send();
    }
    protected void lbtnSend_Click(object sender, EventArgs e)
    {
        send(ViewState["userName"].ToString(),ViewState["password"].ToString());
    }
}