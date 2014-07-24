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

public partial class admin_index_img : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (file_menu_0.HasFile)
        {
            file_menu_0.SaveAs(op.staValue.path + "/images/menu_0.jpg");
        }
        if (file_menu_1.HasFile)
        {
            file_menu_1.SaveAs(op.staValue.path + "/images/menu_1.jpg");
        }
        if (file_menu_2.HasFile)
        {
            file_menu_2.SaveAs(op.staValue.path + "/images/menu_2.jpg");
        }
        op.staValue.MessageShow(this.Page, "修改成功!", "img.aspx");
    }
}
