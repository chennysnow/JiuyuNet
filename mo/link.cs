using System;

namespace mo
{
	public class link
	{
		private int _id=0;
		private string _nameC="0";
		private string _typS="0";
		private string _urlC="0";
        private string _logo = "";
		public link(){/*���캯��*/}
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
        public string logo
        {
            get {
                return _logo;           
            }
            set{
                _logo = value;
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
		/// <summary>
		///����
		/// </summary>
		public string urlC
		{
			get
			{
				return _urlC;
			}
			set
			{
				_urlC= value;
			}
		}
	}
}
