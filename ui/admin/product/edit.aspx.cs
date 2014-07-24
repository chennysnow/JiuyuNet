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
using System.IO;
using System.Drawing;
public partial class admin_product_edit : System.Web.UI.Page
{
    public mo.proInfo model = new mo.proInfo();
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "产品修改";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        if (Request.Params["id"] != null)
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            model = pro.getModel("where id=" + Request.Params["id"].ToString());
            txtName.Text = model.nameC;
            txtProId.Text = model.proId;
            // txtPrice.Text = model.priceC.ToString();
            // txtMarketPrice.Text = model.marketPrice;
            // txtSize.Text = model.sizeC.ToString();
            txtWeight.Text = model.weightC.ToString();
            txtStock.Text = model.stockC;
            txtContent.Text = model.contentC;
            txtTitle.Text = model.titleC;
            txtKeywords.Text = model.keywordsC;
            txtDescription.Text = model.descriptionC;
            txtHtmlName.Text = model.htmlName;
            txtMoq.Text = model.moqC;
            txtChi.Text = model.characteristic;
            slstar.Value = model.star.ToString();
            supplys(model.supplyid);
            ViewState["id"] = model.id;
            ViewState["page"] = Request.QueryString["page"];
            attrBin(model.attrId.Split(','), model.attrValue.Split('@'));
            dislpayBin(model.displayC);
            priceBin(model.id.ToString());
            typBin();
            //  dropBrand.SelectedValue = model.brandC.ToString();
        }
        else
        {
            op.staValue.divAlert(this.Page, "加载失败", Request.RawUrl);
        }
    }
    private void typBin()
    {
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(1);
        foreach (mo.menu model in modelList)
        {
            ListItem li = new ListItem();
            li.Text = model.nameC;
            li.Value = model.id.ToString() + "|" + model.preId;
            ddlNewsType.Items.Add(li);
        }
    }
    
    private void priceBin(string typ)
    {
        //dal.price pri = new dal.price();
        MySqlDal.PriceDB pri = new MySqlDal.PriceDB();
        List<mo.price> modelList = pri.getModelListWhere("where typ=" + typ);
        //if (modelList.Count <= 0)
        //{
        //    litpriceqj.Text = "<div id='price0' > <input type=\"hidden\" name='priCount' id='priCount' value='1' />1:<input type='text' name='txtMin0' id='txtMin0' onkeyup=\"value=value.replace(/[^\\d]/g,'')\" readonly='readonly' value='1'/>--<input type='text' name='txtMax0' id='txtMax0' onkeyup=\"value=value.replace(/[^\\d]/g,'')\" />价格:<input type='text' name='txtPrice0' id='txtPrice0' />交货:<input type='text' name='txtDay0' id='txtDay0' value='3 Days' /></div>";
        //}

        repPrice.DataSource = modelList;
        repPrice.DataBind();
    }
    private void attrBin(string[] attrId, string[] attrValue)
    {
        //dal.attr attr = new dal.attr();
        MySqlDal.attrDB attr = new MySqlDal.attrDB();
        List<mo.attr> modelList = attr.getModelListAll();
        for (int i = 0; i < modelList.Count; i++)
        {
            for (int j = 0; j < attrId.Length; j++)//找有没有此ID
            {
                if (modelList[i].id.ToString() == attrId[j])
                {
                    modelList[i].typ = "1";
                    modelList[i].valueC = attrValue[j].Replace("|" + modelList[i].id + "|", "");
                    break;
                }
            }
        }
        repAttr.DataSource = modelList;
        repAttr.DataBind();
    }
    
    public void dislpayBin(string displayC)
    {
        op.staValue sta = new op.staValue();
        for (int i = 0; i < sta.display.Length; i++)
        {
            checkDis.Items.Add(new ListItem(sta.display[i], (i + 1).ToString()));
            checkDis.Items[i].Selected = displayC.IndexOf("," + (i + 1) + ",") >= 0 ? true : false;
        }
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        string strImg = (Request.Form["moreImg"].Trim(',')+","+Request.Form["sonImg"]).Trim(',');
        if (!string.IsNullOrEmpty(Request.Form["fileImg"]))
        {
            strImg = Request.Form["fileImg"].ToString() + "," + strImg;
            EditInfo(Request.Form["fileImg"].ToString(), strImg);
        }
        else
            EditInfo("",strImg);
    }
    protected void BtClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }
    private void EditInfo(string img,string moreImg)//向数据库添加信息
    {
        try
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            mo.proInfo model = pro.getModel("where id=" + ViewState["id"].ToString());
            if (img != "")
                model.imgC = img;
            model.nameC = txtName.Text;
            model.moreImg = moreImg;
            model.proId = txtProId.Text;
            model.weightC = double.Parse(txtWeight.Text);
            model.stockC = txtStock.Text;
            model.moqC = txtMoq.Text;
            model.titleC = txtTitle.Text;
            model.keywordsC = txtKeywords.Text;
            model.star =  Convert.ToInt32(slstar.Value);
            model.characteristic = txtChi.Text;
            model.descriptionC = txtDescription.Text;
            op.Operation ope = new op.Operation();
            model.attrValue = ope.strOrder(Request.Form["attrValue"]);
            model.supplyid = Request.Form["supply"] + ",";


            model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC) : op.staValue.RexSpecial(txtHtmlName.Text);
           
            ////////////////显示方式////////////////////////////////
            string disp = ",";
            for (int i = 0; i < checkDis.Items.Count; i++)
            {
                if (checkDis.Items[i].Selected)
                    disp += checkDis.Items[i].Value + ",";
            }
            ////////////////属性列表////////////////////////////////
            string[] attr = Request.Form.GetValues("attr");
            if (attr != null && attr.Length > 0)
            {
                string strAttrId = "", strAttrValue = "";
                for (int i = 0; i < attr.Length; i++)
                {
                    strAttrId += attr[i] + ",";
                    strAttrValue += Request.Form["attrValue" + attr[i]] + "@";
                }
                model.attrId = strAttrId.TrimEnd(',');
                model.attrValue = strAttrValue.Substring(0, strAttrValue.LastIndexOf('@'));
            }
            else
            {
                model.attrValue = "";
                model.attrId = "";
            }
            model.contentC = txtContent.Text;
            model.displayC = disp;
            //附加类别
            string[] typ = ddlNewsType.SelectedValue.Split('|');
            model.typ = Convert.ToInt32(typ[0]);
            model.addType = "," + typ[1] + "," + Request.Form["addType"] + ",";
            model.strPrice = getPrice(model.id);
            pro.UpdateModel(model);
            op.staValue.divAlert(this.Page, "产品修改成功!", "list.aspx?p=" + ViewState["page"].ToString());
        }
        catch
        {
            op.staValue.divAlert(this.Page, "产品修改失败");
        }
    }
    private string getPrice(int id)
    {
        //dal.price price = new dal.price();
        MySqlDal.PriceDB price = new MySqlDal.PriceDB();
        mo.price model = new mo.price();
        try
        {
            string prePrice = "";
            int num = int.Parse(Request.Form["priCount"].ToString());
            string[] priId = Request.Form.GetValues("priId");
            for (int i = 0; i < priId.Length; i++)
            {
                model.id = int.Parse(priId[i]);
                model.minC = int.Parse(Request.Form["txtMin" + i + ""].ToString());
                model.maxC = int.Parse(Request.Form["txtMax" + i + ""].ToString());

                if (i > 0)
                {
                    if (model.minC < int.Parse(Request.Form["txtMax" + (i - 1) + ""].ToString()) || model.maxC < model.minC)
                    {
                        op.staValue.divAlert(this.Page, "价格区间错误！");
                        return null;
                    }
 
                }


                model.priceC = double.Parse(Request.Form["txtPrice" + i + ""].ToString());
                model.dayC = Request.Form["txtDay" + i + ""].ToString();
                model.typ = id;
                price.UpdateModel(model);
            }
            if (num > priId.Length)//插入新字段
            {
                for (int i = priId.Length; i < num; i++)
                {
                    model.minC = int.Parse(Request.Form["txtMin" + i + ""].ToString());
                    model.maxC = int.Parse(Request.Form["txtMax" + i + ""].ToString());
                    model.priceC = double.Parse(Request.Form["txtPrice" + i + ""].ToString());
                    model.dayC = Request.Form["txtDay" + i + ""].ToString();
                    model.typ = id;
                    price.InsertModel(model);
                }
            }
            prePrice = model.priceC + "-" + Request.Form["txtPrice0"].ToString();
            return prePrice;
        }
        catch
        {
            op.staValue.divAlert(this.Page, "价格区间错误！");
            return null;
        }
    }
    protected void repPrice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
     
        if (e.CommandName == "del")//
        {

            string[] priId = Request.Form.GetValues("priId");
            if (priId.Length == 1)
            {
                //op.staValue.divAlert(this.Page, "必须保留一个价格区间！");

                ScriptManager.RegisterStartupScript(updatePanle,Page.GetType(), "message", "<script language='javascript'>alertC.show('必须保留一个价格区间');</script>", false);
                return;
            }

            //dal.price pri = new dal.price();
            MySqlDal.PriceDB pri = new MySqlDal.PriceDB();
            pri.DelId(int.Parse(e.CommandArgument.ToString()));
            priceBin(ViewState["id"].ToString());
            i--;
        }
    }

    private void supplys(string supps)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();



        //dal.supply att = new dal.supply();
        MySqlDal.SupplyDB att = new MySqlDal.SupplyDB();
        List<mo.supply> modelList = att.getModelListAll();


        string[] supp = supps.Split(',');
        for (int i = 0; i < modelList.Count; i++)
        {
            string num = "0";
            for (int j = 0; j < supp.Length; j++)
            {

                if (supp[j] == modelList[i].id.ToString())
                {
                    sb.AppendFormat("<input type='checkbox' name='supply' value='{0}'   checked='checked' /> {1}", modelList[i].id, modelList[i].sname);
                    num = "1";
                    break;
                }
                //else
                //{

                //}
            }
            if (num != "1")
            {

                sb.AppendFormat("<input type='checkbox' name='supply' value='{0}'  />{1} ", modelList[i].id, modelList[i].sname);

            }

        }

        Lisupply.Text = sb.ToString();
    }
}
