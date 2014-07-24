using System;
using System.Collections.Generic;
using System.Data.OleDb;
namespace dal
{
    /// <summary>
    /// 0用过,1末用
    /// </summary>
    public class coupon
    {
        public coupon() { }
        protected opDal.Operation ope = new opDal.Operation();
        public List<mo.coupon> getModelListAll()
        {
            return setDr("select * from coupon order by priceC desc");
        }
        public List<mo.coupon> getModelListWhere(string strWhere)
        {
            return setDr("select * from coupon " + strWhere + " order by priceC desc");
        }
        public List<mo.coupon> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select " + strTop + " * from coupon " + strWhere + " order by priceC desc");
        }
        public List<mo.coupon> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from coupon where " + strWhere + " " + order + "");
        }
        private List<mo.coupon> setDr(string strSql)
        {
            List<mo.coupon> modelList = new List<mo.coupon>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
            mo.coupon model = new mo.coupon();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.coupon getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from coupon " + strWhere + "");
            mo.coupon model = new mo.coupon();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.coupon setModel(OleDbDataReader dr)
        {
            mo.coupon model = new mo.coupon();
            model.id = int.Parse(dr["id"].ToString());
            model.numC = dr["numC"].ToString();
            model.tipsC = dr["tipsC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            model.userId = int.Parse(dr["userId"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from coupon " + strWhere);
        }
        public void InsertModel(mo.coupon model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into coupon(numC,tipsC,priceC,typ,userId) values (");
            sb.Append("@numC,@tipsC,@priceC,@typ,@userId)");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@numC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@tipsC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@priceC", OleDbType.Double,10),
                                          new OleDbParameter("@typ", OleDbType.Integer,5),
                                          new OleDbParameter("@userId", OleDbType.Integer,10)
                                          };
            parameters[0].Value = model.numC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.userId;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.coupon model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update coupon set ");
            sb.Append("numC=@numC,");
            sb.Append("tipsC=@tipsC,");
            sb.Append("priceC=@priceC,");
            sb.Append("typ=@typ,");
            sb.Append("userId=@userId");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@numC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@tipsC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@priceC", OleDbType.Double,10),
                                          new OleDbParameter("@typ", OleDbType.Integer,5),
                                          new OleDbParameter("@userId", OleDbType.Integer,10),
                                          new OleDbParameter("@id", OleDbType.Integer,10)
                                          };
            parameters[0].Value = model.numC;
            parameters[1].Value = model.tipsC;
            parameters[2].Value = model.priceC;
            parameters[3].Value = model.typ;
            parameters[4].Value = model.userId;
            parameters[5].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update coupon set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from coupon " + where);
        }
    }
}
