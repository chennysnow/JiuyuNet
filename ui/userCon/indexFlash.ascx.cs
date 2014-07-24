using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class userCon_indexFlash : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            MySqlDal.FlashDB flash = new MySqlDal.FlashDB();
            List<mo.flash> modelList = flash.getModelListWhere("where typS='indexImg'");//读取6张图片的信息
            repFlash.DataSource = modelList;
            repFlash.DataBind();
        }
    }
}