<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;
using System.Collections.Generic;
public class ajax : IHttpHandler {

    HttpContext context1 = null;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context1 = context;
        switch (context.Request.QueryString["action"])
        {
            case "getPrice": getPrice(); break;
            case "expPrice": exPrice(); break;
            case "regMail": regMail(); break;
            default: break; 
        }
    }
    /// <summary>
    /// 获取所在的价格区间
    /// </summary>
    private void getPrice()
    {
        int id = op.staValue.RequestInt(context1.Request.QueryString["id"]);
        int count = op.staValue.RequestInt(context1.Request.QueryString["count"]);
        string price = "0";
        if (id != 0)
        {
            //dal.price pri = new dal.price();
            dal.PriceDB pri = new dal.PriceDB();
            price = pri.getString("priceC", "where typ=" + id + " and minC<=" + count + " order by priceC asc");
            if (string.IsNullOrEmpty(price))
            {
                price = "0";
            }
        }
        context1.Response.Write(price);
        context1.Response.End();
    }
    /// <summary>
    /// 获取快递价格
    /// </summary>
    private void exPrice()
    {
        string id = context1.Request.QueryString["id"];
        //dal.expPlace expPlace = new dal.expPlace();
        dal.expPlaceDB expPlace = new dal.expPlaceDB();
        //List<mo.expPlace> modelList = expPlace.getModelListWhere("where placeId=" + id);

        org.jiuyu.express.ExpService service = new org.jiuyu.express.ExpService();
        org.jiuyu.express.ExpressPrice[] list = service.GetPrice(id);
        
        
        string json = "[";
        for (int i = 0; i < list.Length; i++)
        {
            json += "{\"id\":\"" + list[i].expressId + "\",\"price\":\"" + list[i].firstPrice + "\",\"price1\":\"" + list[i].lastPrice + "\"},";
        }
        json = json.TrimEnd(',') + "]";
        context1.Response.Write(json);
        context1.Response.End(); 
    }
    private void regMail()
    {
        //dal.message message = new dal.message();
        dal.MessageDB message = new dal.MessageDB();
        mo.message model = new mo.message();
        op.Operation ope = new op.Operation();
        model.mailC = ope.StrEncode(context1.Request.QueryString["mail"]);
        model.nameC = "用户邮件注册";
        model.timeC = DateTime.Now.ToString();
        model.typ = 0;
        message.InsertModel(model);        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}