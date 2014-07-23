//using System;
//using System.Collections.Generic;
//using System.Data.OleDb;

//namespace dal
//{
//    public class searchWords
//    {
//        public searchWords(){/*¹¹Ôìº¯Êý*/}
//        protected opDal.Operation ope = new opDal.Operation();

//        public List<mo.searchWords> getModelListAll()
//        {
//            List<mo.searchWords> modelList=new List<mo.searchWords>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from searchWords");
//            mo.searchWords model=new mo.searchWords();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.searchWords> getModelListWhere(string strWhere)
//        {
//            List<mo.searchWords> modelList=new List<mo.searchWords>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from searchWords " + strWhere + " order by countC desc");
//            mo.searchWords model=new mo.searchWords();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.searchWords> getModelListWhere(string strTop, string strWhere)
//        {
//            List<mo.searchWords> modelList=new List<mo.searchWords>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from searchWords " + strWhere + " order by countC desc");
//            mo.searchWords model=new mo.searchWords();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.searchWords> getModelListWhere(string strTop, string strWhere, string order)
//        {
//            List<mo.searchWords> modelList=new List<mo.searchWords>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from searchWords " + strWhere + " " + order + "");
//            mo.searchWords model=new mo.searchWords();
//            while(dr.Read())
//            {
//                model=setModel(dr);
//                modelList.Add(model);
//            }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public mo.searchWords getModel(string strWhere)
//        {
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from searchWords "+strWhere+"");
//            mo.searchWords model=new mo.searchWords();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                }
//            dr.Close();  dr.Dispose();
//             return model;
//        }
//        private mo.searchWords setModel(OleDbDataReader dr)
//        {
//            mo.searchWords model=new mo.searchWords();
//            model.countC = int.Parse(dr["countC"].ToString());
//            model.id = int.Parse(dr["id"].ToString());
//            model.nameC = dr["nameC"].ToString();
//            return model;
//        }
//        public string getString(string ziduan, string strWhere)
//        {
//            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from searchWords " + strWhere);
//        }
//        public void InsertModel(mo.searchWords model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("insert into searchWords(countC,nameC) values (");
//            sb.Append("@countC,@nameC)");
//            OleDbParameter[] parameters ={new OleDbParameter("@countC",OleDbType.Integer,10),new OleDbParameter("@nameC",OleDbType.VarChar,255)};
//            parameters[0].Value = model.countC;
//            parameters[1].Value = model.nameC;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateModel(mo.searchWords model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//sb.Append("update searchWords set ");			sb.Append("countC=@countC,");
//            sb.Append("nameC=@nameC");
//            sb.Append(" where id=@id");
//            OleDbParameter[] parameters = { new OleDbParameter("@countC", OleDbType.Integer, 10), new OleDbParameter("@nameC", OleDbType.VarChar, 255), new OleDbParameter("@id", OleDbType.Integer, 10) };
//            parameters[0].Value = model.countC;
//            parameters[1].Value = model.nameC;
//            parameters[2].Value = model.id;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateString(string Ziduan, string strWhere)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.AppendFormat("update searchWords set {0} {1}", Ziduan, strWhere);
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
//        }
//        public void DelId(int id)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from searchWords where id=" + id);
//        }
//    }
//}
