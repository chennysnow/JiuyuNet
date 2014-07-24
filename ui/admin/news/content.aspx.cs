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
public partial class admin_news_content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["id"] != null)
            {
                bin(Request.Params["id"].ToString());
            }

        }
    }

    private void bin(string id)
    {
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        mo.news model = news.getModel("where id=" + id);
        Master.title = model.nameC;
        txtContent.Text = model.contentC;
        ViewState["id"] = model.id;
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        try
        {
            //dal.news news = new dal.news();
            dal.NewsDB news = new dal.NewsDB();
            news.UpdateString("contentC='"+txtContent.Text+"'", "where id=" + ViewState["id"].ToString());
            op.staValue.divAlert(this.Page, "修改成功!", "speList.aspx");
        }
        catch
        {
            op.staValue.divAlert(this.Page, "修改失败!");
        }
    }
    protected void BtClear_Click(object sender, EventArgs e)
    {
        txtContent.Text = "";
    }
}
