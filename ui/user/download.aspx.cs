using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.userJudge();
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            MySqlDal.FlashDB flash = new MySqlDal.FlashDB();
            List<mo.flash> modelList = flash.getModelListWhere("where typS='file'");
            repList.DataSource = modelList;
            repList.DataBind();
        }
    }
}