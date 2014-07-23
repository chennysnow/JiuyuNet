using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class expPayDB : DBBase
    {
        public List<mo.expPay> getModelListAll()
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            MySqlDataReader dr = SqlReader("select * from expPay");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strWhere)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            MySqlDataReader dr = SqlReader("select * from expPay " + strWhere + " order by sortC desc");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            MySqlDataReader dr = SqlReader("select  * from expPay " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            MySqlDataReader dr = SqlReader("select * from expPay " + strWhere + " " + order + " "+ strTop.ToLower().Replace("top", "LIMIT"));
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.expPay getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from expPay " + strWhere + "");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.expPay setModel(MySqlDataReader dr)
        {
            mo.expPay model = new mo.expPay();
            model.id = (int)dr["id"];
            model.nameC = dr["nameC"].ToString();
            model.tipsC = dr["tipsC"].ToString();
            if (dr["priceC"].ToString() != "")
                model.priceC = double.Parse(dr["priceC"].ToString());
            if (dr["sortC"].ToString() != "")
                model.sortC = (int)dr["sortC"];
            model.typ = (int)dr["typ"];
            model.imgC = dr["imgC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from expPay " + strWhere);
        }
        public void InsertModel(mo.expPay model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into expPay(nameC,tipsC,priceC,sortC,typ,imgC,id) values (");
            sb.Append("@nameC,@tipsC,@priceC,@sortC,@typ,@imgC,@id)");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@tipsC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                              new MySqlParameter("@sortC", MySqlDbType.Int32),
                                              new MySqlParameter("@typ", MySqlDbType.Int32),
                                              new MySqlParameter("@imgC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            parameters[5].Value = model.imgC;
            parameters[6].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.expPay model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update expPay set ");
            sb.Append("nameC=@nameC,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("priceC=@priceC,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ,");
            sb.Append("imgC=@imgC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@tipsC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                              new MySqlParameter("@sortC", MySqlDbType.Int32),
                                              new MySqlParameter("@typ", MySqlDbType.Int32),
                                              new MySqlParameter("@imgC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            parameters[5].Value = model.imgC;
            parameters[6].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update expPay set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            SqlExecuteNonQuery("delete from expPay where id=" + id);
        }

        public void AddExpress(string[] id,string[] name)
        {
            SqlExecuteNonQuery("delete from expPay where typ=0");

            string strSql ="";
            if (name == null || name.Length == 0)
                return;
            for (int i = 0; i < name.Length; i++)
            {
                strSql += string.Format("INSERT INTO `exppay` (nameC,tipsC,typ)VALUES ('{0}','{1}','0'); ", name[i], id[i]);
            }
            SqlExecuteNonQuery(strSql);
        }
    }
}
