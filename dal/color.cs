using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class color
    {
        public color() {/*¹¹Ôìº¯Êý*/}
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.color> getModelListAll()
        {
            List<mo.color> modelList = new List<mo.color>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from color");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strWhere)
        {
            List<mo.color> modelList = new List<mo.color>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from color " + strWhere + " order by sortC desc");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.color> modelList = new List<mo.color>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from color " + strWhere + " order by sortC desc");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.color> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.color> modelList = new List<mo.color>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from color " + strWhere + " " + order + "");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.color getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from color " + strWhere + "");
            mo.color model = new mo.color();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.color setModel(OleDbDataReader dr)
        {
            mo.color model = new mo.color();
            model.colorC = dr["colorC"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.tipsC = dr["tipsC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from color " + strWhere);
        }
        public void InsertModel(mo.color model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into color(colorC,id,tipsC,typ) values (");
            sb.Append("@colorC,@id,@tipsC,@typ)");
            OleDbParameter[] parameters = { new OleDbParameter("@colorC", OleDbType.VarChar, 20), new OleDbParameter("@id", OleDbType.Integer, 10), new OleDbParameter("@tipsC", OleDbType.VarChar, 50), new OleDbParameter("@typ", OleDbType.Integer, 10) };
            parameters[0].Value = model.colorC;
            parameters[1].Value = model.id;
            parameters[2].Value = model.tipsC;
            parameters[3].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.color model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update color set "); sb.Append("colorC=@colorC,");
            sb.Append("id=@id,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@colorC", OleDbType.VarChar, 20), new OleDbParameter("@id", OleDbType.Integer, 10), new OleDbParameter("@tipsC", OleDbType.VarChar, 50), new OleDbParameter("@typ", OleDbType.Integer, 10) };
            parameters[0].Value = model.colorC;
            parameters[1].Value = model.id;
            parameters[2].Value = model.tipsC;
            parameters[3].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update color set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from color where id=" + id);
        }
    }
}
