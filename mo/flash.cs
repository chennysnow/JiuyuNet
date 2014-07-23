using System;

namespace mo
{
	public class flash
	{
		private int _id=0;
		private string _imgC="0";
		private string _nameC="0";
		private string _typS="0";
		private string _urlC="0";
        private string _url2 = "#";
        private string _url1 = "#";
		public flash(){/*构造函数*/}
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
		///图片
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
		///标题
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
		/// <summary>
		///地址
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
        public string url1
        {
            get
            {
                int i = _urlC.IndexOf(';');
                if (i > 0)
                {
                    return _urlC.Substring(0, i);
                }
                else
                    return _urlC;
            }
            set
            {
                _url1 = value;
            }
        }
        public string url2
        {
            get {
                int i = _urlC.IndexOf(';');
                if (i > 0)
                {
                    return _urlC.Substring(i+1);
                }
                else
                    return _url2;
            }
            set { _url2 = value; }
        }
	}
}
