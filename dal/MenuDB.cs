using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class MenuDB
    {
   
        protected opDal.Operation ope = new opDal.Operation();

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
            return setDr("select " + strTop + " * from menu " + strWhere + " order by sortC desc");
        }
        public List<mo.menu> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from menu " + strWhere + " " + order + "");
        }
        private List<mo.menu> setDr(string strSql)
        {
            List<mo.menu> modelList = new List<mo.menu>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
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
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from menu " + strWhere + "");
            mo.menu model = new mo.menu();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.menu setModel(OleDbDataReader dr)
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
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from menu " + strWhere);
        }
        public void InsertModel(mo.menu model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into menu(aboutC,displayC,flgC,htmlName,id,levelC,nameC,sortC,typ,urlC,countC,preId,sonId,titleC,keywordsC,descriptionC,topKey) values (");
            sb.Append("@aboutC,@displayC,@flgC,@htmlName,@id,@levelC,@nameC,@sortC,@typ,@urlC,@countC,@preId,@sonId,@titleC,@keywordsC,@descriptionC,@topKey)");
            OleDbParameter[] parameters ={
                                             new OleDbParameter("@aboutC",OleDbType.VarChar,0),
                                             new OleDbParameter("@displayC",OleDbType.Integer,10),
                                             new OleDbParameter("@flgC",OleDbType.Integer,10),
                                             new OleDbParameter("@htmlName",OleDbType.VarChar,100),
                                             new OleDbParameter("@id",OleDbType.Integer,10),
                                             new OleDbParameter("@levelC",OleDbType.Integer,10),
                                             new OleDbParameter("@nameC",OleDbType.VarChar,50),
                                             new OleDbParameter("@sortC",OleDbType.Integer,10),
                                             new OleDbParameter("@typ",OleDbType.Integer,10),
                                             new OleDbParameter("@urlC",OleDbType.VarChar,255),
                                             new OleDbParameter("@countC",OleDbType.Integer,10),
                                             new OleDbParameter("@preId",OleDbType.VarChar,20),
                                             new OleDbParameter("@sonId",OleDbType.VarChar,255),
                                             new OleDbParameter("@titleC",OleDbType.VarChar,255),
                                             new OleDbParameter("@keywordsC",OleDbType.VarChar,255),
                                             new OleDbParameter("@descriptionC",OleDbType.VarChar,255),
                                             new OleDbParameter("@topKey",OleDbType.VarChar)                                            
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
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
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
            OleDbParameter[] parameters ={
                                             new OleDbParameter("@aboutC",OleDbType.VarChar,0),
                                             new OleDbParameter("@displayC",OleDbType.Integer,10),
                                             new OleDbParameter("@flgC",OleDbType.Integer,10),
                                             new OleDbParameter("@htmlName",OleDbType.VarChar,100),
                                             new OleDbParameter("@levelC",OleDbType.Integer,10),
                                             new OleDbParameter("@nameC",OleDbType.VarChar,50),
                                             new OleDbParameter("@sortC",OleDbType.Integer,10),
                                             new OleDbParameter("@typ",OleDbType.Integer,10),
                                             new OleDbParameter("@urlC",OleDbType.VarChar,255),
                                             new OleDbParameter("@countC",OleDbType.Integer,10),
                                             new OleDbParameter("@preId",OleDbType.VarChar,20),
                                             new OleDbParameter("@sonId",OleDbType.VarChar,255),
                                             new OleDbParameter("@titleC",OleDbType.VarChar,255),
                                             new OleDbParameter("@keywordsC",OleDbType.VarChar,255),
                                             new OleDbParameter("@descriptionC",OleDbType.VarChar,255),
                                             new OleDbParameter("@topKey",OleDbType.VarChar),
                                             new OleDbParameter("@id",OleDbType.Integer,10)
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
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update menu set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from menu " + where);
        }
    }
}
