using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class BrandDB : DBBase
    {
        public List<mo.brand> getModelListAll()
        {
            return setDr("select * from brand order by sortC desc");
        }
        public List<mo.brand> getModelListWhere(string strWhere)
        {
            return setDr("select * from brand " + strWhere + " order by sortC desc");
        }
        public List<mo.brand> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select  * from brand " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.brand> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select  * from brand " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.brand> setDr(string strSql)
        {
            List<mo.brand> modelList = new List<mo.brand>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.brand model = new mo.brand();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.brand getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from brand " + strWhere + "");
            mo.brand model = new mo.brand();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.brand setModel(MySqlDataReader dr)
        {
            mo.brand model = new mo.brand();
            model.id = int.Parse(dr["id"].ToString());
            model.imgC = dr["imgC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.aboutC = dr["aboutC"].ToString();
            model.sortC = int.Parse(dr["sortC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from brand " + strWhere);
        }
        public void InsertModel(mo.brand model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into brand(imgC,nameC,aboutC,sortC,typ) values (");
            sb.Append("@imgC,@nameC,@aboutC,@sortC,@typ)");
            MySqlParameter[] parameters = { 
                            new MySqlParameter("@imgC", MySqlDbType.VarChar, 255), 
                            new MySqlParameter("@nameC", MySqlDbType.VarChar, 255),
                            new MySqlParameter("@aboutC", MySqlDbType.VarChar),
                            new MySqlParameter("@sortC", MySqlDbType.Int32),
                            new MySqlParameter("@typ", MySqlDbType.Int32)};
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.aboutC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.brand model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update brand set ");
            sb.Append("imgC=@imgC,");
            sb.Append("nameC=@nameC,");
            sb.Append("aboutC=@aboutC,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                            new MySqlParameter("@imgC", MySqlDbType.VarChar, 255), 
                            new MySqlParameter("@nameC", MySqlDbType.VarChar, 255),
                            new MySqlParameter("@aboutC", MySqlDbType.VarChar),
                            new MySqlParameter("@sortC", MySqlDbType.Int32),
                            new MySqlParameter("@typ", MySqlDbType.Int32),
                            new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.aboutC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            parameters[5].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update brand set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from brand " + where);
        }
    }
}
