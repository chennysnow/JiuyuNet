using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace dal
{
    public class userFavorite
    {
        public userFavorite() {/*¹¹Ôìº¯Êý*/}
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.userFavorite> getModelListAll()
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from userFavorite");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strWhere)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select * from userFavorite " + strWhere + " order by sortC desc");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from userFavorite " + strWhere + " order by sortC desc");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.userFavorite> getModelListWhere(string strTop, string strWhere, string order)
        {
            List<mo.userFavorite> modelList = new List<mo.userFavorite>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select " + strTop + " * from userFavorite " + strWhere + " " + order + "");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.userFavorite getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from userFavorite " + strWhere + "");
            mo.userFavorite model = new mo.userFavorite();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.userFavorite setModel(OleDbDataReader dr)
        {
            mo.userFavorite model = new mo.userFavorite();
            model.id = int.Parse(dr["id"].ToString());
            model.proId = int.Parse(dr["proId"].ToString());
            model.sortC = int.Parse(dr["sortC"].ToString());
            model.userId = int.Parse(dr["userId"].ToString());
            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from userFavorite " + strWhere);
        }
        public void InsertModel(mo.userFavorite model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into userFavorite(proId,sortC,userId) values (");
            sb.Append("@proId,@sortC,@userId)");
            OleDbParameter[] parameters = { new OleDbParameter("@proId", OleDbType.Integer, 10), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@userId", OleDbType.Integer, 10) };
            parameters[0].Value = model.proId;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.userId;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.userFavorite model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update userFavorite set ");
            sb.Append("proId=@proId,");
            sb.Append("sortC=@sortC,");
            sb.Append("userId=@userId");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters = { new OleDbParameter("@proId", OleDbType.Integer, 10), new OleDbParameter("@sortC", OleDbType.Integer, 10), new OleDbParameter("@userId", OleDbType.Integer, 10), new OleDbParameter("@id", OleDbType.Integer, 10) };

            parameters[0].Value = model.proId;
            parameters[1].Value = model.sortC;
            parameters[2].Value = model.userId;
            parameters[3].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update userFavorite set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            opDal.Sqlcs.SqlExecuteNonQuery("delete from userFavorite where id=" + id);
        }
    }
}
