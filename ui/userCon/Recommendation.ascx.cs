using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_Recommendation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            List<mo.products> modelList = pro.getModelListWhere("where displayC like '%,3,%'");
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}