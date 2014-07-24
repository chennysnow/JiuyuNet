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
public partial class ProShow : System.Web.UI.Page
{
    public mo.proInfo model = new mo.proInfo();
    public string Categroy = "";
    //dal.products pro = new dal.products();
    MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
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
        model = pro.getModel("where id=" + id);
        string[] arrMoreImg = model.moreImg.Split(',');
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < arrMoreImg.Length; i++)//小图
        {
            sb.AppendFormat("<li><img src=\"{0}/sImg{1}\" /></li>", model.fileName, arrMoreImg[i]);
        }
        liMoreImg.Text = sb.ToString();
        MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
        Categroy = menu.getString("nameC", "where id=" + model.typ);
        op.staValue.setMeta(Page, model.titleC, model.keywordsC, model.descriptionC);
        liDescription.Text = model.contentC;
        binProType(model.typ);
        binAttr(model.attrId, model.attrValue);
        binKey(model.keywordsC);
        binPrice(model.id);


        //添加产品访问数
        if (Session["visitor"] == null || !Session["visitor"].ToString().Contains("_" + model.id.ToString() + "_"))
        {
            MySqlDal.VisitorsReportDB db = new MySqlDal.VisitorsReportDB();
            mo.VisitorsReport obj = new mo.VisitorsReport();
            obj.Createdate = DateTime.Now;
            obj.ProductID = model.id.ToString();
            obj.ProductName = model.nameC;
            string IpAdderss;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)//获取用户内部ip
            {
                IpAdderss = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];//可以获得位于代理（网关）后面的直接IP，当然必须这个代理支持
                if (IpAdderss == null)
                    IpAdderss = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];//本机ip
            }
            else
            {
                IpAdderss = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];//发出请求的远程主机的IP地址
            }
            obj.VisitorIP = obj.VisitorIP;
            obj.VCount = 1;
            db.InsertModel(obj);
            if (Session["visitor"] == null)
                Session["visitor"] = "_" + model.id.ToString() + "_";
            else
                Session["visitor"] =Session["visitor"].ToString()+ model.id.ToString() + "_";

        }

    }
    private void binAttr(string attrId, string attrValue)
    {
        if (!string.IsNullOrEmpty(attrId))
        {
            //dal.attr attr = new dal.attr();
            MySqlDal.attrDB attr = new MySqlDal.attrDB();
            List<mo.attr> modelList = attr.getModelListWhere("where id in(" + attrId + ")");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<string> value = attrValue.Split('@').ToList();
            for (int i = 0; i < modelList.Count; i++)
            {
                for (int j = 0; j < value.Count; j++)
                {
                    if (value[j].IndexOf("|" + modelList[i].id + "|") >= 0)
                    {
                        sb.AppendFormat("<li><span>{0}</span>{1}</li>", modelList[i].nameC, value[j].Replace("|" + modelList[i].id + "|", ""));//值加上了头部标识
                        value.Remove(value[j]);
                        break;
                    }
                }

            }
            liAttr.Text = sb.ToString();
        }
    }
    private void binProType(int typ)
    {
        List<mo.products> modelList = pro.getModelListWhere("top 10", "and typ=" + typ + " and displayC like '%,3,%'");
        repProType.DataSource = modelList;
        repProType.DataBind();
    }
    private void binPrice(int typ)
    {
        //dal.price price = new dal.price();
        MySqlDal.PriceDB price = new MySqlDal.PriceDB();
        List<mo.price> modelList = price.getModelListWhere("where typ=" + typ);
        repPrice.DataSource = modelList;
        repPrice.DataBind();
    }
    /// <summary>
    /// 关键字搜索
    /// </summary>
    /// <param name="title_1"></param>
    private void binKey(string key)
    {
        string where = "";
        if (key != "")
        {
            where = "and (";
            string[] arrKey = key.Split(',');
            for (int i = 0; i < arrKey.Length; i++)
            {
                where += " nameC like '" + arrKey[0] + "' or";
            }
            where = where.Remove(where.Length - 2);
            where += ")";
        }
        List<mo.products> modelList = pro.getModelListWhere("top 20", where);
        if (modelList.Count <= 0)
        {
            modelList = pro.getModelListWhere("top 20", "and qx=0 and typ=" + model.typ);
        }
        repSeaKey.DataSource = modelList;
        repSeaKey.DataBind();
    }
}
