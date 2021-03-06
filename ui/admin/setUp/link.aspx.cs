﻿using System;
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

public partial class admin_link : System.Web.UI.Page
{
    //dal.link link = new dal.link();
    dal.LinkDB link = new dal.LinkDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "链接管理";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        string where = "";
        if (ViewState["type"] != null)
            where = "where typS='" + ViewState["type"].ToString()+"'";
        List<mo.link> modelList = link.getModelListWhere(where);
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
                mo.link model = link.getModel("where id=" + id);
                txtNameEdit.Text = model.nameC;
                txtUrlEdit.Text = model.urlC;
            }
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        mo.link model = new mo.link();
        model.nameC = txtName.Text;
        model.urlC = txtUrl.Text;
        model.typS=dropType.SelectedValue;
        link.InsertModel(model);
        op.staValue.divAlert(Page, "添加成功!");
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
        mo.link model = new mo.link();
        model.id = Convert.ToInt32(ViewState["id"].ToString());
        model.nameC = txtNameEdit.Text;
        model.urlC = txtUrlEdit.Text;
        model.typS = dropTypeEdit.SelectedValue;
        link.UpdateModel(model);
        op.staValue.divAlert(Page, "修改成功!");
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
            link.DelId("id in(" + id + ")");
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
    public string strTyp(string typ)
    {
        switch (typ)
        {
            case "bottom": return "底部链接";
            case "top": return "顶部链接";
            default: return "";
        }
    }
    protected void dropBin_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState.Clear();
        if (dropBin.SelectedValue != "all")
            ViewState["type"] = dropBin.SelectedValue;
        bin();
    }
}
