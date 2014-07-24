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
public partial class admin_news_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "添加文章";
        if (!IsPostBack)
        {
            DorBin();
        }
    }
    ///// <summary>
    ///// 
    ///// </summary>
    ///// 
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
        //dal.news news = new dal.news();
        MySqlDal.NewsDB news = new MySqlDal.NewsDB();
        mo.news model = new mo.news();
        op.Operation ope = new op.Operation();
        model.id = ope.MaxId("news");
        model.nameC = txtName.Text;
        model.sortC = model.id;
        model.aboutC = txtAbout.Text;
        model.contentC = txtContent.Text;
        model.typ = int.Parse(dropType.SelectedValue);
        model.timeC = DateTime.Now.ToString("yyyy/MM/dd");
        model.titleC = txtTitle.Text;
        model.keywordsC = txtKeywords.Text;
        model.descriptionC = txtDescription.Text;
        model.showC = showC.Checked ? 1 : 0;
        model.typS = "0";
        model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC,"-") + ".html" : op.staValue.RexSpecial(txtHtmlName.Text) + ".html";
        try
        {
            news.InsertModel(model);
            op.staValue.divAlert(this.Page, "添加成功!");
        }
        catch
        {
            op.staValue.divAlert(this.Page, "添加失败!");
        }
    }
}
