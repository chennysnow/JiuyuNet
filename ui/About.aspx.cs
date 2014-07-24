using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
            org.jiuyu.express.ExpService service = new org.jiuyu.express.ExpService();
            //获取运费
            //service.GetShippingPrice()
            //国外快递 0  国内1
            //service.GetExpressList("0");

           //首重 续重
            //service.GetExpressPrice()
        }
    }
    private void bin()
    {
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        mo.news model = news.getModel("where typS='about'");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<dt>{0}</dt>", model.nameC);
        sb.AppendFormat("<dd>{0}</dd>", model.contentC);
        Page.Title = "About Us";
        liNews.Text = sb.ToString();
    }
    
}