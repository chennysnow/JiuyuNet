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
public partial class admin_news_type : System.Web.UI.Page
{
    //dal.menu menu = new dal.menu();
    dal.MenuDB menu = new dal.MenuDB();
    setWeb set = new setWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "新闻分类管理";
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
        dropType.Items.Add(new ListItem("一级分类", "2"));
        dropType_edit.Items.Add(new ListItem("一级分类", "2"));
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(2);
        foreach (mo.menu model in modelList)
        {
            ListItem li = new ListItem();
            li.Text = model.nameC;
            li.Value = model.id.ToString();
            dropType.Items.Add(li);
            dropType_edit.Items.Add(li);
        }
    }
    private void RepBin()//绑定一级菜单
    {
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(2);
        Repeater1.DataSource = modelList;
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
        if (ty == 2)//判断是添加几级分类
        {
            model.levelC = 1;
        }
        else
        {
            model.levelC = Convert.ToInt32(menu.getString("levelC", "where id=" + ty)) + 1;
        }
        op.Operation ope = new op.Operation();
        model.nameC = txtName.Text;
        model.typ = ty;
        model.id = ope.MaxId("menu");
        model.sortC = model.id;
       // model.htmlName = "taoci-news-" + model.id + "--1.html";
       // model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC) + ".html" : op.staValue.RexSpecial(txtHtmlName.Text) + ".html";
        model.titleC = txtTitle.Text == "" ? model.nameC : txtTitle.Text;
        model.keywordsC = txtKeywords.Text;
        model.descriptionC = txtDescription.Text;
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
            txtTitle_edit.Text = model.titleC;
            txtKeywords_edit.Text = model.keywordsC;
            txtDescription_edit.Text = model.descriptionC;
           // txtHtmlName_edit.Text = model.htmlName;
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
            if (ty == 2)
            {
                menulevel = 1;
            }
            else
                menulevel = Convert.ToInt32(menu.getString("levelC", "where id=" + ty)) + 1;
            model.levelC = menulevel;
            model.typ = ty;
            model.nameC = txtName_edit.Text;
            model.titleC = txtTitle_edit.Text == "" ? model.nameC : txtTitle_edit.Text;
            model.keywordsC = txtKeywords_edit.Text;
            model.descriptionC = txtDescription_edit.Text;
            //if (txtHtmlName_edit.Text.IndexOf(".html") > 0)
            //{
            //    model.htmlName = txtHtmlName_edit.Text;
            //}
            //else
            //{
            //    model.htmlName = op.staValue.RexSpecial(txtHtmlName_edit.Text) + ".html";
            //}
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
        for (int i = 0; i < id.Length; i++)
        {
            menu.UpdateString("sortC=" + sort[i] + "", "where id=" + id[i]);
        }
        op.staValue.divAlert(this.Page, "保存成功");
        set.updateCacheFile();
        RepBin();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("chkId"); ;
        for (int i = 0; i < id.Length; i++)
        {
            menu.DelId("where id=" + id[i] + " or typ=" + id[i] + "");
        }
        op.staValue.divAlert(this.Page, "删除成功");
        set.updateCacheFile();
        RepBin();
    }
    protected void lbtnBottomShow_Click(object sender, EventArgs e)
    {
        string strId = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(strId))
        {
            menu.UpdateString("displayC=2", "where id in(" + strId + ")");
        }
        op.staValue.divAlert(this.Page, "更新成功");
        set.updateCacheFile();
        RepBin();
    }
    protected void ltbnNormalShow_Click(object sender, EventArgs e)
    {
        string strId = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(strId))
        {
            menu.UpdateString("displayC=0", "where id in(" + strId + ")");
        }
        op.staValue.divAlert(this.Page, "更新成功");
        set.updateCacheFile();
        RepBin();
    }
    protected void lbtnTopShow_Click(object sender, EventArgs e)
    {
        string strId = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(strId))
        {
            menu.UpdateString("displayC=1", "where id in(" + strId + ")");
        }
        op.staValue.divAlert(this.Page, "更新成功");
        set.updateCacheFile();
        RepBin();
    }
}
