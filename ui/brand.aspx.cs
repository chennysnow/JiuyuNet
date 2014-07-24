using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class brand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.brand brand = new dal.brand();
            dal.BrandDB brand = new dal.BrandDB();
            List<mo.brand> modelList = brand.getModelListAll();
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}