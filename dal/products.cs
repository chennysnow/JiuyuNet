//using System;
//using System.Collections.Generic;
//using System.Data.OleDb;

//namespace dal
//{
//    public class products
//    {
//        public products() {/*¹¹Ôìº¯Êý*/}
//        protected opDal.Operation ope = new opDal.Operation();
//        public List<mo.proInfo> getModelListAll_info()
//        {
//            List<mo.proInfo> modelList = new List<mo.proInfo>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from products,proInfo where products.id=proInfo.preId");
//            mo.proInfo model = new mo.proInfo();
//            while (dr.Read())
//            {
//                    model.displayC = dr["displayC"].ToString();
//                    model.fileName = dr["fileName"].ToString();
//                    model.htmlName = dr["htmlName"].ToString();
//                    model.id = int.Parse(dr["id"].ToString());
//                    model.imgC = dr["imgC"].ToString();
//                    model.nameC = dr["nameC"].ToString();
//                    model.priceC = double.Parse(dr["priceC"].ToString());
//                    model.proId = dr["proId"].ToString();
//                    model.typ = int.Parse(dr["typ"].ToString());
//                    model.weightC = double.Parse(dr["weightC"].ToString());
//                    model.qx = dr["qx"].ToString();
//                    model.sortC = int.Parse(dr["sortC"].ToString());
//                    model.stockC = dr["stockC"].ToString();
//                    model.aboutC = dr["aboutC"].ToString();
//                    model.showC = int.Parse(dr["showC"].ToString());
//                    model.sellCount = int.Parse(dr["sellCount"].ToString());
//                    model.strPrice = dr["strPrice"].ToString();
//                    model.brandC = int.Parse(dr["brandC"].ToString());
//                    model.addType = dr["addType"].ToString();
//                    model.star = Convert.ToInt32(dr["star"].ToString());
//                    model.characteristic = dr["Characteristic"].ToString();
//                    model.titleC = dr["titleC"].ToString();
//                    model.contentC = dr["contentC"].ToString();
//                    model.descriptionC = dr["descriptionC"].ToString();
//                    model.keywordsC = dr["keywordsC"].ToString();
//                    model.moqC = dr["moqC"].ToString();
//                    model.preId = model.id;
//                    model.attrId = dr["attrId"].ToString();
//                    model.attrValue = dr["attrValue"].ToString();
//                    model.addTypeName = dr["addTypeName"].ToString();
//                    model.moreImg = dr["moreImg"].ToString();

//                    modelList.Add(model);
//                    model = new mo.proInfo();
//            }
//            dr.Close();dr.Dispose();
//            return modelList;
//        }
//        public List<mo.proInfo> getModelListAll_info(string top,string where)
//        {
//            List<mo.proInfo> modelList = new List<mo.proInfo>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select "+top+" * from products,proInfo where products.id=proInfo.preId"+where);
//            mo.proInfo model = new mo.proInfo();
//            while (dr.Read())
//            {
//                model.displayC = dr["displayC"].ToString();
//                model.fileName = dr["fileName"].ToString();
//                model.htmlName = dr["htmlName"].ToString();
//                model.id = int.Parse(dr["id"].ToString());
//                model.imgC = dr["imgC"].ToString();
//                model.nameC = dr["nameC"].ToString();
//                model.priceC = double.Parse(dr["priceC"].ToString());
//                model.proId = dr["proId"].ToString();
//                model.typ = int.Parse(dr["typ"].ToString());
//                model.weightC = double.Parse(dr["weightC"].ToString());
//                model.qx = dr["qx"].ToString();
//                model.sortC = int.Parse(dr["sortC"].ToString());
//                model.stockC = dr["stockC"].ToString();
//                model.aboutC = dr["aboutC"].ToString();
//                model.showC = int.Parse(dr["showC"].ToString());
//                model.sellCount = int.Parse(dr["sellCount"].ToString());
//                model.strPrice = dr["strPrice"].ToString();
//                model.brandC = int.Parse(dr["brandC"].ToString());
//                model.addType = dr["addType"].ToString();
//                model.star = Convert.ToInt32(dr["star"].ToString());
//                model.characteristic = dr["Characteristic"].ToString();
//                model.titleC = dr["titleC"].ToString();
//                model.contentC = dr["contentC"].ToString();
//                model.descriptionC = dr["descriptionC"].ToString();
//                model.keywordsC = dr["keywordsC"].ToString();
//                model.moqC = dr["moqC"].ToString();
//                model.preId = model.id;
//                model.attrId = dr["attrId"].ToString();
//                model.attrValue = dr["attrValue"].ToString();
//                model.addTypeName = dr["addTypeName"].ToString();
//                model.moreImg = dr["moreImg"].ToString();

//                modelList.Add(model);
//                model = new mo.proInfo();
//            }
//            dr.Close(); dr.Dispose();
//            return modelList;
//        }
//        public List<mo.products> getAll_admin(string strWhere)
//        {
//            return setDr("select * from products "+strWhere+" order by sortC desc");
//        }
//        public List<mo.products> getModelListAll()
//        {
//            return setDr("select * from products where showC=1 order by sortC desc");
//        }
//        public List<mo.products> getModelListWhere(string strWhere)
//        {
//            return setDr("select * from products where showC=1 " + strWhere + " order by sortC desc");
//        }
//        public List<mo.products> getModelListWhere(string strTop, string strWhere)
//        {
//            return setDr("select " + strTop + " * from products where showC=1 " + strWhere + " order by sortC desc");
//        }
//        public List<mo.products> getModelListWhere(string strTop, string strWhere, string order)
//        {
//            return setDr("select " + strTop + " * from products where showC=1 " + strWhere + " " + order + "");
//        }
//        public System.Data.DataTable getTable(string strSql)
//        {
//            return opDal.Sqlcs.SqlTable(strSql);
//        }
//        private List<mo.products> setDr(string strSql)
//        {
//            List<mo.products> modelList = new List<mo.products>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
//            mo.products model = new mo.products();
//            while (dr.Read())
//            {
//                model = setModel(dr);
//                modelList.Add(model);
//            }
//            dr.Close(); dr.Dispose();
//            return modelList;
//        }
//        public mo.proInfo getModel(string strWhere)
//        {
//            return getModel_s("select * from products,proInfo " + strWhere + " and products.id=proInfo.preId");
//        }
//        public mo.proInfo getModel(string top,string strWhere)
//        {
//            return getModel_s("select "+top+" * from products,proInfo " + strWhere + " and products.id=proInfo.preId");
//        }
//        public mo.proInfo getModel_s(string strSql)
//        {
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
//            mo.proInfo model = new mo.proInfo();
//            while (dr.Read())
//            {
//                model.displayC = dr["displayC"].ToString();
//                model.fileName = dr["fileName"].ToString();
//                model.htmlName = dr["htmlName"].ToString();
//                model.id = int.Parse(dr["id"].ToString());
//                model.imgC = dr["imgC"].ToString();
//                model.nameC = dr["nameC"].ToString();
//                model.priceC = double.Parse(dr["priceC"].ToString());
//                model.proId = dr["proId"].ToString();
//                model.typ = int.Parse(dr["typ"].ToString());
//                model.weightC = double.Parse(dr["weightC"].ToString());
//                model.qx = dr["qx"].ToString();
//                model.sortC = int.Parse(dr["sortC"].ToString());
//                model.stockC = dr["stockC"].ToString();
//                model.aboutC = dr["aboutC"].ToString();
//                model.showC = int.Parse(dr["showC"].ToString());
//                model.brandC = int.Parse(dr["brandC"].ToString());
//                model.addType = dr["addType"].ToString();
//                model.sellCount = int.Parse(dr["sellCount"].ToString());
//                model.strPrice = dr["strPrice"].ToString();;
//                model.titleC = dr["titleC"].ToString();
//                model.contentC = dr["contentC"].ToString();
//                model.descriptionC = dr["descriptionC"].ToString();
//                model.keywordsC = dr["keywordsC"].ToString();
//                model.moqC = dr["moqC"].ToString();
//                model.preId = model.id;
//                model.attrId = dr["attrId"].ToString();
//                model.attrValue = dr["attrValue"].ToString();
//                model.addTypeName = dr["addTypeName"].ToString();
//                model.moreImg = dr["moreImg"].ToString();
//                model.star = Convert.ToInt32(dr["star"].ToString());
//                model.characteristic = dr["Characteristic"].ToString();
//            }
//            dr.Close(); dr.Dispose();
//            return model;
//        }
//        private mo.products setModel(OleDbDataReader dr)
//        {
//            mo.products model = new mo.products();
//            model.displayC = dr["displayC"].ToString();
//            model.fileName = dr["fileName"].ToString();
//            model.htmlName = dr["htmlName"].ToString();
//            model.id = int.Parse(dr["id"].ToString());
//            model.imgC = dr["imgC"].ToString();
//            model.nameC = dr["nameC"].ToString();
//            model.priceC = double.Parse(dr["priceC"].ToString());
//            model.proId = dr["proId"].ToString();
//            model.typ = int.Parse(dr["typ"].ToString());
//            model.weightC = double.Parse(dr["weightC"].ToString());
//            model.qx = dr["qx"].ToString();
//            model.sortC = int.Parse(dr["sortC"].ToString());
//            model.stockC = dr["stockC"].ToString();
//            model.aboutC = dr["aboutC"].ToString();
//            model.showC = int.Parse(dr["showC"].ToString());
//            model.sellCount = int.Parse(dr["sellCount"].ToString());
//            model.strPrice = dr["strPrice"].ToString();
//            model.addType = dr["addType"].ToString();
//            model.star =Convert.ToInt32(dr["star"].ToString());
//            model.characteristic = dr["Characteristic"].ToString();
//            model.brandC = int.Parse(dr["brandC"].ToString());
//            return model;
//        }
//        public string getString(string ziduan, string strWhere)
//        {
//            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from products " + strWhere);
//        }
//        public void InsertModel(mo.proInfo model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("insert into products(displayC,fileName,htmlName,id,imgC,nameC,priceC,proId,sortC,typ,weightC,qx,stockC,aboutC,showC,sellCount,strPrice,brandC,addType,star,Characteristic) values (");
//            sb.Append("@displayC,@fileName,@htmlName,@id,@imgC,@nameC,@priceC,@proId,@sortC,@typ,@weightC,@qx,@stockC,@aboutC,@showC,@selCount,@strPrice,@brandC,@addType,@star,@Characteristic)");
//            OleDbParameter[] parameters = { 
//                                              new OleDbParameter("@displayC", OleDbType.VarChar, 20),
//                                              new OleDbParameter("@fileName", OleDbType.VarChar, 50),
//                                              new OleDbParameter("@htmlName", OleDbType.VarChar, 100),
//                                              new OleDbParameter("@id", OleDbType.Integer, 10),
//                                              new OleDbParameter("@imgC", OleDbType.VarChar, 50),
//                                              new OleDbParameter("@nameC", OleDbType.VarChar, 255),
//                                              new OleDbParameter("@priceC", OleDbType.Double, 10),
//                                              new OleDbParameter("@proId", OleDbType.VarChar, 50), 
//                                              new OleDbParameter("@sortC", OleDbType.Integer, 10),
//                                              new OleDbParameter("@typ", OleDbType.Integer, 10),
//                                              new OleDbParameter("@weightC", OleDbType.Double, 10), 
//                                              new OleDbParameter("@qx", OleDbType.Integer, 2),
//                                              new OleDbParameter("@stockC", OleDbType.VarChar, 50),
//                                              new OleDbParameter("@aboutC", OleDbType.VarChar, 255),
//                                              new OleDbParameter("@showC", OleDbType.Integer, 2), 
//                                              new OleDbParameter("@sellCount", OleDbType.Integer, 10),
//                                              new OleDbParameter("@strPrice", OleDbType.VarChar, 20), 
//                                              new OleDbParameter("@brandC", OleDbType.Integer, 10),
//                                              new OleDbParameter("@addType", OleDbType.VarChar, 50),
//                                              new OleDbParameter("@star",OleDbType.Integer,10),
//                                              new OleDbParameter("@Characteristic",OleDbType.VarChar,255)};
//            parameters[0].Value = model.displayC;
//            parameters[1].Value = model.fileName;
//            parameters[2].Value = model.htmlName;
//            parameters[3].Value = model.id;
//            parameters[4].Value = model.imgC;
//            parameters[5].Value = model.nameC;
//            parameters[6].Value = model.priceC;
//            parameters[7].Value = model.proId;
//            parameters[8].Value = model.sortC;
//            parameters[9].Value = model.typ;
//            parameters[10].Value = model.weightC;
//            parameters[11].Value = model.qx;
//            parameters[12].Value = model.stockC;
//            parameters[13].Value = model.aboutC;
//            parameters[14].Value = model.showC;
//            parameters[15].Value = model.sellCount;
//            parameters[16].Value = model.strPrice;
//            parameters[17].Value = model.brandC;
//            parameters[18].Value = model.addType;
//            parameters[19].Value = model.star;
//            parameters[20].Value = model.characteristic;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//            sb.Length = 0;
//            sb.Append("insert into proInfo(contentC,descriptionC,keywordsC,moqC,preId,titleC,attrId,attrValue,addTypeName,moreImg) values (");
//            sb.Append("@contentC,@descriptionC,@keywordsC,@moqC,@preId,@titleC,@attrId,@attrValue,@addTypeName,@moreImg)");
//            OleDbParameter[] parameters_1 = { 
//                                                new OleDbParameter("@contentC", OleDbType.VarChar, 0),
//                                                new OleDbParameter("@descriptionC", OleDbType.VarChar, 255),
//                                                new OleDbParameter("@keywordsC", OleDbType.VarChar, 255),
//                                                new OleDbParameter("@moqC", OleDbType.VarChar, 50), 
//                                                new OleDbParameter("@preId", OleDbType.Integer, 10),
//                                                new OleDbParameter("@titleC", OleDbType.VarChar, 255), 
//                                                new OleDbParameter("@attrId", OleDbType.VarChar, 100), 
//                                                new OleDbParameter("@attrValue", OleDbType.VarChar),
//                                                new OleDbParameter("@addTypeName", OleDbType.VarChar, 255),
//                                                new OleDbParameter("@moreImg", OleDbType.VarChar)
//                                            };
//            parameters_1[0].Value = model.contentC;
//            parameters_1[1].Value = model.descriptionC;
//            parameters_1[2].Value = model.keywordsC;
//            parameters_1[3].Value = model.moqC;
//            parameters_1[4].Value = model.id;
//            parameters_1[5].Value = model.titleC;
//            parameters_1[6].Value = model.attrId;
//            parameters_1[7].Value = model.attrValue;
//            parameters_1[8].Value = model.addTypeName;
//            parameters_1[9].Value = model.moreImg;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters_1);
//        }
//        public void UpdateModel(mo.proInfo model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("update products set ");
//            sb.Append("displayC=@displayC,");
//            sb.Append("fileName=@fileName,");
//            sb.Append("htmlName=@htmlName,");
//            sb.Append("imgC=@imgC,");
//            sb.Append("nameC=@nameC,");
//            sb.Append("priceC=@priceC,");
//            sb.Append("proId=@proId,");
//            sb.Append("sortC=@sortC,");
//            sb.Append("typ=@typ,");
//            sb.Append("weightC=@weightC,");
//            sb.Append("qx=@qx,");
//            sb.Append("stockC=@stockC,");
//            sb.Append("aboutC=@aboutC,");
//            sb.Append("showC=@showC,");
//            sb.Append("sellCount=@sellCount,");
//            sb.Append("strPrice=@strPrice,");
//            sb.Append("brandC=@brandC,");
//            sb.Append("addType=@addType,");
//            sb.Append("star=@star,");
//            sb.Append("Characteristic=@Characteristic");
//            sb.Append(" where id=@id");
//            OleDbParameter[] parameters = { new OleDbParameter("@displayC", OleDbType.VarChar, 20), new OleDbParameter("@fileName", OleDbType.VarChar, 50), new OleDbParameter("@htmlName", OleDbType.VarChar, 100), new OleDbParameter("@imgC", OleDbType.VarChar, 50), new OleDbParameter("@nameC", OleDbType.VarChar, 255), new OleDbParameter("@priceC", OleDbType.Double, 10), new OleDbParameter("@proId", OleDbType.VarChar, 50), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@typ", OleDbType.Integer, 10), new OleDbParameter("@weightC", OleDbType.Double, 10), new OleDbParameter("@qx", OleDbType.Integer, 2), new OleDbParameter("@stockC", OleDbType.VarChar, 50), new OleDbParameter("@aboutC", OleDbType.VarChar, 255), new OleDbParameter("@showC", OleDbType.Integer, 2), new OleDbParameter("@sellCount", OleDbType.Integer, 10), new OleDbParameter("@strPrice", OleDbType.VarChar, 20), new OleDbParameter("@brandC", OleDbType.Integer, 10), new OleDbParameter("@addType", OleDbType.VarChar, 50), new OleDbParameter("@star", OleDbType.Integer, 10), new OleDbParameter("@Characteristic", OleDbType.VarChar,255), new OleDbParameter("@id", OleDbType.Integer, 10) };
//            parameters[0].Value = model.displayC;
//            parameters[1].Value = model.fileName;
//            parameters[2].Value = model.htmlName;
//            parameters[3].Value = model.imgC;
//            parameters[4].Value = model.nameC;
//            parameters[5].Value = model.priceC;
//            parameters[6].Value = model.proId;
//            parameters[7].Value = model.sortC;
//            parameters[8].Value = model.typ;
//            parameters[9].Value = model.weightC;
//            parameters[10].Value = model.qx;
//            parameters[11].Value = model.stockC;
//            parameters[12].Value = model.aboutC;
//            parameters[13].Value = model.showC;
//            parameters[14].Value = model.sellCount;
//            parameters[15].Value = model.strPrice;
//            parameters[16].Value = model.brandC;
//            parameters[17].Value = model.addType;
//            parameters[18].Value = model.star;
//            parameters[19].Value = model.characteristic;
//            parameters[20].Value = model.id;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//            sb.Length = 0;
//            sb.Append("update proInfo set "); 
//            sb.Append("contentC=@contentC,");
//            sb.Append("descriptionC=@descriptionC,");
//            sb.Append("keywordsC=@keywordsC,");
//            sb.Append("moqC=@moqC,");
//            sb.Append("titleC=@titleC,");
//            sb.Append("attrId=@attrId,");
//            sb.Append("attrValue=@attrValue,");
//            sb.Append("addTypeName=@addTypeName,");
//            sb.Append("moreImg=@moreImg");
//            sb.Append(" where preId=@preId");
//            OleDbParameter[] parameters_1 = { new OleDbParameter("@contentC", OleDbType.VarChar, 0), new OleDbParameter("@descriptionC", OleDbType.VarChar, 255), new OleDbParameter("@keywordsC", OleDbType.VarChar, 255), new OleDbParameter("@moqC", OleDbType.VarChar, 50), new OleDbParameter("@titleC", OleDbType.VarChar, 255), new OleDbParameter("@attrId", OleDbType.VarChar, 100), new OleDbParameter("@attrValue", OleDbType.VarChar), new OleDbParameter("@addTypeName", OleDbType.VarChar, 255), new OleDbParameter("@moreImg", OleDbType.VarChar), new OleDbParameter("@preId", OleDbType.Integer, 10) };
//            parameters_1[0].Value = model.contentC;
//            parameters_1[1].Value = model.descriptionC;
//            parameters_1[2].Value = model.keywordsC;
//            parameters_1[3].Value = model.moqC;
//            parameters_1[4].Value = model.titleC;
//            parameters_1[5].Value = model.attrId;
//            parameters_1[6].Value = model.attrValue;
//            parameters_1[7].Value = model.addTypeName;
//            parameters_1[8].Value = model.moreImg;
//            parameters_1[9].Value = model.id;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters_1);
//        }
//        public void updateContent(string content, int id)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("update proInfo set ");
//            sb.Append("contentC=@contentC");
//            sb.Append(" where id=@id");
//            OleDbParameter[] parameters = { new OleDbParameter("@contentC", OleDbType.VarChar, 0),
//                                          new OleDbParameter("@id", OleDbType.Integer, 10)};
//            parameters[0].Value = content;
//            parameters[1].Value = id;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateString(string Ziduan, string strWhere)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.AppendFormat("update products set {0} {1}", Ziduan, strWhere);
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
//        }
//        public void UpdateStringProInfo(string Ziduan, string strWhere)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.AppendFormat("update proInfo set {0} {1}", Ziduan, strWhere);
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
//        }
//        public void DelId(int id)
//        {
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from price where typ=" + id + "");
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from proInfo where preId=" + id + "");
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from products where id=" + id + "");
//        }
//        public void DelId(string id)
//        {
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from price where typ=" + id + "");
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from proInfo where preId=" + id + "");
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from products where id=" + id + "");
//        }
//        public string maxId(string str)
//        {
//           return opDal.Sqlcs.SqlExecuteScalar(str);
//        }
//    }
//}
