using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_supply_add : System.Web.UI.Page
{
    //dal.supply att = new dal.supply();
    dal.SupplyDB att = new dal.SupplyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            attrBin();
        }

    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        try { 
        mo.supply model = new mo.supply();
        model.sname = txtName.Text;
        model.phone = txtphone.Text.Trim();
        model.address = txtaddress.Text.Trim();
        model.mail = txtmail.Text.Trim();
        model.contactus = txtcontactus.Text.Trim();  
        model.times = DateTime.Now.ToString("yyyy/MM/dd");//时间
        model.note1 = txtnote1.Text.Trim();

        //自定义属性
        string[] attr = Request.Form.GetValues("attr");
        if (attr != null && attr.Length > 0)
        {
            string[] id = Request.Form.GetValues("attrValueid");
            string[] attrValue = Request.Form.GetValues("attrValue");
            string strAttrId = "", strAttrValue = "";
            for (int i = 0; i < attr.Length; i++)
            {

                for (int j = 0; j < id.Length; j++)
                {
                    if (id[j] == attr[i])
                    {
                        strAttrId += attr[i] + ",";
                        strAttrValue += attrValue[i] + ",";//值加上了头部标识
                    }
                }
               
            }
            model.abrand =strAttrValue ;
            model.agentyp =strAttrId ;
        }
       



        att.InsertModel(model);
        op.staValue.divAlert(Page, "添加成功!", "list.aspx");
        }
        catch
        {
            op.staValue.divAlert(Page, "添加失败!", "list.aspx");
        }
    }
    
    private void attrBin()
    {
        //dal.supplyvalue attr = new dal.supplyvalue();
        dal.SupplyvalueDB attr = new dal.SupplyvalueDB();
        List<mo.supplyvalue> modelList = attr.getModelListAll();
        repAttr.DataSource = modelList;
        repAttr.DataBind();
    }
  
}