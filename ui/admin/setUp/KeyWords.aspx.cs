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
public partial class admin_KeyWords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "优化关键词设置";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        //dal.keywords keyWords = new dal.keywords();
        dal.KeywordsDB keyWords = new dal.KeywordsDB();
        List<mo.keywords> modelList = keyWords.getModelListAll();
        repList.DataSource = modelList;
        repList.DataBind();
    }

   
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //dal.keywords keyWords = new dal.keywords();
        dal.KeywordsDB keyWords = new dal.KeywordsDB();
        string[] id = Request.Form.GetValues("id");
        string[] key = Request.Form.GetValues("keywordsC");
        string[] des = Request.Form.GetValues("descriptionC");
        string[] title = Request.Form.GetValues("titleC");
        string[] typS = Request.Form.GetValues("typS");
        string[] tipsC = Request.Form.GetValues("tipsC");
        for (int i = 0; i < id.Length; i++)
        {
            mo.keywords model = new mo.keywords();
            model.id = int.Parse(id[i]);
            model.keywordsC = key[i];
            model.descriptionC = des[i];
            model.titleC = title[i];
            model.typS = typS[i];
            model.tipsC = tipsC[i];
            keyWords.UpdateModel(model);
        }
        bin();
        op.staValue.divAlert(this.Page, "保存成功!");
    }
}
