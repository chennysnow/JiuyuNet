using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class MessageDB:DBBase
    {
        public List<mo.message> getModelListAll()
        {
            List<mo.message> modelList = new List<mo.message>();
            MySqlDataReader dr = SqlReader("select * from message");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strWhere)
        {
            List<mo.message> modelList = new List<mo.message>();
            MySqlDataReader dr = SqlReader("select * from message " + strWhere + " order by id desc");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.message> modelList = new List<mo.message>();
            MySqlDataReader dr = SqlReader("select * from message " + strWhere + " order by id desc " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.message> modelList = new List<mo.message>();
            MySqlDataReader dr = SqlReader("select  * from message " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.message getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from message " + strWhere + "");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.message setModel(MySqlDataReader dr)
        {
            mo.message model = new mo.message();
            model.addressC = dr["addressC"].ToString();
            model.contentC = dr["contentC"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.ipC = dr["ipC"].ToString();
            model.mailC = dr["mailC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.product = dr["product"].ToString();
            model.telC = dr["telC"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from message " + strWhere);
        }
        public void InsertModel(mo.message model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into message(addressC,contentC,ipC,mailC,nameC,product,telC,timeC,typ) values (");
            sb.Append("@addressC,@contentC,@ipC,@mailC,@nameC,@product,@telC,@timeC,@typ)");
            MySqlParameter[] parameters = { new MySqlParameter("@addressC", MySqlDbType.VarChar, 255), new MySqlParameter("@contentC", MySqlDbType.VarChar, 0), new MySqlParameter("@ipC", MySqlDbType.VarChar, 50), new MySqlParameter("@mailC", MySqlDbType.VarChar, 100), new MySqlParameter("@nameC", MySqlDbType.VarChar, 50), new MySqlParameter("@product", MySqlDbType.VarChar, 100), new MySqlParameter("@telC", MySqlDbType.VarChar, 50), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@typ", MySqlDbType.Int32) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.ipC;
            parameters[3].Value = model.mailC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.product;
            parameters[6].Value = model.telC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.message model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update message set "); sb.Append("addressC=@addressC,");
            sb.Append("contentC=@contentC,");
            sb.Append("ipC=@ipC,");
            sb.Append("mailC=@mailC,");
            sb.Append("nameC=@nameC,");
            sb.Append("product=@product,");
            sb.Append("telC=@telC,");
            sb.Append("timeC=@timeC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@addressC", MySqlDbType.VarChar, 255), new MySqlParameter("@contentC", MySqlDbType.VarChar, 0), new MySqlParameter("@ipC", MySqlDbType.VarChar, 50), new MySqlParameter("@mailC", MySqlDbType.VarChar, 100), new MySqlParameter("@nameC", MySqlDbType.VarChar, 50), new MySqlParameter("@product", MySqlDbType.VarChar, 100), new MySqlParameter("@telC", MySqlDbType.VarChar, 50), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.ipC;
            parameters[3].Value = model.mailC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.product;
            parameters[6].Value = model.telC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.typ;
            parameters[9].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update message set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            SqlExecuteNonQuery("delete from message where " + id);
        }
    }
}
