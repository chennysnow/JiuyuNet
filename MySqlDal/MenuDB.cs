using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
   public class MenuDB:DBBase
   {
       public List<mo.menu> getModelListAll()
       {
           return setDr("select * from menu");
       }
       public List<mo.menu> getModelListWhere(string strWhere)
       {
           return setDr("select * from menu " + strWhere + " order by sortC desc");
       }
       public List<mo.menu> getModelListWhere(string strTop, string strWhere)
       {
           return setDr("select * from menu " + strWhere + " order by sortC desc " + strTop.ToLower().Replace("top", "LIMIT"));
       }
       public List<mo.menu> getModelListWhere(string strTop, string strWhere, string order)
       {
           return setDr("select * from menu " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
       }
       private List<mo.menu> setDr(string strSql)
       {
           List<mo.menu> modelList = new List<mo.menu>();
           MySqlDataReader dr = SqlReader(strSql);
           mo.menu model = new mo.menu();
           while (dr.Read())
           {
               model = setModel(dr);
               modelList.Add(model);
           }
           dr.Close(); dr.Dispose();
           return modelList;
       }
       public mo.menu getModel(string strWhere)
       {
           MySqlDataReader dr = SqlReader("select  * from menu " + strWhere + "");
           mo.menu model = new mo.menu();
           while (dr.Read())
           {
               model = setModel(dr);
           }
           dr.Close(); dr.Dispose();
           return model;
       }
       private mo.menu setModel(MySqlDataReader dr)
       {
           mo.menu model = new mo.menu();
           model.aboutC = dr["aboutC"].ToString();
           model.displayC = int.Parse(dr["displayC"].ToString());
           model.flgC = int.Parse(dr["flgC"].ToString());
           model.htmlName = dr["htmlName"].ToString();
           model.id = int.Parse(dr["id"].ToString());
           model.levelC = int.Parse(dr["levelC"].ToString());
           model.nameC = dr["nameC"].ToString();
           model.sortC = int.Parse(dr["sortC"].ToString());
           model.typ = int.Parse(dr["typ"].ToString());
           model.urlC = dr["urlC"].ToString();
           model.countC = int.Parse(dr["countC"].ToString());
           if (dr["preId"] != null && dr["preId"].ToString() != "")
               model.preId = int.Parse(dr["preId"].ToString().TrimEnd(','));
           model.sonId = dr["sonId"].ToString();
           model.titleC = dr["titleC"].ToString();
           model.keywordsC = dr["keywordsC"].ToString();
           model.descriptionC = dr["descriptionC"].ToString();
           model.topKey = dr["topKey"].ToString();
           return model;
       }
       public string getString(string ziduan, string strWhere)
       {
           return SqlExecuteScalar("select " + ziduan + " from menu " + strWhere);
       }
       public void InsertModel(mo.menu model)
       {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.Append("insert into menu(aboutC,displayC,flgC,htmlName,id,levelC,nameC,sortC,typ,urlC,countC,preId,sonId,titleC,keywordsC,descriptionC,topKey) values (");
           sb.Append("@aboutC,@displayC,@flgC,@htmlName,@id,@levelC,@nameC,@sortC,@typ,@urlC,@countC,@preId,@sonId,@titleC,@keywordsC,@descriptionC,@topKey)");
           MySqlParameter[] parameters ={
                                             new MySqlParameter("@aboutC",MySqlDbType.VarChar,0),
                                             new MySqlParameter("@displayC",MySqlDbType.Int32),
                                             new MySqlParameter("@flgC",MySqlDbType.Int32),
                                             new MySqlParameter("@htmlName",MySqlDbType.VarChar,100),
                                             new MySqlParameter("@id",MySqlDbType.Int32),
                                             new MySqlParameter("@levelC",MySqlDbType.Int32),
                                             new MySqlParameter("@nameC",MySqlDbType.VarChar,50),
                                             new MySqlParameter("@sortC",MySqlDbType.Int32),
                                             new MySqlParameter("@typ",MySqlDbType.Int32),
                                             new MySqlParameter("@urlC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@countC",MySqlDbType.Int32),
                                             new MySqlParameter("@preId",MySqlDbType.VarChar,20),
                                             new MySqlParameter("@sonId",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@titleC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@keywordsC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@descriptionC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@topKey",MySqlDbType.VarChar)                                            
                                         };
           parameters[0].Value = model.aboutC;
           parameters[1].Value = model.displayC;
           parameters[2].Value = model.flgC;
           parameters[3].Value = model.htmlName;
           parameters[4].Value = model.id;
           parameters[5].Value = model.levelC;
           parameters[6].Value = model.nameC;
           parameters[7].Value = model.sortC;
           parameters[8].Value = model.typ;
           parameters[9].Value = model.urlC;
           parameters[10].Value = model.countC;
           parameters[11].Value = model.preId;
           parameters[12].Value = model.sonId;
           parameters[13].Value = model.titleC;
           parameters[14].Value = model.keywordsC;
           parameters[15].Value = model.descriptionC;
           parameters[16].Value = model.topKey;
           SqlExecuteNonQuery(sb.ToString(), parameters);
       }
       public void UpdateModel(mo.menu model)
       {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.Append("update menu set ");
           sb.Append("aboutC=@aboutC,");
           sb.Append("displayC=@displayC,");
           sb.Append("flgC=@flgC,");
           sb.Append("htmlName=@htmlName,");
           sb.Append("levelC=@levelC,");
           sb.Append("nameC=@nameC,");
           sb.Append("sortC=@sortC,");
           sb.Append("typ=@typ,");
           sb.Append("urlC=@urlC,");
           sb.Append("countC=@count,");
           sb.Append("preId=@preId,");
           sb.Append("sonId=@sonId,");
           sb.Append("titleC=@titleC,");
           sb.Append("keywordsC=@keywordsC,");
           sb.Append("descriptionC=@descriptionC,");
           sb.Append("topKey=@topKey,");
           sb.Append("id=@id");
           sb.Append(" where id=@id");
           MySqlParameter[] parameters ={
                                             new MySqlParameter("@aboutC",MySqlDbType.VarChar,0),
                                             new MySqlParameter("@displayC",MySqlDbType.Int32),
                                             new MySqlParameter("@flgC",MySqlDbType.Int32),
                                             new MySqlParameter("@htmlName",MySqlDbType.VarChar,100),
                                             new MySqlParameter("@levelC",MySqlDbType.Int32),
                                             new MySqlParameter("@nameC",MySqlDbType.VarChar,50),
                                             new MySqlParameter("@sortC",MySqlDbType.Int32),
                                             new MySqlParameter("@typ",MySqlDbType.Int32),
                                             new MySqlParameter("@urlC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@countC",MySqlDbType.Int32),
                                             new MySqlParameter("@preId",MySqlDbType.VarChar,20),
                                             new MySqlParameter("@sonId",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@titleC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@keywordsC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@descriptionC",MySqlDbType.VarChar,255),
                                             new MySqlParameter("@topKey",MySqlDbType.VarChar),
                                             new MySqlParameter("@id",MySqlDbType.Int32)
                                         };
           parameters[0].Value = model.aboutC;
           parameters[1].Value = model.displayC;
           parameters[2].Value = model.flgC;
           parameters[3].Value = model.htmlName;
           parameters[4].Value = model.levelC;
           parameters[5].Value = model.nameC;
           parameters[6].Value = model.sortC;
           parameters[7].Value = model.typ;
           parameters[8].Value = model.urlC;
           parameters[9].Value = model.countC;
           parameters[10].Value = model.preId;
           parameters[11].Value = model.sonId;
           parameters[12].Value = model.titleC;
           parameters[13].Value = model.keywordsC;
           parameters[14].Value = model.descriptionC;
           parameters[15].Value = model.topKey;
           parameters[16].Value = model.id;
           SqlExecuteNonQuery(sb.ToString(), parameters);
       }
       public void UpdateString(string Ziduan, string strWhere)
       {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.AppendFormat("update menu set {0} {1}", Ziduan, strWhere);
           SqlExecuteNonQuery(sb.ToString());
       }
       public void DelId(string where)
       {
           SqlExecuteNonQuery("delete from menu " + where);
       }
    }
}
