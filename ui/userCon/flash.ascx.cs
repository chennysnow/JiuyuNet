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
public partial class userCon_flash : System.Web.UI.UserControl
{
    public int index = 0;
    public mo.flash flashModel ;
    public List<mo.flash> modelList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.flash flash = new dal.flash();
            MySqlDal.FlashDB flash = new MySqlDal.FlashDB();
            modelList = flash.getModelListWhere("where typS='flash'");//读取6张图片的信息
            if (modelList == null || modelList.Count == 0)
                return;

            flashModel = modelList[0];
            repSmalImg.DataSource = modelList;
            repSmalImg.DataBind();
        }
    }
}
