using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_returnOrder : System.Web.UI.Page
{
    //dal.returnOrder retOrder = new dal.returnOrder();
    MySqlDal.ReturnOrderDB retOrder = new MySqlDal.ReturnOrderDB();
    public op.staValue staValue = new op.staValue();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "用户退货申请";
        if (!IsPostBack)
        {
            bin();
            binDropType();
        }
    }
    private void bin()
    {
        string where = "";
        if (ViewState["typ"] != null)
        {
            where = "where typ=" + ViewState["typ"].ToString();
        }
        List<mo.returnOrder> modelList = retOrder.getModelListWhere(where);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    private void binDropType()
    {
        dropType.Items.Add(new ListItem("::全部::","all"));
        for (int i = 0; i < staValue.retOrder.Length; i++)
        {
            dropEditOrder.Items.Add(new ListItem(staValue.retOrder[i], i.ToString()));
            dropType.Items.Add(new ListItem(staValue.retOrder[i], i.ToString()));
        }
        
    }
    protected void dropType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropType.SelectedValue == "all")
            ViewState.Remove("typ");
        else
            ViewState["typ"] = dropType.SelectedValue;
        bin();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            retOrder.DelId("id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void lbtnDisplay_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        string typ = dropEditOrder.SelectedValue;
        if (!string.IsNullOrEmpty(id))
        {
            retOrder.UpdateString("typ="+typ,"where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "修改成功");
        bin();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
}