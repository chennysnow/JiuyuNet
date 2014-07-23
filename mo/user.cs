using System;

namespace mo
{
    public class user
    {
        public string addressC{get;set;}
        public string descriptionC{get;set;}
        public int id{get;set;}
        public int integralC{get;set;}
        public string levelC{get;set;}
        public int loginCount{get;set;}
        public string loginTime{get;set;}
        public string mailC{get;set;}
        public string moneyC{get;set;}
        public string nameC{get;set;}
        public string passwordC{get;set;}
        public string telC{get;set;}
        public string timeC{get;set;}
        public int typ{get;set;}
        public string userName{get;set;}
        public string Sex { get; set; }
     
        /// <summary>
        /// 等级
        /// </summary>
        public string Creditlevel { get; set; }
        public string countryC { get; set; }
        public user() {/*注册用户*/}

        /// <summary>
        /// 店铺主键ID
        /// </summary>
        public int SID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }


    }
}
