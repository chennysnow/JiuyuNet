using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class OrderItemDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.OrderItem> getModelListWhere(string strWhere)
        {
            return setDr("select * from [OrderItem] " + strWhere + " order by CreateDate desc");
        }
        public List<mo.OrderItem> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select " + strTop + " * from [OrderItem] " + strWhere + " order by CreateDate desc");
        }
        public List<mo.OrderItem> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from [OrderItem] " + strWhere + " " + order + "");
        }
        private List<mo.OrderItem> setDr(string strSql)
        {
            List<mo.OrderItem> modelList = new List<mo.OrderItem>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
            mo.OrderItem model = new mo.OrderItem();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.OrderItem getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from [OrderItem] " + strWhere + "");
            mo.OrderItem model = new mo.OrderItem();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.OrderItem setModel(OleDbDataReader dr)
        {
            mo.OrderItem model = new mo.OrderItem();
            model.ID = int.Parse(dr["ID"].ToString());
            model.OrderID = dr["OrderID"].ToString();
            model.ProductId = dr["ProductId"].ToString();
            model.Quantity = int.Parse(dr["Quantity"].ToString());
            model.UnitPrice = decimal.Parse(dr["UnitPrice"].ToString());
            model.ProductName = dr["ProductName"].ToString();
            model.ProductNO = dr["ProductNO"].ToString();
            model.HtmlName = dr["HtmlName"].ToString();
            model.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            model.ProImgURL = dr["ProImgURL"].ToString();
            model.TotalAmount = decimal.Parse(dr["TotalAmount"].ToString());
            if (dr["Discounte"] != null && dr["Discounte"].ToString() != "")
            {
                model.Discounte = double.Parse(dr["Discounte"].ToString());
                model.DisPrice = double.Parse(dr["DisPrice"].ToString());
            }

            return model;
        }

        public void InsertModel(mo.OrderItem model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into [OrderItem](OrderID,ProductId,Quantity,UnitPrice,ProductName,TotalAmount,CreateDate,HtmlName,ProductNO,Discounte,DisPrice,ProImgURL) values (");
            sb.Append("@orderC,@OrderID,@ProductId,@UnitPrice,@Description,@TotalAmount,@CreateDate,@HtmlName,@ProductNO,@Discounte,@DisPrice,@ProImgURL)");
            OleDbParameter[] parameters = { 
                                              new OleDbParameter("@OrderID", OleDbType.BigInt),
                                              new OleDbParameter("@ProductId", OleDbType.BigInt),
                                              new OleDbParameter("@Quantity", OleDbType.BigInt),
                                              new OleDbParameter("@UnitPrice", OleDbType.Decimal),
                                              new OleDbParameter("@ProductName", OleDbType.VarChar),
                                              new OleDbParameter("@TotalAmount", OleDbType.Decimal),
                                              new OleDbParameter("@CreateDate", OleDbType.DBDate),
                                              new OleDbParameter("@HtmlName", OleDbType.VarChar),
                                              new OleDbParameter("@ProductNO", OleDbType.VarChar),
                                              new OleDbParameter("@Discounte", OleDbType.Double),
                                              new OleDbParameter("@DisPrice", OleDbType.Double),
                                              new OleDbParameter("@ProImgURL", OleDbType.VarChar)
                                          };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProductId;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.UnitPrice;
            parameters[4].Value = model.ProductName;
            parameters[5].Value = model.TotalAmount;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.HtmlName;
            parameters[8].Value = model.ProductNO;
            parameters[9].Value = model.Discounte;
            parameters[10].Value = model.DisPrice;
            parameters[11].Value = model.ProImgURL;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }

        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update [OrderItem] set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }


    }
}
