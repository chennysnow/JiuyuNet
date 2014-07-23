using System;

namespace mo
{
	public class news
	{
		public string aboutC{get;set;}
		public string contentC{get;set;}
		public string descriptionC{get;set;}
		public string htmlName{get;set;}
		public int id{get;set;}
		public string keywordsC{get;set;}
		public string nameC{get;set;}
		public int sortC{get;set;}
		public string timeC{get;set;}
		public string titleC{get;set;}
		public int typ{get;set;}
		public string typS{get;set;}
        public int showC { get; set; }
		public news(){/*¹¹Ôìº¯Êı*/}
        public string url
        {
            get
            {
                return adminUser.siteUrl + "/news/" + htmlName;
            }
        }
	}
}
