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
public partial class ProSearch : System.Web.UI.Page
{
    public mo.proInfo model = new mo.proInfo();
    public string Categroy = "";
    public string display = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        op.staValue.setMeta(Page,"product");
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        string search = "";
        int typ = op.staValue.RequestInt(Request.QueryString["typ"]);
        display = Request.Params["display"];

        if (typ == 0)
        {
            if (Request.QueryString["Search"] != null)
            {
                search = op.staValue.RexSpecial(Request.QueryString["Search"].ToString());
                Categroy = "Search: \"" + search + "\"";
                search = "and qx=0 and (nameC like '%" + search + "%' or proId like '%" + search + "%')";
            }
        }
        else
        {
            search = op.staValue.RexSpecial(Request.QueryString["Search"].ToString());
            Categroy = "Search: \"" + search + "\"";
            if (string.IsNullOrEmpty(search))
            {
                search = "and qx=0 and addType like '%," + typ + ",%'";
            }
            else
            {
                search = "and qx=0 and addType like '%," + typ + ",%' and (nameC like '%" + search + "%' or proId like '%" + search + "%')";
            }
        }
        if (display != "" && display != null)
            search+=" and displayC like '%,"+display+",%'";

        AspNetPager1.PageSize = op.staValue.pageSize;
        //dal.products pro = new dal.products();
        MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
        List<mo.products> modelList = pro.getModelListWhere(search);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        int index = op.staValue.RequestInt(Request.QueryString["p"]);
        pds.CurrentPageIndex = (index > 0 ? index : 1) - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        repProDisplay.DataSource = pds;
        repProDisplay.DataBind();

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

    public string getCart(string index, string display)
    {
        if (display.IndexOf("1") > 0)
            return "<img src='images/addcartbg.jpg' alt='Add Cart' onclick='addCart(" + index + ",1)' style='cursor:pointer'/>";
        else
            return "";
    }
}
