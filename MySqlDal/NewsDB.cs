using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class NewsDB:DBBase
    {


        public List<mo.news> getModelListAll()
        {
            return setDr("select * from news where showC=1");
        }
        public List<mo.news> getAll_admin(string strWhere)
        {
            return setDr("select * from news " + strWhere + " order by sortC desc");
        }
        public List<mo.news> getModelListWhere(string strWhere)
        {
            return setDr("select * from news where showC=1 " + strWhere + " order by sortC desc");
        }
        public List<mo.news> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select * from news where showC=1 " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.news> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from news where showC=1 " + strWhere + " " + order + "");
        }
        private List<mo.news> setDr(string strSql)
        {
            List<mo.news> modelList = new List<mo.news>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.news model = new mo.news();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.news getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from news " + strWhere + "");
            mo.news model = new mo.news();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.news setModel(MySqlDataReader dr)
        {
            mo.news model = new mo.news();
            model.aboutC = dr["aboutC"].ToString();
            model.contentC = dr["contentC"].ToString();
            model.descriptionC = dr["descriptionC"].ToString();
            model.htmlName = dr["htmlName"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.keywordsC = dr["keywordsC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.sortC = int.Parse(dr["sortC"].ToString());
            model.timeC = dr["timeC"].ToString();
            model.titleC = dr["titleC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            model.typS = dr["typS"].ToString();
            model.showC = int.Parse(dr["showC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from news " + strWhere);
        }
        public void InsertModel(mo.news model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into news(aboutC,contentC,descriptionC,htmlName,keywordsC,nameC,sortC,timeC,titleC,typ,typS,showC,id) values (");
            sb.Append("@aboutC,@contentC,@descriptionC,@htmlName,@keywordsC,@nameC,@sortC,@timeC,@titleC,@typ,@typS,@showC,@id)");
            MySqlParameter[] parameters = { new MySqlParameter("@aboutC", MySqlDbType.VarChar, 0), new MySqlParameter("@contentC", MySqlDbType.VarChar, 0), new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100), new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@showC", MySqlDbType.Int32), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.aboutC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.descriptionC;
            parameters[3].Value = model.htmlName;
            parameters[4].Value = model.keywordsC;
            parameters[5].Value = model.nameC;
            parameters[6].Value = model.sortC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.titleC;
            parameters[9].Value = model.typ;
            parameters[10].Value = model.typS;
            parameters[11].Value = model.showC;
            parameters[12].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.news model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update news set "); sb.Append("aboutC=@aboutC,");
            sb.Append("contentC=@contentC,");
            sb.Append("descriptionC=@descriptionC,");
            sb.Append("htmlName=@htmlName,");
            sb.Append("keywordsC=@keywordsC,");
            sb.Append("nameC=@nameC,");
            sb.Append("sortC=@sortC,");
            sb.Append("timeC=@timeC,");
            sb.Append("titleC=@titleC,");
            sb.Append("typ=@typ,");
            sb.Append("typS=@typS,");
            sb.Append("showC=@showC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@aboutC", MySqlDbType.VarChar, 0), new MySqlParameter("@contentC", MySqlDbType.VarChar, 0), new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100), new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@typS", MySqlDbType.VarChar, 10), new MySqlParameter("@showC", MySqlDbType.Int32), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.aboutC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.descriptionC;
            parameters[3].Value = model.htmlName;
            parameters[4].Value = model.keywordsC;
            parameters[5].Value = model.nameC;
            parameters[6].Value = model.sortC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.titleC;
            parameters[9].Value = model.typ;
            parameters[10].Value = model.typS;
            parameters[11].Value = model.showC;
            parameters[12].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void updateContent(string content, int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update news set ");
            sb.Append("contentC=@contentC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@contentC", MySqlDbType.VarChar, 0),
                                          new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = content;
            parameters[1].Value = id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update news set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            SqlExecuteNonQuery("delete from news where id=" + id);
        }
        public void DelId(string id)
        {
            SqlExecuteNonQuery("delete from news where " + id);
        }
    }
}
