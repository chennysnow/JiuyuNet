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
public partial class admin_product_type : System.Web.UI.Page
{
    //dal.menu menu = new dal.menu();
    dal.MenuDB menu = new dal.MenuDB();
    setWeb set = new setWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "产品分类管理";
        if (!IsPostBack)
        {
            DorBin();
            RepBin();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    private void DorBin()//只绑定 
    {
        dropType.Items.Clear();
        dropType_edit.Items.Clear();
        dropType.Items.Add(new ListItem("一级分类", "1"));
        dropType_edit.Items.Add(new ListItem("一级分类", "1"));
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(0);
        foreach (mo.menu model in modelList)
        {
            ListItem li = new ListItem();
            li.Value = model.id.ToString();
            li.Text = model.nameC;
            dropType.Items.Add(li);
            dropType_edit.Items.Add(li);
        }
    }
    private void RepBin()//绑定一级菜单  重构
    {
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(0);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    protected void LbAdd_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = true;
        PanelRep.Visible = false;
    }
    protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
        panelEdit.Visible = false;
        RepBin();
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        int ty = Convert.ToInt32(dropType.SelectedValue);
        mo.menu model = new mo.menu();
        op.Operation ope = new op.Operation();
        model.id = ope.MaxId("menu");
        if (ty == 1)//判断是添加几级分类
        {
            model.levelC = 1;
        }
        else
        {
            model.levelC = Convert.ToInt32(menu.getString("levelC", "where id=" + ty)) + 1;

        }
        if (fileAdd.HasFile)
        {
            model.urlC = "/uploadfile/menu/"+fileAdd.FileName;
            fileAdd.SaveAs(op.staValue.path + model.urlC);
        }
        model.nameC = txtName.Text;
        model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC)  : op.staValue.RexSpecial(txtHtmlName.Text) ;
       
        model.typ = ty;
        model.sortC = model.id;

        model.titleC = txtTitle.Text == "" ? model.nameC : txtTitle.Text;
        model.keywordsC = txtKeywords.Text;
        model.descriptionC = txtDescription.Text;
        model.topKey = txtTopKey.Text;
        //model.preId = model.id.ToString() + ",";
        model.sonId = model.preId.ToString();
        model.aboutC = txtContent.Text;
        menu.InsertModel(model);
        op.staValue.divAlert(this.Page, "添加成功!");
        set.updateCacheFile();
        DorBin();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edi")//修改绑定
        {
            PanelRep.Visible = false;
            panelEdit.Visible = true;
            string str = e.CommandArgument.ToString();
            mo.menu model = menu.getModel("where id=" + str);
            txtName_edit.Text = model.nameC;
            //txtCount_edit.Text = model.countC.ToString();
            txtTitle_edit.Text = model.titleC;
            txtKeywords_edit.Text = model.keywordsC;
            txtDescription_edit.Text = model.descriptionC;
            txtTopKey_edit.Text = model.topKey;
            txtHtmlName_edit.Text = model.htmlName;
            txtContent_edit.Text = model.aboutC;
            if (model.typ != 0)
                dropType_edit.SelectedValue = model.typ.ToString();
            ViewState["menuId"] = model.id;
        }

    }
    protected void BtEditOk_Click(object sender, EventArgs e)
    {
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            mo.menu model = menu.getModel("where id=" + ViewState["menuId"].ToString());
            int menulevel = 0;
            int ty = Convert.ToInt32(dropType_edit.SelectedValue);
            if (ty == 1)
            {
                menulevel = 1;
            }
            else
            {
                menulevel = Convert.ToInt32(menu.getString("levelC", "where id=" + ty)) + 1;
            }
            model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC) : op.staValue.RexSpecial(txtHtmlName.Text);
            if (fileEdit.HasFile)
            {
                model.urlC = "/uploadfile/menu/" + fileEdit.FileName;
                fileEdit.SaveAs(op.staValue.path + model.urlC);
            }
            model.levelC = menulevel;
            model.typ = ty;
            model.nameC = txtName_edit.Text;
            //model.countC = int.Parse(txtCount_edit.Text);
            model.titleC = txtTitle_edit.Text == "" ? model.nameC : txtTitle_edit.Text;
            model.keywordsC = txtKeywords_edit.Text;
            model.descriptionC = txtDescription_edit.Text;
            model.topKey = txtTopKey_edit.Text;
            model.aboutC = txtContent_edit.Text;
            menu.UpdateModel(model);
            set.updateCacheFile();
        }
        catch
        {
            op.staValue.divAlert(Page, "修改失败!");
        }
        PanelRep.Visible = true;
        panelEdit.Visible = false;
        RepBin();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("id");
        string[] sort = Request.Form.GetValues("sort");
        // string[] display = Request.Form.GetValues("display");
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        for (int i = 0; i < id.Length; i++)
        {
            menu.UpdateString("sortC=" + sort[i], "where id=" + id[i]);
        }
        op.staValue.divAlert(this.Page, "保存成功");
        set.updateCacheFile();
        RepBin();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("chkId"); ;
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        for (int i = 0; i < id.Length; i++)
        {
            menu.DelId("where id=" + id[i] + " or typ=" + id[i] + "");
        }
        set.updateCacheFile();
        op.staValue.divAlert(this.Page, "删除成功",Request.Url.AbsoluteUri);
        //RepBin();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        set.updateCount(1);
        set.updateCacheFile();
        RepBin();
    }
    protected void lbtnUpdateContain_Click(object sender, EventArgs e)
    {
        op.staValue.divAlert(Page, "更新成功!");
        set.updateContainId();
        set.updateCacheFile();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        RepBin();
    }
    //protected void lbtnShow_Click(object sender, EventArgs e)
    //{
    //    string id = Request.Form["chkId"];
    //    if (!string.IsNullOrEmpty(id))
    //    {
    //        menu.UpdateString("displayC=1", "where id in(" + id + ")");
    //    }
    //    set.updateCacheFile();
    //    op.staValue.divAlert(this.Page, "操作成功", Request.Url.AbsoluteUri);
    //}
    //protected void lbtnHidden_Click(object sender, EventArgs e)
    //{
    //    string id = Request.Form["chkId"];
    //    if (!string.IsNullOrEmpty(id))
    //    {
    //        menu.UpdateString("displayC=0", "where id in(" + id + ")");
    //    }
    //    set.updateCacheFile();
    //    op.staValue.divAlert(this.Page, "操作成功", Request.Url.AbsoluteUri);
    //}
}

