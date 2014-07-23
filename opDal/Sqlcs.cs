using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Web;
namespace opDal
{
    public class Sqlcs
    {

        private static string Connection = ConfigurationManager.AppSettings["Accessdb"].ToString();
        public Sqlcs()
        {

        }
        /// <summary>
        /// 数据库绑定 返回一个数据表
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataTable SqlTable(string sqlstr)
        {
            using (OleDbConnection myConn = new OleDbConnection(Connection))
            {
                DataSet ds = new DataSet();
                try
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, myConn);
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
        /// <summary>
        ///  SqlExecuteNonQuery 执行SQL修改,删除,添加操作 返回值影响行数
        /// </summary>
        /// <param name="sqlstr"></param>
        public static int SqlExecuteNonQuery(string sqlstr, params OleDbParameter[] cmdPara)
        {
            using (OleDbConnection myConn = new OleDbConnection(Connection))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        preCommand(cmd, myConn, null, sqlstr, cmdPara);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }

                }
            }
        }
        /// <summary>
        /// SqlReader 只往前读数据,用于绑定  不适合对表操作
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static OleDbDataReader SqlReader(string sqlstr)
        {
            OleDbConnection myConn = new OleDbConnection(Connection);

            if (myConn.State != ConnectionState.Open)
                myConn.Open();
            OleDbCommand cmd = new OleDbCommand(sqlstr, myConn);
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Dispose();
            return dr;

        }
        /// <summary>
        /// SqlExecuteScalar 只返回一行记录 没有记录则返回null
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static string SqlExecuteScalar(string sqlstr)
        {
            using (OleDbConnection myConn = new OleDbConnection(Connection))
            {
                try
                {
                    myConn.Open();
                    OleDbCommand cmd = new OleDbCommand(sqlstr, myConn);
                    string str = null;
                    if (cmd.ExecuteScalar() == null)//判断下有没有记录  有就返回  没有就返回Null
                        return str;
                    else
                        return cmd.ExecuteScalar().ToString().Trim();
                }
                finally
                {
                    myConn.Close();
                }
            }
        }
        private static void preCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParam)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParam != null)
            {
                foreach (OleDbParameter parm in cmdParam)
                {
                    if (parm.Value == null)
                        parm.Value = 0;
                    cmd.Parameters.Add(parm);
                }
            }
        }


    }
}