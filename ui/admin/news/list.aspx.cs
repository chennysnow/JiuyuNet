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
public partial class admin_news_list : System.Web.UI.Page
{
    public op.Operation opera = new op.Operation();
    //dal.news news = new dal.news();
    MySqlDal.NewsDB news = new MySqlDal.NewsDB();
    //public dal.menu menu = new dal.menu();
   public MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "文章列表";
        if (!IsPostBack)
        {
             bin();
             DorBin();
        }
    }
    PagedDataSource pds = new PagedDataSource();
    private void bin()
    {
        string where="where typS='0' ";
        if (ViewState["typeid"] != null)
        {
            where+= "and typ=" + ViewState["typeid"].ToString();
        }
        List<mo.news> modelList = news.getAll_admin(where);
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
            news.DelId("id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        bin();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
         bin();
    }
    private void DorBin()//
    {
        ListItem li1 = new ListItem();
        li1.Text = "::全部::";
        li1.Value = "all";
        ddlNewsType.Items.Add(li1);
        List<mo.menu> modelList = menu.getModelListWhere("where typ=2");
        for (int i = 0; i < modelList.Count; i++)
        {
            ListItem li = new ListItem();
            li.Value = modelList[i].id.ToString();
            li.Text = modelList[i].nameC;
            ddlNewsType.Items.Add(li);
          //  DorSon(modelList[i].id, ddlNewsType);
        }
    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="id"></param>
    private void DorSon(int id, DropDownList dro)
    {
        List<mo.menu> modelList = menu.getModelListWhere("where typ=" + id);
        for (int i = 0; i < modelList.Count; i++)
        {
            ListItem li = new ListItem();
            li.Value = modelList[i].id.ToString();
            li.Text = "├" + modelList[i].nameC; 
            li.Selected = false;
            dro.Items.Add(li);
        }
    }
    protected void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNewsType.SelectedValue == "all")
            ViewState.Clear();
        else
            ViewState["typeid"] = ddlNewsType.SelectedValue;
        bin();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("id");
        string[] sort = Request.Form.GetValues("sort");
        for (int i = 0; i < id.Length; i++)
        {
            news.UpdateString("sortC=" + sort[i] + "", "where id=" + id[i]);
        }
        op.staValue.divAlert(this.Page, "保存成功");
        bin();
    }
    protected void lbtnShow_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            news.UpdateString("showC=1", "where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "操作成功", Request.Url.AbsoluteUri);
    }
    protected void lbtnHidden_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            news.UpdateString("showC=0", "where id in(" + id + ")");
        }
        op.staValue.divAlert(this.Page, "操作成功", Request.Url.AbsoluteUri);
    }
}
