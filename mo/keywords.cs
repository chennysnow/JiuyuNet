using System;

namespace mo
{
	public class keywords
	{
		private string _descriptionC="0";
		private int _id=0;
		private string _keywordsC="0";
		private string _titleC="0";
		private string _typS="0";
        public string tipsC { get; set; }
		public keywords(){/*构造函数*/}
		/// <summary>
		///描述
		/// </summary>
		public string descriptionC
		{
			get
			{
				return _descriptionC;
			}
			set
			{
				_descriptionC= value;
			}
		}
		/// <summary>
		///
		/// </summary>
		public int id
		{
			get
			{
				return _id;
			}
			set
			{
				_id= value;
			}
		}
		/// <summary>
		///关键字
		/// </summary>
		public string keywordsC
		{
			get
			{
				return _keywordsC;
			}
			set
			{
				_keywordsC= value;
			}
		}
		/// <summary>
		///标题
		/// </summary>
		public string titleC
		{
			get
			{
				return _titleC;
			}
			set
			{
				_titleC= value;
			}
		}
		/// <summary>
		///类型
		/// </summary>
		public string typS
		{
			get
			{
				return _typS;
			}
			set
			{
				_typS= value;
			}
		}
	}
}
