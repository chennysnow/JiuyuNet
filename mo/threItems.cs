using System;

namespace mo
{
    /// <summary>
    ///三键集合 一个整型
    /// </summary>
    public class threItems
    {
        public threItems()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        private string _id;
        private string _tips;
        private string _value;
        private string _add;
        /// <summary>
        /// 
        /// </summary>
        public string key
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tips
        {
            set { _tips = value; }
            get { return _tips; }
        }
        public string value
        {
            set { _value = value; }
            get { return _value; }
        }
        public string add
        {
            set { _add = value; }
            get { return _add; }
        }
    }
}