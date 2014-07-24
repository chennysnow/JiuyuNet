using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class expPay
    {
        public expPay() { }
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.expPay> getModelListAll()
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from expPay");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strWhere)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from expPay " + strWhere + " order by sortC desc");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from expPay " + strWhere + " order by sortC desc");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPay> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.expPay> modelList = new List<mo.expPay>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from expPay " + strWhere + " " + order + "");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.expPay getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from expPay " + strWhere + "");
            mo.expPay model = new mo.expPay();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.expPay setModel(OleDbDataReader dr)
        {
            mo.expPay model = new mo.expPay();
            model.id = (int)dr["id"];
            model.nameC = dr["nameC"].ToString();
            model.tipsC = dr["tipsC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.sortC = (int)dr["sortC"];
            model.typ = (int)dr["typ"];
            model.imgC = dr["imgC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from expPay " + strWhere);
        }
        public void InsertModel(mo.expPay model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into expPay(nameC,tipsC,priceC,sortC,typ,imgC,id) values (");
            sb.Append("@nameC,@tipsC,@priceC,@sortC,@typ,@imgC,@id)");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                              new OleDbParameter("@tipsC", OleDbType.VarChar, 255),
                                              new OleDbParameter("@priceC", OleDbType.Double, 10),
                                              new OleDbParameter("@sortC", OleDbType.Integer, 10),
                                              new OleDbParameter("@typ", OleDbType.Integer, 10),
                                              new OleDbParameter("@imgC", OleDbType.VarChar, 255),
                                              new OleDbParameter("@id", OleDbType.Integer, 10)};
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            parameters[5].Value = model.imgC;
            parameters[6].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.expPay model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update expPay set ");
            sb.Append("nameC=@nameC,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("priceC=@priceC,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ,");
            sb.Append("imgC=@imgC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                              new OleDbParameter("@tipsC", OleDbType.VarChar, 255),
                                              new OleDbParameter("@priceC", OleDbType.Double, 10),
                                              new OleDbParameter("@sortC", OleDbType.Integer, 10),
                                              new OleDbParameter("@typ", OleDbType.Integer, 10),
                                              new OleDbParameter("@imgC", OleDbType.VarChar, 255),
                                              new OleDbParameter("@id", OleDbType.Integer, 10)};
            parameters[0].Value = model.nameC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.sortC;
            parameters[4].Value = model.typ;
            parameters[5].Value = model.imgC;
            parameters[6].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update expPay set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from expPay where id=" + id);
        }
    }
}
