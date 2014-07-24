using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_backOrder : System.Web.UI.Page
{
    op.tipsMessage tips = new op.tipsMessage();
    public op.staValue staValue = new op.staValue();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["user"] = cook.userJudge();
            //dal.order order = new dal.order();
            MySqlDal.OrderDB order = new MySqlDal.OrderDB();
            List<mo.order> modelList_order = order.getModelListWhere("where userName='" + ViewState["user"].ToString() + "' and typ<>2");
            if (modelList_order.Count > 0)
            {
                dropListBack.Items.Clear();

                foreach (mo.order mod in modelList_order)
                {
                    dropListBack.Items.Add(new ListItem(mod.orderC));
                }
                if (!btnOk_return.Enabled)
                    btnOk_return.Enabled = true;
                binRetOrder();
            }
            else
            {
                op.staValue.divAlert(Page, "您没有订单可退!","user.aspx");
            }
        }
    }
    protected void repRetrunOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //dal.returnOrder retOrder = new dal.returnOrder();
        MySqlDal.ReturnOrderDB retOrder = new MySqlDal.ReturnOrderDB();
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "del")
        {
            retOrder.DelId("id=" + id);
            op.staValue.divAlert(Page, tips.opSuccess);
            binRetOrder();
        }
        else if (e.CommandName == "see")
        {
            mo.returnOrder model = retOrder.getModel("where id=" + id);
            dropListBack.SelectedValue = model.orderC;
            txtMethod.Text = model.methodC;
            txtPrice_return.Text = model.priceC;
            txtReason.Text = model.reasonC;
            txtProList_return.Text = model.proList;
            txtMessage_return.Text = model.messageC;
            lbId_return.Text = model.id.ToString();
            if (model.typ != 0)
            {
                btnOk_return.Enabled = false;
            }
            else
            {
                btnOk_return.Enabled = true;
            }
        }
    }
    private void binRetOrder()
    {
        //dal.returnOrder retOrder = new dal.returnOrder();
        MySqlDal.ReturnOrderDB retOrder = new MySqlDal.ReturnOrderDB();
        List<mo.returnOrder> modelList = retOrder.getModelListWhere("where userName='" + ViewState["user"].ToString() + "'");
        repRetrunOrder.DataSource = modelList;
        repRetrunOrder.DataBind();
    }
    private void clearRetrun()
    {
        txtMethod.Text = "";
        txtPrice_return.Text = "";
        txtReason.Text = "";
        txtProList_return.Text = "";
        txtMessage_return.Text = "";
        lbId_return.Text = "";
       // ltbnOrderOk.Enabled = true;
    }
    protected void btnOk_return_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        if (ope.validate(txtCode_return.Text))
        {
            mo.returnOrder model = new mo.returnOrder();
            model.orderC = dropListBack.SelectedValue;
            model.userName = ViewState["user"].ToString();
            model.methodC = txtMethod.Text;
            model.priceC = txtPrice_return.Text;
            model.reasonC = txtReason.Text;
            model.timeC = DateTime.Now.ToString();
            model.proList = txtProList_return.Text;
            model.typ = 0;
            model.messageC = txtMessage_return.Text;
            //dal.returnOrder retOrder = new dal.returnOrder();
            MySqlDal.ReturnOrderDB retOrder = new MySqlDal.ReturnOrderDB();
            if (lbId_return.Text != "")//判断是修改还是插入
            {
                model.id = int.Parse(lbId_return.Text);
                retOrder.UpdateModel(model);
            }
            else
            {
                if (retOrder.getString("id", "where orderC='" + model.orderC + "'") == null)
                {
                    retOrder.InsertModel(model);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ImageButton1click", "showAlert('此订单已申请退货!','true');", true);
                    return;
                }
            }
            binRetOrder();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ImageButton1click", "showAlert('提交成功!','true');", true);
            clearRetrun();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ImageButton1click", "showAlert('验证码错误!','true');", true);
        }
    }
    protected void btnClear_return_Click(object sender, EventArgs e)
    {
        clearRetrun();
    }
}