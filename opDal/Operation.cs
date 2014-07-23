using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
namespace opDal
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
        /// 返回最大的值
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="ziDuan">字段</param>
        /// <returns></returns>
        public string MaxZiDuan(string tbName, string ziDuan)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("select max({0})+1 from {1}", ziDuan, tbName);
            //string str = Sqlcs.SqlExecuteScalar(sb.ToString());
            string str = MySqlDal.DBBase.SqlExecuteScalar(sb.ToString());
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
        /// 增加点击率
        /// </summary>
        /// <param name="biao">哪个表</param>
        /// <param name="dj">原始点击率</param>
        /// <param name="id">文章id</param>
        public void dianji(string biao, int dj, int id)
        {
            int d = dj + 1;
            string sqlstr = "update " + biao + " set dj=" + d + " where id=" + id;
            Sqlcs.SqlExecuteNonQuery(sqlstr);
        }
    }
}
