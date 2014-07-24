using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class OrderDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.order> getModelListAll()
        {
            return setDr("select * from [order]");
        }
        public List<mo.order> getModelListWhere(string strWhere)
        {
            return setDr("select * from [order] " + strWhere + " order by timeC desc");
        }
        public List<mo.order> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select " + strTop + " * from [order] " + strWhere + " order by timeC desc");
        }
        public List<mo.order> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from [order] " + strWhere + " " + order + "");
        }
        private List<mo.order> setDr(string strSql)
        {
            List<mo.order> modelList = new List<mo.order>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
            mo.order model = new mo.order();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.order getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from [order] " + strWhere + "");
            mo.order model = new mo.order();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.order setModel(OleDbDataReader dr)
        {
            mo.order model = new mo.order();
            model.orderC = dr["orderC"].ToString();
            model.userName = dr["userName"].ToString();
            model.proInfo = dr["proInfo"].ToString();
            model.addInfo = dr["addInfo"].ToString();
            model.timeC =DateTime.Parse( dr["timeC"].ToString());
            model.payName = dr["payName"].ToString();
            model.expName = dr["expName"].ToString();
            model.expNum = dr["expNum"].ToString();
            model.expTime = dr["expTime"].ToString();
            model.expPrice = double.Parse(dr["expPrice"].ToString());
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = int.Parse(dr["typ"].ToString());
            model.remarksC = dr["remarksC"].ToString();
            model.cutCount = dr["cutCount"].ToString();
            model.curFlg = int.Parse(dr["cutFlg"].ToString());
            model.totalInfo = dr["totalInfo"].ToString();
            model.ShippingAddress = dr["ShippingAddress"].ToString();
            model.ShippingCountry = dr["ShippingCountry"].ToString();
            model.ShippingTel = dr["ShippingTel"].ToString();
            model.ShippingName = dr["ShippingName"].ToString();


            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from [order] " + strWhere);
        }
        public void InsertModel(mo.order model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into [order](orderC,userName,proInfo,addInfo,timeC,payName,expName,expNum,expTime,expPrice,priceC,typ,remarksC,cutCount,cutFlg,totalInfo,ShippingName,ShippingTel,ShippingCountry,ShippingAddress) values (");
            sb.Append("@orderC,@userName,@proInfo,@addInfo,@timeC,@payName,@expName,@expNum,@expTime,@expPrice,@priceC,@typ,@remarksC,@cutCount,@cutFlg,@totalInfo,@ShippingName,@ShippingTel,@ShippingCountry,@ShippingAddress)");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@orderC", OleDbType.VarChar, 30),
                                              new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                              new OleDbParameter("@proInfo", OleDbType.VarChar, 0),
                                              new OleDbParameter("@addInfo", OleDbType.VarChar, 0),
                                              new OleDbParameter("@timeC", OleDbType.VarChar, 30),
                                              new OleDbParameter("@payName", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expName", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expNum", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expTime", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expPrice", OleDbType.Double, 10),
                                              new OleDbParameter("@priceC", OleDbType.Double, 10),
                                              new OleDbParameter("@typ", OleDbType.Integer, 10),
                                              new OleDbParameter("@remarksC", OleDbType.VarChar,0),
                                              new OleDbParameter("@cutCount", OleDbType.VarChar,255),
                                              new OleDbParameter("@cutFlg", OleDbType.Integer, 10),
                                              new OleDbParameter("@totalInfo", OleDbType.VarChar),
                                              new OleDbParameter("@ShippingName", OleDbType.VarChar),
                                              new OleDbParameter("@ShippingTel", OleDbType.VarChar),
                                              new OleDbParameter("@ShippingCountry", OleDbType.VarChar),
                                              new OleDbParameter("@ShippingAddress", OleDbType.VarChar)
                                          };
            parameters[0].Value = model.orderC;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.proInfo;
            parameters[3].Value = model.addInfo;
            parameters[4].Value = model.timeC;
            parameters[5].Value = model.payName;
            parameters[6].Value = model.expName;
            parameters[7].Value = model.expNum;
            parameters[8].Value = model.expTime;
            parameters[9].Value = model.expPrice;
            parameters[10].Value = model.priceC;
            parameters[11].Value = model.typ;
            parameters[12].Value = model.remarksC;
            parameters[13].Value = model.cutCount;
            parameters[14].Value = model.curFlg;
            parameters[15].Value = model.totalInfo;
            parameters[16].Value = model.ShippingName;
            parameters[17].Value = model.ShippingTel;
            parameters[18].Value = model.ShippingCountry;
            parameters[19].Value = model.ShippingAddress;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.order model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update [order] set ");
            sb.Append("userName=@userName,");
            sb.Append("proInfo=@proInfo,");
            sb.Append("addInfo=@addInfo,");
            sb.Append("timeC=@timeC,");
            sb.Append("payName=@payName,");
            sb.Append("expName=@expName,");
            sb.Append("expNum=@expNum,");
            sb.Append("expTime=@expTime,");
            sb.Append("expPrice=@expPrice,");
            sb.Append("priceC=@priceC,");
            sb.Append("typ=@typ,");
            sb.Append("remarksC=@remarksC,");
            sb.Append("cutCount=@cutCount,");
            sb.Append("cutFlg=@cutFlg,");
            sb.Append("totalInfo=@totalInfo,");
            sb.Append("orderC=@orderC");
            sb.Append(" where orderC=@orderC");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                              new OleDbParameter("@proInfo", OleDbType.VarChar, 0),
                                              new OleDbParameter("@addInfo", OleDbType.VarChar, 0),
                                              new OleDbParameter("@timeC", OleDbType.VarChar, 30),
                                              new OleDbParameter("@payName", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expName", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expNum", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expTime", OleDbType.VarChar, 30),
                                              new OleDbParameter("@expPrice", OleDbType.Double, 10),
                                              new OleDbParameter("@priceC", OleDbType.Double, 10),
                                              new OleDbParameter("@typ", OleDbType.Integer, 10),
                                              new OleDbParameter("@remarksC", OleDbType.VarChar,0),
                                              new OleDbParameter("@cutCount", OleDbType.VarChar,255),
                                               new OleDbParameter("@cutFlg", OleDbType.Integer,10),
                                               new OleDbParameter("@totalInfo", OleDbType.VarChar),
                                              new OleDbParameter("@orderC", OleDbType.VarChar, 30)
                                          };
            parameters[0].Value = model.userName;
            parameters[1].Value = model.proInfo;
            parameters[2].Value = model.addInfo;
            parameters[3].Value = model.timeC;
            parameters[4].Value = model.payName;
            parameters[5].Value = model.expName;
            parameters[6].Value = model.expNum;
            parameters[7].Value = model.expTime;
            parameters[8].Value = model.expPrice;
            parameters[9].Value = model.priceC;
            parameters[10].Value = model.typ;
            parameters[11].Value = model.remarksC;
            parameters[12].Value = model.cutCount;
            parameters[13].Value = model.curFlg;
            parameters[14].Value = model.totalInfo;
            parameters[15].Value = model.orderC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update [order] set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string order)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from [order] where " + order + "");
        }
    }
}
