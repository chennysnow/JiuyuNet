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
public partial class userCon_NewType : System.Web.UI.UserControl
{
    public int show = 0;
    string typeid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        List<mo.menu> listMenu = menu.getModelListWhere("where typ=2");
      
        if (Request.Params["typeid"] != null)
            typeid = Request.Params["typeid"].ToString();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < listMenu.Count; i++)
        {
                if (listMenu[i].id.ToString() == typeid)//设置首选的样式
                {
                    sb.AppendFormat("<dt class='slider_open'><a href='CompanyNewList.aspx?typeid={0}'>{1}</a></dt>", listMenu[i].id, listMenu[i].nameC);
                    show = i;
                }
                else
                    sb.AppendFormat("<dt><a href='CompanyNewList.aspx?typeid={0}'>{1}</a></dt>", listMenu[i].id, listMenu[i].nameC);
                childMenu(sb, listMenu[i].id,i);
        }
        
        LiProtype.Text = sb.ToString();
    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="sb">字符串</param>
    /// <param name="id">父菜单ID</param>
    /// <param name="j">父菜单所在的下标</param>
    private void childMenu(System.Text.StringBuilder sb, int id,int j)
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        List<mo.menu> listMenu = menu.getModelListWhere("where typ=" + id);
        if (listMenu.Count > 0)
        {
            sb.Append("<dd>");
            string a = "CompanyNewList.aspx?typeid=";
            for (int i = 0; i < listMenu.Count; i++)
            {
                //if (listMenu[i].more == 1)
                //    a = "CompanyNews.aspx?typeid=";
                if (listMenu[i].id.ToString() == typeid)//设置首选的样式
                {
                    show = j;
                }
                sb.AppendFormat("<div><img src='images/triangle1.gif' />&nbsp;<a href='{0}{1}'>{2}</a></div>", a, listMenu[i].id, listMenu[i].nameC);
            }
            sb.Append("</dd>");
        }
    }
}
