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
using System.Collections.Generic;

public partial class admin_user_User : System.Web.UI.Page
{
    //public dal.userLevelDb userLevel = new dal.userLevelDb();
   // dal.user user = new dal.user();
    MySqlDal.UserDB user = new MySqlDal.UserDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "用户信息管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        string where = "";
        if (Request.QueryString["id"] != null)
            where = "where userName='" + Request.QueryString["id"] + "'";
        List<mo.user> modelList = user.getModelListWhere(where);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            user.DelId("id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            mo.user model = user.getModel("where id=" + e.CommandArgument.ToString());
            txtUserName.Text = model.userName;
            txtPasswords.Text = model.passwordC;
            txtName.Text = model.nameC;
            txtTel.Text = model.telC;
            txtAddress.Text = model.addressC;
            txtRemarks.Text = model.descriptionC;
            // dropUser.SelectedValue = model.typ.ToString();
            ViewState["id"] = e.CommandArgument.ToString();
            panelEdit.Visible = true;
            panelRep.Visible = false;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        mo.user model = user.getModel("where id=" + ViewState["id"].ToString());
        model.userName = txtUserName.Text;
        model.passwordC = txtPasswords.Text;
        model.nameC = txtName.Text;
        model.telC = txtTel.Text;
        model.addressC = txtAddress.Text;
        //model.typ = int.Parse(dropUser.SelectedValue);
        user.UpdateModel(model);
        op.staValue.MessageShow(this.Page, "修改成功!");
        bin();
        panelRep.Visible = true;
        panelEdit.Visible = false;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        panelRep.Visible = true;
        panelEdit.Visible = false;
    }
    protected void lbtnUser1_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            user.UpdateString("typ=1","where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "审核成功");
        bin();
    }
    protected void lbtnUser0_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            user.UpdateString("typ=0", "where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "取消成功");
        bin();
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string[] id = Request.Form.GetValues("id");
            string[] discount = Request.Form.GetValues("discount");
            for (int i = 0; i < id.Length; i++)
            {
                double dbTest = double.Parse(discount[i]);
                user.UpdateString("levelC='"+discount[i]+"'", "where id="+id[i]);
            }
            op.staValue.divAlert(this.Page, "保存成功");
            bin();
        }
        catch
        {
            op.staValue.divAlert(this.Page, "折扣数据类型只能是整数或小数!");
        }
    }
    
}
