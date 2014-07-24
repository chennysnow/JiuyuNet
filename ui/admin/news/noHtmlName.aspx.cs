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
public partial class admin_news_noHtmlName : System.Web.UI.Page
{
    public string typ = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.Judge();
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
        txtName.Text = model.nameC;
        txtTitle.Text = model.titleC;
        txtKeywords.Text = model.keywordsC;
        txtDescription.Text = model.descriptionC;
        txtAbout.Text = model.aboutC;
        txtContent.Text = model.contentC;
        ViewState["id"] = id;
        typ = model.typS;
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        try
        {
            //dal.news news = new dal.news();
            dal.NewsDB news = new dal.NewsDB();
            mo.news model = news.getModel("where id="+ViewState["id"].ToString());
            model.nameC = txtName.Text;
            model.titleC = txtTitle.Text;
            model.keywordsC = txtKeywords.Text;
            model.descriptionC = txtDescription.Text;
            model.aboutC = txtAbout.Text;
            model.contentC = txtContent.Text;
            model.timeC = DateTime.Now.ToString("yyyy/MM/dd");
            news.UpdateModel(model);
            op.staValue.divAlert(this.Page, "修改成功!", "speList.aspx");
        }
        catch
        {
            op.staValue.divAlert(this.Page, "修改失败!");
        }
    }
}
