using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class BoxDB : DBBase
    {
        public List<mo.box> getModelListAll()
        {
            return setDr("select * from box");
        }
        public List<mo.box> getModelListWhere(string strWhere)
        {
            return setDr("select * from box " + strWhere + " order by id desc");
        }
        public List<mo.box> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select  * from box " + strWhere + " order by id desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.box> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select  * from box " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.box> setDr(string strSql)
        {
            List<mo.box> modelList = new List<mo.box>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.box model = new mo.box();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.box getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from box " + strWhere + "");
            mo.box model = new mo.box();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.box setModel(MySqlDataReader dr)
        {
            mo.box model = new mo.box();
            model.id = int.Parse(dr["id"].ToString());
            model.nameC = dr["nameC"].ToString();
            model.sizeC = double.Parse(dr["sizeC"].ToString());
            model.weightC = double.Parse(dr["weightC"].ToString());
            model.imgC = dr["imgC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.aboutC = dr["aboutC"].ToString();
            model.countC = int.Parse(dr["countC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from box " + strWhere);
        }
        public void InsertModel(mo.box model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into box(nameC,sizeC,weightC,imgC,priceC,aboutC,countC) values (");
            sb.Append("@nameC,@sizeC,@weightC,@imgC,@priceC,@aboutC,@countC)");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@sizeC", MySqlDbType.Double, 10),
                                          new MySqlParameter("@weightC", MySqlDbType.Double,10),
                                          new MySqlParameter("@imgC", MySqlDbType.VarChar,50),
                                          new MySqlParameter("@priceC", MySqlDbType.Double,10),
                                          new MySqlParameter("@aboutC", MySqlDbType.VarChar,255),  
                                          new MySqlParameter("@countC", MySqlDbType.Int32)

                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.sizeC;
            parameters[2].Value = model.weightC;
            parameters[3].Value = model.imgC;
            parameters[4].Value = model.priceC;
            parameters[5].Value = model.aboutC;
            parameters[6].Value = model.countC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.box model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update box set ");
            sb.Append("nameC=@nameC,");
            sb.Append("sizeC=@sizeC,");
            sb.Append("weightC=@weightC,");
            sb.Append("imgC=@imgC,");
            sb.Append("priceC=@priceC,");
            sb.Append("aboutC=@aboutC,");
            sb.Append("countC=@countC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                                          new MySqlParameter("@nameC", MySqlDbType.VarChar, 50),
                                          new MySqlParameter("@sizeC", MySqlDbType.Double, 10),
                                          new MySqlParameter("@weightC", MySqlDbType.Double,10),
                                          new MySqlParameter("@imgC", MySqlDbType.VarChar,50),
                                          new MySqlParameter("@priceC", MySqlDbType.Double,10),
                                          new MySqlParameter("@aboutC", MySqlDbType.VarChar,255),  
                                          new MySqlParameter("@countC", MySqlDbType.Int32),
                                          new MySqlParameter("@id", MySqlDbType.Int32)
                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.sizeC;
            parameters[2].Value = model.weightC;
            parameters[3].Value = model.imgC;
            parameters[4].Value = model.priceC;
            parameters[5].Value = model.aboutC;
            parameters[6].Value = model.countC;
            parameters[7].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update box set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from box where " + where);
        }
    }
}
