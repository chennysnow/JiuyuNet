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

public partial class admin_flash : System.Web.UI.Page
{
    //dal.flash flash = new dal.flash();
    MySqlDal.FlashDB flash = new MySqlDal.FlashDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "图片切换";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        List<mo.flash> modelList = flash.getModelListAll();
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
            if (e.CommandName == "edit")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                panelEdit.Visible = true;
                PanelRep.Visible = false;
                ViewState["id"] = id;
                mo.flash model = flash.getModel("where id=" + id);
                txtNameEdit.Text = model.nameC;
                dropEdit.SelectedValue = model.typS;
                if (model.typS == "indexImg")
                {
                    txtUrlEdit.Text = model.url1;
                    txtUrlEdit2.Text = model.url2;
                }
                else
                    model.urlC = txtUrlEdit.Text;
                //if(model.typS=="index")
                //    panelMenuSmollEdit.Visible=true;
            }
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        mo.flash model = new mo.flash();
        model.nameC = txtName.Text;
        model.urlC = txtUrl.Text;
        model.typS = dropAdd.SelectedValue;//"flash";//
        if (fileAdd.HasFile)
        {
            model.imgC ="/uploadFile/flash/"+ fileAdd.FileName;
            fileAdd.SaveAs(op.staValue.path + model.imgC);
        }
        if (model.typS == "indexImg")
        {
            model.urlC = model.urlC + ";" + txtUrl2.Text;
        }
        flash.InsertModel(model);
        op.staValue.divAlert(this.Page, "添加成功");
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
        bin();
    }
    protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
    }
    protected void BtEditOk_Click(object sender, EventArgs e)
    {
        mo.flash model = flash.getModel("where id=" + ViewState["id"].ToString());
        model.nameC = txtNameEdit.Text;
        if (model.typS == "indexImg")
        {
            model.urlC = txtUrlEdit.Text + ";" + txtUrlEdit2.Text;
        }
        else
            model.urlC = txtUrlEdit.Text;
        model.typS = dropEdit.SelectedValue;
        if (fileAddEdit.HasFile)
        {
            model.imgC = "/uploadFile/flash/" + fileAddEdit.FileName;
            fileAddEdit.SaveAs(op.staValue.path + model.imgC);
            if (model.typS == "file")
            {
                model.urlC = model.imgC;
            }
        }
        flash.UpdateModel(model);
        op.staValue.divAlert(this.Page, "修改成功");
        PanelRep.Visible = true;
        panelEdit.Visible = false;
        bin();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            flash.DelId("id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        PanelRep.Visible = false;
        PanelAdd.Visible = true;
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
}
