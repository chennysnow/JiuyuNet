using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class LinkDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.link> getModelListAll()
        {
            List<mo.link> modelList = new List<mo.link>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from link");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strWhere)
        {
            List<mo.link> modelList = new List<mo.link>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from link " + strWhere + " ");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.link> modelList = new List<mo.link>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from link " + strWhere + " ");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.link> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.link> modelList = new List<mo.link>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from link " + strWhere + " " + order + "");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.link getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from link " + strWhere + "");
            mo.link model = new mo.link();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.link setModel(OleDbDataReader dr)
        {
            mo.link model = new mo.link();
            model.id = (int)dr["id"];
            model.nameC = dr["nameC"].ToString();
            model.typS = dr["typS"].ToString();
            model.urlC = dr["urlC"].ToString();
            model.logo = dr["logo"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from link " + strWhere);
        }
        public void InsertModel(mo.link model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into link(nameC,typS,urlC,logo) values (");
            sb.Append("@nameC,@typS,@urlC,@logo)");
            OleDbParameter[] parameters = { new OleDbParameter("@nameC", OleDbType.VarChar, 100), new OleDbParameter("@typS", OleDbType.VarChar, 10), new OleDbParameter("@urlC", OleDbType.VarChar, 255), new OleDbParameter("@logo", OleDbType.VarChar, 255) };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.typS;
            parameters[2].Value = model.urlC;
            parameters[3].Value = model.logo;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.link model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update link set ");
            sb.Append("nameC=@nameC,");
            sb.Append("typS=@typS,");
            sb.Append("urlC=@urlC,");
            sb.Append("logo=@logo");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@nameC", OleDbType.VarChar, 100), new OleDbParameter("@typS", OleDbType.VarChar, 10), new OleDbParameter("@urlC", OleDbType.VarChar, 255), new OleDbParameter("@logo", OleDbType.VarChar, 255), new OleDbParameter("@id", OleDbType.Integer, 10) };

            parameters[0].Value = model.nameC;
            parameters[1].Value = model.typS;
            parameters[2].Value = model.urlC;
            parameters[3].Value = model.logo;
            parameters[4].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update link set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from link where " + where);
        }
    }
}
