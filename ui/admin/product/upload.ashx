<%@ WebHandler Language="C#" Class="upload" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
public class upload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            HttpPostedFile file;
            op.Operation ope = new op.Operation();
            //dal.price pri = new dal.price();
            dal.PriceDB pri = new dal.PriceDB();
            //dal.products product = new dal.products();
            dal.ProductsDB product = new dal.ProductsDB();
            mo.proInfo model = product.getModel_s("select top 1 * from products,proInfo order by sortC asc");
            string cateId = context.Request["cateId"].ToString();
            string shui = context.Request["shui"].ToString();
            for (int i = 0; i < context.Request.Files.Count; ++i)
            {
                file = context.Request.Files[i];
                if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                op.UploadFile upfiles = new op.UploadFile();
                mo.proInfo pro = new mo.proInfo();
                if (shui == "0")
                    upfiles.IsMadeShuiYin = false;
                // upfiles.fileSaveAs(file, true);
                pro.proId = file.FileName.Replace(".jpg", "").Replace(".JPG", "");
                upfiles.fileSaveAs(file);
                pro.imgC = upfiles.proName;
                pro.moreImg = pro.imgC;
                pro.fileName = "/uploadFile";

                pro.nameC = model.nameC;
                pro.proId = model.proId;
                pro.attrId = model.attrId;
                pro.attrValue = model.attrValue;
                pro.titleC = model.titleC;
                pro.keywordsC = model.keywordsC;
                pro.descriptionC = model.descriptionC;
                pro.displayC = model.displayC;
                pro.priceC = model.priceC;
                pro.weightC = model.weightC;
                pro.stockC = model.stockC;
                pro.contentC = model.contentC;

                string[] typ = cateId.Split('|');
                pro.typ = Convert.ToInt32(typ[0]);
                pro.addType = "," + pro.typ + ",";
                
                pro.id = ope.MaxId("products");
                pro.sortC = pro.id; 
                pro.htmlName = typ[1]+"Product_" + pro.id + ".html";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                pro.preId = pro.id;
                pro.showC = 1;
                product.InsertModel(pro);
                mo.price modelPrice = new mo.price();
                modelPrice.typ = pro.id;
                modelPrice.minC = 1;
                modelPrice.maxC = 100;
                modelPrice.priceC = 0;
                modelPrice.dayC = "3 Days";
                pri.InsertModel(modelPrice);                
            }
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.Write(ex);
            context.Response.End();
        }
        finally
        {
            // context.Response.Redirect(context.Request.RawUrl);
            context.Response.End();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}