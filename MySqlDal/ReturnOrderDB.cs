using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class ReturnOrderDB : DBBase
    {
        public List<mo.returnOrder> getModelListAll()
        {
            return setDr("select * from returnOrder");
        }
        public List<mo.returnOrder> getModelListWhere(string strWhere)
        {
            return setDr("select * from returnOrder " + strWhere + " order by timeC desc");
        }
        public List<mo.returnOrder> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select  * from returnOrder " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.returnOrder> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from returnOrder " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.returnOrder> setDr(string strSql)
        {
            List<mo.returnOrder> modelList = new List<mo.returnOrder>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.returnOrder model = new mo.returnOrder();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.returnOrder getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from returnOrder " + strWhere + "");
            mo.returnOrder model = new mo.returnOrder();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.returnOrder setModel(MySqlDataReader dr)
        {
            mo.returnOrder model = new mo.returnOrder();
            model.id = int.Parse(dr["id"].ToString());
            model.orderC = dr["orderC"].ToString();
            model.userName = dr["userName"].ToString();
            model.methodC = dr["methodC"].ToString();
            model.priceC = dr["priceC"].ToString();
            model.reasonC = dr["reasonc"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.proList = dr["proList"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            model.messageC = dr["messageC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from returnOrder " + strWhere);
        }
        public void InsertModel(mo.returnOrder model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into returnOrder(orderC,userName,methodC,priceC,reasonC,timeC,proList,typ,messageC) values (");
            sb.Append("@orderC,@userName,@methodC,@priceC,@reasonC,@timeC,@proList,@typ,@messageC)");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@orderC", MySqlDbType.VarChar, 30),
                                          new MySqlParameter("@userName", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@methodC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@priceC", MySqlDbType.VarChar, 20),
                                          new MySqlParameter("@reasonC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@timeC", MySqlDbType.VarChar, 20),
                                          new MySqlParameter("@proList", MySqlDbType.VarChar,255),
                                          new MySqlParameter("@typ", MySqlDbType.Int32),
                                          new MySqlParameter("@messageC", MySqlDbType.VarChar)
                                          };
            parameters[0].Value = model.orderC;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.methodC;
            parameters[3].Value = model.priceC;
            parameters[4].Value = model.reasonC;
            parameters[5].Value = model.timeC;
            parameters[6].Value = model.proList;
            parameters[7].Value = model.typ;
            parameters[8].Value = model.messageC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.returnOrder model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update returnOrder set ");
            sb.Append("orderC=@orderC,");
            sb.Append("userName=@userName,");
            sb.Append("methodC=@methodC,");
            sb.Append("priceC=@priceC,");
            sb.Append("reasonC=@reasonC,");
            sb.Append("timeC=@timeC,");
            sb.Append("proList=@proList,");
            sb.Append("typ=@typ,");
            sb.Append("messageC=@messageC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@orderC", MySqlDbType.VarChar, 30),
                                          new MySqlParameter("@userName", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@methodC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@priceC", MySqlDbType.VarChar, 20),
                                          new MySqlParameter("@reasonC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@timeC", MySqlDbType.VarChar, 20),
                                          new MySqlParameter("@proList", MySqlDbType.VarChar,255),
                                          new MySqlParameter("@typ", MySqlDbType.Int32),
                                          new MySqlParameter("@messageC", MySqlDbType.VarChar),
                                          new MySqlParameter("@id", MySqlDbType.Int32)
                                          };
            parameters[0].Value = model.orderC;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.methodC;
            parameters[3].Value = model.priceC;
            parameters[4].Value = model.reasonC;
            parameters[5].Value = model.timeC;
            parameters[6].Value = model.proList;
            parameters[7].Value = model.typ;
            parameters[8].Value = model.messageC;
            parameters[9].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update returnOrder set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from returnOrder where " + where);
        }
    }
}
