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

public partial class admin_news_Search : System.Web.UI.Page
{
    //dal.searchWords search = new dal.searchWords();
    MySqlDal.SearchWordsDB search = new MySqlDal.SearchWordsDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.Judge();
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        List<mo.searchWords> modelList = search.getModelListAll();
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
        if (e.CommandName == "del")
        {
            try
            {
                int id = int.Parse(e.CommandArgument.ToString());
                search.DelId(id);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('删除成功！');</script>");
                bin();
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('删除失败！');window.location.href='" + Request.RawUrl + "';</script>");
                bin();
            }
        }
        else
            if (e.CommandName == "edit")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                panelEdit.Visible = true;
                PanelRep.Visible = false;
                ViewState["id"] = id;
                mo.searchWords model = search.getModel("where id=" + id);
                txtNameEdit.Text = model.nameC;
                
                txtCrtEdit.Text = model.countC.ToString();
            }
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        mo.searchWords model = new mo.searchWords();
        model.nameC = txtName.Text;
        model.countC = int.Parse(txtCrt.Text);
        search.InsertModel(model);
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加成功！');</script>");
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
        mo.searchWords model = new mo.searchWords();
        model.id = Convert.ToInt32(ViewState["id"].ToString());
        model.nameC = txtNameEdit.Text;
        model.countC = int.Parse(txtCrtEdit.Text);
        search.UpdateModel(model);
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功！');</script>");
        PanelRep.Visible = true;
        panelEdit.Visible = false;
        bin();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlInputCheckBox chkId = (HtmlInputCheckBox)item.FindControl("chkId");
                if (chkId.Checked)
                {
                    int id = int.Parse(chkId.Value);
                    search.DelId(id);
                }
            }
        }
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
