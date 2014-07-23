using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class OrderProBD : DBBase
    {
        public List<mo.orderPro> getModelListAll()
        {
            List<mo.orderPro> modelList = new List<mo.orderPro>();
            MySqlDataReader dr = SqlReader("select * from orderPro");
            mo.orderPro model = new mo.orderPro();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.orderPro> getModelListWhere(string strWhere)
        {
            List<mo.orderPro> modelList = new List<mo.orderPro>();
            MySqlDataReader dr = SqlReader("select * from orderPro " + strWhere + "");
            mo.orderPro model = new mo.orderPro();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.orderPro> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.orderPro> modelList = new List<mo.orderPro>();
            MySqlDataReader dr = SqlReader("select * from orderPro " + strWhere + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.orderPro model = new mo.orderPro();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.orderPro> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.orderPro> modelList = new List<mo.orderPro>();
            MySqlDataReader dr = SqlReader("select * from orderPro " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
            mo.orderPro model = new mo.orderPro();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.orderPro getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from orderPro " + strWhere + "");
            mo.orderPro model = new mo.orderPro();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.orderPro setModel(MySqlDataReader dr)
        {
            mo.orderPro model = new mo.orderPro();
            model.countC = int.Parse(dr["countC"].ToString());
            model.htmlName = dr["htmlName"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.imgC = dr["imgC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.numC = dr["numC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.proId = dr["proId"].ToString();
            model.remarkC = dr["remarkC"].ToString();
            model.weightC = double.Parse(dr["weightC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from orderPro " + strWhere);
        }
        public void InsertModel(mo.orderPro model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into orderPro(countC,htmlName,imgC,nameC,numC,priceC,proId,remarkC,weightC) values (");
            sb.Append("@countC,@htmlName,@imgC,@nameC,@numC,@priceC,@proId,@remarkC,@weightC)");
            MySqlParameter[] parameters = { new MySqlParameter("@countC", MySqlDbType.Int32), new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100), new MySqlParameter("@imgC", MySqlDbType.VarChar, 100), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@numC", MySqlDbType.VarChar, 20), new MySqlParameter("@priceC", MySqlDbType.VarChar, 0), new MySqlParameter("@proId", MySqlDbType.VarChar, 50), new MySqlParameter("@remarkC", MySqlDbType.VarChar, 255), new MySqlParameter("@weightC", MySqlDbType.VarChar, 0) };
            parameters[0].Value = model.countC;
            parameters[1].Value = model.htmlName;
            parameters[2].Value = model.imgC;
            parameters[3].Value = model.nameC;
            parameters[4].Value = model.numC;
            parameters[5].Value = model.priceC;
            parameters[6].Value = model.proId;
            parameters[7].Value = model.remarkC;
            parameters[8].Value = model.weightC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.orderPro model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update orderPro set "); sb.Append("countC=@countC,");
            sb.Append("htmlName=@htmlName,");
            sb.Append("imgC=@imgC,");
            sb.Append("nameC=@nameC,");
            sb.Append("numC=@numC,");
            sb.Append("priceC=@priceC,");
            sb.Append("proId=@proId,");
            sb.Append("remarkC=@remarkC,");
            sb.Append("weightC=@weightC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@countC", MySqlDbType.Int32), new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100), new MySqlParameter("@imgC", MySqlDbType.VarChar, 100), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@numC", MySqlDbType.VarChar, 20), new MySqlParameter("@priceC", MySqlDbType.VarChar, 0), new MySqlParameter("@proId", MySqlDbType.VarChar, 50), new MySqlParameter("@remarkC", MySqlDbType.VarChar, 255), new MySqlParameter("@weightC", MySqlDbType.VarChar, 0) };
            parameters[0].Value = model.countC;
            parameters[1].Value = model.htmlName;
            parameters[2].Value = model.imgC;
            parameters[3].Value = model.nameC;
            parameters[4].Value = model.numC;
            parameters[5].Value = model.priceC;
            parameters[6].Value = model.proId;
            parameters[7].Value = model.remarkC;
            parameters[8].Value = model.weightC;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update orderPro set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            SqlExecuteNonQuery("delete from orderPro where id=" + id);
        }
    }
}
