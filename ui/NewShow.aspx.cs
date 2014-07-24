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

public partial class CompanyNews : System.Web.UI.Page
{
    public string category = "News Center";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        int id = op.staValue.RequestInt(Request.QueryString["id"]);
        string strSql = "";
        op.Operation ope = new op.Operation();
        if (Request.QueryString["typ"] != null)
        {
            strSql = "where typS='" + ope.StrEncode(Request.QueryString["typ"]) + "'";
        }
        else
        {
            strSql = "where id=" + id;
        }
        //dal.news news = new dal.news();
        MySqlDal.NewsDB news = new MySqlDal.NewsDB();
        mo.news model = news.getModel(strSql);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<dt>{0}</dt>", model.nameC);
        sb.AppendFormat("<dd>{0}</dd>", model.contentC);
        sb.AppendFormat("<dd><span style='margin-left:480px;'></span>Posted:{0}</dd>", model.timeC);
        liNews.Text = sb.ToString();
        op.staValue.setMeta(Page, model.titleC, model.keywordsC, model.descriptionC);
        leftBin(model.typ);
    }
    private void leftBin(int typ)
    {
        if (typ == 0)
            typ = 4;
        //dal.menu menu = new dal.menu();
        MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
        string str = menu.getString("nameC", "where id=" + typ);
        category = str == null ? category : str;
        //dal.news news = new dal.news();
        MySqlDal.NewsDB news = new MySqlDal.NewsDB();
        List<mo.news> modelList = news.getModelListWhere("top 15", "and typ=" + typ);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < modelList.Count; i++)
        {
            sb.AppendFormat("<li><font color=\"#aa0000\">&#8226;&nbsp;</font><a href='{0}'>{1}</a></li>", modelList[i].htmlName, modelList[i].nameC);
        }
        liNewMenu.Text = sb.ToString();
    }
}
