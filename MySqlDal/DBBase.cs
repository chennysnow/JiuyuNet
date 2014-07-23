using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace MySqlDal
{
    public class DBBase
    {
        public static string Connection
        {
            get { return ConfigurationManager.AppSettings["MySqlConnect"].ToString(); }
        }

        /// <summary>
        /// SqlReader 只往前读数据,用于绑定  不适合对表操作
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static MySqlDataReader SqlReader(string sqlstr)
        {

            MySqlConnection myConn = new MySqlConnection(Connection);
            MySqlDataReader cmd = MySqlLiveHelper.ExecuteReader(myConn, CommandType.Text, sqlstr);
            return cmd;

        }


        /// <summary>
        /// SqlExecuteScalar 只返回一行记录 没有记录则返回null
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static string SqlExecuteScalar(string sqlstr)
        {
            using (MySqlConnection myConn = new MySqlConnection(Connection))
            {
                try
                {
                    myConn.Open();
                    return MySqlLiveHelper.ExecuteScalar(myConn, sqlstr).ToString();

                }
                catch
                {
                    return null;
                }
            
            }
        }


        /// <summary>
        ///  SqlExecuteNonQuery 执行SQL修改,删除,添加操作 返回值影响行数
        /// </summary>
        /// <param name="sqlstr"></param>
        public static int SqlExecuteNonQuery(string sqlstr, params MySqlParameter[] cmdPara)
        {
            using (MySqlConnection myConn = new MySqlConnection(Connection))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {

                        // return (int)MySqlLiveHelper.ExecuteScalar(myConn, sqlstr, cmdPara);
                        return MySqlLiveHelper.ExecuteNonQuery(myConn, CommandType.Text, sqlstr, cmdPara);
                      
                    }
                    catch 
                    {
                        return -1;
                    }

                }
            }
        }


        public static int ExecuteScalar(string sqlstr, params MySqlParameter[] cmdPara)
        {
            try
            {
                object o = MySqlLiveHelper.ExecuteScalar(Connection, sqlstr, cmdPara);

                return (int)o;
            }
            catch
            {
                return -1;
            }

        }


        /// <summary>
        /// 数据库绑定 返回一个数据表
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataTable SqlTable(string sqlstr)
        {
            using (MySqlConnection myConn = new MySqlConnection(Connection))
            {
                DataSet ds = new DataSet();
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlstr, myConn);
                    da.Fill(ds);
                    da.Dispose();
                    return ds.Tables[0];
                }
                 finally  //释放所有资源
                {
                    ds.Dispose();
                    myConn.Close();
                }
            }
        }


    }
}
