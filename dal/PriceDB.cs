using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class PriceDB
    {
        public PriceDB() {/*¹¹Ôìº¯Êý*/}
        //protected op.Operation ope = new op.Operation();

        public List<mo.price> getModelListAll()
        {
            List<mo.price> modelList = new List<mo.price>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from price");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strWhere)
        {
            List<mo.price> modelList = new List<mo.price>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from price " + strWhere + " order by priceC desc");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.price> modelList = new List<mo.price>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from price " + strWhere + " order by priceC desc");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.price> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.price> modelList = new List<mo.price>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from price " + strWhere + " " + order + "");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.price getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from price " + strWhere + "");
            mo.price model = new mo.price();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.price setModel(OleDbDataReader dr)
        {
            mo.price model = new mo.price();
            model.id = int.Parse(dr["id"].ToString());
            model.maxC = int.Parse(dr["maxC"].ToString());
            model.minC = int.Parse(dr["minC"].ToString());
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            model.dayC = dr["dayC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from price " + strWhere);
        }
        public void InsertModel(mo.price model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into price(maxC,minC,priceC,typ,dayC) values (");
            sb.Append("@maxC,@minC,@priceC,@typ,@dayC)");
            OleDbParameter[] parameters ={
                                             new OleDbParameter("@maxC",OleDbType.Integer,10),
                                             new OleDbParameter("@minC",OleDbType.Integer,10),
                                             new OleDbParameter("@priceC",OleDbType.Double,10),
                                             new OleDbParameter("@typ",OleDbType.Integer,10),
                                             new OleDbParameter("@dayC",OleDbType.VarChar,20)};
            parameters[0].Value = model.maxC;
            parameters[1].Value = model.minC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.dayC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.price model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update price set ");
            sb.Append("maxC=@maxC,");
            sb.Append("minC=@minC,");
            sb.Append("priceC=@priceC,");
            sb.Append("typ=@typ,");
            sb.Append("dayC=@dayC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@maxC",OleDbType.Integer,10),
                                             new OleDbParameter("@minC",OleDbType.Integer,10),
                                             new OleDbParameter("@priceC",OleDbType.Double,10),
                                             new OleDbParameter("@typ",OleDbType.Integer,10),
                                             new OleDbParameter("@dayC",OleDbType.VarChar,20),
                                              new OleDbParameter("@id", OleDbType.Integer, 10) };
            parameters[0].Value = model.maxC;
            parameters[1].Value = model.minC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.dayC;
            parameters[5].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update price set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from price where id=" + id);
        }
        public void DelByproductId(int productId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from price where typ=" + productId);
        }
    }
}
