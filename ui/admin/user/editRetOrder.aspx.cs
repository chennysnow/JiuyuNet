using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_editRetOrder : System.Web.UI.Page
{
    public mo.returnOrder model = new mo.returnOrder();
    //dal.returnOrder retOrder = new dal.returnOrder();
    dal.ReturnOrderDB retOrder = new dal.ReturnOrderDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "查看退货申请";
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                op.staValue staValue = new op.staValue();
                model = retOrder.getModel("where id=" + Request.QueryString["id"]);
                for (int i = 0; i < staValue.retOrder.Length; i++)
                {
                    dropType.Items.Add(new ListItem(staValue.retOrder[i], i.ToString()));
                }
                dropType.SelectedValue = model.typ.ToString();
                txtPrice_return.Text = model.priceC;
                txtMethod.Text = model.methodC;
                txtReason.Text = model.reasonC;
                txtProList_return.Text = model.proList;
                txtMessage_return.Text = model.messageC;
                lbId_return.Text = model.id.ToString();
            }
        }
    }
    protected void btnOk_return_Click(object sender, EventArgs e)
    {
        model = retOrder.getModel("where id=" + lbId_return.Text);
        model.typ = int.Parse(dropType.SelectedValue);
        model.priceC = txtPrice_return.Text;
        model.methodC = txtMethod.Text;
        model.reasonC = txtReason.Text;
        model.proList = txtProList_return.Text;
        model.messageC = txtMessage_return.Text;
        retOrder.UpdateModel(model);
        op.staValue.divAlert(Page, "修改成功!", "returnOrder.aspx");
    }
}