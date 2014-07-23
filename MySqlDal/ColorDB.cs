using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class ColorDB : DBBase
    {
        public List<mo.color> getModelListAll()
        {
            List<mo.color> modelList = new List<mo.color>();
            MySqlDataReader dr = SqlReader("select * from color");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strWhere)
        {
            List<mo.color> modelList = new List<mo.color>();
            MySqlDataReader dr = SqlReader("select * from color " + strWhere + " order by sortC desc");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.color> modelList = new List<mo.color>();
            MySqlDataReader dr = SqlReader("select " + strTop + " * from color " + strWhere + " order by sortC desc");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.color> modelList = new List<mo.color>();
            MySqlDataReader dr = SqlReader("select " + strTop + " * from color " + strWhere + " " + order + "");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.color getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from color " + strWhere + "");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.color setModel(MySqlDataReader dr)
        {
            mo.color model = new mo.color();
            model.colorC = dr["colorC"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.tipsC = dr["tipsC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from color " + strWhere);
        }
        public void InsertModel(mo.color model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into color(colorC,id,tipsC,typ) values (");
            sb.Append("@colorC,@id,@tipsC,@typ)");
            MySqlParameter[] parameters = { new MySqlParameter("@colorC", MySqlDbType.VarChar, 20), new MySqlParameter("@id", MySqlDbType.Int32), new MySqlParameter("@tipsC", MySqlDbType.VarChar, 50), new MySqlParameter("@typ", MySqlDbType.Int32) };
            parameters[0].Value = model.colorC;
            parameters[1].Value = model.id;
            parameters[2].Value = model.tipsC;
            parameters[3].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.color model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update color set "); sb.Append("colorC=@colorC,");
            sb.Append("id=@id,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@colorC", MySqlDbType.VarChar, 20), new MySqlParameter("@id", MySqlDbType.Int32), new MySqlParameter("@tipsC", MySqlDbType.VarChar, 50), new MySqlParameter("@typ", MySqlDbType.Int32) };
            parameters[0].Value = model.colorC;
            parameters[1].Value = model.id;
            parameters[2].Value = model.tipsC;
            parameters[3].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update color set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from color where id=" + id);
        }
    }
}
