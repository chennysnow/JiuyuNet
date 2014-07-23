using System;

namespace mo
{
    /// <summary>
    ///userLevelModel 的摘要说明
    /// </summary>
    public class userLevelModel
    {
        public userLevelModel()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        private int _id;
        private string _name;
        private double _discount;
        private int _type;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
    }
}
