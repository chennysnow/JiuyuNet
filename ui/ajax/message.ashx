<%@ WebHandler Language="C#" Class="message" %>

using System;
using System.Web;
using System.Web.SessionState;
public class message : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        if (context.Session["Validate"] == null)
             context.Response.Write("Code error, please re-enter!!");
        else
        if (context.Request.Form["code"].ToString().ToLower() == context.Session["Validate"].ToString().ToLower())
        {
            mo.message model = new mo.message();
            string[] arr = HttpUtility.UrlDecode(context.Request.Form["img"]).Split('@');
            model.nameC = context.Request.Form["name"] + "       产品编号:" + arr[1];
            model.mailC = context.Request.Form["email"];
            model.contentC = context.Request.Form["content"];
            model.product = arr[0];
            model.typ = 1;
            model.ipC = context.Request.UserHostAddress;
            model.timeC = DateTime.Now.ToString();
            op.Operation ope = new op.Operation();
            //dal.message message = new dal.message();
            MySqlDal.MessageDB message = new MySqlDal.MessageDB();
            message.InsertModel(model);
            context.Response.Write("Submitted successfully!!");            
        }
        else
            context.Response.Write("Code error, please re-enter!!");
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}