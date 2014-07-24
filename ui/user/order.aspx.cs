using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_order : System.Web.UI.Page
{
    public op.staValue staValue = new op.staValue();
    //dal.order order = new dal.order();
    dal.OrderDB order = new dal.OrderDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.userJudge();
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
            string strSql = "where userName='" + cook.userJudge() + "' ";
            if (Request.QueryString["order"]!=null)
                strSql += "and orderC like '%" + op.staValue.RexSpecial(Request.QueryString["order"]) + "%'";
            List<mo.order> modelList = order.getModelListWhere("", strSql);
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = modelList;
            AspNetPager1.RecordCount = modelList.Count;
            repProInfo.DataSource = pds;
            repProInfo.DataBind();
    }
    protected void repProInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtn = (ImageButton)e.Item.FindControl("lbtnDel");
           // HtmlInputHidden flg = (HtmlInputHidden)e.Item.FindControl("typ");
          // if (flg.Value != "0" && flg.Value != "3")
           //     lbtn.Enabled = false;
        }
    }
    protected void repProInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "del")
        {
            order.DelId(" orderC='"+id+"'");
            op.staValue.divAlert(Page, "删除成功!");
            bin();
        }
        else if (e.CommandName == "see")
        {
            mo.order model = order.getModel("where orderC='" + id + "'");
            //liAddInfo.Text = model.addInfo;
            //liProInfo.Text = model.proInfo;
            //liTotalInfo.Text = model.totalInfo;
            txtRemarks.Text = model.remarksC;

            txtRemarks.Enabled = model.typ == 0 ? true : false;
            editPanel.Visible = model.typ == 0 ? true : false;
            orderId.Value = id;
            panelList.Visible = false;
            panelEdit.Visible = true;

            litExpPrice.Text = model.expPrice.ToString();
            litProPrice.Text = (model.priceC - model.expPrice).ToString();
            litTotalPrice.Text = model.priceC.ToString();

            litExpNum.Text = model.expNum == "" ? "暂无" : model.expNum; ;
            kutExpTime.Text = model.expTime == "" ? "暂无" : model.expTime; 
            litExpAddress.Text = model.ShippingAddress;
            litExpCountry.Text = model.ShippingCountry;
            litExpName.Text = model.ShippingName;
            litExpTel.Text = model.ShippingTel;
            litExpType.Text = model.expName;
            litEmail.Text = model.userName;

            //List<mo.OrderItem> items = new dal.OrderItem().getModelListWhere("where OrderID='" + model.orderC + "'");
            List<mo.OrderItem> items = new dal.OrderItemDB().getModelListWhere("where OrderID='" + model.orderC + "'");

            repOrderItem.DataSource = items;
            repOrderItem.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
    protected void btn_editOrder_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        order.UpdateString("timeC='" + DateTime.Now.ToString() + "',remarksC='" + ope.StrEncode(txtRemarks.Text) + "'", "where orderC='" + orderId.Value + "'");
        panelEdit.Visible = false;
        panelList.Visible = true;
    }
}