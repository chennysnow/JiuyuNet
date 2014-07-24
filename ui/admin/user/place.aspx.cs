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

public partial class admin_user_place : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "地方管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    //dal.place place = new dal.place();
    MySqlDal.PlaceDB place = new MySqlDal.PlaceDB();
    private void bin()
    {
        List<mo.place> modelList = place.getModelListAll();
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            try
            {
                place.DelId(e.CommandArgument.ToString());
                op.staValue.divAlert(Page, "删除成功!");
                bin();
            }
            catch
            {
                op.staValue.divAlert(Page, "删除失败!");
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        mo.place model = new mo.place();
        model.nameC = txtPlace.Text;
        model.sortC = 1;
        place.InsertModel(model);
        op.staValue.divAlert(this.Page, "添加成功！");
        bin();
       
    }
}
