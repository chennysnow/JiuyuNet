using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order_box : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binBox();
        }
    }
    private void binBox()
    {
        if (Request.QueryString["size"] != null)
        {
            //dal.box box = new dal.box();
            dal.BoxDB box = new dal.BoxDB();
            List<mo.box> modelList = null;
            double size = 0;
            bool flg = double.TryParse(Request.QueryString["size"].ToString(), out size);
            if (flg)
                modelList = box.getModelListWhere("top 10", "where sizeC>=" + size);
            else
            {
                modelList = box.getModelListWhere("top 10", "");
            }
            if (modelList.Count <= 0)
                lbInfo.Visible = true;
            else
            {
                repBoxList.DataSource = modelList;
                repBoxList.DataBind();
            }
        }
        else
        {
            Response.Redirect("shopping.aspx");
        }
    }
}