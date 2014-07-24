using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class userCon_ImgScoll : System.Web.UI.UserControl
{
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products products = new dal.products();
            dal.ProductsDB pro = new dal.ProductsDB();
            List<mo.products> modelList = pro.getModelListWhere("top 30", "and displayC like '%,2,%'");
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}
