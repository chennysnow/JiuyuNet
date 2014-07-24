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
using System.IO;
using System.Drawing;
using System.Collections.Generic;
public partial class admin_product_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "添加商品";
        if (!IsPostBack)
        {
            ddlNewsType.Items.Add(new ListItem("请选择类别", "0"));
            dislpayBin();
            attrBin();
          //  brandBin();
            typBin();
            supplyBin();
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
    private void attrBin()
    {
        //dal.attr attr = new dal.attr();
        dal.attrDB attr = new dal.attrDB();
        List<mo.attr> modelList = attr.getModelListAll();
        repAttr.DataSource = modelList;
        repAttr.DataBind();
    }
    private void dislpayBin()
    {
        op.staValue sta = new op.staValue();
        for (int i = 0; i < sta.display.Length; i++)
        {
            checkDis.Items.Add(new ListItem(sta.display[i], (i + 1).ToString()));
        }
    }
    protected void BtClear_Click(object sender, EventArgs e)
    {
        // fckIntro.Value = "";
        // TbTitle.Text = "";
        //// fckIntro_en.Value = "";
        // TbTitle_en.Text = "";
        // TbProId.Text = "";
        // TbQty.Text = "";
    }
    protected void BtOk_Click(object sender, EventArgs e)
    {
        string strImg = Request.Form["sonImg"];
        if (!string.IsNullOrEmpty(Request.Form["fileImg"]))
        {
            mo.img model = new mo.img();
            //把自己写进img表
            strImg = Request.Form["fileImg"].ToString() +","+strImg;
            addInfo("/uploadFile", Request.Form["fileImg"].ToString(),strImg);
        }
        else
        {
            op.staValue.divAlert(this.Page, "主图片必须上传");
        }
    }
    private void addInfo(string fileName, string ProName,string strImg)
    {
        //////////////////////////////////向数据库添加信息
        try
        {
            //dal.products pro = new dal.products();
            dal.ProductsDB pro = new dal.ProductsDB();
            mo.proInfo model = new mo.proInfo();
            op.Operation ope = new op.Operation();
            model.id = ope.MaxId("products");
            model.nameC = txtName.Text;
            model.proId = txtProId.Text;
          //  model.priceC = txtPrice.Text;
            //model.sizeC = double.Parse(txtSize.Text);
            model.weightC = double.Parse(txtWeight.Text);
            model.stockC = txtStock.Text;
            if (model.stockC == "")
            { model.stockC = "0"; }
            else
            {
                int count = 0;
                if (!int.TryParse(model.stockC, out count))
                {
                    op.staValue.divAlert(this.Page, "产品库存格式错误为数字形式!");
                    return;
                }
            }
            model.moqC = txtMoq.Text;
            model.sortC = model.id;
            model.imgC = ProName;
            model.fileName = fileName;
            model.moreImg = strImg;
            model.contentC = txtContent.Text;
            model.star =Convert.ToInt32(slstar.Value);
            model.characteristic = txtChi.Text;
            model.titleC = txtTitle.Text;
            model.keywordsC = txtKeywords.Text;
            model.descriptionC = txtDescription.Text;
            model.htmlName = txtHtmlName.Text == "" ? op.staValue.RexSpecial(model.nameC) : op.staValue.RexSpecial(txtHtmlName.Text) ;
            string disp = ",";
            for (int i = 0; i < checkDis.Items.Count; i++)
            {
                if (checkDis.Items[i].Selected)
                    disp += checkDis.Items[i].Value + ",";
            }
            //自定义属性
            string[] attr = Request.Form.GetValues("attr");
            if (attr != null && attr.Length > 0)
            {
                string[] attrValue = Request.Form.GetValues("attrValue");
                string strAttrId = "", strAttrValue = "";
                for (int i = 0; i < attr.Length; i++)
                {
                    strAttrId += attr[i] + ",";
                    strAttrValue += "|" + attr[i] + "|" + attrValue[i] + "@";//值加上了头部标识
                }
                model.attrId = strAttrId.TrimEnd(',');
                model.attrValue = strAttrValue.Substring(0, strAttrValue.LastIndexOf('@'));
            }
            model.displayC = disp;
            //附加类别
            string[] typ = ddlNewsType.SelectedValue.Split('|');
            model.typ = Convert.ToInt32(typ[0]);
            model.addType = ","+typ[1]+","+Request.Form["addType"]+",";
            model.supplyid = Request.Form["supply"] + ",";
            model.strPrice = getPrice(model.id);
            pro.InsertModel(model);
            op.staValue.divAlert(this.Page, "产品添加成功!");
        }
        catch
        {
            op.staValue.divAlert(this.Page, "产品添加失败");
        }
    }

    private void supplyBin()
    {
        //dal.supply att = new dal.supply();
        dal.SupplyDB att = new dal.SupplyDB();
        List<mo.supply> modelList = att.getModelListAll();
        //foreach (mo.supply model in modelList)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = model.sname;
        //    li.Value = model.id.ToString();
        //    ddlNewsType.Items.Add(li);
        //}
        supply.DataSource = modelList;
        supply.DataBind();
    }
    private string getPrice(int id)
    {
        //dal.price price = new dal.price();
        dal.PriceDB price = new dal.PriceDB();
        mo.price model = new mo.price();
        try
        {
            string prePrice = "";
            int num = int.Parse(Request.Form["priCount"].ToString());
            for (int i = 0; i < num; i++)
            {
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
                price.InsertModel(model);
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }
}
