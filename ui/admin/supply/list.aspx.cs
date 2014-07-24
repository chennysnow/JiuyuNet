using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_supply_list : System.Web.UI.Page
{
    //dal.supply att = new dal.supply();
    dal.SupplyDB att = new dal.SupplyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        //dal.supply att = new dal.supply();  
        //dal.SupplyDB att = new dal.SupplyDB();
        List<mo.supply> modelList = att.getModelListAll();
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            att.DelId("where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功", "list.aspx");
    }
   
 
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
}