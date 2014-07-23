using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class FlashDB:DBBase
    {
        public List<mo.flash> getModelListAll()
        {
            List<mo.flash> modelList = new List<mo.flash>();
            MySqlDataReader dr = SqlReader("select * from flash");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strWhere)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            MySqlDataReader dr = SqlReader("select * from flash " + strWhere + " order by id desc");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            MySqlDataReader dr = SqlReader("select * from flash " + strWhere + " order by id desc "+ strTop.ToLower().Replace("top", "LIMIT"));
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            MySqlDataReader dr = SqlReader("select * from flash " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.flash getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from flash " + strWhere + "");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.flash setModel(MySqlDataReader dr)
        {
            mo.flash model = new mo.flash();
            model.id = (int)dr["id"];
            model.imgC = dr["imgC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.typS = dr["typS"].ToString();
            model.urlC = dr["urlC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from flash " + strWhere);
        }
        public void InsertModel(mo.flash model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into flash(imgC,nameC,typS,urlC) values (");
            sb.Append("@imgC,@nameC,@typS,@urlC)");
            MySqlParameter[] parameters = { new MySqlParameter("@imgC", MySqlDbType.VarChar, 255), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@urlC", MySqlDbType.VarChar, 255) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.typS;
            parameters[3].Value = model.urlC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.flash model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update flash set ");
            sb.Append("imgC=@imgC,");
            sb.Append("nameC=@nameC,");
            sb.Append("typS=@typS,");
            sb.Append("urlC=@urlC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@imgC", MySqlDbType.VarChar, 255), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@urlC", MySqlDbType.VarChar, 255), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.typS;
            parameters[3].Value = model.urlC;
            parameters[4].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update flash set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            SqlExecuteNonQuery("delete from flash where " + id);
        }
    }
}
