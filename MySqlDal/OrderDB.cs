using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class OrderDB:DBBase
    {
        public List<mo.order> getModelListAll()
        {
            return setDr("select * from `order`");
        }
        public List<mo.order> getModelListWhere(string strWhere)
        {
            return setDr("select * from `order` " + strWhere + " order by timeC desc");
        }
        public List<mo.order> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select  * from `order` " + strWhere + " order by timeC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.order> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select * from `order` " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.order> setDr(string strSql)
        {
            List<mo.order> modelList = new List<mo.order>();
            MySqlDataReader dr = SqlReader(strSql);
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
            MySqlDataReader dr = SqlReader("select  * from `order` " + strWhere + "");
            mo.order model = new mo.order();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.order setModel(MySqlDataReader dr)
        {
            mo.order model = new mo.order();
            model.orderC = dr["orderC"].ToString();
            model.userName = dr["userName"].ToString();
            model.proInfo = dr["proInfo"].ToString();
            model.addInfo = dr["addInfo"].ToString();
            model.timeC = DateTime.Parse(dr["timeC"].ToString());
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
            return SqlExecuteScalar("select " + ziduan + " from order " + strWhere);
        }
        public void InsertModel(mo.order model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into `order`(orderC,userName,proInfo,addInfo,timeC,payName,expName,expNum,expTime,expPrice,priceC,typ,remarksC,cutCount,cutFlg,totalInfo,ShippingName,ShippingTel,ShippingCountry,ShippingAddress) values (");
            sb.Append("@orderC,@userName,@proInfo,@addInfo,@timeC,@payName,@expName,@expNum,@expTime,@expPrice,@priceC,@typ,@remarksC,@cutCount,@cutFlg,@totalInfo,@ShippingName,@ShippingTel,@ShippingCountry,@ShippingAddress)");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@orderC", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@userName", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@proInfo", MySqlDbType.VarChar, 0),
                                              new MySqlParameter("@addInfo", MySqlDbType.VarChar, 0),
                                              new MySqlParameter("@timeC", MySqlDbType.DateTime),
                                              new MySqlParameter("@payName", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expName", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expNum", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expTime", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expPrice", MySqlDbType.Double, 10),
                                              new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                              new MySqlParameter("@typ", MySqlDbType.Int32),
                                              new MySqlParameter("@remarksC", MySqlDbType.VarChar,0),
                                              new MySqlParameter("@cutCount", MySqlDbType.VarChar,255),
                                              new MySqlParameter("@cutFlg", MySqlDbType.Int32),
                                              new MySqlParameter("@totalInfo", MySqlDbType.VarChar),
                                              new MySqlParameter("@ShippingName", MySqlDbType.VarChar),
                                              new MySqlParameter("@ShippingTel", MySqlDbType.VarChar),
                                              new MySqlParameter("@ShippingCountry", MySqlDbType.VarChar),
                                              new MySqlParameter("@ShippingAddress", MySqlDbType.VarChar)
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
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.order model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update `order` set ");
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
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@userName", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@proInfo", MySqlDbType.VarChar, 0),
                                              new MySqlParameter("@addInfo", MySqlDbType.VarChar, 0),
                                              new MySqlParameter("@timeC", MySqlDbType.DateTime),
                                              new MySqlParameter("@payName", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expName", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expNum", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expTime", MySqlDbType.VarChar, 30),
                                              new MySqlParameter("@expPrice", MySqlDbType.Double, 10),
                                              new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                              new MySqlParameter("@typ", MySqlDbType.Int32),
                                              new MySqlParameter("@remarksC", MySqlDbType.VarChar,0),
                                              new MySqlParameter("@cutCount", MySqlDbType.VarChar,255),
                                               new MySqlParameter("@cutFlg", MySqlDbType.Int32),
                                               new MySqlParameter("@totalInfo", MySqlDbType.VarChar),
                                              new MySqlParameter("@orderC", MySqlDbType.VarChar, 30)
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
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update `order` set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string order)
        {
            SqlExecuteNonQuery("`order` from order where " + order + "");
        }
    }
}
