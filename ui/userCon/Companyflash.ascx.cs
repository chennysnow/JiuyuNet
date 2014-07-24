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
public partial class userCon_Companyflash : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            dal.FlashDB flash = new dal.FlashDB();
            List<mo.flash> modelList = flash.getModelListWhere("where typS='flash'");//读取6张图片的信息
            repFlash.DataSource = modelList;
            repFlash.DataBind();
        }
    }
}
