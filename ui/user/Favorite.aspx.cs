using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Favorite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string cookName = "favName";
            if (Request.Cookies[cookName] != null)
            {
                string cartInfo = HttpUtility.UrlDecode(Request.Cookies[cookName].Value);
                if (!string.IsNullOrEmpty(cartInfo))
                {
                    try
                    {
                        cartInfo = op.staValue.RexSpecial(cartInfo, ",");
                        //dal.products pro = new dal.products();
                        MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
                        List<mo.products> modelList = pro.getModelListWhere("top 20", "where id in(" + cartInfo + ")");
                        repFavorite.DataSource = modelList;
                        repFavorite.DataBind();
                    }
                    catch { }
                }
            }
        }
    }
}