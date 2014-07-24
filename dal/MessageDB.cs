using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class MessageDB
    {
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.message> getModelListAll()
        {
            List<mo.message> modelList = new List<mo.message>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from message");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strWhere)
        {
            List<mo.message> modelList = new List<mo.message>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from message " + strWhere + " order by id desc");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.message> modelList = new List<mo.message>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from message " + strWhere + " order by id desc");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.message> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.message> modelList = new List<mo.message>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from message " + strWhere + " " + order + "");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.message getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from message " + strWhere + "");
            mo.message model = new mo.message();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.message setModel(OleDbDataReader dr)
        {
            mo.message model = new mo.message();
            model.addressC = dr["addressC"].ToString();
            model.contentC = dr["contentC"].ToString();
            model.id = int.Parse(dr["id"].ToString());
            model.ipC = dr["ipC"].ToString();
            model.mailC = dr["mailC"].ToString();
            model.nameC = dr["nameC"].ToString();
            model.product = dr["product"].ToString();
            model.telC = dr["telC"].ToString();
            model.timeC = dr["timeC"].ToString();
            model.typ = int.Parse(dr["typ"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from message " + strWhere);
        }
        public void InsertModel(mo.message model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into message(addressC,contentC,ipC,mailC,nameC,product,telC,timeC,typ) values (");
            sb.Append("@addressC,@contentC,@ipC,@mailC,@nameC,@product,@telC,@timeC,@typ)");
            OleDbParameter[] parameters = { new OleDbParameter("@addressC", OleDbType.VarChar, 255), new OleDbParameter("@contentC", OleDbType.VarChar, 0), new OleDbParameter("@ipC", OleDbType.VarChar, 50), new OleDbParameter("@mailC", OleDbType.VarChar, 100), new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@product", OleDbType.VarChar, 100), new OleDbParameter("@telC", OleDbType.VarChar, 50), new OleDbParameter("@timeC", OleDbType.VarChar, 20), new OleDbParameter("@typ", OleDbType.Integer, 10) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.ipC;
            parameters[3].Value = model.mailC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.product;
            parameters[6].Value = model.telC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.typ;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.message model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update message set "); sb.Append("addressC=@addressC,");
            sb.Append("contentC=@contentC,");
            sb.Append("ipC=@ipC,");
            sb.Append("mailC=@mailC,");
            sb.Append("nameC=@nameC,");
            sb.Append("product=@product,");
            sb.Append("telC=@telC,");
            sb.Append("timeC=@timeC,");
            sb.Append("typ=@typ");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@addressC", OleDbType.VarChar, 255), new OleDbParameter("@contentC", OleDbType.VarChar, 0), new OleDbParameter("@ipC", OleDbType.VarChar, 50), new OleDbParameter("@mailC", OleDbType.VarChar, 100), new OleDbParameter("@nameC", OleDbType.VarChar, 50), new OleDbParameter("@product", OleDbType.VarChar, 100), new OleDbParameter("@telC", OleDbType.VarChar, 50), new OleDbParameter("@timeC", OleDbType.VarChar, 20), new OleDbParameter("@typ", OleDbType.Integer, 10), new OleDbParameter("@id", OleDbType.Integer, 10) };
            parameters[0].Value = model.addressC;
            parameters[1].Value = model.contentC;
            parameters[2].Value = model.ipC;
            parameters[3].Value = model.mailC;
            parameters[4].Value = model.nameC;
            parameters[5].Value = model.product;
            parameters[6].Value = model.telC;
            parameters[7].Value = model.timeC;
            parameters[8].Value = model.typ;
            parameters[9].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update message set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string id)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from message where " + id);
        }
    }
}
