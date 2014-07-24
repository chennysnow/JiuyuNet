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

public partial class admin_product_brand : System.Web.UI.Page
{
    //dal.brand brand = new dal.brand();
    MySqlDal.BrandDB brand = new MySqlDal.BrandDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "品牌管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        List<mo.brand> modelList = brand.getModelListAll();
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")//修改绑定
        {
            mo.brand model=brand.getModel("where id="+e.CommandArgument.ToString());
            PanelRep.Visible = false;
            panelEdit.Visible = true;
            imgEdit.Src = model.imgC;
            txtNameEdit.Text = model.nameC;
            ViewState["id"] = model.id;
        }
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        PanelRep.Visible = false;
        PanelAdd.Visible = true;
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            op.staValue.divAlert(this.Page, "品牌名称不能为空");
        }
        if (fileAdd.HasFile)
        {  
            mo.brand model = new mo.brand();
            model.imgC = "/uploadFile/brand/"+fileAdd.FileName;
            fileAdd.SaveAs(op.staValue.path + model.imgC);
            model.nameC = txtName.Text;
            brand.InsertModel(model);
            op.staValue.divAlert(this.Page, "添加成功");
            PanelRep.Visible = true;
            PanelAdd.Visible = false;
            bin();
        }
        else
        {
            op.staValue.divAlert(this.Page,"图片必须上传");
        }
    }
    protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelRep.Visible = true;
        PanelAdd.Visible = false;
    }
    protected void BtEditOk_Click(object sender, EventArgs e)
    {
        mo.brand model = brand.getModel("where id=" + ViewState["id"].ToString());
        if (txtNameEdit.Text == "")
        {
            op.staValue.divAlert(this.Page, "品牌名称不能为空");
        }
        if (fileEdit.HasFile)
        {
            model.imgC = "/uploadFile/brand/"+fileEdit.FileName;
            fileEdit.SaveAs(op.staValue.path + model.imgC);
        }
        model.nameC = txtNameEdit.Text;
        brand.UpdateModel(model);
        op.staValue.divAlert(this.Page, "修改成功");
        panelEdit.Visible = false;
        PanelRep.Visible = true;
        bin();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"]; ;
        brand.DelId("where id in(" +id + ")");
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("id");
        string[] sort = Request.Form.GetValues("sort");
        for (int i = 0; i < id.Length; i++)
        {
            brand.UpdateString("sortC=" + sort[i], "where id=" + id[i]);
        }
        op.staValue.divAlert(this.Page, "保存成功");
        bin();
    }
}
