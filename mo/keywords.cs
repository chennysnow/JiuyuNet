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
		public keywords(){/*���캯��*/}
		/// <summary>
		///����
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
		///�ؼ���
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
		///����
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
		///����
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
