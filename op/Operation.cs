using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
namespace op
{
    /// <summary>
    ///Operation 基本操作类  编码 剪字符,等
    /// </summary>
    public class Operation
    {
        public Operation()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 截字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Strsub(string str, int n)
        {
            if (str != null)
            {
                if (str.Length > n)  //判断标题有没有超过25个字  有就截下来
                {
                    str = str.ToString().Substring(0, n) + "..";
                }
            }
            return str;
        }
        /// <summary>
        /// 对用户输入的字符进行过滤和Html编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StrEncode(string str)
        {
            if (!(null == str || str == string.Empty))
            {
                str = HttpContext.Current.Server.HtmlEncode(str);
                str = str.Replace("'", "#@");
            }
            return str;
        }
        /// <summary>
        /// 把用户输入的字符还原
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StrDecode(string str)
        {
            if (!(null == str || str == string.Empty))
            {
                str = HttpContext.Current.Server.HtmlDecode(str);
                str = str.Replace("#@", "'");
            }
            return str;
        }
        /// <summary>
        /// 生成为一的文件名
        /// </summary>
        /// <returns></returns>
        public string NameRndOnly()
        {
            Random rand=new Random();
            string newFileName = System.DateTime.Now.ToString("yyMMddHHmmssffff") + rand.Next(100, 999);
            return newFileName;
        }
        public bool validate(string code)
        {
            if (HttpContext.Current.Session["Validate"] != null && HttpContext.Current.Session["Validate"].ToString() == code.ToLower())
            {
                HttpContext.Current.Session.Remove("Validate");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 返回最大的值
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="ziDuan">字段</param>
        /// <returns></returns>
        public string MaxZiDuan(string tbName, string ziDuan)
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("select max({0})+1 from {1}", ziDuan, tbName);
            string str = pro.maxId(sb.ToString());
            if (string.IsNullOrEmpty(str))
                return "1";
            return str;
        }
        /// <summary>
        /// 返回最大的值　用于id获得
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="ziDuan">字段</param>
        /// <returns></returns>
        public int MaxId(string tbName)
        {
            string str = MaxZiDuan(tbName, "id");
            return Convert.ToInt32(str);
        }
        /// <summary>
        /// 判断是否为正确格式的电子邮箱
        /// </summary>
        /// <param name="Str">需要判断的电子邮箱</param>
        /// <returns></returns>
        public bool IsEmail(string Str)
        {
            string strRegex = @"^[_\.0-9a-z-]+@([0-9a-z][0-9a-z-]+\.){1,4}[a-z]{2,3}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Str))
                return true;
            else
                return false;
        }
        /// <summary>
        ///  过滤所谓的 html    |   [\\r\\\n\\t]  |  &[^;]+; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string removeHtml(string str)
        {
            return removeHtml(str, "<[^>]+>|[\\r\\\n\\t]|&[^;]+;");
        }
        /// <summary>
        ///  过滤  &[^;]+;   过滤&nbsp;  以&开头 ;结尾
        /// </summary>
        /// <param name="str"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public string removeHtml(string str, string reg)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Regex.Replace(str, reg, "");
            }
            else
                return "";
        }

        /// <summary>
        /// 数字 字符串排序
        /// </summary>
        /// <param name="str">1,2,3,4</param>
        /// <returns></returns>
        public string strOrder(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            str = str.Trim(',');
            if (!string.IsNullOrEmpty(str))
            {
                string[] arr = str.Split(',');
                string s = "";
                str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (int.Parse(arr[i]) > int.Parse(arr[j]))
                        {
                            s = arr[i];
                            arr[i] = arr[j];
                            arr[j] = s;
                        }
                    }
                    str += arr[i] + ",";
                }
                return "," + str;
            }
            else return "";
        }
    }

}