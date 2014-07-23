//using System;
//using System.Collections.Generic;
//using System.Data.OleDb;

//namespace dal
//{
//    public class orderPro
//    {
//        public orderPro(){/*¹¹Ôìº¯Êý*/}
//        protected opDal.Operation ope = new opDal.Operation();

//        public List<mo.orderPro> getModelListAll()
//        {
//            List<mo.orderPro> modelList=new List<mo.orderPro>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from orderPro");
//            mo.orderPro model=new mo.orderPro();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.orderPro> getModelListWhere(string strWhere)
//        {
//            List<mo.orderPro> modelList=new List<mo.orderPro>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from orderPro " + strWhere + "");
//            mo.orderPro model=new mo.orderPro();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.orderPro> getModelListWhere(string strTop, string strWhere)
//        {
//            List<mo.orderPro> modelList=new List<mo.orderPro>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from orderPro " + strWhere + "");
//            mo.orderPro model=new mo.orderPro();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                modelList.Add(model);
//                }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public List<mo.orderPro> getModelListWhere(string strTop, string strWhere, string order)
//        {
//            List<mo.orderPro> modelList=new List<mo.orderPro>();
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from orderPro " + strWhere + " " + order + "");
//            mo.orderPro model=new mo.orderPro();
//            while(dr.Read())
//            {
//                model=setModel(dr);
//                modelList.Add(model);
//            }
//            dr.Close();  dr.Dispose();
//             return modelList;
//        }
//        public mo.orderPro getModel(string strWhere)
//        {
//            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from orderPro "+strWhere+"");
//            mo.orderPro model=new mo.orderPro();
//            while(dr.Read())
//                {
//                model=setModel(dr);
//                }
//            dr.Close();  dr.Dispose();
//             return model;
//        }
//        private mo.orderPro setModel(OleDbDataReader dr)
//        {
//            mo.orderPro model=new mo.orderPro();
//            model.countC = int.Parse(dr["countC"].ToString());
//            model.htmlName = dr["htmlName"].ToString();
//            model.id = int.Parse(dr["id"].ToString());
//            model.imgC = dr["imgC"].ToString();
//            model.nameC = dr["nameC"].ToString();
//            model.numC = dr["numC"].ToString();
//            model.priceC = double.Parse(dr["priceC"].ToString());
//            model.proId = dr["proId"].ToString();
//            model.remarkC = dr["remarkC"].ToString();
//            model.weightC = double.Parse(dr["weightC"].ToString());
//            return model;
//        }
//        public string getString(string ziduan, string strWhere)
//        {
//            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from orderPro " + strWhere);
//        }
//        public void InsertModel(mo.orderPro model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.Append("insert into orderPro(countC,htmlName,imgC,nameC,numC,priceC,proId,remarkC,weightC) values (");
//            sb.Append("@countC,@htmlName,@imgC,@nameC,@numC,@priceC,@proId,@remarkC,@weightC)");
//            OleDbParameter[] parameters ={new OleDbParameter("@countC",OleDbType.Integer,10),new OleDbParameter("@htmlName",OleDbType.VarChar,100),new OleDbParameter("@imgC",OleDbType.VarChar,100),new OleDbParameter("@nameC",OleDbType.VarChar,255),new OleDbParameter("@numC",OleDbType.VarChar,20),new OleDbParameter("@priceC",OleDbType.VarChar,0),new OleDbParameter("@proId",OleDbType.VarChar,50),new OleDbParameter("@remarkC",OleDbType.VarChar,255),new OleDbParameter("@weightC",OleDbType.VarChar,0)};
//            parameters[0].Value = model.countC;
//            parameters[1].Value = model.htmlName;
//            parameters[2].Value = model.imgC;
//            parameters[3].Value = model.nameC;
//            parameters[4].Value = model.numC;
//            parameters[5].Value = model.priceC;
//            parameters[6].Value = model.proId;
//            parameters[7].Value = model.remarkC;
//            parameters[8].Value = model.weightC;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateModel(mo.orderPro model)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//sb.Append("update orderPro set ");			sb.Append("countC=@countC,");
//            sb.Append("htmlName=@htmlName,");
//            sb.Append("imgC=@imgC,");
//            sb.Append("nameC=@nameC,");
//            sb.Append("numC=@numC,");
//            sb.Append("priceC=@priceC,");
//            sb.Append("proId=@proId,");
//            sb.Append("remarkC=@remarkC,");
//            sb.Append("weightC=@weightC");
//            sb.Append(" where id=@id");
//            OleDbParameter[] parameters ={new OleDbParameter("@countC",OleDbType.Integer,10),new OleDbParameter("@htmlName",OleDbType.VarChar,100),new OleDbParameter("@imgC",OleDbType.VarChar,100),new OleDbParameter("@nameC",OleDbType.VarChar,255),new OleDbParameter("@numC",OleDbType.VarChar,20),new OleDbParameter("@priceC",OleDbType.VarChar,0),new OleDbParameter("@proId",OleDbType.VarChar,50),new OleDbParameter("@remarkC",OleDbType.VarChar,255),new OleDbParameter("@weightC",OleDbType.VarChar,0)};
//            parameters[0].Value = model.countC;
//            parameters[1].Value = model.htmlName;
//            parameters[2].Value = model.imgC;
//            parameters[3].Value = model.nameC;
//            parameters[4].Value = model.numC;
//            parameters[5].Value = model.priceC;
//            parameters[6].Value = model.proId;
//            parameters[7].Value = model.remarkC;
//            parameters[8].Value = model.weightC;
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
//        }
//        public void UpdateString(string Ziduan, string strWhere)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            sb.AppendFormat("update orderPro set {0} {1}", Ziduan, strWhere);
//            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
//        }
//        public void DelId(int id)
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            opDal.Sqlcs.SqlExecuteNonQuery("delete from orderPro where id=" + id);
//        }
//    }
//}
