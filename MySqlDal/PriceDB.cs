using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class PriceDB:DBBase
    {
        public List<mo.price> getModelListAll()
        {
            List<mo.price> modelList = new List<mo.price>();
            MySqlDataReader dr = SqlReader("select * from price");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strWhere)
        {
            List<mo.price> modelList = new List<mo.price>();
            MySqlDataReader dr = SqlReader("select * from price " + strWhere + " order by priceC desc");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.price> modelList = new List<mo.price>();
            MySqlDataReader dr = SqlReader("select * from price " + strWhere + " order by priceC desc " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.price> modelList = new List<mo.price>();
            MySqlDataReader dr = SqlReader("select * from price " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.price getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from price " + strWhere + "");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.price setModel(MySqlDataReader dr)
        {
            mo.price model = new mo.price();
            model.id = int.Parse(dr["id"].ToString());
            model.maxC = int.Parse(dr["maxC"].ToString());
            model.minC = int.Parse(dr["minC"].ToString());
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            model.dayC = dr["dayC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from price " + strWhere);
        }
        public void InsertModel(mo.price model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into price(maxC,minC,priceC,typ,dayC) values (");
            sb.Append("@maxC,@minC,@priceC,@typ,@dayC)");
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@maxC",MySqlDbType.Int32),
                                             new MySqlParameter("@minC",MySqlDbType.Int32),
                                             new MySqlParameter("@priceC",MySqlDbType.Double,10),
                                             new MySqlParameter("@typ",MySqlDbType.Int32),
                                             new MySqlParameter("@dayC",MySqlDbType.VarChar,20)};
            parameters[0].Value = model.maxC;
            parameters[1].Value = model.minC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.dayC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.price model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update price set ");
            sb.Append("maxC=@maxC,");
            sb.Append("minC=@minC,");
            sb.Append("priceC=@priceC,");
            sb.Append("typ=@typ,");
            sb.Append("dayC=@dayC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@maxC",MySqlDbType.Int32),
                                             new MySqlParameter("@minC",MySqlDbType.Int32),
                                             new MySqlParameter("@priceC",MySqlDbType.Double,10),
                                             new MySqlParameter("@typ",MySqlDbType.Int32),
                                             new MySqlParameter("@dayC",MySqlDbType.VarChar,20),
                                              new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.maxC;
            parameters[1].Value = model.minC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.dayC;
            parameters[5].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update price set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from price where id=" + id);
        }
        public void DelByproductId(int productId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from price where typ=" + productId);
        }
    }
}
