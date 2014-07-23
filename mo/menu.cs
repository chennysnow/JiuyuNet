using System;

namespace mo
{
	public class menu
	{
        public menu() {/*构造函数*/}
		public string aboutC{get;set;}
		public int displayC{get;set;}
		public int flgC{get;set;}
		public string htmlName{get;set;}
		public int id{get;set;}
        /// <summary>
        /// 类目级别，目前只支持3级类目，所以是1、2或3
        /// </summary>
		public int levelC{get;set;}
        /// <summary>
        /// 类目名称
        /// </summary>
		public string nameC{get;set;}
        /// <summary>
        /// 表示与其映射的淘宝类目编号
        /// </summary>
        public int Group_id { get; set; }


              /// <summary>
        /// 类目编号，00，01，C01等
        /// </summary>
        public string Cat_code { get; set; }
        /// <summary>
        /// 记录所属1级类目、2级类目的类目编号，如果是1级类目，则为空，多个类目用逗号“,”分隔
        /// </summary>
        public string Id_path { get; set; }

        /// <summary>
        /// 记录所属1级类目、2级类目的类目名称，如果是1级类目，则为空，多个类目用逗号“,”分隔
        /// </summary>
        public string Name_path { get; set; }


        //public int Level { get; set; }

        /// <summary>
        /// 是否叶子结点，1表示是，0表示不是。
        /// </summary>
        public int Is_leaf { get; set; }

        /// <summary>
        /// 类目状态，-1表示删除，0表示存盘，1表示启用，2表示停用，默认为0
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 类目映射状态，判断是否与淘宝类目建立了映射关系，0代表未建立，1代表已建立，2代表映射的淘宝类目异常，默认为0
        /// </summary>
        public int Map_status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sortC { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Gmt_create { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        public string Creator_name { get; set; }

        /// <summary>
        /// 修改人编号
        /// </summary>
        public string Modifier_name { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Gmt_modified { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否分配库区  0：否  1是
        /// </summary>
        public int Has_region { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Attribute { get; set; }

		public int typ{get;set;}
		public string urlC{get;set;}
        public int countC { get; set; }
        public string titleC { get; set; }
        public string keywordsC { get; set; }
        public string descriptionC { get; set; }
        public string topKey { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int preId { get; set; }
        /// <summary>
        /// 子id
        /// </summary>
        public string sonId { get; set; }
        public string url
        {
            get
            {
                 return adminUser.siteUrl +"/"+htmlName+"_p"+id; 
            }
        }

	}
}
