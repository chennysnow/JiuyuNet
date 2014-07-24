using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_left : System.Web.UI.UserControl
{
    public op.Operation ope = new op.Operation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.brand brand = new dal.brand();
            dal.BrandDB brand = new dal.BrandDB();
            List<mo.brand> modelBrand = brand.getModelListAll();
            repBrand.DataSource = modelBrand;
            repBrand.DataBind();

            //dal.order order = new dal.order();
            dal.OrderDB order = new dal.OrderDB();
            List<mo.order> modelOrder = order.getModelListWhere("");
            repOrder.DataSource = modelOrder;
            repOrder.DataBind();

            //dal.flash flash = new dal.flash();
            dal.FlashDB flash = new dal.FlashDB();
            List<mo.flash> modelFlash = flash.getModelListWhere("where typS='file'");
            repDownload.DataSource = modelFlash;
            repDownload.DataBind();

            //dal.news news = new dal.news();
            dal.NewsDB news = new dal.NewsDB();
            List<mo.news> modelNews = news.getModelListWhere("and typ=6");
            repFaq.DataSource = modelNews;
            repFaq.DataBind();

            liContact.Text = news.getString("aboutC", "where typS='contact'");
        }
    }
}