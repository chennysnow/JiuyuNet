using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_hotPro : System.Web.UI.UserControl
{
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products pro = new dal.products();
            dal.ProductsDB pro = new dal.ProductsDB();
            List<mo.products> modelList = pro.getModelListWhere("top 5","and displayC like '%,2,%'");
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}