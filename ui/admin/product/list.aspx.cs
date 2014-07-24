using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;
using org.in2bits.MyXls;
public partial class admin_product_list : System.Web.UI.Page
{
    //dal.products pro = new dal.products();
    dal.ProductsDB pro = new dal.ProductsDB();
    //public dal.menu menu = new dal.menu();
    public dal.MenuDB menu = new dal.MenuDB();
    public int index = 0, page = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "商品列表";
        if (!IsPostBack)
        {
            bin();
            displayBin();
            menuBin();
        }
        litRepInfo.Text = "";
    }
    /// <summary>
    /// 显示方式
    /// </summary>
    private void displayBin()
    {
        dropDisplay.Items.Add(new ListItem("::请选择::", "0"));
        dropDisplay.Items.Add(new ListItem("全部", "0"));
        dropDisplay.Items.Add(new ListItem("上架", "show1"));
        dropDisplay.Items.Add(new ListItem("下架", "show0"));
        op.staValue sta = new op.staValue();
        for (int i = 0; i < sta.display.Length; i++)
        {
            dropDisplay.Items.Add(new ListItem(sta.display[i], (i + 1).ToString()));
        }
        if (Request.QueryString["display"] != null)
            dropDisplay.SelectedValue = Request.QueryString["display"];
    }
    /// <summary>
    /// 类别
    /// </summary>
    private void menuBin()
    {
        dropTyp.Items.Add(new ListItem("::全部::", "0"));
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(1);
        for (int i = 0; i < modelList.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = modelList[i].nameC;
            li.Value = modelList[i].id.ToString();
            dropTyp.Items.Add(li);
        }
        if (Request.QueryString["typ"] != null)
            dropTyp.SelectedValue = Request.QueryString["typ"];
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "tg")
        {
            this.litSMail.Text = "&nbsp;|&nbsp;<a href='javascript:sendMail()'>推广被选产品</a>";
        }
    }
    private void bin()
    {
        op.staValue staValue = new op.staValue();
        string where = "where id>0 ";
        if (Request.QueryString["typ"] != null)//类别
        {
            where += " and addType like '%," + Request.QueryString["typ"]+ ",%'";
        }
        if (Request.QueryString["show"] != null)
        {
            where += " and showC="+Request.QueryString["show"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["seaKey"]))//搜索词
        {
            where += " and (nameC like '%" + Request.QueryString["seaKey"] + "%' or proId like  '%" + Request.QueryString["seaKey"] + "%')";
        }
        if (Request.QueryString["display"] != null)//显示方式
        {
            where += " and displayC like'%," + Request.QueryString["display"] + ",%'";
        }
        //strSql = "where displayC like '%," + dropDisplayBin.SelectedValue + ",%'"; break;
        List<mo.products> modelList = pro.getAll_admin(where);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        int index = op.staValue.RequestInt(Request.QueryString["p"]);
        pds.CurrentPageIndex = (index > 0 ? index : 1) - 1;
        pds.DataSource = modelList;
        AspNetPager1.RecordCount = modelList.Count;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }
    protected void lbtnBatchDelete_Click(object sender, EventArgs e)//批量删除
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("chkId");
        if (id != null && id.Length > 0)
        {
            for (int i = 0; i < id.Length; i++)
            {
                imgDel(id[i]);
                pro.DelId(id[i]);

                new dal.PriceDB().DelByproductId(int.Parse(id[i]));
            }
            op.staValue.divAlert(this.Page, "删除成功");
            bin();
        }
    }
    private void DorBin(DropDownList dro)//
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
        List<mo.menu> modelList = menu.getModelListWhere("where typ=1");
        for (int i = 0; i < modelList.Count; i++)
        {
            ListItem li = new ListItem();
            li.Value = modelList[i].id.ToString();
            li.Text = modelList[i].nameC;
            dro.Items.Add(li);
            DorSon(modelList[i].id, dro);
        }
    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="id"></param>
    private void DorSon(int id, DropDownList dro)
    {
        //dal.menu menu = new dal.menu();
        dal.MenuDB menu = new dal.MenuDB();
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
    public string getDisplay(string display, string id)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        op.staValue sta = new op.staValue();
        for (int i = 0; i < sta.display.Length; i++)
        {
            sb.AppendFormat("<input name='checkDis{0}' type='checkbox' value='{1}' />{2}@", id, i + 1, sta.display[i]);
        }
        string[] arr1 = sb.ToString().TrimEnd('@').Split('@');//用一个bool标志 判断有没有选中 
        if (display != "")
        {
            string[] arr = display.Substring(1).TrimEnd(',').Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "")
                {
                    try
                    {
                        int j = int.Parse(arr[i]) - 1;
                        arr1[j] = arr1[j].Replace("/>", "checked='checked' />");
                    }
                    catch { }
                }
            }
        }
        sb.Length = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            sb.Append(arr1[i]);
        }
        //sb.AppendFormat("<input type='hidden' name='id{0}' value='{1}' />",index,id);
        return sb.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        op.Operation ope = new op.Operation();
        string[] id = Request.Form.GetValues("id");
        string[] sort = Request.Form.GetValues("sort");
        for (int i = 0; i < id.Length; i++)
        {
            pro.UpdateString("sortC=" + sort[i] + ",displayC='," + Request.Form["checkDis" + id[i]] + ",'", "where id=" + id[i]);
        }
        op.staValue.divAlert(this.Page, "保存成功");
        bin();
    }
    protected void btnReportOut_Click(object sender, EventArgs e)
    {
        CreateExcel();
    }
    protected void btnRepInput_Click(object sender, EventArgs e)
    {
        if (!fileUp.HasFile)
        {
            op.staValue.divAlert(this.Page, "请选择文件");
            return;
        }
        if (fileUp.FileName.Substring(fileUp.FileName.LastIndexOf('.')) != ".zip")
        {
            op.staValue.divAlert(this.Page, "导入文件格式必须是.zip");
            return;
        }
        string zipName = Server.MapPath("/")+"uploadFile\\Report\\Load\\"+DateTime.Now.ToString("yyyyMMdd")+".zip";
        fileUp.SaveAs(zipName);

        ExcelToSql(zipName);
    }
    
    private void imgDel(string id)
    {
        //dal.img img = new dal.img();
        dal.imgDB img = new dal.imgDB();
        string proMapPath = Server.MapPath("~/"), path = "";
        // mo.proInfo modelPro = pro.getModel("where id=" + id);
        List<mo.img> modelList = img.getModelListWhere("where typ=" + id);
        path = proMapPath + "uploadFile";
        if (modelList.Count > 0)
        {
            for (int i = 0; i < modelList.Count; i++)
            {
                if (File.Exists(path + modelList[i].imgC))//水印图
                {
                    File.Delete(path + modelList[i].imgC);
                }
                if (File.Exists(path + "sImg/y/" + modelList[i].imgC))//原图
                {
                    File.Delete(path + "sImg/y/" + modelList[i].imgC);
                }
                if (File.Exists(path + "sImg/" + modelList[i].imgC))//缩略图
                {
                    File.Delete(path + "sImg/" + modelList[i].imgC);
                }
            }
        }
    }
    protected void lbtnRun_Click(object sender, EventArgs e)
    {
        string id = Request.Form["chkId"];
        if (!string.IsNullOrEmpty(id))
        {
            switch (dropRunTyp.SelectedValue)
            {
                case "0": op.staValue.divAlert(Page, "请选择要执行的操作!"); break;
                case "1": pro.UpdateString("showC=1", "where id in(" + id + ")"); break;
                case "2": pro.UpdateString("showC=0", "where id in(" + id + ")"); break;
                case "3": pro.UpdateString("qx=0", "where id in(" + id + ")"); break;
                case "4": pro.UpdateString("qx=1", "where id in(" + id + ")"); break;
                default: break;
            }
        }
        else
        {
            op.staValue.divAlert(Page, "请选择修改的产品!");
        }
        bin();
    }




    /// <summary>
    /// 绝对地址 包括路径和名称
    /// </summary>
    /// <param name="imgPath"></param>
    private string upImg(string imgPath)
    {
        //   图片有三处:分别是uploadFile-水印图,sImg-缩略图,sImg/y-原图
        op.UploadFile file = new op.UploadFile();
        string path = op.staValue.path + "uploadFile/";
        string imgName = imgPath.Substring(imgPath.LastIndexOf("/") + 1);
        string dir = "/" + imgName;
        if (File.Exists(path + "sImg/y/" + imgName))
        {
            op.Operation ope = new op.Operation();
            string sEx = System.IO.Path.GetExtension(imgName);
            dir = "/" + ope.NameRndOnly() + sEx;
        }
        File.Copy(imgPath, path + "sImg/y" + dir);
        if (Request.Form["check"] != null)
        {
            file.makeShui(path + "/sImg/y", dir);//原图在sImg/y里,水印图片则在自己目录下
        }
        else
        {
            File.Copy(path + "sImg/y" + dir, path + dir);//移动不打水印的图片
        }
        file.MakeThumbnail(path + dir, path + "/sImg" + dir);
        return dir;

    }

    private void CreateExcel()
    {
        dal.ProductsDB pro = new dal.ProductsDB();
        List<mo.proInfo> modelList = pro.getModelListAll_info();

        string pathTo = Server.MapPath("/") + "uploadFile/Report/Up/" + DateTime.Now.ToString("yyyyMMdd") + "/";
        string pathZipTo = Server.MapPath("/") + "uploadFile/Report/Up/" + DateTime.Now.ToString("yyyyMMdd") + ".zip";
        string filePath = pathTo + "Product_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
        XlsDocument xls = new XlsDocument();//创建空xls文档
        xls.FileName = filePath;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        org.in2bits.MyXls.XF xf = xls.NewXF();//设置字体格式
        xf.Font.Bold = true;//粗体
        Worksheet sheet = xls.Workbook.Worksheets.Add("Products");
        Cells cells = sheet.Cells;
        xf.VerticalAlignment = VerticalAlignments.Centered;
        cells.Add(1, 1, "imgC", xf);
        cells.Add(1, 2, "Id", xf);
        cells.Add(1, 3, "proId", xf);
        cells.Add(1, 4, "nameC", xf);
        cells.Add(1, 5, "priceC", xf);
        cells.Add(1, 6, "weightC", xf);
        cells.Add(1, 7, "strPrice", xf);
        cells.Add(1, 8, "typ", xf);
        cells.Add(1, 9, "displayC", xf);
        cells.Add(1, 10, "fileName", xf);
        cells.Add(1, 11, "htmlName", xf);
        cells.Add(1, 12, "qx", xf);
        cells.Add(1, 13, "aboutC", xf);
        cells.Add(1, 14, "showC", xf);
        cells.Add(1, 15, "sellCount", xf);
        cells.Add(1, 16, "brandC", xf);
        cells.Add(1, 17, "addType", xf);
        cells.Add(1, 18, "star", xf);
        cells.Add(1, 19, "Characteristic", xf);
        cells.Add(1, 20, "contentC", xf);
        cells.Add(1, 21, "descriptionC", xf);
        cells.Add(1, 22, "keywordsC", xf);
        cells.Add(1, 23, "moqC", xf);
        cells.Add(1, 24, "attrId", xf);
        cells.Add(1, 25, "attrValue", xf);
        cells.Add(1, 26, "addTypeName", xf);
        cells.Add(1, 27, "moreImg", xf);
        cells.Add(1, 28, "supplyid", xf);

        for (int i = 0; i < modelList.Count; i++)
        {
            cells.Add(2 + i, 1, modelList[i].imgC);
            cells.Add(2 + i, 2, modelList[i].id);
            cells.Add(2 + i, 3, modelList[i].proId);
            cells.Add(2 + i, 4, modelList[i].nameC + " ");
            cells.Add(2 + i, 5, modelList[i].priceC);
            cells.Add(2 + i, 6, modelList[i].weightC);
            cells.Add(2 + i, 7, modelList[i].strPrice + " ");
            cells.Add(2 + i, 8, modelList[i].priceC);
            cells.Add(2 + i, 9, modelList[i].displayC + " ");
            cells.Add(2 + i, 10, modelList[i].fileName + " ");
            cells.Add(2 + i, 11, modelList[i].htmlName + " ");
            cells.Add(2 + i, 12, modelList[i].qx);
            cells.Add(2 + i, 13, modelList[i].aboutC + " ");
            cells.Add(2 + i, 14, modelList[i].showC + " ");
            cells.Add(2 + i, 15, modelList[i].sellCount + " ");
            cells.Add(2 + i, 16, modelList[i].brandC + " ");
            cells.Add(2 + i, 17, modelList[i].addType + " ");
            cells.Add(2 + i, 18, modelList[i].star);
            cells.Add(2 + i, 19, modelList[i].characteristic + " ");
            cells.Add(2 + i, 20, modelList[i].contentC + " ");
            cells.Add(2 + i, 21, modelList[i].descriptionC + " ");
            cells.Add(2 + i, 22, modelList[i].keywordsC + " ");
            cells.Add(2 + i, 23, modelList[i].moqC + " ");
            cells.Add(2 + i, 24, modelList[i].attrId + " ");
            cells.Add(2 + i, 25, modelList[i].attrValue + " ");
            cells.Add(2 + i, 26, modelList[i].addTypeName + " ");
            cells.Add(2 + i, 27, modelList[i].moreImg + " ");
            cells.Add(2 + i, 28, modelList[i].supplyid + " ");

            string filename = Server.MapPath("/") + modelList[i].fileName + modelList[i].imgC;
            if (File.Exists(filename))
            {
                if (!Directory.Exists(pathTo + "img/"))
                {
                    Directory.CreateDirectory(pathTo + "img/");
                }
                if (!File.Exists(pathTo + "img/" + modelList[i].imgC.Replace('/', '_')))
                {
                    File.Copy(filename, pathTo + "img/" + modelList[i].imgC.Replace('/', '_'));
                }
            }


        }
        xls.Save();
        xls = null;
        op.ClassZip.Zip(pathTo.TrimEnd('/'), pathZipTo, 1);
        litRepInfo.Text ="<a href='/uploadFile/Report/Up/" + DateTime.Now.ToString("yyyyMMdd") + ".zip'>下载<a>";


    }


    private void ExcelToSql(string zipName)
    {

        string zipPath = zipName.Substring(0, zipName.LastIndexOf('.'));
        //解压缩
        if (!op.SharpZip.UnpackFiles(zipName, zipPath.Substring(0, zipPath.LastIndexOf('\\') + 1)))
        {
            //解压缩失败
            return;
        }

        string[] strFile = Directory.GetFiles(zipPath, "*.xls");
        if (strFile.Length <= 0)
        {
            return;
        }
        string exclePath = strFile[0];
        XlsDocument xls = new XlsDocument(exclePath);//加载外部Excel

        //获得Excel中的指定一个工作页
        Worksheet sheet = xls.Workbook.Worksheets[0];
        //读取数据 循环每sheet工作页的每一行,不读取前两行
        for (int i = 2; i < sheet.Rows.Count; i++)
        {
            Row row = sheet.Rows[ushort.Parse(i.ToString())];
            if (row.CellCount < 27)  //列数不符
                continue;

            bool isNew = false;
            mo.proInfo mo = new mo.proInfo();
            mo.imgC = row.GetCell(1).Value.ToString();
            if (!string.IsNullOrEmpty(row.GetCell(2).Value.ToString()))
            {
                mo.id = int.Parse(row.GetCell(2).Value.ToString());
                isNew = true;
            }
            mo.proId = row.GetCell(3).Value.ToString().Trim();
            mo.nameC = row.GetCell(4).Value.ToString().Trim();
            mo.priceC = double.Parse(row.GetCell(5).Value.ToString());
            mo.weightC = double.Parse(row.GetCell(6).Value.ToString());
            mo.strPrice = row.GetCell(7).Value.ToString().Trim();
            mo.typ = int.Parse(row.GetCell(8).Value.ToString());
            mo.displayC = row.GetCell(9).Value.ToString().Trim();
            mo.fileName = row.GetCell(10).Value.ToString().Trim();
            mo.htmlName = row.GetCell(11).Value.ToString().Trim();
            mo.qx = int.Parse(row.GetCell(12).Value.ToString());
            mo.aboutC = row.GetCell(13).Value.ToString().Trim();
            mo.showC = int.Parse(row.GetCell(14).Value.ToString());
            mo.sellCount = int.Parse(row.GetCell(15).Value.ToString());
            mo.brandC = int.Parse(row.GetCell(16).Value.ToString());
            mo.addType = row.GetCell(17).Value.ToString().Trim();
            mo.star = int.Parse(row.GetCell(18).Value.ToString());
            mo.characteristic = row.GetCell(19).Value.ToString().Trim();
            mo.contentC = row.GetCell(20).Value.ToString().Trim();
            mo.descriptionC = row.GetCell(21).Value.ToString().Trim();
            mo.keywordsC = row.GetCell(22).Value.ToString().Trim();
            mo.moqC = row.GetCell(23).Value.ToString().Trim();
            mo.attrId = row.GetCell(24).Value.ToString().Trim();
            mo.attrValue = row.GetCell(25).Value.ToString().Trim();
            mo.addTypeName = row.GetCell(26).Value.ToString().Trim();
            mo.moreImg = row.GetCell(27).Value.ToString().Trim();
            mo.supplyid = row.GetCell(28).Value.ToString().Trim();
            if (isNew)
            {
                //上传文件
                mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));
                mo.id = new op.Operation().MaxId("products");
                new dal.ProductsDB().InsertModel(mo);
            }
            else
            {

                mo.proInfo oldmo = new dal.ProductsDB().getModel("where id = " + mo.id);
                if (oldmo.id <= 0)
                {
                    //上传文件
                    mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));
                    mo.id = new op.Operation().MaxId("products");
                    new dal.ProductsDB().InsertModel(mo);
                    return;
                }
                else
                {
                    if (oldmo.imgC.Replace('/', '_') != mo.imgC)
                    {
                        mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));
                    }
                    new dal.ProductsDB().UpdateModel(mo);
                }


            }



        }



    }
}
