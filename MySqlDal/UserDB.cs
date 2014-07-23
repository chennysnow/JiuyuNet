using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public class UserDB: DBBase
    {
        public List<mo.user> getModelListAll()
        {
            return setDr("select * from user");
        }

        private List<mo.user> setDr(string strSql)
        {
            List<mo.user> modelList = new List<mo.user>();


            MySqlDataReader dr = SqlReader(strSql);
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }

        private mo.user setModel(MySqlDataReader dr)
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

        //public void UpdateString(string Ziduan, string strWhere)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.AppendFormat("update uc_user set {0} {1}", Ziduan, strWhere);
        //    SqlExecuteNonQuery(sb.ToString());
        //}

        public void DelId(string where)
        {
            SqlExecuteNonQuery("delete from user " + where);
        }

        public string getString(string ziduan, string strWhere)
        {
            return SqlExecuteScalar("select " + ziduan + " from user " + strWhere);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        public void InsertModel(mo.user model)
        {
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("insert into uc_user(user_name,s_id,status,gmt_create) values (");
            //sb.Append("@user_name,@s_id,@status,@gmt_create)");
            //MySqlParameter[] parameters = { new MySqlParameter("@user_name", MySqlDbType.VarChar, 100), new MySqlParameter("@s_id", MySqlDbType.Int64), new MySqlParameter("@status", MySqlDbType.Bit), new MySqlParameter("@gmt_create", MySqlDbType.DateTime) };


            

            //parameters[0].Value = model.userName;
            //parameters[1].Value = model.SID;
            //parameters[2].Value = model.Status;
            //parameters[3].Value = model.CreateDate;
            //SqlExecuteNonQuery(sb.ToString(), parameters);

            //string id = getString("id", "where user_name='"+model.userName+"'");

            //if (!string.IsNullOrEmpty(id))
            //{
            //    System.Text.StringBuilder sql = new System.Text.StringBuilder();
            //    sql.Append("insert into uc_user_psw(user_id,password,gmt_create) values (");
            //    sql.Append("@user_id,@password,@gmt_create)");
            //    MySqlParameter[] parameters1 = { new MySqlParameter("@user_id", MySqlDbType.UInt64), new MySqlParameter("@password", MySqlDbType.VarChar), new MySqlParameter("@gmt_create", MySqlDbType.DateTime) };

            //    parameters1[0].Value = id;
            //    parameters1[1].Value = model.passwordC;
            //    parameters1[2].Value = model.CreateDate;
            //    SqlExecuteNonQuery(sql.ToString(), parameters1);
            //}



            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into user(addressC,descriptionC,integralC,levelC,loginCount,loginTime,mailC,moneyC,nameC,passwordC,telC,timeC,typ,userName,countryC) values (");
            sb.Append("@addressC,@descriptionC,@integralC,@levelC,@loginCount,@loginTime,@mailC,@moneyC,@nameC,@passwordC,@telC,@timeC,@typ,@userName,@countryC)");
            MySqlParameter[] parameters = { new MySqlParameter("@addressC", MySqlDbType.VarChar, 100), new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@integralC", MySqlDbType.Int32, 10), new MySqlParameter("@levelC", MySqlDbType.VarChar, 50), new MySqlParameter("@loginCount", MySqlDbType.Int32), new MySqlParameter("@loginTime", MySqlDbType.VarChar, 20), new MySqlParameter("@mailC", MySqlDbType.VarChar, 50), new MySqlParameter("@moneyC", MySqlDbType.VarChar, 50), new MySqlParameter("@nameC", MySqlDbType.VarChar, 50), new MySqlParameter("@passwordC", MySqlDbType.VarChar, 50), new MySqlParameter("@telC", MySqlDbType.VarChar, 50), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@userName", MySqlDbType.VarChar, 100), new MySqlParameter("@countryC", MySqlDbType.VarChar, 50) };
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
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }


        //public mo.user getUserByPwd(string userName, string pwd)
        //{
        //    List<mo.user> users = setDr("select * from user where userName='" + userName.Replace(",", ",,") + "'");
        //    if (users == null|| users.Count==0)
        //        return null;
        //    string resID = SqlExecuteScalar("select id from uc_user_psw where password='" + pwd + "' and user_id=" + users[0].id);
        //    if (string.IsNullOrEmpty(resID))
        //        return null;

        //    return users[0];
        //}


        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update user set {0} {1}", Ziduan, strWhere);
            SqlExecuteNonQuery(sb.ToString());
        }

        public mo.user getModel(string strWhere)
        {
            MySqlDataReader dr = SqlReader("select  * from user " + strWhere + "");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        public void UpdateModel(mo.user model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update user set "); sb.Append("addressC=@addressC,");
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
            MySqlParameter[] parameters = { new MySqlParameter("@addressC", MySqlDbType.VarChar, 100), new MySqlParameter("@descriptionC", MySqlDbType.VarChar, 255), new MySqlParameter("@integralC", MySqlDbType.Int32), new MySqlParameter("@levelC", MySqlDbType.VarChar, 50), new MySqlParameter("@loginCount", MySqlDbType.Int32), new MySqlParameter("@loginTime", MySqlDbType.VarChar, 20), new MySqlParameter("@mailC", MySqlDbType.VarChar, 50), new MySqlParameter("@moneyC", MySqlDbType.VarChar, 50), new MySqlParameter("@nameC", MySqlDbType.VarChar, 50), new MySqlParameter("@passwordC", MySqlDbType.VarChar, 50), new MySqlParameter("@telC", MySqlDbType.VarChar, 50), new MySqlParameter("@timeC", MySqlDbType.VarChar, 20), new MySqlParameter("@typ", MySqlDbType.Int32), new MySqlParameter("@userName", MySqlDbType.VarChar, 100), new MySqlParameter("@countryC", MySqlDbType.VarChar, 50), new MySqlParameter("@id", MySqlDbType.Int32) };
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
            SqlExecuteNonQuery(sb.ToString(), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTop"> LIMIT 15</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<mo.user> getModelListWhere(string strTop, string strWhere)
        {
            List<mo.user> modelList = new List<mo.user>();
            MySqlDataReader dr = SqlReader("select  * from user " + strWhere + " order by id desc " + strTop);
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
            MySqlDataReader dr = SqlReader("select * from user " + strWhere + " order by id desc");
            mo.user model = new mo.user();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }

    }
}
