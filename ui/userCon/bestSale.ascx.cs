using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userCon_bestSale : System.Web.UI.UserControl
{
    public int typ { get; set; }
    public int count { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            string where = "";
            if (typ != 0)
            {
                where = "and typ="+typ;
            }
            List<mo.products> modelList = pro.getModelListWhere("top " + count, where, "order by sellCount desc,id");
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}