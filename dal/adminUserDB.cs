using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace dal
{
    public class adminUserDB
    {

        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.adminUser> getModelListAll()
        {
            List<mo.adminUser> modelList = new List<mo.adminUser>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from adminUser");
            mo.adminUser model = new mo.adminUser();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.adminUser> getModelListWhere(string strWhere)
        {
            List<mo.adminUser> modelList = new List<mo.adminUser>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from adminUser " + strWhere + " order by id desc");
            mo.adminUser model = new mo.adminUser();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.adminUser> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.adminUser> modelList = new List<mo.adminUser>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from adminUser " + strWhere + " order by id desc");
            mo.adminUser model = new mo.adminUser();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.adminUser> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.adminUser> modelList = new List<mo.adminUser>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from adminUser " + strWhere + " " + order + "");
            mo.adminUser model = new mo.adminUser();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.adminUser getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from adminUser " + strWhere + "");
            mo.adminUser model = new mo.adminUser();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.adminUser setModel(OleDbDataReader dr)
        {
            mo.adminUser model = new mo.adminUser();
            model.id = int.Parse(dr["id"].ToString());
            model.userName = dr["userName"].ToString();
            model.passwordC = dr["passwordC"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.historyC = dr["historyC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.telC = dr["telC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from adminUser " + strWhere);
        }
        public void InsertModel(mo.adminUser model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into adminUser(userName,passwordC,timeC,historyC,nameC,telC,typ) values (");
            sb.Append("@userName,@passwordC,@timeC,@historyC,@nameC,@telC,@typ)");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                          new OleDbParameter("@passwordC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@timeC", OleDbType.VarChar,20),
                                          new OleDbParameter("@historyC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@telC", OleDbType.VarChar, 50),
                                           new OleDbParameter("@typ", OleDbType.Integer, 10)
                                          };
            parameters[0].Value = model.userName;
            parameters[1].Value = model.passwordC;
            parameters[2].Value = model.timeC;
            parameters[3].Value = model.historyC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.telC;
            parameters[6].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.adminUser model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update adminUser set ");
            sb.Append("userName=@userName,");
            sb.Append("passwordC=@passwordC,");
            sb.Append("timeC=@timeC,");
            sb.Append("historyC=@historyC,");
            sb.Append("nameC=@nameC,");
            sb.Append("telC=@telC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { 
                                          new OleDbParameter("@userName", OleDbType.VarChar, 50),
                                          new OleDbParameter("@passwordC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@timeC", OleDbType.VarChar,20),
                                          new OleDbParameter("@historyC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@nameC", OleDbType.VarChar, 50),
                                          new OleDbParameter("@telC", OleDbType.VarChar, 50),
                                           new OleDbParameter("@typ", OleDbType.Integer, 10),
                                          new OleDbParameter("@id", OleDbType.Integer, 10)
                                          };
            parameters[0].Value = model.userName;
            parameters[1].Value = model.passwordC;
            parameters[2].Value = model.timeC;
            parameters[3].Value = model.historyC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.telC;
            parameters[6].Value = model.typ;
            parameters[7].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update adminUser set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from adminUser where id=" + id);
        }
    }
}
