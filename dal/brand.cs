//using System;
//using System.Collections.Generic;
//using System.Data.OleDb;

//namespace dal
//{
//    public class brand
//    {
//        public brand() {/*构造函数*/}
//        protected opDal.Operation ope = new opDal.Operation();
//        public List<mo.brand> getModelListAll()
//        {
//            return setDr("select * from brand order by sortC desc");
//        }
//        public List<mo.brand> getModelListWhere(string strWhere)
//        {
//            return setDr("select * from brand " + strWhere + " order by sortC desc");
//        }
//        public List<mo.brand> getModelListWhere(string strTop, string strWhere)
//        {
//            return setDr("select " + strTop + " * from brand " + strWhere + " order by sortC desc");
//        }
//        public List<mo.brand> getModelListWhere(string strTop, string strWhere, string order)
//        {
//            return setDr("select " + strTop + " * from brand " + strWhere + " " + order + "");
//        }
//        private List<mo.brand> setDr(string strSql)
//        {
//            List<mo.brand> modelList = new List<mo.brand>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
//            mo.brand model = new mo.brand();
//            while (dr.Read())
//            {
//                model = setModel(dr);
//                modelList.Add(model);
//            }
//            dr.Close(); dr.Dispose();
//            return modelList;
//        }
//        public mo.brand getModel(string strWhere)
//        {
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from brand " + strWhere + "");
//            mo.brand model = new mo.brand();
//            while (dr.Read())
//            {
//                model = setModel(dr);
//            }
//            dr.Close(); dr.Dispose();
//            return model;
//        }
//        private mo.brand setModel(OleDbDataReader dr)
//        {
//            mo.brand model = new mo.brand();
//            model.id = int.Parse(dr["id"].ToString());
//            model.imgC = dr["imgC"].ToString();
//            model.nameC = dr["nameC"].ToString();
//            model.aboutC = dr["aboutC"].ToString();
//            model.sortC = int.Parse(dr["sortC"].ToString());
//            model.typ = int.Parse(dr["typ"].ToString());
//            return model;
//        }
//        public string getString(string ziduan, string strWhere)
//        {
//            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from brand " + strWhere);
//        }
//        public void InsertModel(mo.brand model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("insert into brand(imgC,nameC,aboutC,sortC,typ) values (");
//            sb.Append("@imgC,@nameC,@aboutC,@sortC,@typ)");
//            OleDbParameter[] parameters = { 
//                            new OleDbParameter("@imgC", OleDbType.VarChar, 255), 
//                            new OleDbParameter("@nameC", OleDbType.VarChar, 255),
//                            new OleDbParameter("@aboutC", OleDbType.VarChar),
//                            new OleDbParameter("@sortC", OleDbType.Integer, 10),
//                            new OleDbParameter("@typ", OleDbType.Integer, 10)};
//            parameters[0].Value = model.imgC;
//            parameters[1].Value = model.nameC;
//            parameters[2].Value = model.aboutC;
//            parameters[3].Value = model.sortC;
//            parameters[4].Value = model.typ;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateModel(mo.brand model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("update brand set "); 
//            sb.Append("imgC=@imgC,");
//            sb.Append("nameC=@nameC,");
//            sb.Append("aboutC=@aboutC,");
//            sb.Append("sortC=@sortC,");
//            sb.Append("typ=@typ");
//            sb.Append(" where id=@id");
//            OleDbParameter[] parameters = { 
//                            new OleDbParameter("@imgC", OleDbType.VarChar, 255), 
//                            new OleDbParameter("@nameC", OleDbType.VarChar, 255),
//                            new OleDbParameter("@aboutC", OleDbType.VarChar),
//                            new OleDbParameter("@sortC", OleDbType.Integer, 10),
//                            new OleDbParameter("@typ", OleDbType.Integer, 10),
//                            new OleDbParameter("@id", OleDbType.Integer, 10)};
//            parameters[0].Value = model.imgC;
//            parameters[1].Value = model.nameC;
//            parameters[2].Value = model.aboutC;
//            parameters[3].Value = model.sortC;
//            parameters[4].Value = model.typ;
//            parameters[5].Value = model.id;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateString(string Ziduan, string strWhere)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.AppendFormat("update brand set {0} {1}", Ziduan, strWhere);
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
//        }
//        public void DelId(string where)
//        {
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from brand "+where);
//        }
//    }
//}
