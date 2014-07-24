using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_product_attrList : System.Web.UI.Page
{
    //dal.supplyvalue attr = new dal.supplyvalue();
    MySqlDal.SupplyvalueDB attr = new MySqlDal.SupplyvalueDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bin();
            Master.title = "供应商属性管理";
        }
    }
    public void bin()
    {
        List<mo.supplyvalue> modelList = attr.getModelListAll();
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string[] id = Request.Form.GetValues("id");
        string[] nameC = Request.Form.GetValues("nameC");
        string[] valueC = Request.Form.GetValues("valueC");
        for (int i = 0; i < id.Length; i++)
        {
            mo.supplyvalue model = new mo.supplyvalue();
            model.id = int.Parse(id[i]);
            model.name = nameC[i];
            model.value= valueC[i];
            attr.UpdateModel(model);
        }
        bin();
        op.staValue.divAlert(Page, "保存成功!");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            attr.DelId("where id in(" + id + ")");
            /////////////////更新产品包含的属性
            //id = "," + id + ",";
            //bool flg = true;
            //dal.products pro = new dal.products();
            //System.Data.DataTable dt = pro.getTable("select attrId,attrValue,preId from proInfo where attrId<>'0'");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string[] attrId = dt.Rows[i][0].ToString().Split(',');
            //    string[] attrValue = dt.Rows[i][1].ToString().Split('@');
            //    string strValue = "", strId = "";
            //    for (int j = 0; j < attrId.Length; j++)
            //    {
            //        if (id.IndexOf("," + attrId[j] + ",") >= 0)
            //        {
            //            flg = false;
            //        }
            //        else
            //        {
            //            strId += attrId[j] + ',';
            //            strValue += attrValue[j] + '@';
            //        }
            //    }
            //    if (!flg)
            //    {
            //       // pro.UpdateString("attrId='" + strId.TrimEnd(',') + "',attrValue='" + strValue.TrimEnd('@') + "'", "where preId=" + dt.Rows[i]["preId"]);
            //        flg = true;//还原
            //    }
            //}
        }
        bin();
        op.staValue.divAlert(Page, "删除成功!");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelList.Visible = false;
        panelAdd.Visible = true;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        mo.supplyvalue model = new mo.supplyvalue();
        model.name = txtName.Text;
        model.value= txtValue.Text;
        attr.InsertModel(model);
        op.staValue.divAlert(Page, "添加成功!");
    }
    protected void btnBakc_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = false;
        panelList.Visible = true;
        bin();
    }
}