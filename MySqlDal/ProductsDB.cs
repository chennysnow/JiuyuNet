using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class ProductsDB : DBBase
    {

        public List<mo.proInfo> getModelListAll_info()
        {
            List<mo.proInfo> modelList = new List<mo.proInfo>();
            MySqlDataReader dr = SqlReader("select * from products,proInfo where products.id=proInfo.preId");
            mo.proInfo model = new mo.proInfo();
            while (dr.Read())
            {
                model.displayC = dr["displayC"].ToString();
                model.fileName = dr["fileName"].ToString();
                model.htmlName = dr["htmlName"].ToString();
                model.id = int.Parse(dr["id"].ToString());
                model.imgC = dr["imgC"].ToString();
                model.nameC = dr["nameC"].ToString();
                model.priceC = double.Parse(dr["priceC"].ToString());
                model.proId = dr["proId"].ToString();
                model.typ = int.Parse(dr["typ"].ToString());
                model.weightC = double.Parse(dr["weightC"].ToString());
                model.qx = int.Parse(dr["qx"].ToString());
                model.sortC = int.Parse(dr["sortC"].ToString());
                model.stockC = dr["stockC"].ToString();
                model.aboutC = dr["aboutC"].ToString();
                model.showC = int.Parse(dr["showC"].ToString());
                model.sellCount = int.Parse(dr["sellCount"].ToString());
                model.strPrice = dr["strPrice"].ToString();
                model.brandC = int.Parse(dr["brandC"].ToString());
                model.addType = dr["addType"].ToString();
                model.star = Convert.ToInt32(dr["star"].ToString());
                model.characteristic = dr["Characteristic"].ToString();
                model.titleC = dr["titleC"].ToString();
                model.contentC = dr["contentC"].ToString();
                model.descriptionC = dr["descriptionC"].ToString();
                model.keywordsC = dr["keywordsC"].ToString();
                model.moqC = dr["moqC"].ToString();
                model.preId = model.id;
                model.attrId = dr["attrId"].ToString();
                model.attrValue = dr["attrValue"].ToString();
                model.addTypeName = dr["addTypeName"].ToString();
                model.moreImg = dr["moreImg"].ToString();

                modelList.Add(model);
                model = new mo.proInfo();
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.proInfo> getModelListAll_info(string top, string where)
        {
            List<mo.proInfo> modelList = new List<mo.proInfo>();
            MySqlDataReader dr = SqlReader("select  * from products,proInfo where products.id=proInfo.preId " + where + top.ToLower().Replace("top", "LIMIT"));
            mo.proInfo model = new mo.proInfo();
            while (dr.Read())
            {
                model.displayC = dr["displayC"].ToString();
                model.fileName = dr["fileName"].ToString();
                model.htmlName = dr["htmlName"].ToString();
                model.id = int.Parse(dr["id"].ToString());
                model.imgC = dr["imgC"].ToString();
                model.nameC = dr["nameC"].ToString();
                model.priceC = double.Parse(dr["priceC"].ToString());
                model.proId = dr["proId"].ToString();
                model.typ = int.Parse(dr["typ"].ToString());
                model.weightC = double.Parse(dr["weightC"].ToString());
                if (dr["qx"] != null && dr["qx"].ToString() != "")
                    model.qx = int.Parse(dr["qx"].ToString());
                model.sortC = int.Parse(dr["sortC"].ToString());
                model.stockC = dr["stockC"].ToString();
                model.aboutC = dr["aboutC"].ToString();
                model.showC = int.Parse(dr["showC"].ToString());
                model.sellCount = int.Parse(dr["sellCount"].ToString());
                model.strPrice = dr["strPrice"].ToString();
                model.brandC = int.Parse(dr["brandC"].ToString());
                model.addType = dr["addType"].ToString();
                model.star = Convert.ToInt32(dr["star"].ToString());
                model.characteristic = dr["Characteristic"].ToString();
                model.titleC = dr["titleC"].ToString();
                model.contentC = dr["contentC"].ToString();
                model.descriptionC = dr["descriptionC"].ToString();
                model.keywordsC = dr["keywordsC"].ToString();
                model.moqC = dr["moqC"].ToString();
                model.preId = model.id;
                model.attrId = dr["attrId"].ToString();
                model.attrValue = dr["attrValue"].ToString();
                model.addTypeName = dr["addTypeName"].ToString();
                model.moreImg = dr["moreImg"].ToString();

                modelList.Add(model);
                model = new mo.proInfo();
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.products> getAll_admin(string strWhere)
        {
            return setDr("select * from products " + strWhere + " order by sortC desc");
        }
        public List<mo.products> getModelListAll()
        {
            return setDr("select * from products where showC=1 order by sortC desc");
        }
        public List<mo.products> getModelListWhere(string strWhere)
        {
            return setDr("select * from products where showC=1 " + strWhere + " order by sortC desc");
        }
        public List<mo.products> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select  * from products where showC=1 " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.products> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select  * from products where showC=1 " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public System.Data.DataTable getTable(string strSql)
        {
            return SqlTable(strSql);
        }
        private List<mo.products> setDr(string strSql)
        {
            List<mo.products> modelList = new List<mo.products>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.products model = new mo.products();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.proInfo getModel(string strWhere)
        {
            return getModel_s("select * from products,proInfo " + strWhere + " and products.id=proInfo.preId");
        }
        public mo.proInfo getModel(string top, string strWhere)
        {
            return getModel_s("select " + top + " * from products,proInfo " + strWhere + " and products.id=proInfo.preId");
        }
        public mo.proInfo getModel_s(string strSql)
        {
            MySqlDataReader dr = SqlReader(strSql);
            mo.proInfo model = new mo.proInfo();
            while (dr.Read())
            {
                model.displayC = dr["displayC"].ToString();
                model.fileName = dr["fileName"].ToString();
                model.htmlName = dr["htmlName"].ToString();
                model.id = int.Parse(dr["id"].ToString());
                model.imgC = dr["imgC"].ToString();
                model.nameC = dr["nameC"].ToString();
                model.priceC = double.Parse(dr["priceC"].ToString());
                model.proId = dr["proId"].ToString();
                model.typ = int.Parse(dr["typ"].ToString());
                model.weightC = double.Parse(dr["weightC"].ToString());
                if (dr["qx"] != null && dr["qx"].ToString() != "")
                    model.qx = int.Parse(dr["qx"].ToString());
                model.sortC = int.Parse(dr["sortC"].ToString());
                model.stockC = dr["stockC"].ToString();
                model.aboutC = dr["aboutC"].ToString();
                model.showC = int.Parse(dr["showC"].ToString());
                model.brandC = int.Parse(dr["brandC"].ToString());
                model.addType = dr["addType"].ToString();
                model.sellCount = int.Parse(dr["sellCount"].ToString());
                model.strPrice = dr["strPrice"].ToString(); ;
                model.titleC = dr["titleC"].ToString();
                model.contentC = dr["contentC"].ToString();
                model.descriptionC = dr["descriptionC"].ToString();
                model.keywordsC = dr["keywordsC"].ToString();
                model.moqC = dr["moqC"].ToString();
                model.preId = model.id;
                model.attrId = dr["attrId"].ToString();
                model.attrValue = dr["attrValue"].ToString();
                model.addTypeName = dr["addTypeName"].ToString();
                model.moreImg = dr["moreImg"].ToString();
                model.star = Convert.ToInt32(dr["star"].ToString());
                model.supplyid = dr["supplyid"].ToString();
                model.characteristic = dr["Characteristic"].ToString();
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.products setModel(MySqlDataReader dr)
        {
            mo.products model = new mo.products();
            model.displayC = dr["displayC"].ToString();
            model.fileName = dr["fileName"].ToString();
            model.htmlName = dr["htmlName"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.imgC = dr["imgC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.proId = dr["proId"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            model.weightC = double.Parse(dr["weightC"].ToString());
            if (dr["qx"] != null && dr["qx"].ToString() != "")
                model.qx = int.Parse(dr["qx"].ToString());
            model.sortC = int.Parse(dr["sortC"].ToString());
            model.stockC = dr["stockC"].ToString();
            model.aboutC = dr["aboutC"].ToString();
            model.showC = int.Parse(dr["showC"].ToString());
            model.sellCount = int.Parse(dr["sellCount"].ToString());
            model.strPrice = dr["strPrice"].ToString();
            model.addType = dr["addType"].ToString();
            model.star = Convert.ToInt32(dr["star"].ToString());
            model.characteristic = dr["Characteristic"].ToString();
            model.brandC = int.Parse(dr["brandC"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from products " + strWhere);
        }
        public void InsertModel(mo.proInfo model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into products(displayC,fileName,htmlName,id,imgC,nameC,priceC,proId,sortC,typ,weightC,qx,stockC,aboutC,showC,sellCount,strPrice,brandC,addType,star,Characteristic) values (");
            sb.Append("@displayC,@fileName,@htmlName,@id,@imgC,@nameC,@priceC,@proId,@sortC,@typ,@weightC,@qx,@stockC,@aboutC,@showC,@sellCount,@strPrice,@brandC,@addType,@star,@Characteristic)");
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("@displayC", MySqlDbType.VarChar, 20),
                                              new MySqlParameter("@fileName", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100),
                                              new MySqlParameter("@id", MySqlDbType.Int32),
                                              new MySqlParameter("@imgC", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@nameC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                              new MySqlParameter("@proId", MySqlDbType.VarChar, 50), 
                                              new MySqlParameter("@sortC", MySqlDbType.Int32),
                                              new MySqlParameter("@typ", MySqlDbType.Int32),
                                              new MySqlParameter("@weightC", MySqlDbType.Double, 10), 
                                              new MySqlParameter("@qx", MySqlDbType.Int32),
                                              new MySqlParameter("@stockC", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@aboutC", MySqlDbType.VarChar, 255),
                                              new MySqlParameter("@showC", MySqlDbType.Int32), 
                                              new MySqlParameter("@sellCount", MySqlDbType.Int32),
                                              new MySqlParameter("@strPrice", MySqlDbType.VarChar, 20), 
                                              new MySqlParameter("@brandC", MySqlDbType.Int32),
                                              new MySqlParameter("@addType", MySqlDbType.VarChar, 50),
                                              new MySqlParameter("@star",MySqlDbType.Int32),
                                               new MySqlParameter("@supplyid",MySqlDbType.VarChar,200),
                                              new MySqlParameter("@Characteristic",MySqlDbType.VarChar,255)};
            parameters[0].Value = model.displayC;
            parameters[1].Value = model.fileName;
            parameters[2].Value = model.htmlName;
            parameters[3].Value = model.id;
            parameters[4].Value = model.imgC;
            parameters[5].Value = model.nameC;
            parameters[6].Value = model.priceC;
            parameters[7].Value = model.proId;
            parameters[8].Value = model.sortC;
            parameters[9].Value = model.typ;
            parameters[10].Value = model.weightC;
            parameters[11].Value = model.qx;
            parameters[12].Value = model.stockC;
            parameters[13].Value = model.aboutC;
            parameters[14].Value = model.showC;
            parameters[15].Value = model.sellCount;
            parameters[16].Value = model.strPrice;
            parameters[17].Value = model.brandC;
            parameters[18].Value = model.addType;
            parameters[19].Value = model.star;
            parameters[20].Value = model.supplyid;
            parameters[21].Value = model.characteristic;
            SqlExecuteNonQuery(sb.ToString(), parameters);
            sb.Length = 0;
            sb.Append("insert into proInfo(contentC,descriptionC,keywordsC,moqC,preId,titleC,attrId,attrValue,addTypeName,moreImg) values (");
            sb.Append("@contentC,@descriptionC,@keywordsC,@moqC,@preId,@titleC,@attrId,@attrValue,@addTypeName,@moreImg)");
            MySqlParameter[] parameters_1 = { 
                                                new MySqlParameter("@contentC", MySqlDbType.VarChar, 0),
                                                new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255),
                                                new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255),
                                                new MySqlParameter("@moqC", MySqlDbType.VarChar, 50), 
                                                new MySqlParameter("@preId", MySqlDbType.Int32),
                                                new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), 
                                                new MySqlParameter("@attrId", MySqlDbType.VarChar, 100), 
                                                new MySqlParameter("@attrValue", MySqlDbType.VarChar),
                                                new MySqlParameter("@addTypeName", MySqlDbType.VarChar, 255),
                                                new MySqlParameter("@moreImg", MySqlDbType.VarChar)
                                            };
            parameters_1[0].Value = model.contentC;
            parameters_1[1].Value = model.descriptionC;
            parameters_1[2].Value = model.keywordsC;
            parameters_1[3].Value = model.moqC;
            parameters_1[4].Value = model.id;
            parameters_1[5].Value = model.titleC;
            parameters_1[6].Value = model.attrId;
            parameters_1[7].Value = model.attrValue;
            parameters_1[8].Value = model.addTypeName;
            parameters_1[9].Value = model.moreImg;
            SqlExecuteNonQuery(sb.ToString(), parameters_1);
        }
        public void UpdateModel(mo.proInfo model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update products set ");
            sb.Append("displayC=@displayC,");
            sb.Append("fileName=@fileName,");
            sb.Append("htmlName=@htmlName,");
            sb.Append("imgC=@imgC,");
            sb.Append("nameC=@nameC,");
            sb.Append("priceC=@priceC,");
            sb.Append("proId=@proId,");
            sb.Append("sortC=@sortC,");
            sb.Append("typ=@typ,");
            sb.Append("weightC=@weightC,");
            sb.Append("qx=@qx,");
            sb.Append("stockC=@stockC,");
            sb.Append("aboutC=@aboutC,");
            sb.Append("showC=@showC,");
            sb.Append("sellCount=@sellCount,");
            sb.Append("strPrice=@strPrice,");
            sb.Append("brandC=@brandC,");
            sb.Append("addType=@addType,");
            sb.Append("star=@star,");
            sb.Append("Characteristic=@Characteristic,");
            sb.Append("supplyid=@supplyid");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@displayC", MySqlDbType.VarChar, 20), new MySqlParameter("@fileName", MySqlDbType.VarChar, 50), new MySqlParameter("@htmlName", MySqlDbType.VarChar, 100), new MySqlParameter("@imgC", MySqlDbType.VarChar, 50), new MySqlParameter("@nameC", MySqlDbType.VarChar, 255), new MySqlParameter("@priceC", MySqlDbType.Double, 10), new MySqlParameter("@proId", MySqlDbType.VarChar, 50), new MySqlParameter("@sortC", MySqlDbType.Int32), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@weightC", MySqlDbType.Double, 10), new MySqlParameter("@qx", MySqlDbType.Int32), new MySqlParameter("@stockC", MySqlDbType.VarChar, 50), new MySqlParameter("@aboutC", MySqlDbType.VarChar, 255), new MySqlParameter("@showC", MySqlDbType.Int32), new MySqlParameter("@sellCount", MySqlDbType.Int32), new MySqlParameter("@strPrice", MySqlDbType.VarChar, 20), new MySqlParameter("@brandC", MySqlDbType.Int32), new MySqlParameter("@addType", MySqlDbType.VarChar, 50), new MySqlParameter("@star", MySqlDbType.Int32), new MySqlParameter("@Characteristic", MySqlDbType.VarChar, 255), new MySqlParameter("@supplyid", MySqlDbType.VarChar), new MySqlParameter("@id", MySqlDbType.Int32) };
            parameters[0].Value = model.displayC;
            parameters[1].Value = model.fileName;
            parameters[2].Value = model.htmlName;
            parameters[3].Value = model.imgC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.priceC;
            parameters[6].Value = model.proId;
            parameters[7].Value = model.sortC;
            parameters[8].Value = model.typ;
            parameters[9].Value = model.weightC;
            parameters[10].Value = model.qx;
            parameters[11].Value = model.stockC;
            parameters[12].Value = model.aboutC;
            parameters[13].Value = model.showC;
            parameters[14].Value = model.sellCount;
            parameters[15].Value = model.strPrice;
            parameters[16].Value = model.brandC;
            parameters[17].Value = model.addType;
            parameters[18].Value = model.star;
            parameters[19].Value = model.characteristic;
            parameters[20].Value = model.supplyid;
            parameters[21].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
            sb.Length = 0;
            sb.Append("update proInfo set ");
            sb.Append("contentC=@contentC,");
            sb.Append("descriptionC=@descriptionC,");
            sb.Append("keywordsC=@keywordsC,");
            sb.Append("moqC=@moqC,");
            sb.Append("titleC=@titleC,");
            sb.Append("attrId=@attrId,");
            sb.Append("attrValue=@attrValue,");
            sb.Append("addTypeName=@addTypeName,");
            sb.Append("moreImg=@moreImg");
            sb.Append(" where preId=@preId");
            MySqlParameter[] parameters_1 = { new MySqlParameter("@contentC", MySqlDbType.VarChar, 0), new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@keywordsC", MySqlDbType.VarChar, 255), new MySqlParameter("@moqC", MySqlDbType.VarChar, 50), new MySqlParameter("@titleC", MySqlDbType.VarChar, 255), new MySqlParameter("@attrId", MySqlDbType.VarChar, 100), new MySqlParameter("@attrValue", MySqlDbType.VarChar), new MySqlParameter("@addTypeName", MySqlDbType.VarChar, 255), new MySqlParameter("@moreImg", MySqlDbType.VarChar), new MySqlParameter("@preId", MySqlDbType.Int32) };
            parameters_1[0].Value = model.contentC;
            parameters_1[1].Value = model.descriptionC;
            parameters_1[2].Value = model.keywordsC;
            parameters_1[3].Value = model.moqC;
            parameters_1[4].Value = model.titleC;
            parameters_1[5].Value = model.attrId;
            parameters_1[6].Value = model.attrValue;
            parameters_1[7].Value = model.addTypeName;
            parameters_1[8].Value = model.moreImg;
            parameters_1[9].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters_1);
        }
        public void updateContent(string content, int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update proInfo set ");
            sb.Append("contentC=@contentC");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters = { new MySqlParameter("@contentC", MySqlDbType.VarChar, 0),
                                          new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = content;
            parameters[1].Value = id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update products set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void UpdateStringProInfo(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update proInfo set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            SqlExecuteNonQuery("delete from price where typ=" + id + "");
            SqlExecuteNonQuery("delete from proInfo where preId=" + id + "");
            SqlExecuteNonQuery("delete from products where id=" + id + "");
        }
        public void DelId(string id)
        {
            SqlExecuteNonQuery("delete from price where typ=" + id + "");
            SqlExecuteNonQuery("delete from proInfo where preId=" + id + "");
            SqlExecuteNonQuery("delete from products where id=" + id + "");
        }
        public string maxId(string str)
        {
            return SqlExecuteScalar(str);
        }
    }
}
