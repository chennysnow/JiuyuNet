using System;

namespace mo
{
	public class OrderItem
	{
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
	
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 认购数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 认购单价
        /// </summary>
        public Decimal UnitPrice { get; set; }

        /// <summary>
        /// 商品路径
        /// </summary>
        public string HtmlName { get; set; }


        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品类别ID
        /// </summary>
        public string ProClassId { get; set; }

        /// <summary>
        /// 商品型号
        /// </summary>
        public string ProductNO { get; set; }
        
        /// <summary>
        /// 总价 认购单价*认购数量
        /// </summary>
        public Decimal TotalAmount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        public double Discounte { get; set; }

        /// <summary>
        /// 折扣金额
        /// </summary>
        public double DisPrice { get; set; } 

        /// <summary>
        /// 商品图片路径
        /// </summary>
        public string ProImgURL { get; set; }
        /// <summary>
        /// 商品状态  0初始值  1已付款
        /// </summary>
        public int ProState { get; set; } 
        

	}
}
