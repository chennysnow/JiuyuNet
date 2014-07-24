using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
public partial class CompanyNewList : System.Web.UI.Page
{
    public op.Operation ope= new op.Operation();
    public string category = "Rnd News";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
          bin();
          op.staValue.setMeta(Page, "news");
        }
    }
    private void bin()
    {
        int typ = op.staValue.RequestInt(Request.QueryString["typ"]);
        typ=typ==0?4:typ;
        AspNetPager1.PageSize =op.staValue.newsSize;
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        mo.menu model = menu.getModel("where id=" + typ);
        category = model.nameC;
        this.AspNetPager1.UrlRewritePattern = "newList.html?p={0}&typ=" + typ + "";
        dal.NewsDB news = new dal.NewsDB();
        //dal.news news = new dal.news();
        List<mo.news> modelList = news.getModelListWhere("and typ="+typ);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        AspNetPager1.RecordCount = modelList.Count;
        int index = op.staValue.RequestInt(Request.QueryString["p"]);
        pds.CurrentPageIndex = (index > 0 ? index : 1) - 1;
        pds.DataSource = modelList;
        RepList.DataSource = pds;
        RepList.DataBind();
        //leftBin(typ);
    }
}
