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
public partial class userCon_ProDisplay : System.Web.UI.UserControl
{
    public int typ { get; set; }
    public string name { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products pro = new dal.products();
            dal.ProductsDB pro = new dal.ProductsDB();
            List<mo.products> modelList = pro.getModelListWhere("top 8", "where displayC like '%,1,%' and typ=" + typ);
            repProDisplay.DataSource = modelList;
            repProDisplay.DataBind();

        }
    }
}
