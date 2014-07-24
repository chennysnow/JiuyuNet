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

public partial class admin_user_Payment : System.Web.UI.Page
{
    //dal.expPay expPay = new dal.expPay();
    MySqlDal.expPayDB expPay = new MySqlDal.expPayDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "支付管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        List<mo.expPay> modeList = expPay.getModelListWhere("where typ=1");
        Repeater1.DataSource = modeList;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "del")
        {
            try
            {
                expPay.DelId(id);
                op.staValue.divAlert(Page, "删除成功!");
            }
            catch
            {
                op.staValue.divAlert(Page, "删除失败!");
            }
        }
        else
            if (e.CommandName == "edit")
            {
                ViewState["id"] = id;
                mo.expPay model = expPay.getModel("where id=" + id);
                txtNameEdit.Text = model.nameC;
                txtDescirptionEdit.Text = model.tipsC;
                PanelRep.Visible = false;
                panelEdit.Visible = true;
            }
        bin();
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        mo.expPay model = new mo.expPay();
        op.Operation ope = new op.Operation();
        model.id = ope.MaxId("expPay");
        model.nameC = txtName.Text;
        model.tipsC = txtDescription.Text;
        model.typ = 1;
        if (fileAdd.HasFile)
        {
            model.imgC = "/uploadFile/flash/" + fileAdd.FileName;
            fileAdd.SaveAs(op.staValue.path + "uploadFile/flash/" + fileAdd.FileName);
        }
        expPay.InsertModel(model);
        bin();
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
        op.staValue.divAlert(this.Page, "添加成功！");
    }
    protected void BtEditOk_Click(object sender, EventArgs e)
    {
        mo.expPay model = expPay.getModel("where id=" + ViewState["id"].ToString());
        model.nameC = txtNameEdit.Text;
        model.tipsC = txtDescirptionEdit.Text;
        if (fileEdit.HasFile)
        {
            model.imgC = "/uploadFile/flash/" + fileEdit.FileName;
            fileEdit.SaveAs(op.staValue.path + "uploadFile/flash/" + fileEdit.FileName);
        }
        expPay.UpdateModel(model);
        bin();
        panelEdit.Visible = false;
        PanelRep.Visible = true;
        op.staValue.divAlert(this.Page, "添加成功！");
    }
    protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = true;
        PanelRep.Visible = false;
    }
}
