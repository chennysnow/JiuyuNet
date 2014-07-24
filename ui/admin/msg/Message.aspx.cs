using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
public partial class admin_Message : System.Web.UI.Page
{
    public op.Operation ope = new op.Operation();
    //dal.message message = new dal.message();
    MySqlDal.MessageDB message = new MySqlDal.MessageDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "留言信息";
        if (!IsPostBack)
        {
           bin();
        }
    }
    private void bin()
    {
        string typ = Request.QueryString["typ"];
        if (string.IsNullOrEmpty(typ))
        {
            typ = "0";
        }
        List<mo.message> modelList = message.getModelListWhere("", "where typ=" + typ+ "");
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            message.DelId("id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "see")
        {
            PanelBin(e.CommandArgument.ToString());
        }
    }
    /// <summary>
    /// 绑定Panel 查看留言
    /// </summary>
    /// <param name="id"></param>
    private void PanelBin(string id)
    {
        mo.message model = message.getModel("where id=" + id);
        TbContent.Text = model.contentC;
        LbPeople.Text = model.nameC;
        LbTel.Text = model.telC;
        LbAddress.Text = model.addressC;
        LbEmail.Text = model.mailC;
        lbTime.Text = model.timeC;
        lbIp.Text = model.ipC;
        Image1.ImageUrl = "/"+model.product;
        if (model.typ == 1)
        {
            Image1.Visible = true;
        }
        else
        {
            Image1.Visible = false;
        }
        panelSee.Visible = true;
        panelRep.Visible = false;
    }
    protected void BtnDispalyNone_Click(object sender, EventArgs e)
    {
        panelSee.Visible = false;
        panelRep.Visible = true;
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bin();
    }
}
