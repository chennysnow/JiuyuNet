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
using System.Text;
public partial class admin_user_EditOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "查看订单详情";
        if (!IsPostBack)
        {
            dropBin();
            bin();
        }
    }
    private void bin()
    {
        if (Request.Params["id"] != null)
        {
            string id = Request.Params["id"].ToString();
            op.staValue staValue = new op.staValue();
            //dal.order order = new dal.order();
            MySqlDal.OrderDB order = new MySqlDal.OrderDB();
            mo.order model = order.getModel("where orderC='" + id+"'");
            //liAddInfo.Text = model.addInfo;
 
            //txtTotalInfo.Text = model.totalInfo;
            txtRemarks.Text = model.remarksC;
            txtPostNum.Text = model.expNum;
            txtPostTime.Text = model.expTime;
            txtPrice.Text = model.priceC.ToString();
            liOrderTime.Text = model.timeC.ToShortDateString();
            litOrderState.Text = staValue.OrderType[int.Parse(model.typ.ToString())];
            txtExPrice.Text = model.expPrice.ToString("0.00");
            txtProPrice.Text = model.priceC.ToString("0.00");
            litExpAddress.Text = model.ShippingAddress;
            litExpCountry.Text = model.ShippingCountry;
            litExpName.Text = model.ShippingName;
            litExpTel.Text = model.ShippingTel;
            litExpType.Text = model.expName;
            litEmail.Text = model.userName;
            ((System.Web.UI.WebControls.ListItem)dropType.Items.FindByValue(model.typ.ToString())).Selected = true;
         

            ViewState["id"] = id;

            //List<mo.OrderItem> items = new dal.OrderItem().getModelListWhere("where OrderID='" + model.orderC + "'");
            List<mo.OrderItem> items = new MySqlDal.OrderItemDB().getModelListWhere("where OrderID='" + model.orderC + "'");
            repOrderItem.DataSource = items;
            repOrderItem.DataBind();


        }
    }
    private void dropBin()
    {
        op.staValue staValue = new op.staValue();
        for (int i = 0; i < staValue.OrderType.Length; i++)
        {
            dropType.Items.Add(new ListItem(staValue.OrderType[i], i.ToString()));
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            //dal.order order = new dal.order();
            MySqlDal.OrderDB order = new MySqlDal.OrderDB();
            mo.order model = order.getModel("where orderC='" + ViewState["id"].ToString() + "'");
            op.Operation ope = new op.Operation();
            model.expTime = txtPostTime.Text;
            model.priceC = double.Parse(txtPrice.Text);
            //model.totalInfo = txtTotalInfo.Text;
            model.remarksC = ope.StrEncode(txtRemarks.Text);
            model.typ = int.Parse(dropType.SelectedValue);
            model.expNum = txtPostNum.Text;
            if (model.typ == 2 && model.curFlg == 0)
            {
                order.UpdateModel(model);
                model.curFlg = 1;//减完以后 设置标志
            }
    
            
            // 修改订单商品信息

            //List<mo.OrderItem> items = new dal.OrderItem().getModelListWhere("where OrderID='" + model.orderC + "'");
            List<mo.OrderItem> items = new MySqlDal.OrderItemDB().getModelListWhere("where OrderID='" + model.orderC + "'");
            string[] unitPrice = Request.Form.GetValues("DiscountPrice");
            string[] unitQunary = Request.Form.GetValues("ProQuantity");

            for (int i = 0; i < items.Count; i++)
            {
                if (unitPrice[i] != items[i].DisPrice.ToString() || unitQunary[i] != items[i].Quantity.ToString())
                {
                    double totalAmount = double.Parse(unitPrice[i]) * double.Parse(unitQunary[i]);

                    //new dal.OrderItem().UpdateString("DisPrice=" + unitPrice[i] + ",Quantity=" + unitQunary[i] + ",TotalAmount=" + totalAmount, "where id = " + items[i].ID);
                    new MySqlDal.OrderItemDB().UpdateString("DisPrice=" + unitPrice[i] + ",Quantity=" + unitQunary[i] + ",TotalAmount=" + totalAmount, "where id = " + items[i].ID);
                }
            }


            cutCount(model.orderC);
            order.UpdateModel(model);








            op.staValue.divAlert(this.Page, "更新成功！", "Order.aspx");
        }
        catch {
            op.staValue.divAlert(Page, "数据格式不正确!");
        }
    }
    public void cutCount(string orderC)
    {
        //dal.order order = new dal.order();
        MySqlDal.OrderDB order = new MySqlDal.OrderDB();
        MySqlDal.UserDB user = new MySqlDal.UserDB();
        mo.order model = order.getModel(" where orderC='" + orderC + "'");
        //dal.products pro = new dal.products();
        MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
        if (model.curFlg == 0)//判断是否已减过库存
        {
            string[] proId = model.cutCount.Split('@');
            for (int j = 0; j < proId.Length; j++)
            {
                string[] proCount = proId[j].Split(',');
                pro.UpdateString("sellCount=sellCount+" + proCount[1], "where id=" + proCount[0]);
            }
            user.UpdateString("integralC=integralC+" + model.priceC + "", "where userName='" + model.userName + "'");//增加积分
        }
    }
}
