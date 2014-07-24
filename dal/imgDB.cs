using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class imgDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.img> getModelListAll()
        {
            List<mo.img> modelList = new List<mo.img>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from img");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strWhere)
        {
            List<mo.img> modelList = new List<mo.img>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from img " + strWhere + " order by sortC desc");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.img> modelList = new List<mo.img>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from img " + strWhere + " order by sortC desc");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.img> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.img> modelList = new List<mo.img>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from img " + strWhere + " " + order + "");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.img getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from img " + strWhere + "");
            mo.img model = new mo.img();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.img setModel(OleDbDataReader dr)
        {
            mo.img model = new mo.img();
            model.id = (int)dr["id"];
            model.imgC = dr["imgC"].ToString();
            model.sortC = (int)dr["sortC"];
            model.typ = (int)dr["typ"];
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from img " + strWhere);
        }
        public void InsertModel(mo.img model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into img(imgC,sortC,typ) values (");
            sb.Append("@imgC,@sortC,@typ)");
            OleDbParameter[] parameters = { new OleDbParameter("@imgC", OleDbType.VarChar, 100), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@typ", OleDbType.Integer, 10) };
            parameters[0].Value = model.imgC;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.img model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update img set "); sb.Append("id=@id,");
            sb.Append("imgC=@imgC,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@id", OleDbType.Integer, 10), new OleDbParameter("@imgC", OleDbType.VarChar, 100), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@typ", OleDbType.Integer, 10) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.imgC;
            parameters[2].Value = model.sortC;
            parameters[3].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update img set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from img where id=" + id);
        }
    }
}
