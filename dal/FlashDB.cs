using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class FlashDB
    {
        public FlashDB() {/*¹¹Ôìº¯Êý*/}
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.flash> getModelListAll()
        {
            List<mo.flash> modelList = new List<mo.flash>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from flash");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strWhere)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from flash " + strWhere + " order by id desc");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from flash " + strWhere + " order by id desc");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.flash> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.flash> modelList = new List<mo.flash>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from flash " + strWhere + " " + order + "");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.flash getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from flash " + strWhere + "");
            mo.flash model = new mo.flash();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.flash setModel(OleDbDataReader dr)
        {
            mo.flash model = new mo.flash();
            model.id = (int)dr["id"];
            model.imgC = dr["imgC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.typS = dr["typS"].ToString();
            model.urlC = dr["urlC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from flash " + strWhere);
        }
        public void InsertModel(mo.flash model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into flash(imgC,nameC,typS,urlC) values (");
            sb.Append("@imgC,@nameC,@typS,@urlC)");
            OleDbParameter[] parameters = { new OleDbParameter("@imgC", OleDbType.VarChar, 255), new OleDbParameter("@nameC", OleDbType.VarChar, 255), new OleDbParameter("@typS", OleDbType.VarChar, 10), new OleDbParameter("@urlC", OleDbType.VarChar, 255) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.typS;
            parameters[3].Value = model.urlC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.flash model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update flash set ");
            sb.Append("imgC=@imgC,");
            sb.Append("nameC=@nameC,");
            sb.Append("typS=@typS,");
            sb.Append("urlC=@urlC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@imgC", OleDbType.VarChar, 255), new OleDbParameter("@nameC", OleDbType.VarChar, 255), new OleDbParameter("@typS", OleDbType.VarChar, 10), new OleDbParameter("@urlC", OleDbType.VarChar, 255), new OleDbParameter("@id", OleDbType.Integer, 10) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.nameC;
            parameters[2].Value = model.typS;
            parameters[3].Value = model.urlC;
            parameters[4].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update flash set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from flash where " + id);
        }
    }
}
