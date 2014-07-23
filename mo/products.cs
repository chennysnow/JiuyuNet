using System;

namespace mo
{
    public class products
    {
        public string displayC { get; set; }
        public string fileName { get; set; }
        public string htmlName { get; set; }
        public int id { get; set; }
        public string imgC { get; set; }
        public string nameC { get; set; }
        public double priceC { get; set; }
        public string proId { get; set; }
        public int sortC { get; set; }
        public int typ { get; set; }
        public double weightC { get; set; }
        public int qx { get; set; }
        /// <summary>
        /// 产品简介 
        /// </summary>
        public string aboutC { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public string stockC { get; set; }
        /// <summary>
        /// 上下架,1为下架
        /// </summary>
        public int showC { get; set; }
        public int sellCount { get; set; }
        public string strPrice { get; set; }
        public string addType { get; set; }
        public int brandC { get; set; }
        public int star { get; set; }
        public string characteristic { get; set; }

        public string url
        {
            get
            {
                return adminUser.siteUrl + "/" + htmlName + "_s" + id;
            }
        }
        public products() {/*构造函数*/}
    }
}
