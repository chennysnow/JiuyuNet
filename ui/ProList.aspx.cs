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
public partial class ProList : System.Web.UI.Page
{
    public string category = "Product List";
    public string display = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();//
        }
    }
    private void bin()
    {
        try
        {
            //dal.menu menu = new dal.menu();
            MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
            int typ = op.staValue.RequestInt(Request.Params["typ"]);
            display = Request.Params["display"];
            string flg="";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            AspNetPager1.PageSize = op.staValue.pageSize;
            if (Request.QueryString["flg"] != null && Request.QueryString["flg"] == "new")
            {
                if (Request.Cookies["userName"] == null || Request.Cookies["userName"].Value == "")
                {
                    op.staValue.MessageShow(this.Page, "Please login!", "login.aspx");
                    return;
                }
                if (Request.Cookies["userType"] == null || Request.Cookies["userType"].Value == "0")
                {
                    op.staValue.MessageShow(this.Page, "Please wait for the auditing!", "/");
                    return;
                }
                flg="new";
                sb.Append("and qx=1 ");
            }
            else
            {
                sb.Append("and qx=0 ");
            }
            mo.menu modelMenu = null;
            if (typ != 0)
            {
                modelMenu = menu.getModel("where id=" + typ);
                Master.topKey = modelMenu.topKey;
                op.staValue.setMeta(Page,modelMenu.titleC,modelMenu.keywordsC,modelMenu.descriptionC);
                sb.Append("and addType like '%," + modelMenu.id + ",%'");
                category = modelMenu.nameC;
                //liMenuAbout.Text ="<div class=\"ListAbout\" style=\"background:url("+modelMenu.urlC+") no-repeat center;\">"+modelMenu.aboutC+"</div>";
            }
            else
            {
                op.staValue.setMeta(Page, "product");
            }
            if (display != "" && display != null)
                sb.Append(" and displayC like '%,2,%'");
            else
                sb.Append(" and displayC like '%,1,%'");
            this.AspNetPager1.UrlRewritePattern = "proList.html?flg=" + flg + "&p={0}&typ=" + typ + "";
            this.AspNetPager1.EnableUrlRewriting = true;
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            List<mo.products> listModel = pro.getModelListWhere(sb.ToString());//不显示FLASH产品 displayindex<>2 and 
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            int index = op.staValue.RequestInt(Request.QueryString["p"]);
            pds.CurrentPageIndex = (index > 0 ? index : 1) - 1;
            pds.DataSource = listModel;
            AspNetPager1.RecordCount = listModel.Count;
            repProDisplay.DataSource = pds;
            repProDisplay.DataBind();
        }
        catch { }
    }
    public string getStar(int count)
    {
        string star = "";
        for (int j = 0; j < count; j++)
        {
            star += "<img src='images/productstar.jpg' width='15px' height='15px'>";
        }
        return star;
    }

    public string getCart(string index,string display)
    {
        if (display.IndexOf("1") > 0)
            return "<img src='images/addcartbg.jpg' alt='Add Cart' onclick='addCart(" + index + ",1)' style='cursor:pointer'/>";
        else
            return "";
    }
}
