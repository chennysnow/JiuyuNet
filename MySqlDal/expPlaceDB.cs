using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class expPlaceDB : DBBase
    {
        public List<mo.expPlace> getModelListAll()
        {
            List<mo.expPlace> modelList = new List<mo.expPlace>();
            MySqlDataReader dr = SqlReader("select * from expPlace");
            mo.expPlace model = new mo.expPlace();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public List<mo.expPlace> getModelListWhere(string strWhere)
        {
            List<mo.expPlace> modelList = new List<mo.expPlace>();
            MySqlDataReader dr = SqlReader("select * from expPlace " + strWhere + "");
            mo.expPlace model = new mo.expPlace();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        private mo.expPlace setModel(MySqlDataReader dr)
        {
            mo.expPlace model = new mo.expPlace();
            model.placeId = (int)dr["placeId"];
            model.priceC = double.Parse(dr["priceC"].ToString());
            model.typ = (int)dr["typ"];
            return model;
        }
        public void InsertModel(mo.expPlace model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into expPlace(placeId,priceC,typ) values (");
            sb.Append("@placeId,@priceC,@typ)");
            MySqlParameter[] parameters = { 
                                           new MySqlParameter("@placeId", MySqlDbType.Int32),
                                           new MySqlParameter("@priceC", MySqlDbType.Double, 10),
                                           new MySqlParameter("@typ", MySqlDbType.Int32)};
            parameters[0].Value = model.placeId;
            parameters[1].Value = model.priceC;
            parameters[2].Value = model.typ;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from expPlace " + strWhere);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update expPlace set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from expPlace where " + where);
        }
    }
}
