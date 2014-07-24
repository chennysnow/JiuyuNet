using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class shopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string cookName = "userCart";
            try
            {
                if (Request.Cookies[cookName] != null)
                {
                    string cartInfo = HttpUtility.UrlDecode(Request.Cookies[cookName].Value);
                    string allId = "";
                    Hashtable allCount = new Hashtable();
                    List<mo.products> modelList = new List<mo.products>();
                    if (cartInfo != null && cartInfo != "")
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
                            dal.ProductsDB pro = new dal.ProductsDB();
                            modelList = pro.getModelListWhere("and id in(" + allId.TrimEnd(',') + ")");
                            //dal.price pri = new dal.price();
                            dal.PriceDB pri = new dal.PriceDB();
                            for (int i = 0; i < modelList.Count; i++)
                            {
                                modelList[i].displayC = allCount["" + modelList[i].id + ""].ToString();//displayC 存数量
                                string price = pri.getString("priceC", "where typ=" + modelList[i].id + " and minC<=" + modelList[i].displayC + "  order by priceC asc");
                                if (!string.IsNullOrEmpty(price))
                                    modelList[i].priceC = double.Parse(price);
                                else//如果没有价格,则移除这个产品
                                {

                                    System.IO.StreamWriter sw = System.IO.File.AppendText(op.staValue.path + "/rizhi.txt");
                                    sw.WriteLine("-------------------------购物车-----------------------------" + DateTime.Now.ToString());
                                    sw.WriteLine("ID:" + modelList[i].id + "   名称:" + modelList[i].nameC + "         没有价格");
                                    sw.Flush();
                                    sw.Close();
                                    sw.Dispose();

                                    cartInfo = (cartInfo + "@").Replace(modelList[i].id + "|" + modelList[i].displayC + "@", "").TrimEnd('@');//移除COOKIES
                                    Response.Cookies[cookName].Value = cartInfo;
                                    modelList.Remove(modelList[i]);//移除MODEL
                                    i--;
                                }
                            }
                            repList.DataSource = modelList;
                            repList.DataBind();
                        }

                    }
                    else
                    {
                        op.staValue.divAlert(Page, "Your cart is empty now,Please choose your product!");
                    }
                }
            }
            catch
            {
                Response.Cookies[cookName].Value = "";
                op.staValue.divAlert(Page, "The shopping cart data error!","/");
            }
        }
    }
}