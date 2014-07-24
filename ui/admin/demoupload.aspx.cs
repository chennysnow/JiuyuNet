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
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;

public partial class demoupload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cook.Judge();
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
            ListItem li = new ListItem();
            li.Text = model.nameC;
            li.Value = model.id.ToString();
            ddlProductCategory.Items.Add(li);
        }
    }
}
