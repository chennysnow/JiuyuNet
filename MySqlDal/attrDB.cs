using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace MySqlDal
{
    public class attrDB : DBBase
    {
     
        public List<mo.attr> getModelListAll()
        {
            List<mo.attr> modelList = new List<mo.attr>();
            MySqlDataReader dr = SqlReader("select * from attr order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strWhere)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            MySqlDataReader dr = SqlReader("select * from attr " + strWhere + " order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            MySqlDataReader dr = SqlReader("select " + strTop + " * from attr " + strWhere + " order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            MySqlDataReader dr = SqlReader("select * from attr " + strWhere + " " + order + strTop.ToLower().Replace("top", "LIMIT"));
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.attr getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from attr " + strWhere + "");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.attr setModel(MySqlDataReader dr)
        {
            mo.attr model = new mo.attr();
            model.id = int.Parse(dr["id"].ToString());
            model.nameC = dr["nameC"].ToString();
            model.valueC = dr["valueC"].ToString();
            model.typ = dr["typ"].ToString();
            model.sortC = int.Parse(dr["sortC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from attr " + strWhere);
        }
        public void InsertModel(mo.attr model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into attr(nameC,valueC,typ,sortC) values (");
            sb.Append("@nameC,@valueC,@typ,@sortC)");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@valueC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@typ", MySqlDbType.VarChar,20),
                                          new MySqlParameter("@sortC", MySqlDbType.Int24)
                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.valueC;
            parameters[2].Value = model.typ;
            parameters[3].Value = model.sortC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.attr model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update attr set ");
            sb.Append("nameC=@nameC,");
            sb.Append("valueC=@valueC,");
            sb.Append("typ=@typ,");
            sb.Append("sortC=@sortC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@valueC", MySqlDbType.VarChar, 255),
                                          new MySqlParameter("@typ", MySqlDbType.VarChar,20),
                                          new MySqlParameter("@sortC", MySqlDbType.Int24),
                                          new MySqlParameter("@id", MySqlDbType.Int24)
                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.valueC;
            parameters[2].Value = model.typ;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update attr set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from attr where " + where);
        }
    }
}
