using System;

namespace mo
{
	public class img
	{
		private int _id=0;
		private string _imgC="0";
		private int _sortC=1;
		private int _typ=0;
		public img(){/*���캯��*/}
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
		///ͼƬ��ַ
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
		///����
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
		///���
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
