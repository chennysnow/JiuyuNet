using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class address : System.Web.UI.Page
{
    public mo.user model = new mo.user();
    public int flg = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["userName"] != null)
            {
                dal.UserDB user = new dal.UserDB();
                model = user.getModel("where userName='" + Request.Cookies["userName"].Value + "'");
                flg = 1;
            }
            else
            {
                model.userName = "";
                model.nameC = "";
                model.telC = "";
                model.addressC = "";
            }
            binPlace();
            binExpress();
        }
    }

    //绑定国家区域
    private void binPlace()
    {
        //dal.place place = new dal.place();
        dal.PlaceDB place = new dal.PlaceDB();
        List<mo.place> modelList = place.getModelListAll();
        repPlace.DataSource = modelList;
        repPlace.DataBind();
    }
    private void binExpress()
    {
        //dal.expPay expPay = new dal.expPay();
        dal.expPayDB expPay = new dal.expPayDB();
        List<mo.expPay> modelList = expPay.getModelListWhere("where typ=0");
        string ids = "";
        for (int i = 0; i < modelList.Count; i++)
        {
            ids += modelList[i].tipsC + ",";
        }
        ids = ids.TrimEnd(',');
        org.jiuyu.express.ExpService service = new org.jiuyu.express.ExpService();
        org.jiuyu.express.Express[] list = service.GetExpressPrice(ids);

       repExpress.DataSource = list;
        repExpress.DataBind();


        modelList = expPay.getModelListWhere("where typ=1");
        repPayment.DataSource = modelList;
        repPayment.DataBind();
    }
}