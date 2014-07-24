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

public partial class admin_user_Order : System.Web.UI.Page
{
    public op.staValue staValue = new op.staValue();
    MySqlDal.UserDB user = new MySqlDal.UserDB();
    //dal.order order = new dal.order();
    MySqlDal.OrderDB order = new MySqlDal.OrderDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "订单信息管理";
        if (!IsPostBack)
        {
            ddlNewsType.Items.Add(new ListItem("所有订单", "all"));
            DropBin(dropEditOrder);
            DropBin(ddlNewsType);
            bin();
           
        }
    }
    private void bin()
    {
       
        string where="";
        if (ddlNewsType.SelectedValue != "all")
        {
            where = "where typ="+ddlNewsType.SelectedValue;
        }
        if (Request.QueryString["typ"] != null)
        {
            string typ = Request.QueryString["typ"].ToString();
            where = "where typ=" + typ;
            ddlNewsType.SelectedValue = typ;
        }
        List<mo.order> modelList = order.getModelListWhere("", where);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    private void DropBin(DropDownList drop)
    {
        for (int i = 0; i < staValue.OrderType.Length; i++)
        {
            drop.Items.Add(new ListItem(staValue.OrderType[i],i.ToString()));
        }
        
    }
    protected void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bin();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)//批量删除
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("chkId");
        string str = "";
        for (int i = 0; i < id.Length; i++)
        {
            str += "'" + id[i] + "',";
        }
        str = str.TrimEnd(',');
        if (!string.IsNullOrEmpty(str))
        {
            order.DelId("orderC in(" + str + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void lbtnDisplay_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("chkId");
        string str = "";
        for (int i = 0; i < id.Length; i++)
        {
            str += "'" + id[i] + "',";
        }
        str = str.TrimEnd(',');
        if (!string.IsNullOrEmpty(str))
        {
            int cutFlg = 0;
            MySqlDal.OrderItemDB itemdb = new MySqlDal.OrderItemDB();
            // 已付款
            if (dropEditOrder.SelectedValue != "0")
            {
              
                itemdb.UpdateString(" ProState=1", "where OrderID in (" + str + ")");
            }
            else
            {
                itemdb.UpdateString(" ProState=0", "where OrderID in (" + str + ")");
            }
            if (dropEditOrder.SelectedValue == "2")
            {
                cutFlg = 1;
                cutCount(str);
            }
            order.UpdateString("cutFlg="+cutFlg+",typ=" + dropEditOrder.SelectedValue, " where orderC in(" + str + ")");
        }
       
        bin();
    }
    public void cutCount(string allId)
    {
        List<mo.order> modelList = order.getModelListWhere(" where orderC in(" + allId + ")");
        //dal.products pro = new dal.products();
        MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
        for (int i = 0; i < modelList.Count; i++)
        {
            if (modelList[i].curFlg==0)//判断是否已减过库存
            {
                string[] proId = modelList[i].cutCount.Split('@');
                for (int j = 0; j < proId.Length; j++)
                {
                    string[] proCount = proId[j].Split(',');
                    pro.UpdateString("stockC=stockC-" + proCount[1] + ",sellCount=sellCount+"+proCount[1], "where id=" + proCount[0]);
                }
                user.UpdateString("integralC=integralC+" + modelList[i].priceC + "", "where userName='" + modelList[i].userName + "'");//增加积分
            }
        }
    }
}
