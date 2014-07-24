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

public partial class userCon_hotSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.searchWords search = new dal.searchWords();
            MySqlDal.SearchWordsDB search = new MySqlDal.SearchWordsDB();
            List<mo.searchWords> modelList = search.getModelListAll();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < modelList.Count; i++)
            {
                sb.AppendFormat("<dd><img src='/images/biao.gif' align='absmiddle' />&nbsp;<a href='CompanyProSearch.aspx?searchId={0}'>{1}</a>", modelList[i].id, modelList[i].nameC);
            }
            liSearch.Text = sb.ToString();
        }
    }
}
