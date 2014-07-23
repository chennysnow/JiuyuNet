using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
  public class LinkDB:DBBase
    {
        public List<mo.link> getModelListAll()
        {
            List<mo.link> modelList = new List<mo.link>();
            MySqlDataReader dr = SqlReader("select * from link");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strWhere)
        {
            List<mo.link> modelList = new List<mo.link>();
            MySqlDataReader dr = SqlReader("select * from link " + strWhere + " ");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.link> modelList = new List<mo.link>();
            MySqlDataReader dr = SqlReader("select * from link " + strWhere + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.link> modelList = new List<mo.link>();
            MySqlDataReader dr = SqlReader("select * from link " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.link getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from link " + strWhere + "");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.link setModel(MySqlDataReader dr)
        {
            mo.link model = new mo.link();
            model.id = (int)dr["id"];
            model.nameC = dr["nameC"].ToString();
            model.typS = dr["typS"].ToString();
            model.urlC = dr["urlC"].ToString();
            model.logo = dr["logo"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from link " + strWhere);
        }
        public void InsertModel(mo.link model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into link(nameC,typS,urlC,logo) values (");
            sb.Append("@nameC,@typS,@urlC,@logo)");
            MySqlParameter[] parameters = { new MySqlParameter("@nameC", MySqlDbType.VarChar, 100), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@urlC", MySqlDbType.VarChar, 255), new MySqlParameter("@logo", MySqlDbType.VarChar, 255) };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.typS;
            parameters[2].Value = model.urlC;
            parameters[3].Value = model.logo;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.link model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update link set ");
            sb.Append("nameC=@nameC,");
            sb.Append("typS=@typS,");
            sb.Append("urlC=@urlC,");
            sb.Append("logo=@logo");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@nameC", MySqlDbType.VarChar, 100), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@urlC", MySqlDbType.VarChar, 255), new MySqlParameter("@logo", MySqlDbType.VarChar, 255), new MySqlParameter("@id", MySqlDbType.Int32) };

            parameters[0].Value = model.nameC;
            parameters[1].Value = model.typS;
            parameters[2].Value = model.urlC;
            parameters[3].Value = model.logo;
            parameters[4].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update link set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from link where " + where);
        }
    }
}
