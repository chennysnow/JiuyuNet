using System;

namespace mo
{
	public class menu
	{
        public menu() {/*���캯��*/}
		public string aboutC{get;set;}
		public int displayC{get;set;}
		public int flgC{get;set;}
		public string htmlName{get;set;}
		public int id{get;set;}
        /// <summary>
        /// ��Ŀ����Ŀǰֻ֧��3����Ŀ��������1��2��3
        /// </summary>
		public int levelC{get;set;}
        /// <summary>
        /// ��Ŀ����
        /// </summary>
		public string nameC{get;set;}
        /// <summary>
        /// ��ʾ����ӳ����Ա���Ŀ���
        /// </summary>
        public int Group_id { get; set; }


              /// <summary>
        /// ��Ŀ��ţ�00��01��C01��
        /// </summary>
        public string Cat_code { get; set; }
        /// <summary>
        /// ��¼����1����Ŀ��2����Ŀ����Ŀ��ţ������1����Ŀ����Ϊ�գ������Ŀ�ö��š�,���ָ�
        /// </summary>
        public string Id_path { get; set; }

        /// <summary>
        /// ��¼����1����Ŀ��2����Ŀ����Ŀ���ƣ������1����Ŀ����Ϊ�գ������Ŀ�ö��š�,���ָ�
        /// </summary>
        public string Name_path { get; set; }


        //public int Level { get; set; }

        /// <summary>
        /// �Ƿ�Ҷ�ӽ�㣬1��ʾ�ǣ�0��ʾ���ǡ�
        /// </summary>
        public int Is_leaf { get; set; }

        /// <summary>
        /// ��Ŀ״̬��-1��ʾɾ����0��ʾ���̣�1��ʾ���ã�2��ʾͣ�ã�Ĭ��Ϊ0
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// ��Ŀӳ��״̬���ж��Ƿ����Ա���Ŀ������ӳ���ϵ��0����δ������1�����ѽ�����2����ӳ����Ա���Ŀ�쳣��Ĭ��Ϊ0
        /// </summary>
        public int Map_status { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public int sortC { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Gmt_create { get; set; }
        /// <summary>
        /// �����˱��
        /// </summary>
        public string Creator_name { get; set; }

        /// <summary>
        /// �޸��˱��
        /// </summary>
        public string Modifier_name { get; set; }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime Gmt_modified { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// �Ƿ�������  0����  1��
        /// </summary>
        public int Has_region { get; set; }
        /// <summary>
        /// ����
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
        /// ��id
        /// </summary>
        public int preId { get; set; }
        /// <summary>
        /// ��id
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
