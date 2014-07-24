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
using System.Xml;
using org.jiuyu.express;
public partial class admin_user_post : System.Web.UI.Page
{
    //dal.expPay expPay = new dal.expPay();
    MySqlDal.expPayDB expPay = new MySqlDal.expPayDB();
   // dal.expPlace expPlace = new dal.expPlace();
    MySqlDal.expPlaceDB expPlace = new MySqlDal.expPlaceDB();

    //static List<mo.expPay> userfulExpress;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "快递管理";
        if (!IsPostBack)
        {
            bin();

        }
    }
    private void bin()
    {

        org.jiuyu.express.ExpService webservice = new org.jiuyu.express.ExpService();
        try
        {
            Express[] allExporess = webservice.GetExpressList("0");


            // userfulExpress.Select(<allExporess[0].expressName,Express>);
            //List<mo.expPay> modelList = expPay.getModelListWhere("where typ=0");
            Repeater1.DataSource = allExporess;
            Repeater1.DataBind();
        }
        catch (Exception)
        {

            return;
        }

    }
    private void repEditBin(string id)
    {
        List<mo.expPlace> modelList = expPlace.getModelListWhere("where typ="+id);
        //dal.place place = new dal.place();
        MySqlDal.PlaceDB place = new MySqlDal.PlaceDB();
        for (int i = 0; i < modelList.Count; i++)
        {
            modelList[i].nameC = place.getString("nameC", "where id=" + modelList[i].placeId);
        }
        repEdit.DataSource = modelList;
        repEdit.DataBind();
    }
     private void repPlaceBin()
        {
            //dal.place place = new dal.place();
            MySqlDal.PlaceDB place = new MySqlDal.PlaceDB();
            List<mo.place> modelList = place.getModelListAll();
            repPlace.DataSource = modelList;
            repPlace.DataBind();
        }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        string[] list = Request.Form.GetValues("chkId");
        if (list.Length > 0)
        {
            string[] id = new string[list.Length];
            string[] expid = new string[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                id[i] = list[i].Substring(0, list[i].IndexOf("_"));
                expid[i] = list[i].Substring(list[i].IndexOf("_")+1);
            }

            expPay.AddExpress(id, expid);
        }
        bin();
        //repPlaceBin();
        //PanelAdd.Visible = true;
        //PanelRep.Visible = false;
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "del")
        {
            try
            {
                expPay.DelId(id);
                expPlace.DelId("typ=" + id);
                op.staValue.divAlert(Page, "删除成功!");
                bin();
            }
            catch
            {
                op.staValue.divAlert(Page, "删除失败!");
            }
        }
        else
            if (e.CommandName == "edit")
            {
                ViewState["id"] = id;
                repEditBin(id);
                mo.expPay model = expPay.getModel("where id=" + id);
                txtNameEdit.Text = model.nameC;
                txtAddWeightEdit.Text = model.priceC.ToString();
                txtDescirptionEdit.Text = model.tipsC;
                PanelRep.Visible = false;
                panelEdit.Visible = true;
            }
        
    }
    protected void BtAddOk_Click(object sender, EventArgs e)
    {
        try
        {
            mo.expPay model = new mo.expPay();
            op.Operation ope = new op.Operation();
            model.id = ope.MaxId("expPay");
            model.nameC = txtName.Text;
            model.tipsC = txtDescription.Text;
            model.priceC = double.Parse(txtAddWeight.Text);
            string[] priceC = Request.Form.GetValues("priceC");
            string[] id = Request.Form.GetValues("id");
            for (int i = 0; i < id.Length; i++)
            {
                mo.expPlace modelPlace = new mo.expPlace();
                modelPlace.placeId = int.Parse(id[i]);
                modelPlace.priceC = double.Parse(priceC[i]);
                modelPlace.typ = model.id;
                expPlace.InsertModel(modelPlace);
            }
            if (fileAdd.HasFile)
            {
                model.imgC ="/uploadFile/flash/" + fileAdd.FileName;
                fileAdd.SaveAs(op.staValue.path +"uploadFile/flash/" + fileAdd.FileName);
            }
            expPay.InsertModel(model);
            op.staValue.divAlert(this.Page, "添加成功！");
            PanelAdd.Visible = false;
            PanelRep.Visible = true;
            bin();
        }
        catch
        {
            op.staValue.divAlert(this.Page, "请检查数据类型！");
        }
    }
   protected void BtRep_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = false;
        PanelRep.Visible = true;
    }
   protected void BtEditOk_Click(object sender, EventArgs e)
   {
       try
       {
           mo.expPay model = expPay.getModel("where id=" + ViewState["id"].ToString());
           model.nameC = txtNameEdit.Text;
           model.tipsC = txtDescirptionEdit.Text;
           model.priceC = double.Parse(txtAddWeightEdit.Text);
           expPlace.DelId("typ=" + model.id);
           string[] priceC = Request.Form.GetValues("priceC");
           string[] placeId = Request.Form.GetValues("placeId");
           for (int i = 0; i < placeId.Length; i++)
           {
               mo.expPlace modelPlace = new mo.expPlace();
               modelPlace.placeId = int.Parse(placeId[i]);
               modelPlace.priceC = double.Parse(priceC[i]);
               modelPlace.typ = model.id;
               expPlace.InsertModel(modelPlace);
           }
           if (fileEdit.HasFile)
           {
               model.imgC = "/uploadFile/flash/" + fileEdit.FileName;
               fileEdit.SaveAs(op.staValue.path + "uploadFile/flash/" + fileEdit.FileName);
           }
           expPay.UpdateModel(model);
           panelEdit.Visible = false;
           PanelRep.Visible = true;
           bin();
       }
       catch
       {
           op.staValue.divAlert(this.Page, "请检查数据类型！");
       }
   }


   public string getExporessState(object ExpName,object id)
   {
       List<mo.expPay> userfulExpress = expPay.getModelListWhere("where typ=0");
       if (ExpName == null || id == null || string.IsNullOrEmpty(ExpName.ToString()) || string.IsNullOrEmpty(id.ToString()))
           return "";
       for (int i = 0; i < userfulExpress.Count; i++)
       {
           if (ExpName.ToString() == userfulExpress[i].nameC)
           {
               return "<input id=\"chkId\" name=\"chkId\" checked='checked' type=\"checkbox\" value='" + id.ToString() + "_" + ExpName.ToString() + "'/>"; ;
           }

       }
       return "<input id=\"chkId\" name=\"chkId\" type=\"checkbox\" value='" + id.ToString() + "_" + ExpName.ToString() + "'/>";
      
   }
}
