using System;

namespace mo
{
	public class img
	{
		private int _id=0;
		private string _imgC="0";
		private int _sortC=1;
		private int _typ=0;
		public img(){/*构造函数*/}
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
		///图片地址
		/// </summary>
		public string imgC
		{
			get
			{
				return _imgC;
			}
			set
			{
				_imgC= value;
			}
		}
		/// <summary>
		///排序
		/// </summary>
		public int sortC
		{
			get
			{
				return _sortC;
			}
			set
			{
				_sortC= value;
			}
		}
		/// <summary>
		///类别
		/// </summary>
		public int typ
		{
			get
			{
				return _typ;
			}
			set
			{
				_typ= value;
			}
		}
	}
}
