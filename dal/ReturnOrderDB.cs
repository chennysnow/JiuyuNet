using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace dal
{
    public class ReturnOrderDB
    {
        public ReturnOrderDB() { }
        protected opDal.Operation ope = new opDal.Operation();
        public List<mo.returnOrder> getModelListAll()
        {
            return setDr("select * from returnOrder");
        }
        public List<mo.returnOrder> getModelListWhere(string strWhere)
        {
            return setDr("select * from returnOrder " + strWhere + " order by timeC desc");
        }
        public List<mo.returnOrder> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select " + strTop + " * from returnOrder " + strWhere + " order by sortC desc");
        }
        public List<mo.returnOrder> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from returnOrder " + strWhere + " " + order + "");
        }
        private List<mo.returnOrder> setDr(string strSql)
        {
            List<mo.returnOrder> modelList = new List<mo.returnOrder>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
            mo.returnOrder model = new mo.returnOrder();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.returnOrder getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from returnOrder " + strWhere + "");
            mo.returnOrder model = new mo.returnOrder();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.returnOrder setModel(OleDbDataReader dr)
        {
            mo.returnOrder model = new mo.returnOrder();
            model.id = int.Parse(dr["id"].ToString());
            model.orderC = dr["orderC"].ToString();
            model.userName = dr["userName"].ToString();
            model.methodC = dr["methodC"].ToString();
            model.priceC = dr["priceC"].ToString();
            model.reasonC = dr["reasonc"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.proList = dr["proList"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            model.messageC = dr["messageC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from returnOrder " + strWhere);
        }
        public void InsertModel(mo.returnOrder model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into returnOrder(orderC,userName,methodC,priceC,reasonC,timeC,proList,typ,messageC) values (");
            sb.Append("@orderC,@userName,@methodC,@priceC,@reasonC,@timeC,@proList,@typ,@messageC)");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@orderC", OleDbType.VarChar, 30),
                                          new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                          new OleDbParameter("@methodC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@priceC", OleDbType.VarChar, 20),
                                          new OleDbParameter("@reasonC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@timeC", OleDbType.VarChar, 20),
                                          new OleDbParameter("@proList", OleDbType.VarChar,255),
                                          new OleDbParameter("@typ", OleDbType.Integer,2),
                                          new OleDbParameter("@messageC", OleDbType.VarChar)
                                          };
            parameters[0].Value = model.orderC;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.methodC;
            parameters[3].Value = model.priceC;
            parameters[4].Value = model.reasonC;
            parameters[5].Value = model.timeC;
            parameters[6].Value = model.proList;
            parameters[7].Value = model.typ;
            parameters[8].Value = model.messageC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.returnOrder model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update returnOrder set ");
            sb.Append("orderC=@orderC,");
            sb.Append("userName=@userName,");
            sb.Append("methodC=@methodC,");
            sb.Append("priceC=@priceC,");
            sb.Append("reasonC=@reasonC,");
            sb.Append("timeC=@timeC,");
            sb.Append("proList=@proList,");
            sb.Append("typ=@typ,");
            sb.Append("messageC=@messageC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@orderC", OleDbType.VarChar, 30),
                                          new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                          new OleDbParameter("@methodC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@priceC", OleDbType.VarChar, 20),
                                          new OleDbParameter("@reasonC", OleDbType.VarChar, 255),
                                          new OleDbParameter("@timeC", OleDbType.VarChar, 20),
                                          new OleDbParameter("@proList", OleDbType.VarChar,255),
                                          new OleDbParameter("@typ", OleDbType.Integer,2),
                                          new OleDbParameter("@messageC", OleDbType.VarChar),
                                          new OleDbParameter("@id", OleDbType.Integer,10)
                                          };
            parameters[0].Value = model.orderC;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.methodC;
            parameters[3].Value = model.priceC;
            parameters[4].Value = model.reasonC;
            parameters[5].Value = model.timeC;
            parameters[6].Value = model.proList;
            parameters[7].Value = model.typ;
            parameters[8].Value = model.messageC;
            parameters[9].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update returnOrder set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from returnOrder where " + where);
        }
    }
}
