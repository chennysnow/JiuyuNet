using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_supply_prosupply : System.Web.UI.Page
{
    //dal.products att = new dal.products();
    MySqlDal.ProductsDB att = new MySqlDal.ProductsDB();
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Master.title = "";
        if (!IsPostBack)
        {
          
            bin();
            dropBin();
        }
    }
    private void dropBin()//只绑定 
    {
        //dal.supply att = new dal.supply();
        MySqlDal.SupplyDB att = new MySqlDal.SupplyDB();
        List<mo.supply> modelList = att.getModelListAll();

        foreach (mo.supply model in modelList)
        {
            ListItem li = new ListItem();
            li.Value = model.id.ToString();
            li.Text = model.sname;

            dropList.Items.Add(new ListItem(model.sname, model.id.ToString()));

        }
    }
    private void bin()
    {
        List<mo.products> modelList =null;
        if (ViewState["where"] == null)
        {
            modelList = att.getAll_admin(""); 
        }
        else { modelList = att.getAll_admin(ViewState["where"].ToString()); }
      
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }

 

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
  
    protected void dropList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropList.SelectedValue != "0")
        {
            ViewState["where"] = "where supplyid like '%" + dropList.SelectedValue+"%'";
        }
        else
        { ViewState["where"] = ""; }
        bin();
    }
  
}