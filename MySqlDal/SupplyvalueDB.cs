﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class SupplyvalueDB:DBBase
    {
        public List<mo.supplyvalue> getModelListAll()
        {
            return setDr("select * from supplyvalue");
        }
        public List<mo.supplyvalue> getModelListWhere(string strWhere)
        {
            return setDr("select * from supplyvalue " + strWhere + " order by address desc");
        }
        public List<mo.supplyvalue> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select * from supplyvalue " + strWhere + " order by address desc " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        public List<mo.supplyvalue> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select * from supplyvalue " + strWhere + " " + order + " " + strTop.ToLower().Replace("top", "LIMIT"));
        }
        private List<mo.supplyvalue> setDr(string strSql)
        {
            List<mo.supplyvalue> modelList = new List<mo.supplyvalue>();
            MySqlDataReader dr = SqlReader(strSql);
            mo.supplyvalue model = new mo.supplyvalue();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.supplyvalue getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from supplyvalue " + strWhere + "");
            mo.supplyvalue model = new mo.supplyvalue();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.supplyvalue setModel(MySqlDataReader dr)
        {
            mo.supplyvalue model = new mo.supplyvalue();
            model.id = int.Parse(dr["id"].ToString());

            model.value = dr["value"].ToString();
            model.note2 = dr["note2"].ToString();
            model.note3 = dr["note3"].ToString();
            model.note4 = dr["note4"].ToString();


            model.name = dr["name"].ToString();
            model.types = dr["types"].ToString();


            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from supplyvalue " + strWhere);
        }
        public void InsertModel(mo.supplyvalue model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into supplyvalue(  `name` ,  types ,  `value` , note2 ,  note3 , note4) values (");
            sb.Append("  @name ,  @types ,  @value , @note2 ,  @note3 , @note4 )");
            MySqlParameter[] parameters ={
                                           new MySqlParameter("@name",MySqlDbType.VarChar,50),
                                      
                                           new MySqlParameter("@types",MySqlDbType.VarChar,50),
                                           new MySqlParameter("@value",MySqlDbType.VarChar,255),
                                           new MySqlParameter("@note2",MySqlDbType.VarChar,255),
                                            new MySqlParameter("@note3",MySqlDbType.VarChar,255),
                                           new MySqlParameter("@note4",MySqlDbType.VarChar,255)};

            parameters[0].Value = model.name;
            parameters[1].Value = model.types;
            parameters[2].Value = model.value;
            parameters[3].Value = model.note2;
            parameters[4].Value = model.note3;
            parameters[5].Value = model.note4;

            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.supplyvalue model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update supplyvalue set ");
            sb.Append("`name`=@name,");

            sb.Append("types=@types,");
            sb.Append("`value`=@value,");
            sb.Append("note2=@note2,");
            sb.Append("note3=@note3,");
            sb.Append("note4=@note4");
            sb.Append(" where id=@id");
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@name",MySqlDbType.VarChar,50),
                                      
                                           new MySqlParameter("@types",MySqlDbType.VarChar,50),
                                           new MySqlParameter("@value",MySqlDbType.VarChar,255),
                                           new MySqlParameter("@note2",MySqlDbType.VarChar,255),
                                            new MySqlParameter("@note3",MySqlDbType.VarChar,255),
                                           new MySqlParameter("@note4",MySqlDbType.VarChar,255),
                                           new MySqlParameter("@id",MySqlDbType.Int32)};
            parameters[0].Value = model.name;

            parameters[1].Value = model.types;
            parameters[2].Value = model.value;
            parameters[3].Value = model.note2;
            parameters[4].Value = model.note3;
            parameters[5].Value = model.note4;
            parameters[6].Value = model.id;
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update supplyvalue set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from supplyvalue " + where);
        }
    }
}
