using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace dal
{
    public class attr
    {
        public attr() { }
        protected opDal.Operation ope = new opDal.Operation();
        public List<mo.attr> getModelListAll()
        {
            List<mo.attr> modelList = new List<mo.attr>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from attr order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strWhere)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from attr " + strWhere + " order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from attr " + strWhere + " order by sortC desc");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.attr> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.attr> modelList = new List<mo.attr>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from attr " + strWhere + " " + order + "");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.attr getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from attr " + strWhere + "");
            mo.attr model = new mo.attr();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.attr setModel(OleDbDataReader dr)
        {
            mo.attr model = new mo.attr();
            model.id = int.Parse(dr["id"].ToString());
            model.nameC = dr["nameC"].ToString();
            model.valueC = dr["valueC"].ToString();
            model.typ = dr["typ"].ToString();
            model.sortC = int.Parse(dr["sortC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from attr " + strWhere);
        }
        public void InsertModel(mo.attr model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into attr(nameC,valueC,typ,sortC) values (");
            sb.Append("@nameC,@valueC,@typ,@sortC)");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@valueC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@typ", OleDbType.VarChar,20),
                                          new OleDbParameter("@sortC", OleDbType.Integer,10)
                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.valueC;
            parameters[2].Value = model.typ;
            parameters[3].Value = model.sortC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.attr model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update attr set ");
            sb.Append("nameC=@nameC,");
            sb.Append("valueC=@valueC,");
            sb.Append("typ=@typ,");
            sb.Append("sortC=@sortC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@valueC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@typ", OleDbType.VarChar,20),
                                          new OleDbParameter("@sortC", OleDbType.Integer,10),
                                          new OleDbParameter("@id", OleDbType.Integer,10)
                                          };
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.valueC;
            parameters[2].Value = model.typ;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update attr set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from attr where " + where);
        }
    }
}
