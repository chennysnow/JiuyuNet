using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class UserFavoriteDB:DBBase
    {
        public List<mo.userFavorite> getModelListAll()
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            MySqlDataReader dr = SqlReader("select * from userFavorite");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strWhere)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            MySqlDataReader dr = SqlReader("select * from userFavorite " + strWhere + " order by sortC desc");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            MySqlDataReader dr = SqlReader("select " + strTop + " * from userFavorite " + strWhere + " order by sortC desc");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            MySqlDataReader dr = SqlReader("select " + strTop + " * from userFavorite " + strWhere + " " + order + "");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.userFavorite getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from userFavorite " + strWhere + "");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.userFavorite setModel(MySqlDataReader dr)
        {
            mo.userFavorite model = new mo.userFavorite();
            model.id = int.Parse(dr["id"].ToString());
            model.proId = int.Parse(dr["proId"].ToString());
            model.sortC = int.Parse(dr["sortC"].ToString());
            model.userId = int.Parse(dr["userId"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from userFavorite " + strWhere);
        }
        public void InsertModel(mo.userFavorite model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into userFavorite(proId,sortC,userId) values (");
            sb.Append("@proId,@sortC,@userId)");
            MySqlParameter[] parameters = { new MySqlParameter("@proId", MySqlDbType.Int32), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@userId", MySqlDbType.Int32) };
            parameters[0].Value = model.proId;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.userId;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.userFavorite model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update userFavorite set ");
            sb.Append("proId=@proId,");
            sb.Append("sortC=@sortC,");
            sb.Append("userId=@userId");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@proId", MySqlDbType.Int32), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@userId", MySqlDbType.Int32), new MySqlParameter("@id", MySqlDbType.Int32) };

            parameters[0].Value = model.proId;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.userId;
            parameters[3].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update userFavorite set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from userFavorite where id=" + id);
        }
    }
}
