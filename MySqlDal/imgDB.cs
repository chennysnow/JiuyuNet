using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class imgDB : DBBase
    {
        public List<mo.img> getModelListAll()
        {
            List<mo.img> modelList = new List<mo.img>();
            MySqlDataReader dr = SqlReader("select * from img");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strWhere)
        {
            List<mo.img> modelList = new List<mo.img>();
            MySqlDataReader dr = SqlReader("select * from img " + strWhere + " order by sortC desc");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.img> modelList = new List<mo.img>();
            MySqlDataReader dr = SqlReader("select * from img " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.img> modelList = new List<mo.img>();
            MySqlDataReader dr = SqlReader("select * from img " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.img getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from img " + strWhere + "");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.img setModel(MySqlDataReader dr)
        {
            mo.img model = new mo.img();
            model.id = (int)dr["id"];
            model.imgC = dr["imgC"].ToString();
            model.sortC = (int)dr["sortC"];
            model.typ = (int)dr["typ"];
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from img " + strWhere);
        }
        public void InsertModel(mo.img model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into img(imgC,sortC,typ) values (");
            sb.Append("@imgC,@sortC,@typ)");
            MySqlParameter[] parameters = { new MySqlParameter("@imgC", MySqlDbType.VarChar, 100), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@typ", MySqlDbType.Int32) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.img model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update img set "); sb.Append("id=@id,");
            sb.Append("imgC=@imgC,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@id", MySqlDbType.Int32), new MySqlParameter("@imgC", MySqlDbType.VarChar, 100), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@typ", MySqlDbType.Int32) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.imgC;
            parameters[2].Value = model.sortC;
            parameters[3].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update img set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from img where id=" + id);
        }
    }
}
