using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class _index : System.Web.UI.Page 
{
    //dal.menu menu = new dal.menu();
    dal.MenuDB menu = new dal.MenuDB();
    //dal.news news = new dal.news();
    dal.NewsDB news = new dal.NewsDB();
    //dal.products pro = new dal.products();
    dal.ProductsDB pro = new dal.ProductsDB();
    //dal.link links = new dal.link();
    dal.LinkDB links = new dal.LinkDB();
    public int index = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            op.staValue.setMeta(Page, "index");
            String about = news.getString("aboutC", "where typS='about'");
            liAbout.Text = about;
            String newPro = news.getString("aboutC", "where typS='NewPro'");
            liNewPro.Text = newPro;
            String Effect = news.getString("aboutC", "where typS='Effect'");
            liEffect.Text = Effect;
            String Custom = news.getString("aboutC", "where typS='Custom'");
            liCustom.Text = Custom;
            List<mo.proInfo> proList = pro.getModelListAll_info("top 8", " and displayC like '%,1,%'");
            
            repProDisplay.DataSource = proList;
            repProDisplay.DataBind();
            List<mo.link> linkList = links.getModelListWhere("where typS='bottom'");
            for (int i = 0; i < linkList.Count; i++)
            {
                liPartner.Text += linkList[i].nameC + "&nbsp;&nbsp;";
            }
            List<mo.link> ImgLink = links.getModelListWhere("where typS='bottom' and logo<>''");
            for (int i = 0; i < ImgLink.Count; i++)
            {
                liPartnerHasImg.Text += "<img src='" + ImgLink[i].logo + "' width='105px' height='45px'> &nbsp;&nbsp;";
            }
        }
    }

    public string getStar(int count)
    {
        string star="";
        for (int j = 0; j < count; j++)
        {
            star += "<img src='images/productstar.jpg' width='15px' height='15px'>";
        }
        return star;
    }
}
