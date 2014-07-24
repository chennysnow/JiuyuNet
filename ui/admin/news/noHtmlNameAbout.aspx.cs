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
        fckIntro.Value = model.contentC;
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
            model.contentC = fckIntro.Value;
            model.timeC = DateTime.Now.ToString("yyyy/MM/dd");
            news.UpdateModel(model);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文章编辑成功！');window.location.href='NewBottom.aspx';</script>");
        }
        catch
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文章编辑失败！');window.location.href='NewBottom.aspx';</script>");
        }
    }
    protected void BtClear_Click(object sender, EventArgs e)
    {
        fckIntro.Value = "";
    }
}
