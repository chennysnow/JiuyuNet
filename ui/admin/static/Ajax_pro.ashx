<%@ WebHandler Language="C#" Class="Ajax_pro" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Caching;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public class Ajax_pro : IHttpHandler {
    setWeb sw = new setWeb();
    //dal.products pro = new dal.products();
    MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
    HttpContext context = null;
    public void ProcessRequest(HttpContext context1)
    {
        context1.Response.ContentType = "text/plain";
        
        context = context1;
        if (context1.Request.Form["typStatic"] != null)
        {
            string typ = context1.Request.Form["typStatic"].ToString();
            switch (typ)
            {
                case "ProCount": proCount(); break;
                case "CreatPro": CreateProAll(int.Parse(context1.Request.Form["page"])); break;
            }
        }
    }
    private void proCount()
    {
        //dal.products pro = new dal.products();
        MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
        string count = pro.getString("count(*)", "");
        context.Response.Write(count);
        context.Response.End();
    }
    /// </summary>
    /// 生成产品详细页
    /// </summary>    
    private void CreateProAll(int page)
    {
        List<mo.products> modelList = new List<mo.products>();
        int pageSize = 20;
        if (context.Cache.Get("list")==null)
        {
            modelList = pro.getModelListAll();
          // sw.Create("CopyProduct.aspx", "productMaster.html");//缓存要用的数据
           // strMaster = sw.ReadMaster("productMaster.html");
            context.Cache.Insert("list", modelList, null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);//绝对过期
          //  context.Cache.Insert("list", modelList, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(2));//相对过期
          //  context.Cache.Insert("master", strMaster, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(2));
        }
        else
        {
            modelList = (List<mo.products>)context.Cache.Get("list");
           // strMaster = context.Cache.Get("master").ToString();
        }
        int count = 0;
        if ((page+1)*pageSize>=modelList.Count)
        {
            count = modelList.Count;
        }
        else
        {
            count = (page+1) * pageSize;
        }
        for (int i = page*pageSize; i < count; i++)//得到所有的
        {
            //CreatOne(strMaster, modelList, i);
            sw.Create("ProShow.aspx?id=" + modelList[i].id, "product/"+modelList[i].htmlName);
        }
        if (count >= modelList.Count)
        {
            context.Cache.Remove("list");
            context.Response.Write("<font style='color:red'>生成成功！</font>第<font style='color:red'>" + (page + 1) + "</font>批生成完成<br/>");
        }
        else
        {
            context.Response.Write("第<font style='color:red'>" + (page + 1) + "</font>批生成完成&nbsp;..请稍后..");
            // System.Threading.Thread.Sleep(2000);
            //  Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", "<script type='text/javascript'>document.write('" + string.Format("总共有:{0}项    已完成:{1}项", modelList.Count, (page + 1) * 20) + "3秒后程序自动生成下页面');window.setInterval(function(){},2000);window.location.href='product.aspx?page=" + (++page) + "';</script></script>");
            // context.Response.Redirect();
        }
        context.Response.End();
    }
    //op.proKey proKey = new op.proKey();
    //dal.menu menu = new dal.menu();
    //dal.img img = new dal.img();
    //dal.price price = new dal.price();
    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //dataBin.dataBin siteBin = new dataBin.dataBin();
    //private void CreatOne(string str, List<mo.proInfo> modelList, int i)
    //{
        
    //    List<mo.proInfo> modelListProkey = proKey.strKey_info(modelList[i].nameC, modelList);//取得过滤的20项
    //    sb = new System.Text.StringBuilder();
    //    for (int j = 0; j < modelListProkey.Count; j++)//匹配关键字
    //    {
    //        sb.AppendFormat("<li><a href='{0}' title='{3}'><img src='UpdataImage/{1}/s{2}' alt='' /></a><div>{3}</div></li>", modelListProkey[j].htmlName, modelListProkey[j].fileName, modelListProkey[j].imgC, modelListProkey[j].nameC);
    //    }
    //    str = str.Replace("$proKey$", sb.ToString());
    //    List<mo.img> modelImg = img.getModelListWhere("where typ=" + modelList[i].id + "");
    //    sb = new System.Text.StringBuilder();
    //    for (int j = 0; j < modelImg.Count; j++)//小图片
    //    {
    //        sb.AppendFormat("<li><img src='UpdataImage/{0}/s{1}' alt='' /></li>",modelList[i].fileName, modelImg[j].imgC);
    //    }
    //    str = str.Replace("$smollImg$", sb.ToString());
    //    List<mo.products> modelProType = pro.getModelListWhere("top 20", "where typ=" + modelList[i].typ);
    //    sb = new System.Text.StringBuilder();
    //    for (int j = 0; j < modelProType.Count; j++)//同类别
    //    {
    //        sb.AppendFormat("<li><a href='{0}' title='{3}'><img src='UpdataImage/{1}/s{2}' alt='{3}' /><h2>{3}</h2></a></li>", modelProType[j].htmlName,modelList[i].fileName, modelProType[j].imgC, modelProType[j].nameC);
    //    }
    //    str = str.Replace("$proType$", sb.ToString());
    //    sb.Length=0;
    //    mo.menu modelMenu = menu.getModel("where id=" + modelList[i].typ);
    //   // str = str.Replace("$siteHtml$", string.Format("<a href='{0}'>{1}</a>><a href='{2}'>{3}</a>", modelMenu.htmlName, modelMenu.nameC, modelList[i].htmlName, modelList[i].nameC));
    //    //价格区间
    //    //List<mo.price> modelPrice = price.getModelListWhere("where typ=" + modelList[i].id);
    //    //sb = new System.Text.StringBuilder();
    //    //sb.Append("<table class='proPrice'><tr class=''><td>Qty.Range(unit)</td><td>Price(pre unit)</td></tr>");
    //    //for (int j = 0; j < modelPrice.Count; j++)
    //    //{
    //    //    sb.AppendFormat("<tr><td>{0}--{1}&nbsp;(Pieces)</td><td>$:{2}</td></tr>", modelPrice[j].minC, modelPrice[j].maxC, modelPrice[j].priceC);
    //    //}
    //    //sb.Append("</table>");
    //    //string[] arrSize = modelList[i].sizeC.Split(',');
    //    for (int j = 0; j < arrSize.Length; j++)
    //    {
    //        sb.AppendFormat("<option value=\"{0}\">{0}</option>", arrSize[j]);
    //    }
    //    str = str.Replace("$sizeC$", sb.ToString());
    //    sb.Length = 0;
    //    string[] arrColor = modelList[i].colorC.Split(',');
    //    for (int j = 0; j < arrColor.Length; j++)
    //    {
    //        sb.AppendFormat("<option value=\"{0}\">{0}</option>", arrColor[j]);
    //    }
    //   // str=str.Replace("$site$",siteBin.getSite("CompanyProduct.aspx?id="+modelList[i].id));
    //    str = str.Replace("$colorC$", sb.ToString());
    //    str = str.Replace("$categroy$", modelMenu.nameC);
    //    str = str.Replace("$priceC$",modelList[i].priceC);
    //    str = str.Replace("$proId$", modelList[i].proId);     
    //    str = str.Replace("$weightC$", modelList[i].weightC.ToString());
    //  //  str = str.Replace("$materialC$", modelList[i].materialC);
    //    str = str.Replace("$moqC$", modelList[i].moqC);
    //    str = str.Replace("$stockC$", modelList[i].stockC.ToString());
    //    str = str.Replace("$content$", modelList[i].contentC);
    //    str = str.Replace("$fileName$", modelList[i].fileName);
    //    str = str.Replace("$imgC$", modelList[i].imgC);
    //    str = str.Replace("$title$", modelList[i].titleC);
    //    str = str.Replace("$keyWords$", modelList[i].keywordsC);
    //    str = str.Replace("$description$", modelList[i].descriptionC);
    //    str = str.Replace("$nameC$", modelList[i].nameC);
    //    str = str.Replace("$id$", modelList[i].id.ToString());
    //    sw.WriterPage(str, modelList[i].htmlName);
    //}
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}