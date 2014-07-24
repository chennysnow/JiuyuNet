using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
namespace dal
{
    public class SupplyDB
    {
        public SupplyDB() {/*¹¹Ôìº¯Êý*/}
        protected opDal.Operation ope = new opDal.Operation();

        public List<mo.supply> getModelListAll()
        {
            return setDr("select * from supply");
        }
        public List<mo.supply> getModelListWhere(string strWhere)
        {
            return setDr("select * from supply " + strWhere + " order by address desc");
        }
        public List<mo.supply> getModelListWhere(string strTop, string strWhere)
        {
            return setDr("select " + strTop + " * from supply " + strWhere + " order by address desc");
        }
        public List<mo.supply> getModelListWhere(string strTop, string strWhere, string order)
        {
            return setDr("select " + strTop + " * from supply " + strWhere + " " + order + "");
        }
        private List<mo.supply> setDr(string strSql)
        {
            List<mo.supply> modelList = new List<mo.supply>();
            OleDbDataReader dr = opDal.Sqlcs.SqlReader(strSql);
            mo.supply model = new mo.supply();
            while (dr.Read())
            {
                model = setModel(dr);
                modelList.Add(model);
            }
            dr.Close(); dr.Dispose();
            return modelList;
        }
        public mo.supply getModel(string strWhere)
        {
            OleDbDataReader dr = opDal.Sqlcs.SqlReader("select  * from supply " + strWhere + "");
            mo.supply model = new mo.supply();
            while (dr.Read())
            {
                model = setModel(dr);
            }
            dr.Close(); dr.Dispose();
            return model;
        }
        private mo.supply setModel(OleDbDataReader dr)
        {
            mo.supply model = new mo.supply();
            model.id = int.Parse(dr["id"].ToString());
            model.abrand = dr["abrand"].ToString();
            model.account = dr["account"].ToString();
            model.address = dr["address"].ToString();
            model.agentyp = dr["agentyp"].ToString();
            model.Banks = dr["Banks"].ToString();
            model.contactus = dr["contactus"].ToString();
            model.mail = dr["mail"].ToString();
            model.note1 = dr["note1"].ToString();
            model.note2 = dr["note2"].ToString();
            model.note3 = dr["note3"].ToString();
            model.note4 = dr["note4"].ToString();
            model.phone = dr["phone"].ToString();
            model.raddress = dr["raddress"].ToString();
            model.rcontact = dr["rcontact"].ToString();
            model.rphone = dr["rphone"].ToString();

            model.sname = dr["sname"].ToString();
            model.times = dr["times"].ToString();


            return model;
        }
        public string getString(string ziduan, string strWhere)
        {
            return opDal.Sqlcs.SqlExecuteScalar("select " + ziduan + " from supply " + strWhere);
        }
        public void InsertModel(mo.supply model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("insert into supply(  sname , contactus ,  phone  , address  , mail , agentyp ,  abrand , Banks , account , raddress , rcontact  , rphone , times ,  note1 , note2 ,  note3 , note4 ) values (");
            sb.Append("  @sname , @contactus ,  @phone  , @address  , @mail , @agentyp ,  @abrand , @Banks , @account , @raddress , @rcontact  , @rphone , @times ,  @note1 , @note2 ,  @note3 , @note4 )");
            OleDbParameter[] parameters ={
                                           new OleDbParameter("@sname",OleDbType.VarChar,50),
                                           new OleDbParameter("@contactus",OleDbType.VarChar,50),
                                           new OleDbParameter("@phone",OleDbType.VarChar,50),
                                           new OleDbParameter("@address",OleDbType.VarChar,50),
                                           new OleDbParameter("@mail",OleDbType.VarChar,50),
                                           new OleDbParameter("@agentyp",OleDbType.VarChar,2000),
                                           new OleDbParameter("@abrand",OleDbType.VarChar,2000),
                                           new OleDbParameter("@Banks",OleDbType.VarChar,300),
                                           new OleDbParameter("@account",OleDbType.VarChar,255),
                                           new OleDbParameter("@raddress",OleDbType.VarChar,255),
                                           new OleDbParameter("@rcontact",OleDbType.VarChar,500),
                                           new OleDbParameter("@rphone",OleDbType.VarChar,50),  
                                           new OleDbParameter("@times",OleDbType.VarChar,50),
                                           new OleDbParameter("@note1",OleDbType.VarChar,255),
                                           new OleDbParameter("@note2",OleDbType.VarChar,255),
                                            new OleDbParameter("@note3",OleDbType.VarChar,255),
                                           new OleDbParameter("@note4",OleDbType.VarChar,255)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.contactus;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.address;
            parameters[4].Value = model.mail;
            parameters[5].Value = model.agentyp;
            parameters[6].Value = model.abrand;
            parameters[7].Value = model.Banks;
            parameters[8].Value = model.account;
            parameters[9].Value = model.raddress;
            parameters[10].Value = model.rcontact;
            parameters[11].Value = model.rphone;
            parameters[12].Value = model.times;
            parameters[13].Value = model.note1;
            parameters[14].Value = model.note2;
            parameters[15].Value = model.note3;
            parameters[16].Value = model.note4;

            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateModel(mo.supply model)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("update supply set ");
            sb.Append("sname=@sname,");
            sb.Append("contactus=@contactus,");
            sb.Append("phone=@phone,");
            sb.Append("address=@address,");
            sb.Append("mail=@mail,");
            sb.Append("agentyp=@agentyp,");
            sb.Append("abrand=@abrand,");
            sb.Append("Banks=@Banks,");
            sb.Append("account=@account,");
            sb.Append("raddress=@raddress,");
            sb.Append("rcontact=@rcontact,");
            sb.Append("rphone=@rphone,");
            sb.Append("times=@times,");
            sb.Append("note1=@note1,");
            sb.Append("note2=@note2,");
            sb.Append("note3=@note3,");
            sb.Append("note4=@note4");
            sb.Append(" where id=@id");
            OleDbParameter[] parameters ={
                                           new OleDbParameter("@sname",OleDbType.VarChar,50),
                                           new OleDbParameter("@contactus",OleDbType.VarChar,50),
                                           new OleDbParameter("@phone",OleDbType.VarChar,50),
                                           new OleDbParameter("@address",OleDbType.VarChar,50),
                                           new OleDbParameter("@mail",OleDbType.VarChar,50),
                                      new OleDbParameter("@agentyp",OleDbType.VarChar,2000),
                                           new OleDbParameter("@abrand",OleDbType.VarChar,2000),
                                           new OleDbParameter("@Banks",OleDbType.VarChar,300),
                                           new OleDbParameter("@account",OleDbType.VarChar,255),
                                           new OleDbParameter("@raddress",OleDbType.VarChar,255),
                                           new OleDbParameter("@rcontact",OleDbType.VarChar,500),
                                           new OleDbParameter("@rphone",OleDbType.VarChar,50),  
                                           new OleDbParameter("@times",OleDbType.VarChar,50),
                                           new OleDbParameter("@note1",OleDbType.VarChar,255),
                                           new OleDbParameter("@note2",OleDbType.VarChar,255),
                                            new OleDbParameter("@note3",OleDbType.VarChar,255),
                                           new OleDbParameter("@note4",OleDbType.VarChar,255),
                                           new OleDbParameter("@id",OleDbType.BigInt,10)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.contactus;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.address;
            parameters[4].Value = model.mail;
            parameters[5].Value = model.agentyp;
            parameters[6].Value = model.abrand;
            parameters[7].Value = model.Banks;
            parameters[8].Value = model.account;
            parameters[9].Value = model.raddress;
            parameters[10].Value = model.rcontact;
            parameters[11].Value = model.rphone;
            parameters[12].Value = model.times;
            parameters[13].Value = model.note1;
            parameters[14].Value = model.note2;
            parameters[15].Value = model.note3;
            parameters[16].Value = model.note4;
            parameters[17].Value = model.id;
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString(), parameters);
        }
        public void UpdateString(string Ziduan, string strWhere)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("update supply set {0} {1}", Ziduan, strWhere);
            opDal.Sqlcs.SqlExecuteNonQuery(sb.ToString());
        }
        public void DelId(string where)
        {
            opDal.Sqlcs.SqlExecuteNonQuery("delete from supply " + where);
        }
    }
}
