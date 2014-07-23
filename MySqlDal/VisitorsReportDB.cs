using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class VisitorsReportDB:DBBase
    {

        public List<mo.VisitorsReport> getModelListWhere(string strWhere)
        {
            return setDr("select * from VisitorsReport " + strWhere + " order by CreateDate desc");
        }
        public List<mo.VisitorsReport> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select * from VisitorsReport " + strWhere + " order by CreateDate desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.VisitorsReport> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select * from VisitorsReport " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.VisitorsReport> setDr(string strSql)
        {
            List<mo.VisitorsReport> modelList = new List<mo.VisitorsReport>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.VisitorsReport model = new mo.VisitorsReport();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.VisitorsReport getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from VisitorsReport " + strWhere + "");
            mo.VisitorsReport model = new mo.VisitorsReport();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.VisitorsReport setModel(MySqlDataReader dr)
        {
            mo.VisitorsReport model = new mo.VisitorsReport();
            model.id = int.Parse(dr["ID"].ToString());
            model.ProductID = dr["ProductId"].ToString();
            model.ProductName = dr["ProductName"].ToString();
            model.VisitorIP = dr["VisitorIP"].ToString();
            model.VCount = (int)dr["VCount"];
            model.Createdate = DateTime.Parse(dr["Createdate"].ToString());
            return model;
        }

        public void InsertModel(mo.VisitorsReport model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into VisitorsReport(ProductId,ProductName,VisitorIP,VCount,Createdate) values (");
            sb.Append("@ProductId,@ProductName,@VisitorIP,@VCount,@Createdate)");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@ProductId", MySqlDbType.VarChar),
                                              new MySqlParameter("@ProductName", MySqlDbType.VarChar),
                                              new MySqlParameter("@VisitorIP", MySqlDbType.VarChar),
                                              new MySqlParameter("@VCount", MySqlDbType.Int32),
                                              new MySqlParameter("@Createdate", MySqlDbType.DateTime),
                                         
                                          };
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.VisitorIP;
            parameters[3].Value = model.VCount;
            parameters[4].Value = model.Createdate;

            SqlExecuteNonQuery(sb.ToString(), parameters);
        }

        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("VisitorsReport OrderItem set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
    }
}
