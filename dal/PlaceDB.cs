using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class PlaceDB
    {
        public PlaceDB() { }
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.place> getModelListAll()
        {
            List<mo.place> modelList = new List<mo.place>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from place");
            mo.place model = new mo.place();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.place> getModelListWhere(string strWhere)
        {
            List<mo.place> modelList = new List<mo.place>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from place " + strWhere + " order by sortC desc");
            mo.place model = new mo.place();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.place> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.place> modelList = new List<mo.place>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from place " + strWhere + " order by sortC desc");
            mo.place model = new mo.place();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.place> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.place> modelList = new List<mo.place>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from place " + strWhere + " " + order + "");
            mo.place model = new mo.place();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.place getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from place " + strWhere + "");
            mo.place model = new mo.place();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.place setModel(OleDbDataReader dr)
        {
            mo.place model = new mo.place();
            model.id = (int)dr["id"];
            model.nameC = dr["nameC"].ToString();
            model.sortC = (int)dr["sortC"];
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from place " + strWhere);
        }
        public void InsertModel(mo.place model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into place(nameC,sortC) values (");
            sb.Append("@placeC,@sortC)");
            OleDbParameter[] parameters = { new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@sortC", OleDbType.Integer, 10) };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.sortC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.place model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update place set "); sb.Append("id=@id,");
            sb.Append("nameC=@nameC,");
            sb.Append("sortC=@sortC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@id", OleDbType.Integer, 10) };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update place set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from place where id=" + id);
        }
    }
}
