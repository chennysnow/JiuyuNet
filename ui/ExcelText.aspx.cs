using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using org.in2bits.MyXls;

public partial class ExcelText : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  excel();
        ExcelToSql();
         //SharpZipTest();
        //    CreateExcel();
        
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
            cells.Add(2 + i, 13, modelList[i].aboutC+" ");
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



    }


    private void ExcelToSql()
    {
        string zipName = @"E:\JiuyunNet_B2CSEO_V1.0\ui\uploadFile\Report\Load\20120811.zip";
        string zipPath = zipName.Substring(0, zipName.LastIndexOf('.'));
        //解压缩
        if (!op.SharpZip.UnpackFiles(zipName, zipPath.Substring(0,zipPath.LastIndexOf('\\')+1)))
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
            mo.proId = row.GetCell(3).Value.ToString();
            mo.nameC = row.GetCell(4).Value.ToString();
            mo.priceC = double.Parse(row.GetCell(5).Value.ToString());
            mo.weightC = double.Parse(row.GetCell(6).Value.ToString());
            mo.strPrice =row.GetCell(7).Value.ToString();
            mo.typ = int.Parse(row.GetCell(8).Value.ToString());
            mo.displayC =row.GetCell(9).Value.ToString();
            mo.fileName = row.GetCell(10).Value.ToString();
            mo.htmlName = row.GetCell(11).Value.ToString();
            mo.qx = int.Parse(row.GetCell(12).Value.ToString());
            mo.aboutC = row.GetCell(13).Value.ToString();
            mo.showC = int.Parse(row.GetCell(14).Value.ToString());
            mo.sellCount = int.Parse(row.GetCell(15).Value.ToString());
            mo.brandC = int.Parse(row.GetCell(16).Value.ToString());
            mo.addType =row.GetCell(17).Value.ToString();
            mo.star = int.Parse(row.GetCell(18).Value.ToString());
            mo.characteristic= row.GetCell(19).Value.ToString();
            mo.contentC = row.GetCell(20).Value.ToString();
            mo.descriptionC = row.GetCell(21).Value.ToString();
            mo.keywordsC = row.GetCell(22).Value.ToString();
            mo.moqC = row.GetCell(23).Value.ToString();
            mo.attrId = row.GetCell(24).Value.ToString();
            mo.attrValue =row.GetCell(25).Value.ToString();
            mo.addTypeName =row.GetCell(26).Value.ToString();
            mo.moreImg =row.GetCell(27).Value.ToString();
            mo.supplyid = row.GetCell(28).Value.ToString();
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

    //    string exclePath = strFile[0];
    //    int StartRow = 2;    //读的起始行

    //private void ExcelToSql()
    //{
    //    string zipName = @"E:\JiuyunNet_B2CSEO_V1.0\ui\uploadFile\Report\Load\20120811.zip";
    //    string zipPath = zipName.Substring(0, zipName.LastIndexOf('.'));
    //    //解压缩
    //    if (!op.SharpZip.UnpackFiles(zipName, zipPath))
    //    {
    //        //解压缩失败
    //        return;
    //    }

    //    string[] strFile = Directory.GetFiles(zipPath, "*.xls");
    //    if (strFile.Length <= 0)
    //    {
    //        return;
    //    }


    //    string exclePath = strFile[0];
    //    int StartRow = 2;    //读的起始行
    //    Application excel = new Application();//引用Excel对象

    //    Workbook workbook = excel.Workbooks.Add(exclePath);
    //    excel.UserControl = true;
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //    excel.Visible = false;


    //    Worksheet sheet = workbook.Worksheets.get_Item(1) as Worksheet;//从１开始.
    //    for (int row = StartRow; row <= sheet.UsedRange.Rows.Count; row++)
    //    {
    //        bool isNew = false;
    //        mo.proInfo mo = new mo.proInfo();
    //        Range range1 = sheet.Cells[row, 1] as Range;
    //        mo.imgC = ((Range)sheet.Cells[row, 1]).Text.ToString();
    //        if (((Range)sheet.Cells[row, 2]).Text.ToString() == "")
    //        {
    //            isNew = true;
    //            mo.id = int.Parse(((Range)sheet.Cells[row, 2]).Text.ToString());
    //        }
    //        mo.proId = ((Range)sheet.Cells[row, 3]).Text.ToString();
    //        mo.nameC = ((Range)sheet.Cells[row, 4]).Text.ToString();
    //        mo.priceC = double.Parse(((Range)sheet.Cells[row, 5]).Text.ToString());
    //        mo.weightC = double.Parse(((Range)sheet.Cells[row, 6]).Text.ToString());
    //        mo.strPrice = ((Range)sheet.Cells[row, 7]).Text.ToString();
    //        mo.typ = int.Parse(((Range)sheet.Cells[row, 8]).Text.ToString());
    //        mo.displayC = ((Range)sheet.Cells[row, 9]).Text.ToString();
    //        mo.fileName = ((Range)sheet.Cells[row, 10]).Text.ToString();
    //        mo.htmlName = ((Range)sheet.Cells[row, 11]).Text.ToString();
    //        mo.qx = int.Parse(((Range)sheet.Cells[row, 12]).Text.ToString());
    //        mo.aboutC = ((Range)sheet.Cells[row, 13]).Text.ToString();
    //        mo.showC = int.Parse(((Range)sheet.Cells[row, 14]).Text.ToString());
    //        mo.sellCount = int.Parse(((Range)sheet.Cells[row, 15]).Text.ToString());
    //        mo.brandC = int.Parse(((Range)sheet.Cells[row, 16]).Text.ToString());
    //        mo.addType = ((Range)sheet.Cells[row, 17]).Text.ToString();
    //        mo.star = int.Parse(((Range)sheet.Cells[row, 18]).Text.ToString());
    //        mo.characteristic = ((Range)sheet.Cells[row, 19]).Text.ToString();
    //        mo.contentC = ((Range)sheet.Cells[row, 20]).Text.ToString();
    //        mo.descriptionC = ((Range)sheet.Cells[row, 21]).Text.ToString();
    //        mo.keywordsC = ((Range)sheet.Cells[row, 22]).Text.ToString();
    //        mo.moqC = ((Range)sheet.Cells[row, 23]).Text.ToString();
    //        mo.attrId = ((Range)sheet.Cells[row, 24]).Text.ToString();
    //        mo.attrValue = ((Range)sheet.Cells[row, 25]).Text.ToString();
    //        mo.addTypeName = ((Range)sheet.Cells[row, 26]).Text.ToString();
    //        mo.moreImg = ((Range)sheet.Cells[row, 27]).Text.ToString();
    //        mo.supplyid = ((Range)sheet.Cells[row, 28]).Text.ToString();
    //        if (isNew)
    //        {
    //            //上传文件
    //            mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));

    //            mo.id = new op.Operation().MaxId("products");
    //            new dal.ProductsDB().InsertModel(mo);



    //        }
    //        else
    //        {

    //            mo.proInfo oldmo = new dal.ProductsDB().getModel("where id = "+mo.id);
    //            if (oldmo.id <= 0)
    //            {
    //                //上传文件
    //                mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));
    //                mo.id = new op.Operation().MaxId("products");
    //                new dal.ProductsDB().InsertModel(mo);
    //                return;
    //            }
    //            else
    //            {
    //                if (oldmo.imgC.Replace('/', '_') != mo.imgC)
    //                {
    //                    mo.imgC = upImg(zipPath + "/img/" + mo.imgC.Replace('/', '_'));
    //                }
    //                new dal.ProductsDB().UpdateModel(mo);
    //            }


    //        }
    //    }
    //    //}
    //    workbook.Close(false, null, null);
    //    excel.Quit();
    //    KillProcessexcel("EXCEL");

    //}

    /// <summary>
    /// 绝对地址 包括路径和名称
    /// </summary>
    /// <param name="imgPath"></param>
    private string upImg(string imgPath)
    {
        //   图片有三处:分别是uploadFile-水印图,sImg-缩略图,sImg/y-原图
        op.UploadFile file = new op.UploadFile();
        string path = op.staValue.path + "uploadFile/";
        string imgName = imgPath.Substring(imgPath.LastIndexOf("/")+1);
        string dir =  "/" + imgName;
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



    private void SharpZipTest()
    {
        string zipPathFrom = @"E:\JiuyunNet_B2CSEO_V1.0\ui\uploadFile\Report\Load\2012-8-10.zip";
        string zipPathTo = Server.MapPath("/") + "uploadFile/Report/Load/";
        op.SharpZip.UnpackFiles(zipPathFrom, zipPathTo);
     
    }


    //private void excel()
    //{

    //    string pathTo = Server.MapPath("/") + "uploadFile/Report/Up/" + DateTime.Now.ToShortDateString()+"/";

    //    string pathZipTo = Server.MapPath("/") + "uploadFile/Report/Up/" + DateTime.Now.ToShortDateString() + ".zip";

    //    //可以直接取图片的地址

    //    dal.ProductsDB pro = new dal.ProductsDB();
    //    List<mo.proInfo> modelList = pro.getModelListAll_info();

    //    int rowIndex = 1;

    //    Workbook xlWorkBook;
    //    Worksheet xlWorkSheet;
    //    xlWorkBook = new Application().Workbooks.Add(Type.Missing);
    //    xlWorkBook.Application.Visible = false;
    //    xlWorkSheet = (Worksheet)xlWorkBook.Sheets[1];

    //    xlWorkSheet.Cells[1, 1] = "imgC";
    //    xlWorkSheet.Cells[1, 2] = "Id";
    //    xlWorkSheet.Cells[1, 3] = "proId";
    //    xlWorkSheet.Cells[1, 4] = "nameC";
    //    xlWorkSheet.Cells[1, 5] = "priceC";
    //    xlWorkSheet.Cells[1, 6] = "weightC";
    //    xlWorkSheet.Cells[1, 7] = "strPrice";
    //    xlWorkSheet.Cells[1, 8] = "typ";
    //    xlWorkSheet.Cells[1, 9] = "displayC";
    //    xlWorkSheet.Cells[1, 10] = "fileName";
    //    xlWorkSheet.Cells[1, 11] = "htmlName";
    //    xlWorkSheet.Cells[1, 12] = "qx";
    //    xlWorkSheet.Cells[1, 13] = "aboutC";
    //    xlWorkSheet.Cells[1, 14] = "showC";
    //    xlWorkSheet.Cells[1, 15] = "sellCount";
    //    xlWorkSheet.Cells[1, 16] = "brandC";
    //    xlWorkSheet.Cells[1, 17] = "addType";
    //    xlWorkSheet.Cells[1, 18] = "star";
    //    xlWorkSheet.Cells[1, 19] = "Characteristic";
    //    xlWorkSheet.Cells[1, 20] = "contentC";
    //    xlWorkSheet.Cells[1, 21] = "descriptionC";
    //    xlWorkSheet.Cells[1, 22] = "keywordsC";
    //    xlWorkSheet.Cells[1, 23] = "moqC";
    //    xlWorkSheet.Cells[1, 24] = "attrId";
    //    xlWorkSheet.Cells[1, 25] = "attrValue";
    //    xlWorkSheet.Cells[1, 26] = "addTypeName";
    //    xlWorkSheet.Cells[1, 27] = "moreImg";

    //    for (int i = 0; i < modelList.Count; i++)
    //    {
    //        xlWorkSheet.Cells[i + 2, 1] = modelList[i].imgC;
    //        xlWorkSheet.Cells[i + 2, 2] = modelList[i].id;
    //        xlWorkSheet.Cells[i + 2, 3] = modelList[i].preId;
    //        xlWorkSheet.Cells[i + 2, 4] = modelList[i].nameC;
    //        xlWorkSheet.Cells[i + 2, 5] = modelList[i].priceC;
    //        xlWorkSheet.Cells[i + 2, 6] = modelList[i].weightC;
    //        xlWorkSheet.Cells[i + 2, 7] = modelList[i].strPrice;
    //        xlWorkSheet.Cells[i + 2, 8] = modelList[i].typ;
    //        xlWorkSheet.Cells[i + 2, 9] = modelList[i].displayC;
    //        xlWorkSheet.Cells[i + 2, 10] = modelList[i].fileName;
    //        xlWorkSheet.Cells[i + 2, 11] = modelList[i].htmlName;
    //        xlWorkSheet.Cells[i + 2, 12] = modelList[i].qx;
    //        xlWorkSheet.Cells[i + 2, 13] = modelList[i].aboutC;
    //        xlWorkSheet.Cells[i + 2, 14] = modelList[i].showC;
    //        xlWorkSheet.Cells[i + 2, 15] = modelList[i].sellCount;
    //        xlWorkSheet.Cells[i + 2, 16] = modelList[i].brandC;
    //        xlWorkSheet.Cells[i + 2, 17] = modelList[i].addType;
    //        xlWorkSheet.Cells[i + 2, 18] = modelList[i].star;
    //        xlWorkSheet.Cells[i + 2, 19] = modelList[i].characteristic;
    //        xlWorkSheet.Cells[i + 2, 20] = modelList[i].contentC;
    //        xlWorkSheet.Cells[i + 2, 21] = modelList[i].descriptionC;
    //        xlWorkSheet.Cells[i + 2, 22] = modelList[i].keywordsC;
    //        xlWorkSheet.Cells[i + 2, 23] = modelList[i].moqC;
    //        xlWorkSheet.Cells[i + 2, 24] = modelList[i].attrId;
    //        xlWorkSheet.Cells[i + 2, 25] = modelList[i].attrValue;
    //        xlWorkSheet.Cells[i + 2, 26] = modelList[i].addTypeName;
    //        xlWorkSheet.Cells[i + 2, 27] = modelList[i].moreImg;
    //        xlWorkSheet.Cells[i + 2, 28] = modelList[i].supplyid;


    //        string filename = Server.MapPath("/") + modelList[i].fileName + modelList[i].imgC;
    //        if(File.Exists(filename))
    //        {
    //            if(!Directory.Exists(pathTo+"img/"))
    //            {
    //                Directory.CreateDirectory(pathTo + "img/");
    //            }
    //            if (!File.Exists(pathTo + "img/" + modelList[i].imgC.Replace('/', '_')))
    //            {
    //                File.Copy(filename, pathTo + "img/" + modelList[i].imgC.Replace('/', '_'));
    //            }
    //        }

    //        rowIndex++;
    //    }

    //    #region 保存excel文件
    //    string filePath = pathTo + "Product_" + System.DateTime.Now.ToShortDateString() + ".xls";
    //    xlWorkBook.SaveAs(filePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    //    xlWorkBook.Application.Quit();
    //    xlWorkSheet = null;
    //    xlWorkBook = null;
    //    GC.Collect();
    //    System.GC.WaitForPendingFinalizers();
    //    #endregion
    //    KillProcessexcel("EXCEL");
    //    op.ClassZip.Zip(pathTo.TrimEnd('/'), pathZipTo, 1);
    //    #region 导出到客户端
    //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
    //    Response.AppendHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode("导出", System.Text.Encoding.UTF8) + ".xls");
    //    Response.ContentType = "Application/excel";
     
    //    Response.WriteFile(filePath);
    //    Response.End();
    //    #endregion




    //}
    #region 杀死进程
    private void KillProcessexcel(string processName)
    { //获得进程对象，以用来操作
        System.Diagnostics.Process myproc = new System.Diagnostics.Process();
        //得到所有打开的进程
        try
        {
            //获得需要杀死的进程名
            foreach (Process thisproc in Process.GetProcessesByName(processName))
            { //立即杀死进程
                thisproc.Kill();
            }
        }
        catch (Exception Exc)
        {
            throw new Exception("", Exc);
        }
    }
    #endregion
}