using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
   public class SearchWordsDB: DBBase
    {
        public List<mo.searchWords> getModelListAll()
        {
            List<mo.searchWords> modelList = new List<mo.searchWords>();
            MySqlDataReader dr = SqlReader("select * from searchWords");
            mo.searchWords model = new mo.searchWords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.searchWords> getModelListWhere(string strWhere)
        {
            List<mo.searchWords> modelList = new List<mo.searchWords>();
            MySqlDataReader dr = SqlReader("select * from searchWords " + strWhere + " order by countC desc");
            mo.searchWords model = new mo.searchWords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.searchWords> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.searchWords> modelList = new List<mo.searchWords>();
            MySqlDataReader dr = SqlReader("select * from searchWords " + strWhere + " order by countC desc " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.searchWords model = new mo.searchWords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.searchWords> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.searchWords> modelList = new List<mo.searchWords>();
            MySqlDataReader dr = SqlReader("select * from searchWords " + strWhere + " " + order + " "+ strTop.ToLower().Replace("top", "LIMIT"));
            mo.searchWords model = new mo.searchWords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.searchWords getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from searchWords " + strWhere + "");
            mo.searchWords model = new mo.searchWords();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.searchWords setModel(MySqlDataReader dr)
        {
            mo.searchWords model = new mo.searchWords();
            model.countC = int.Parse(dr["countC"].ToString());
            model.id = int.Parse(dr["id"].ToString());
            model.nameC = dr["nameC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from searchWords " + strWhere);
        }
        public void InsertModel(mo.searchWords model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into searchWords(countC,nameC) values (");
            sb.Append("@countC,@nameC)");
            MySqlParameter[] parameters = { new MySqlParameter("@countC", MySqlDbType.Int32), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255) };
            parameters[0].Value = model.countC;
            parameters[1].Value = model.nameC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.searchWords model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update searchWords set "); sb.Append("countC=@countC,");
            sb.Append("nameC=@nameC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@countC", MySqlDbType.Int32), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.countC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update searchWords set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from searchWords where id=" + id);
        }
    }
}
