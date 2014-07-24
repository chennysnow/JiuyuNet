using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class Submit : System.Web.UI.Page
{
    string cookName = "userCart";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies[cookName] != null)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    string cartInfo = HttpUtility.UrlDecode(Request.Cookies[cookName].Value);
                    string allId = "";
                    double proWeight = 0;//产品总重量
                    double proPrice = 0;//产品总价格
                    int proCount = 0;//产品总数
                    string cutCount = "";
                    Hashtable allCount = new Hashtable();
                    List<mo.products> modelList = null;
                    if (cartInfo != null)
                    {
                        string[] cartPro = cartInfo.Split('@');
                        for (int i = 0; i < cartPro.Length; i++)
                        {
                            string[] cartIdCount = cartPro[i].Split('|');
                            if (cartIdCount.Length > 0)
                            {
                                allId += cartIdCount[0] + ",";
                                allCount.Add(cartIdCount[0], cartIdCount[1]);
                            }
                        }
                        if (allId != "")
                        {
                            //dal.products pro = new dal.products();
                            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
                            //dal.price pri = new dal.price();
                            MySqlDal.PriceDB pri = new MySqlDal.PriceDB();
                            modelList = pro.getModelListWhere("and id in(" + allId.TrimEnd(',') + ")");
                            for (int i = 0; i < modelList.Count; i++)
                            {
                                int cou = int.Parse(allCount["" + modelList[i].id + ""].ToString());//从hash表里提取数量
                                proCount += cou;
                                modelList[i].displayC = cou.ToString();
                                string priceArea = pri.getString("priceC", "where typ=" + modelList[i].id + " and minC<=" + cou + "  order by priceC asc");
                                if (!string.IsNullOrEmpty(priceArea))
                                    modelList[i].priceC = double.Parse(priceArea);
                                cutCount += modelList[i].id + "," + cou + "@";//减库存
                                proPrice += (cou * modelList[i].priceC);
                                proWeight += modelList[i].weightC * cou;
                            }
                            repProList.DataSource = modelList;
                            repProList.DataBind();
                            ViewState["cutCount"] = cutCount.TrimEnd('@');
                        }
                    }
                    sb.AppendFormat("<div class='cartProInfo_3'>QTY: <span>{0}</span>&nbsp;&nbsp;Sub-total: <span>${1}</span>&nbsp;&nbsp;Weight:{2}kg</div>", proCount, proPrice, proWeight);
                    liTotal.Text = sb.ToString();
                    sb.Length = 0;
                  
                    ////////////////////////////////////////用户信息
                    sb.Append("<div class='Head'>Shipping Address:</div><ul class='ulInfo'>");
                    sb.AppendFormat("<li><div>E-mail:</div>{0}</li>", Request.Form["mailC"]);
                    sb.AppendFormat("<li><div>Name:</div>{0}</li>", Request.Form["nameC"]);
                    sb.AppendFormat("<li><div>Tel:</div>{0}</li>", Request.Form["telC"]);
                    //dal.place pla = new dal.place();
                    MySqlDal.PlaceDB pla = new MySqlDal.PlaceDB();
                    sb.AppendFormat("<li><div>Country:</div>{0}</li>", Request.Form["selectPlace"]);
                    sb.AppendFormat("<li><div>Address:</div>{0}</li></ul>", Request.Form["addressC"]);
                    ////////////////////////////////////////快递
                    sb.Append("<div class='Head'>Payment And Shipping:</div><ul class='ulInfo'>");//id,首重,续重,名称
                    ViewState["userName"] = Request.Form["mailC"];
                    //dal.expPay expPay = new dal.expPay();
                    MySqlDal.expPayDB expPay = new MySqlDal.expPayDB();
                    string express = Request.Form["radioExpress"];//快递ID
                    string payment = Request.Form["radioPayment"];//支付ID
                    string place = Request.Form["selectPlace"];

                    mo.expPay model_expPay = expPay.getModel("where id=" + payment);//支付名称
                    payment = model_expPay.nameC;
                    sb.AppendFormat("<li><div>Payment:</div>{0}---{1}</li>", model_expPay.nameC, model_expPay.tipsC);
                    //model_expPay = expPay.getModel("where id=" + express);//所选择的快递信息

                    org.jiuyu.express.ExpService service = new org.jiuyu.express.ExpService();
                    org.jiuyu.express.Express exp = service.GetExpressModel(express);
                    //service.GetShippingPrice((ids);

                    sb.AppendFormat("<li><div>Shipping:</div>{0}---{0}</li></ul>", exp.expressName, exp.remark);
                    liAddress.Text = sb.ToString();
                    sb.Length = 0;
                    //dal.expPlace expPlace = new dal.expPlace();
                    MySqlDal.expPlaceDB expPlace = new MySqlDal.expPlaceDB();
                    string placePrice = expPlace.getString("priceC", "where placeId=" + place + " and typ=" + model_expPay.id);
                    double expPrice = string.IsNullOrEmpty(placePrice) ? 30 : double.Parse(placePrice);//默认15元
                    double allWeight =  proWeight;
                    double expAllPrice=0;
                    //if (allWeight > 1)
                    //{
                    //    allWeight = allWeight % 1 > 0 ? allWeight : allWeight - 1;//考虑小数与整数的情况
                    //    expAllPrice = Convert.ToInt32(allWeight) * model_expPay.priceC + expPrice;
                    //}
                    expAllPrice = service.GetShippingPrice(Request.Form["selectPlace"], allWeight, express);
                    //org.jiuyu.express.ExpService webservice = new org.jiuyu.express.ExpService();
                    //webservice.GetShippingPrice(model_expPay.nameC, allWeight, pla.getString("nameC", "where id=" + Request.Form["selectPlace"]));
                   
                    double allPrice = expAllPrice + proPrice;
                    sb.Append("<div class='total_3'>");
                    sb.AppendFormat("<p><b>Shipping Price:</b><span> ${0}</span></p>", expAllPrice);
                    sb.AppendFormat("<p><b>Products Price:</b><span> ${0}</span></p>", proPrice);
                    sb.AppendFormat("<p><b>Grand-Total:</b> <span>${0}</span></p>", allPrice);
                    //折扣
                    MySqlDal.UserDB user = new MySqlDal.UserDB();
                    string strDiscount = user.getString("levelC", "where userName='" + ViewState["userName"].ToString()+ "'");
                    if (!string.IsNullOrEmpty(strDiscount))
                    {
                        double discount = double.Parse(strDiscount);
                        discount = discount / 100;

                        ViewState["Discounte"] = strDiscount;  //折扣率
                        //ViewState["DisPrice"] = allPrice - (discount * allPrice);  //折扣金额
                      
                        allPrice = expAllPrice + (discount * allPrice);

                        ViewState["totalPrice"] = Request.Form["discount"];
                        sb.AppendFormat("<p><b>Discount:</b><span> {0}% OFF</span></p>",discount*100);
                        sb.AppendFormat("<p><b>Discounted price:</b> <span>${0}</span></p>",allPrice);
                    }
                   
                    sb.Append("</div>");
                    liTotalInfo.Text = sb.ToString();
                    //快递价格,物品价格,
                    ViewState["info"] = expAllPrice  + "," + model_expPay.nameC + "," + payment;// +"," + model_box.priceC;
                    ViewState["price"] = allPrice;

                    ViewState["nameC"] = Request.Form["nameC"];
                    ViewState["addressC"] = Request.Form["addressC"];
                    ViewState["ShippingCountry"] = Request.Form["selectPlace"];
                    ViewState["telC"] = Request.Form["telC"];

                    ViewState["proPrice"] = proPrice;

                }
            }
            catch
            {
                op.staValue.divAlert(Page, "Sorry! System error,please contact us!", "address.aspx");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string[] info=ViewState["info"].ToString().Split(',');
        mo.order model = new mo.order();
        op.Operation ope = new op.Operation();
        model.orderC = ope.NameRndOnly();
        model.userName = ViewState["userName"].ToString();
        model.addInfo = liAddress.Text;
        model.totalInfo = liTotalInfo.Text;
        model.timeC = DateTime.Now;
        model.expName = info[1];
        model.payName = info[2];
        model.expPrice = double.Parse(info[0]);
        model.priceC = double.Parse(ViewState["price"].ToString());
        model.typ = 0;
        model.remarksC = txtRemarks.Text;
        model.cutCount = ViewState["cutCount"].ToString();
        

        //if (ViewState["Discounte"] != null && ViewState["DisPrice"] != null)
        //{
        //    model.Discounte = double.Parse(ViewState["Discounte"].ToString());
        //    model.DisPrice = double.Parse(ViewState["DisPrice"].ToString());
        //}

        model.ShippingName = ViewState["nameC"].ToString();
        model.ShippingTel = ViewState["telC"].ToString();
        model.ShippingCountry = ViewState["ShippingCountry"].ToString();
        model.ShippingAddress = ViewState["addressC"].ToString();


        //dal.order order = new dal.order();
        MySqlDal.OrderDB order = new MySqlDal.OrderDB();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        repProList.RenderControl(htw);
        model.proInfo=sw.ToString();
        order.InsertModel(model);
   
    



        if (Request.Cookies[cookName] == null)
            return;


        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string cartInfo = HttpUtility.UrlDecode(Request.Cookies[cookName].Value);
        string allId = "";
 


        Hashtable allCount = new Hashtable();
        List<mo.products> modelList = null;
        if (cartInfo != null)
        {
            string[] cartPro = cartInfo.Split('@');
            for (int i = 0; i < cartPro.Length; i++)
            {
                string[] cartIdCount = cartPro[i].Split('|');
                if (cartIdCount.Length > 0)
                {
                    allId += cartIdCount[0] + ",";
                    allCount.Add(cartIdCount[0], cartIdCount[1]);
                }
            }
            if (allId != "")
            {
                //dal.products pro = new dal.products();
                MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
                //dal.price pri = new dal.price();
                MySqlDal.PriceDB pri = new MySqlDal.PriceDB();
                modelList = pro.getModelListWhere("and id in(" + allId.TrimEnd(',') + ")");
                for (int i = 0; i < modelList.Count; i++)
                {
                    int cou = int.Parse(allCount["" + modelList[i].id + ""].ToString());//从hash表里提取数量
         
                    modelList[i].displayC = cou.ToString();
                    string priceArea = pri.getString("priceC", "where typ=" + modelList[i].id + " and minC<=" + cou + "  order by priceC asc");
                    if (!string.IsNullOrEmpty(priceArea))
                        modelList[i].priceC = double.Parse(priceArea);
 
                 

                    mo.OrderItem oitem = new mo.OrderItem();
                    oitem.OrderID = model.orderC;
                    oitem.ProductId = modelList[i].id.ToString();
                    oitem.Quantity = cou;
                   
                    oitem.UnitPrice =(decimal) modelList[i].priceC;
                    if (ViewState["Discounte"] != null)
                    {
                        oitem.Discounte = double.Parse(ViewState["Discounte"].ToString());
                        oitem.DisPrice = (double)oitem.UnitPrice  * oitem.Discounte / 100;
                        oitem.TotalAmount = (decimal)(cou * modelList[i].priceC * oitem.Discounte / 100);
                    }
                    else
                    {
                        oitem.Discounte =100;
                        oitem.DisPrice = modelList[i].priceC;
                        oitem.TotalAmount = (decimal)(cou * modelList[i].priceC);
                    }
                    oitem.ProClassId = modelList[i].addType.ToString();
                    oitem.ProImgURL = modelList[i].fileName + "/sImg" + modelList[i].imgC;
                    oitem.CreateDate = DateTime.Now;
                    oitem.ProductName = modelList[i].nameC;
                    oitem.ProductNO = modelList[i].proId;
                    oitem.HtmlName = modelList[i].htmlName;



                    //new dal.OrderItem().InsertModel(oitem);
                    new MySqlDal.OrderItemDB().InsertModel(oitem);




                }
                //repProList.DataSource = modelList;
                //repProList.DataBind();
                //ViewState["cutCount"] = cutCount.TrimEnd('@');
            }

            HttpCookie cok = Request.Cookies[cookName];
            cok.Value = "";
            Response.Cookies.Add(cok);
        }











        Response.Redirect("Success.aspx?order="+model.orderC+"&name="+model.userName+"");
    }
    protected void btnCoupon_Click(object sender, EventArgs e)
    {
        if (ViewState["coupon"] == null)
        {
            //dal.coupon coupon = new dal.coupon();
            MySqlDal.CouponDB coupon = new MySqlDal.CouponDB();
            string str = op.staValue.RexSpecial(txtCoupon.Text.Trim());
            mo.coupon model = coupon.getModel("where typ=1 and numC='" + str + "'");
            if (model.id != 0)
            {
               
                if (model.priceC > double.Parse(ViewState["price"].ToString()))
                    op.staValue.divAlert(Page, "The coupon is not greater than the actual price！");
                else
                {
                    str = liTotalInfo.Text;
                    str = str.Substring(0, str.Length - 6);
                    str += "<p><b>Coupon Code:</b> " + model.numC + "  ($ <span>" + model.priceC + "</span> discount)</p></div>";
                    liTotalInfo.Text = str;
                    coupon.UpdateString("typ=0", "where id=" + model.id + "");
                    ViewState["price"] = double.Parse(ViewState["price"].ToString()) - model.priceC;
                    ViewState["coupon"] = 1;
                    op.staValue.divAlert(Page, "$ " + model.priceC + " discount!");
                }
            }
            else
            {
                op.staValue.divAlert(Page, "Coupon code is invalid!");
            }
        }
        else
        {
            op.staValue.divAlert(Page, "This order is only used once!");
        }
    }
}