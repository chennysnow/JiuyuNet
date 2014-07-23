using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class CouponDB : DBBase
    {
        
        public List<mo.coupon> getModelListAll()
        {
            return setDr("select * from coupon order by priceC desc");
        }
        public List<mo.coupon> getModelListWhere(string strWhere)
        {
            return setDr("select * from coupon " + strWhere + " order by priceC desc");
        }
        public List<mo.coupon> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select * from coupon " + strWhere + " order by priceC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.coupon> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select  * from coupon where " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.coupon> setDr(string strSql)
        {
            List<mo.coupon> modelList = new List<mo.coupon>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.coupon model = new mo.coupon();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.coupon getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from coupon " + strWhere + "");
            mo.coupon model = new mo.coupon();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.coupon setModel(MySqlDataReader dr)
        {
            mo.coupon model = new mo.coupon();
            model.id = int.Parse(dr["id"].ToString());
            model.numC = dr["numC"].ToString();
            model.tipsC = dr["tipsC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            model.userId = int.Parse(dr["userId"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from coupon " + strWhere);
        }
        public void InsertModel(mo.coupon model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into coupon(numC,tipsC,priceC,typ,userId) values (");
            sb.Append("@numC,@tipsC,@priceC,@typ,@userId)");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@numC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@tipsC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@priceC", MySqlDbType.Double,10),
                                          new MySqlParameter("@typ", MySqlDbType.Int32),
                                          new MySqlParameter("@userId", MySqlDbType.Int32)
                                          };
            parameters[0].Value = model.numC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.userId;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.coupon model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update coupon set ");
            sb.Append("numC=@numC,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("priceC=@priceC,");
            sb.Append("typ=@typ,");
            sb.Append("userId=@userId");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@numC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@tipsC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@priceC", MySqlDbType.Double,10),
                                          new MySqlParameter("@typ", MySqlDbType.Int32),
                                          new MySqlParameter("@userId", MySqlDbType.Int32),
                                          new MySqlParameter("@id", MySqlDbType.Int32)
                                          };
            parameters[0].Value = model.numC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.userId;
            parameters[5].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update coupon set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from coupon " + where);
        }
    }
}
