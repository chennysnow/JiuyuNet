using System;
using System.Configuration;

namespace mo
{
    public class adminUser
    {
        public static string siteUrl = ConfigurationManager.AppSettings["siteUrl"].ToString();
        public adminUser() { }
        public int id { get; set; }
        public string userName { get; set; }
        public string passwordC { get; set; }
        public string timeC { get; set; }
        public string historyC { get; set; }
        public string nameC { get; set; }
        public string telC { get; set; }
        public int typ { get; set; }
    }
}
