using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_product_batch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "批量上传";
        if (!IsPostBack)
        {
            //ddlProductCategory.Items.Clear();
            ddlProductCategory.Items.Add(new ListItem("请选择类别", "0"));
            typBin();
        }
    }
    private void typBin()
    {
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(1);
        foreach (mo.menu model in modelList)
        {
            string html = "";
            if (model.htmlName.IndexOf('/') >= 0)
            {
                html = model.htmlName.Substring(0, model.htmlName.IndexOf('/') + 1);
            }
            ListItem li = new ListItem();
            li.Text = model.nameC;
            li.Value = model.id + "|" + html;
            ddlProductCategory.Items.Add(li);
        }
    }
}