using System;

namespace mo
{
	public class searchWords
	{
		private int _countC=0;
		private int _id=0;
		private string _nameC="0";
		public searchWords(){/*构造函数*/}
		/// <summary>
		///次数
		/// </summary>
		public int countC
		{
			get
			{
				return _countC;
			}
			set
			{
				_countC= value;
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
		///词
		/// </summary>
		public string nameC
		{
			get
			{
				return _nameC;
			}
			set
			{
				_nameC= value;
			}
		}
	}
}
