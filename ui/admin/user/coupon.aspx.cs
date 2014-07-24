using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_coupon : System.Web.UI.Page
{
    //dal.coupon coupon = new dal.coupon();
    MySqlDal.CouponDB coupon = new MySqlDal.CouponDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "优惠券管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        List<mo.coupon> modelList = coupon.getModelListAll();
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")//修改绑定
        {
            mo.coupon model = coupon.getModel("where id=" + e.CommandArgument.ToString());
            PanelRep.Visible = false;
            panelEdit.Visible = true;
            txtNameEdit.Text = model.numC;
            txtPriceEdit.Text = model.priceC.ToString();
            ViewState["id"] = model.id;
        }
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        PanelRep.Visible = false;
        PanelAdd.Visible = true;
        op.Operation ope=new op.Operation();
        txtName.Text = ope.NameRndOnly();
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || txtPrice.Text == "")
        {
            op.staValue.divAlert(this.Page, "不能为空");
        }

        mo.coupon model = new mo.coupon();
        model.numC = txtName.Text;
        model.priceC = double.Parse(txtPrice.Text);
        model.typ = 1;
        coupon.InsertModel(model);
        op.staValue.divAlert(this.Page, "添加成功");
        PanelRep.Visible = true;
        PanelAdd.Visible = false;
        bin();
    }
    protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelRep.Visible = true;
        PanelAdd.Visible = false;
    }
    protected void BtEditOk_Click(object sender, EventArgs e)
    {
        mo.coupon model = coupon.getModel("where id=" + ViewState["id"].ToString());
        if (txtNameEdit.Text == "" || txtPriceEdit.Text == "")
        {
            op.staValue.divAlert(this.Page, "不能为空");
        }
        model.numC = txtNameEdit.Text;
        model.priceC = double.Parse(txtPriceEdit.Text);
        model.typ = 1;
        coupon.UpdateModel(model);
        op.staValue.divAlert(this.Page, "修改成功");
        panelEdit.Visible = false;
        PanelRep.Visible = true;
        bin();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"]; ;
        coupon.DelId("where id in(" + id + ")");
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
}
