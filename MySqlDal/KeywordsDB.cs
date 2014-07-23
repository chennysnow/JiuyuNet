using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class KeywordsDB:DBBase
    {
        public List<mo.keywords> getModelListAll()
        {
            List<mo.keywords> modelList = new List<mo.keywords>();
            MySqlDataReader dr = SqlReader("select * from keywords");
            mo.keywords model = new mo.keywords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.keywords> getModelListWhere(string strWhere)
        {
            List<mo.keywords> modelList = new List<mo.keywords>();
            MySqlDataReader dr = SqlReader("select * from keywords " + strWhere + " ");
            mo.keywords model = new mo.keywords();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.keywords getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from keywords where typS='" + strWhere + "'");
            mo.keywords model = new mo.keywords();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.keywords setModel(MySqlDataReader dr)
        {
            mo.keywords model = new mo.keywords();
            model.descriptionC = dr["descriptionC"].ToString();
            model.id = (int)dr["id"];
            model.keywordsC = dr["keywordsC"].ToString();
            model.titleC = dr["titleC"].ToString();
            model.typS = dr["typS"].ToString();
            model.tipsC = dr["tipsC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from keywords " + strWhere);
        }
        public void InsertModel(mo.keywords model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into keywords(descriptionC,keywordsC,titleC,typS,tipsC) values (");
            sb.Append("@descriptionC,@id,@keywordsC,@titleC,@typS,@tipsC)");
            MySqlParameter[] parameters = { new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255), new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@tipsC", MySqlDbType.VarChar, 50) };
            parameters[0].Value = model.descriptionC;
            parameters[1].Value = model.keywordsC;
            parameters[2].Value = model.titleC;
            parameters[3].Value = model.typS;
            parameters[4].Value = model.tipsC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.keywords model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update keywords set "); sb.Append("descriptionC=@descriptionC,");
            sb.Append("keywordsC=@keywordsC,");
            sb.Append("titleC=@titleC,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("typS=@typS");
            sb.Append(" where typS=@typS");
            MySqlParameter[] parameters = { new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255), new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), new MySqlParameter("@tipsC", MySqlDbType.VarChar, 50), new MySqlParameter("@typS", MySqlDbType.VarChar, 10) };
            parameters[0].Value = model.descriptionC;
            parameters[1].Value = model.keywordsC;
            parameters[2].Value = model.titleC;
            parameters[3].Value = model.tipsC;
            parameters[4].Value = model.typS;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update keywords set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            SqlExecuteNonQuery("delete from keywords where id=" + id);
        }
    }
}
