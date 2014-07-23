using System;

namespace mo
{
	public class color
	{
		private string _colorC="0";
		private int _id=0;
		private string _tipsC="0";
		private int _typ=0;
		public color(){/*构造函数*/}
		/// <summary>
		///颜色
		/// </summary>
		public string colorC
		{
			get
			{
				return _colorC;
			}
			set
			{
				_colorC= value;
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
		///描述
		/// </summary>
		public string tipsC
		{
			get
			{
				return _tipsC;
			}
			set
			{
				_tipsC= value;
			}
		}
		/// <summary>
		///产品ID
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
