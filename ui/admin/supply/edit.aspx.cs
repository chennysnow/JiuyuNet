using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_supply_edit : System.Web.UI.Page
{
    mo.supply model = new mo.supply();
    //dal.supply att = new dal.supply();
    dal.SupplyDB att = new dal.SupplyDB();
    List<mo.supplyvalue> modelList = new List<mo.supplyvalue>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            attrBin();
            Bin();
        }

    }

    protected void BtOk_Click(object sender, EventArgs e)
    {
        try
        {
            mo.supply model = new mo.supply();
            model.id =Convert.ToInt32( Request.QueryString["id"]);
            model.sname = txtName.Text;
            model.phone = txtphone.Text.Trim();
            model.address = txtaddress.Text.Trim();
            model.mail = txtmail.Text.Trim();
            model.contactus = TextBox1.Text;
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
                model.abrand = strAttrValue;
                model.agentyp = strAttrId;
            }




            att.UpdateModel(model);
            op.staValue.divAlert(Page, "修改成功!", "list.aspx");
        }
        catch
        {
            op.staValue.divAlert(Page, "修改失败!", "list.aspx");
        }
    }

    private void attrBin()
    {
        //dal.supplyvalue attr = new dal.supplyvalue();
        dal.SupplyvalueDB attr = new dal.SupplyvalueDB();
        modelList = attr.getModelListAll();
        repAttr.DataSource = modelList;
        repAttr.DataBind();
    }

    private void Bin()
    {
        if (Request.QueryString["id"] != null)
        {

            model = att.getModel("where id=" + Request.QueryString["id"].ToString());
            txtName.Text = model.sname;
            txtName.Text = model.sname;
            txtphone.Text = model.phone;
            txtaddress.Text = model.address;
            txtmail.Text = model.mail;
            TextBox1.Text = model.contactus;

            txtnote1.Text = model.note1;



            string[] attr = model.abrand.Split(',');


            string[] attrValue = model.agentyp.Split(',');

            for (int i = 0; i < attr.Length; i++)
            {

                for (int j = 0; j < modelList.Count; j++)
                {
                    if (modelList[j].id.ToString() == attrValue[i])
                    {
                        modelList[j].types = "1";
                        modelList[j].name = attr[i];
                        modelList[j].id = Convert.ToInt32(attrValue[i]);//值加上了头部标识
                        break;
                    }
                    //else { modelList[i].name = ""; }

                }

                repAttr.DataSource = modelList;
                repAttr.DataBind();
            }
        }
        else { op.staValue.divAlert(this.Page, "加载失败", Request.RawUrl); }
    }
}