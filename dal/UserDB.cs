using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class UserDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.user> getModelListAll()
        {
            List<mo.user> modelList = new List<mo.user>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from [user]");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.user> getModelListWhere(string strWhere)
        {
            List<mo.user> modelList = new List<mo.user>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from [user] " + strWhere + " order by id desc");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.user> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.user> modelList = new List<mo.user>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from [user] " + strWhere + " order by id desc");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.user> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.user> modelList = new List<mo.user>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from [user] " + strWhere + " " + order + "");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.user getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from [user] " + strWhere + "");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.user setModel(OleDbDataReader dr)
        {
            mo.user model = new mo.user();
            model.addressC = dr["addressC"].ToString();
            model.descriptionC = dr["descriptionC"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.integralC = int.Parse(dr["integralC"].ToString());
            model.levelC = dr["levelC"].ToString();
            model.loginCount = int.Parse(dr["loginCount"].ToString());
            model.loginTime = dr["loginTime"].ToString();
            model.mailC = dr["mailC"].ToString();
            model.moneyC = dr["moneyC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.passwordC = dr["passwordC"].ToString();
            model.telC = dr["telC"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            model.userName = dr["userName"].ToString();
            model.countryC = dr["countryC"].ToString();
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from [user] " + strWhere);
        }
        public void InsertModel(mo.user model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into [user](addressC,descriptionC,integralC,levelC,loginCount,loginTime,mailC,moneyC,nameC,passwordC,telC,timeC,typ,userName,countryC) values (");
            sb.Append("@addressC,@descriptionC,@integralC,@levelC,@loginCount,@loginTime,@mailC,@moneyC,@nameC,@passwordC,@telC,@timeC,@typ,@userName,@countryC)");
            OleDbParameter[] parameters = { new OleDbParameter("@addressC", OleDbType.VarChar, 100), new OleDbParameter("@descriptionC", OleDbType.VarChar, 255), new OleDbParameter("@integralC", OleDbType.Integer, 10), new OleDbParameter("@levelC", OleDbType.VarChar, 50), new OleDbParameter("@loginCount", OleDbType.Integer, 10), new OleDbParameter("@loginTime", OleDbType.VarChar, 20), new OleDbParameter("@mailC", OleDbType.VarChar, 50), new OleDbParameter("@moneyC", OleDbType.VarChar, 50), new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@passwordC", OleDbType.VarChar, 50), new OleDbParameter("@telC", OleDbType.VarChar, 50), new OleDbParameter("@timeC", OleDbType.VarChar, 20), new OleDbParameter("@typ", OleDbType.Integer, 10), new OleDbParameter("@userName", OleDbType.VarChar, 100), new OleDbParameter("@countryC", OleDbType.VarChar, 50) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.descriptionC;
            parameters[2].Value = model.integralC;
            parameters[3].Value = model.levelC;
            parameters[4].Value = model.loginCount;
            parameters[5].Value = model.loginTime;
            parameters[6].Value = model.mailC;
            parameters[7].Value = model.moneyC;
            parameters[8].Value = model.nameC;
            parameters[9].Value = model.passwordC;
            parameters[10].Value = model.telC;
            parameters[11].Value = model.timeC;
            parameters[12].Value = model.typ;
            parameters[13].Value = model.userName;
            parameters[14].Value = model.countryC;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.user model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update [user] set "); sb.Append("addressC=@addressC,");
            sb.Append("descriptionC=@descriptionC,");
            sb.Append("integralC=@integralC,");
            sb.Append("levelC=@levelC,");
            sb.Append("loginCount=@loginCount,");
            sb.Append("loginTime=@loginTime,");
            sb.Append("mailC=@mailC,");
            sb.Append("moneyC=@moneyC,");
            sb.Append("nameC=@nameC,");
            sb.Append("passwordC=@passwordC,");
            sb.Append("telC=@telC,");
            sb.Append("timeC=@timeC,");
            sb.Append("typ=@typ,");
            sb.Append("userName=@userName,");
            sb.Append("countryC=@countryC");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@addressC", OleDbType.VarChar, 100), new OleDbParameter("@descriptionC", OleDbType.VarChar, 255), new OleDbParameter("@integralC", OleDbType.Integer, 10), new OleDbParameter("@levelC", OleDbType.VarChar, 50), new OleDbParameter("@loginCount", OleDbType.Integer, 10), new OleDbParameter("@loginTime", OleDbType.VarChar, 20), new OleDbParameter("@mailC", OleDbType.VarChar, 50), new OleDbParameter("@moneyC", OleDbType.VarChar, 50), new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@passwordC", OleDbType.VarChar, 50), new OleDbParameter("@telC", OleDbType.VarChar, 50), new OleDbParameter("@timeC", OleDbType.VarChar, 20), new OleDbParameter("@typ", OleDbType.Integer, 10), new OleDbParameter("@userName", OleDbType.VarChar, 100), new OleDbParameter("@countryC", OleDbType.VarChar, 50), new OleDbParameter("@id", OleDbType.Integer, 10) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.descriptionC;
            parameters[2].Value = model.integralC;
            parameters[3].Value = model.levelC;
            parameters[4].Value = model.loginCount;
            parameters[5].Value = model.loginTime;
            parameters[6].Value = model.mailC;
            parameters[7].Value = model.moneyC;
            parameters[8].Value = model.nameC;
            parameters[9].Value = model.passwordC;
            parameters[10].Value = model.telC;
            parameters[11].Value = model.timeC;
            parameters[12].Value = model.typ;
            parameters[13].Value = model.userName;
            parameters[14].Value = model.countryC;
            parameters[15].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update [user] set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from [user] where " + id);
        }
    }
}
