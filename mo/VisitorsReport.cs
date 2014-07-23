using System;
using System.Configuration;

namespace mo
{
    public class VisitorsReport
    {

        public int id { get; set; }
        public DateTime Createdate { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        /// <summary>
        /// 访问者ip地址
        /// </summary>
        public string VisitorIP { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int VCount { get; set; }

    }
}
