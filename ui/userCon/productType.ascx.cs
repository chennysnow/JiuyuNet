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
public partial class userCon_productType : System.Web.UI.UserControl
{
    //dal.menu menu = new dal.menu();
    dal.MenuDB menu = new dal.MenuDB();
    //string htmlName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
        }
    }    
    private void bin()
    {
        int typ = op.staValue.RequestInt(Request.QueryString["typ"]);
        string where = "where typ=1";
        List<mo.menu> listMenu = menu.getModelListWhere(where);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < listMenu.Count; i++)
        {
            sb.AppendFormat("<dt id='menuId{0}'><a href='{1}'>{2}</a></dt>",listMenu[i].id, listMenu[i].url, listMenu[i].nameC);
            sb.Append("<dd>");
            childMenu(sb, listMenu[i].id);
            sb.Append("</dd>");
        }
        LiProtype.Text = sb.ToString();
    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="sb">字符串</param>
    /// <param name="id">父菜单ID</param>
    /// <param name="j">父菜单所在的下标</param>
    private void childMenu(System.Text.StringBuilder sb, int id)
    {
       List<mo.menu> listMenu = menu.getModelListWhere("where typ=" + id);
       //List<mo.menu> listMenu = new dal.menu().getModelListWhere("where parent_id =" + id);
        if (listMenu.Count <= 0)
            return;
        else
        {
            for (int i = 0; i < listMenu.Count; i++)
            {
                sb.AppendFormat("<div id='menuId{0}'><b>></b> <a href='{1}' title='{2}'>{2}</a></div>", listMenu[i].id, listMenu[i].url, listMenu[i].nameC);
            }

        }
    }
}
