using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
/// <summary>
///cook 的摘要说明
/// </summary>
public class cook
{
    public cook()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 后台登录保存方式 0 Cookie,1 Session
    /// </summary>
    public const string AdminSaveType = "0";
    #region 后台
    /// <summary>
    /// 加入后台登陆标记
    /// </summary>
    /// <param name="userid"></param>
    /// <param name="userpwd"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool ValidataLogin(string userid, string userpwd)
    {
        //dal.adminUser adminUser = new dal.adminUser();
        dal.adminUserDB adminUser = new dal.adminUserDB();
        op.Operation opera = new op.Operation();
        userid = opera.StrEncode(userid);
        userpwd = opera.StrEncode(userpwd);

        mo.adminUser model = adminUser.getModel("where userName='" + userid + "' and passwordC='" + userpwd + "'");
        if (string.IsNullOrEmpty(model.userName) || userid != model.userName)
        {
            return false;
        }
        else
        {
            if (AdminSaveType != null && AdminSaveType == "1")
            {
                HttpContext.Current.Session.Timeout = 60;
                HttpContext.Current.Session.Add("adminUser", model.userName);
                //HttpContext.Current.Session.Add("type", model.typ);
            }
            else
            {
                //HttpContext.Current.Session.Timeout = 60;
                //HttpContext.Current.Session.Add("user", model.userName);
                //HttpContext.Current.Session.Add("type", model.typ);
                HttpCookie cookie;
                cookie = new HttpCookie("adminUser", model.userName);
                cookie.Expires = DateTime.Now.AddDays(3);
                HttpContext.Current.Response.Cookies.Add(cookie);
                //cookie = new HttpCookie("userType", "0");
                //cookie.Expires = DateTime.Now.AddDays(1);
                //HttpContext.Current.Response.Cookies.Add(cookie);
               
            }
            return true;
        }
    }
    /// <summary>
    /// 获取COOKIES  userName的值
    /// </summary>
    private static string adminUserName
    {
        get
        {
            if (AdminSaveType != null && AdminSaveType == "1")
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["adminUser"] != null)
                    return HttpContext.Current.Session["adminUser"].ToString();
                return null;
            }
            else
            {
                if (HttpContext.Current.Request.Cookies["adminUser"] != null)
                    return HttpContext.Current.Request.Cookies["adminUser"].Value;
                return null;
            }
          
        }
    }
    /// <summary>
    /// 获取COOKIES  user的权限
    /// </summary>
    private static string adminType
    {
        get
        {
            if (HttpContext.Current.Session["type"] != null)
                return HttpContext.Current.Session["type"].ToString();
            return null;
        }
    }
    public static void Judge()
    {
        if (string.IsNullOrEmpty(adminUserName))
        {
            HttpContext.Current.Response.Redirect("~/admin/default.aspx");
        }
    }

    /// <summary>
    /// 后台用户退出
    /// </summary>
    public static void AdminLogout()
    {
        if (AdminSaveType != null && AdminSaveType == "1")
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["adminUser"] != null)
                HttpContext.Current.Session["adminUser"] = null;
            
        }
        else
        {
            HttpContext.Current.Response.Cookies["adminUser"].Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Request.Cookies.Remove("adminUser");
        }
    }


    #endregion
    #region 前台会员
    /// <summary>
    /// 加入登陆标记
    /// </summary>
    /// <param name="userid"></param>
    /// <param name="userpwd"></param>
    /// <returns></returns>
    public bool login(string userid, string userpwd)
    {
        dal.UserDB user = new dal.UserDB();
        //dal.user user = new dal.user();
        op.Operation opera = new op.Operation();
        userid = opera.StrEncode(userid);
        userpwd = opera.StrEncode(userpwd);

        mo.user model = user.getModel("where userName='" + userid + "' and passwordC='" + userpwd + "'");
        if (model==null || string.IsNullOrEmpty(model.userName) || userid != model.userName)
        {
            return false;
        }
        else
        {
            HttpCookie cookie;
            cookie = new HttpCookie("userType", model.typ.ToString());
            cookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(cookie);
            
            cookie = new HttpCookie("userName", model.userName);
            cookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(cookie);
            return true;
        }
    }
    /// <summary>
    /// 检测是否登陆,没登陆跳转登陆页面
    /// </summary>
    /// <returns>返回用户名</returns>
    public static string userJudge()
    {
        if (HttpContext.Current.Request.Cookies["userName"] != null && HttpContext.Current.Request.Cookies["userName"].Value != "")
        {
            return HttpContext.Current.Request.Cookies["userName"].Value;
        }
        else
        {
            HttpContext.Current.Response.Redirect("~/login.aspx?url="+HttpContext.Current.Request.RawUrl);
            return null;
        }
    }
    /// <summary>
    /// 前台用户退出 /js/JsBottom.js
    /// </summary>
    public static void Logout()
    {
        //HttpContext.Current.Session.Remove("user");
        HttpContext.Current.Response.Cookies["userName"].Expires = DateTime.Now.AddHours(-1);
        HttpContext.Current.Response.Cookies["userType"].Expires = DateTime.Now.AddHours(-1);
        HttpContext.Current.Request.Cookies.Remove("userName");
        HttpContext.Current.Request.Cookies.Remove("userType");
    }

    #endregion


    public static bool adminJudge()
    {
        //string str = null;
        //if (HttpContext.Current.Request.Cookies["adminUser"] != null)
        //    str = HttpContext.Current.Request.Cookies["adminUser"].Value;
        if (string.IsNullOrEmpty(adminUserName))
        {
            HttpContext.Current.Response.Redirect("~/admin/default.aspx");
            return false;
        }
        else
            return true;
    }
}
