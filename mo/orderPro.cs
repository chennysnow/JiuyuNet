using System;

namespace mo
{
	public class orderPro
	{
		private int _countC=0;
		private string _htmlName="0";
		private int _id=0;
		private string _imgC="0";
		private string _nameC="0";
		private string _numC="0";
		private double _priceC=0;
		private string _proId="0";
		private string _remarkC="0";
		private double _weightC=0;
		public orderPro(){/*���캯��*/}
		/// <summary>
		///����
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
		///��̬����
		/// </summary>
		public string htmlName
		{
			get
			{
				return _htmlName;
			}
			set
			{
				_htmlName= value;
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
		/// <summary>
		///������
		/// </summary>
		public string numC
		{
			get
			{
				return _numC;
			}
			set
			{
				_numC= value;
			}
		}
		/// <summary>
		///��Ǯ
		/// </summary>
		public double priceC
		{
			get
			{
				return _priceC;
			}
			set
			{
				_priceC= value;
			}
		}
		/// <summary>
		///���
		/// </summary>
		public string proId
		{
			get
			{
				return _proId;
			}
			set
			{
				_proId= value;
			}
		}
		/// <summary>
		///��ע
		/// </summary>
		public string remarkC
		{
			get
			{
				return _remarkC;
			}
			set
			{
				_remarkC= value;
			}
		}
		/// <summary>
		///����
		/// </summary>
		public double weightC
		{
			get
			{
				return _weightC;
			}
			set
			{
				_weightC= value;
			}
		}
	}
}
