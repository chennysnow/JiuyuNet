using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
namespace op
{
    public class staValue
    {
        public static string companyName = ConfigurationManager.AppSettings["companyName"].ToString();
        public static string siteUrl = ConfigurationManager.AppSettings["siteUrl"].ToString();
        public static string adminUrl = ConfigurationManager.AppSettings["adminUrl"].ToString();
        public static int imgHeight = int.Parse(ConfigurationManager.AppSettings["imgHeight"].ToString());
        public static int imgWidth = int.Parse(ConfigurationManager.AppSettings["imgWidth"].ToString());
        public static string path = HttpContext.Current.Request.PhysicalApplicationPath;
        public static int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
        public static int newsSize = int.Parse(ConfigurationManager.AppSettings["newsSize"].ToString());
        public static int stockAlarm = int.Parse(ConfigurationManager.AppSettings["stockAlarm"].ToString());
        public static string[] stmpMail = ConfigurationManager.AppSettings["smtpMail"].ToString().Split('|');
        public static string mail = ConfigurationManager.AppSettings["mail"].ToString();
        public static int shuiYin = int.Parse(ConfigurationManager.AppSettings["shuiYin"].ToString());
        public static int webType = 1;//0不优,1优化
        public static string language = ConfigurationManager.AppSettings["language"].ToString();
        public string[] OrderType = { "Submitted", "Paid", "shipped", "Completed" };
        public string[] display = {"销售","新品","同类"};
        public string[] retOrder = { "申请中", "受理中","申请失败", "退货中", "已完成" };
        public staValue() { }
        #region 过滤接收字符串
        /// <summary>
        /// 接收字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int RequestInt(object obj)
        {
            if (obj != null)
            {
                Regex r = new Regex(@"^\d+$");
                if (string.IsNullOrEmpty(obj.ToString()) || !r.IsMatch(obj.ToString()))
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            else
                return 0;
        }
        /// <summary>
        /// 过滤特殊字符 只保存 字母数字下划线
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RexSpecial(string str)
        {
            return Regex.Replace(str, @"[^\w]", "");
        }
        public static string RexSpecial(string str,string repStr)
        {
            return Regex.Replace(str, @"[^\w]", repStr);
        }
        #endregion
        #region 设置title,keywords,description
        /// <summary>
        /// 在keywords表里查找
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="typ">类型</param>
        public static void setMeta(System.Web.UI.Page page,string typ)
        {
            //dal.keywords key = new dal.keywords();
            MySqlDal.KeywordsDB key = new MySqlDal.KeywordsDB();
            mo.keywords model = key.getModel(typ);
            System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
            page.Title = model.titleC;
            meta.Name = "keywords";
            meta.Content = model.keywordsC;
            page.Header.Controls.Add(meta);
            meta = new System.Web.UI.HtmlControls.HtmlMeta();
            meta.Name = "description";
            meta.Content = model.descriptionC;
            page.Header.Controls.Add(meta);
            return;
        }
        /// <summary>
        /// 具体值
        /// </summary>
        /// <param name="page"></param>
        /// <param name="title"></param>
        /// <param name="keywords"></param>
        /// <param name="description"></param>
        public static void setMeta(System.Web.UI.Page page, string title,string keywords,string description)
        {
            System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
            page.Title = title;
            meta.Name = "keywords";
            meta.Content = keywords;
            page.Header.Controls.Add(meta);
            meta = new System.Web.UI.HtmlControls.HtmlMeta();
            meta.Name = "description";
            meta.Content = description;
            page.Header.Controls.Add(meta);
            return;
        }
        #endregion
        #region 菜单
        //dal.menu menu = new dal.menu();
        MySqlDal.MenuDB menu = new MySqlDal.MenuDB();
        /// <summary>
        /// 缓存所有菜单  typ确定
        /// </summary>
        /// <param name="typ"></param>
        /// <returns></returns>
        public List<mo.menu> getMenuList(int typ)
        {
            List<mo.menu> modelList = new List<mo.menu>();
            if (HttpContext.Current.Cache.Get("menuList_"+typ) != null)
            {
                modelList = (List<mo.menu>)System.Web.HttpContext.Current.Cache.Get("menuList_"+typ);
            }
            else
            {
                menuSon(modelList, typ);
                string pah = path + "updateTime.txt";
                System.Web.HttpContext.Current.Cache.Insert("menuList_"+typ, modelList, new System.Web.Caching.CacheDependency(pah));
            }
            return modelList;
        }
        private void menuSon(List<mo.menu> modelList, int typ)
        {
              List<mo.menu> modelList_1 = menu.getModelListWhere("where typ=" + typ);
            //string sql = "";
            //if (typ ==0)
            //{
            //    sql = "where parent_id is null";
            //}
            //else
            //{
            //    sql = "where parent_id=" + typ;
            //}

            //List<mo.menu> modelList_1 = new MySqlDal.menu().getModelListWhere(sql);

           
            if (modelList_1.Count <= 0 || modelList_1 == null)
                return;
            else
            {
                for (int i = 0; i < modelList_1.Count; i++)
                {
                    string str = "";
                    for (int j = 2; j <= modelList_1[i].levelC; j++)
                    {
                        str += "┝";
                    }
                    modelList_1[i].nameC = str + modelList_1[i].nameC;
                    modelList.Add(modelList_1[i]);
                    menuSon(modelList, modelList_1[i].id);
                }
            }
        }
        /// <summary>
        /// 返回某个类别下所包含的ID,包含自身
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getCategoryId(int id)
        {
            List<mo.menu> modelList = getMenuList(1);
            string str = id.ToString() + ",";
            str+=getCategoryId(id, 0,0, modelList);
            return str;
        }
        /// <summary>
        /// 优化了两处,一个j,前面的不用再查找,2是同级菜单,不查找后面的子树   但测试数据显示用了j速度反而慢了,不知道是不是数据量太少的关系
        /// </summary>
        /// <param name="id">要查询的ID</param>
        /// <param name="j">当前找到第几项了,因为缓存的菜单是有规律的,每个一级菜单紧跟后面是二级菜单</param>
        /// <param name="level">当前要查找菜单的等级,用来判断下一个等级是否相等</param>
        /// <param name="modelList">数据源</param>
        /// <returns></returns>
        private string getCategoryId(int id, int j,int level, List<mo.menu> modelList)
        {
            int i = j;
            System.Text.StringBuilder sb = new StringBuilder();
            for (; i < modelList.Count; i++)
            {
                if (modelList[i].levelC == level)//找到另一棵树可以不用找了,也就是同等级的菜单不用再找下去了
                    break;
                if (modelList[i].typ == id)
                {
                    sb.AppendFormat("{0},", modelList[i].id);
                    string str = getCategoryId(modelList[i].id, j + i, level, modelList);
                    if (str != "")
                        sb.AppendFormat("{0},", str);
                }
                if (modelList[i].id == id)
                    level = modelList[i].levelC;
            }
            return sb.ToString();
        }
        #endregion
        #region 对话框
        /// <summary>
        /// div模拟对话框
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="flg">不需要背景</param>
        public static void divAlert(System.Web.UI.Page page, string msg, bool flg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>alertC.show('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 必须在 form=ruannt属性里注册
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void divAlert(System.Web.UI.Page page, string msg,string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>alertC.show('" + msg.ToString() + "');window.location.href='" + url + "';</script>");
        }
        /// <summary>
        /// div模拟对话框
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg">需要背景</param>
        public static void divAlert(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript'>alertC.show('" + msg.ToString() + "',1);</script>");
        }
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void MessageShow(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>alert('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 显示消息提示对话框 跳转页面
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        ///  <param name="url">跳转的URL</param>
        public static void MessageShow(System.Web.UI.Page page, string msg, string url)
        {
            // page.ClientScript.RegisterStartupScript注册在尾部
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "message", "<script language='javascript'>alert('" + msg.ToString() + "');window.location.href='" + url + "';</script>");
        }
        #endregion
    }
}
