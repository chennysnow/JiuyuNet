using System;

namespace mo
{
	public class userFavorite
	{
		private int _id=0;
		private int _proId=0;
		private int _sortC=1;
		private int _userId=0;
		public userFavorite(){/*���캯��*/}
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
		///��ƷID
		/// </summary>
		public int proId
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
		///
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
		///�û�ID
		/// </summary>
		public int userId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId= value;
			}
		}
	}
}
