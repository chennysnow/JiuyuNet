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
public partial class admin_news_Edit : System.Web.UI.Page
{
    //dal.menu menu = new dal.menu();
    MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "文章修改";
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
               DorBin();
               bin(Request.QueryString["id"].ToString());
            }
        }
    }

    private void bin(string id)
    {
        //dal.news news = new dal.news();
        MySqlDal.NewsDB news = new MySqlDal.NewsDB();
        mo.news model = news.getModel("where id=" + id);
        txtName.Text = model.nameC;
        txtTitle.Text = model.titleC;
        txtKeywords.Text = model.keywordsC;
        txtDescription.Text = model.descriptionC;
        txtHtmlName.Text = model.htmlName;
        txtAbout.Text= model.aboutC;
        txtContent.Text = model.contentC;
        showC.Checked = model.showC == 1 ? true : false;
        dropType.SelectedValue = model.typ.ToString();
        ViewState["id"] = id;
    }
    private void DorBin()//只绑定 新闻的菜单
    {
        op.staValue staValue = new op.staValue();
        List<mo.menu> model = staValue.getMenuList(2);
        for (int i = 0; i < model.Count; i++)
        {
            ListItem li = new ListItem();
            li.Value = model[i].id.ToString();
            li.Text = model[i].nameC;
            dropType.Items.Add(li);
        }
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {

        try
        {
            mo.news model = new mo.news();
            model.nameC = txtName.Text;
           
            model.aboutC = txtAbout.Text;
            model.contentC = txtContent.Text;
            model.typ = int.Parse(dropType.SelectedValue);
            model.timeC = DateTime.Now.ToString("yyyy/MM/dd");
            model.id = Convert.ToInt32(ViewState["id"]);
            model.sortC = model.id;
            model.titleC = txtTitle.Text;
            model.keywordsC = txtKeywords.Text;
            model.descriptionC = txtDescription.Text;
            model.showC = showC.Checked ? 1 : 0;
            if (txtHtmlName.Text.IndexOf(".html") > 0)
            {
                model.htmlName = txtHtmlName.Text;
            }
            else
            {
                model.htmlName = op.staValue.RexSpecial(txtHtmlName.Text,"-") + ".html";
            }
            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            news.UpdateModel(model);
            op.staValue.divAlert(this.Page, "修改成功!", "list.aspx");
        }
        catch
         {
             op.staValue.divAlert(this.Page, "修改失败!");
         }
    }
}
