using System;

namespace mo
{
	public class order
	{
		public order(){/*构造函数*/}

        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderC { get; set; }
        /// <summary>
        /// 下单用户  收货人邮箱 （也是网站的用户名）
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 商品信息（废弃 请使用OrderItem）
        /// </summary>
        public string proInfo { get; set; }
        /// <summary>
        /// 送货地址信息（废弃）
        /// </summary>
        public string addInfo { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime timeC { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string payName { get; set; }
        /// <summary>
        /// 快递方式
        /// </summary>
        public string expName { get; set; }
        /// <summary>
        /// 快递号
        /// </summary>
        public string expNum { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        public string expTime { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public double expPrice { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public double priceC { get; set; }
        /// <summary>
        /// 发货状态  0提交的订单,1准备中,2发货中,3收货
        /// </summary>
        public int typ { get; set; }
        /// <summary>
        /// 对订单修改等备注
        /// </summary>
        public string remarksC { get; set; }
        /// <summary>
        /// 1为减过库存
        /// </summary>
        public int curFlg { get; set; }
        /// <summary>
        /// 减库存,cut:包含这个的证明已减过库存,  格式 id,数量
        /// </summary>
        public string cutCount { get; set; }
        /// <summary>
        /// 订单金额（废弃） expPrice  priceC
        /// </summary>
        public string totalInfo { get; set; }


        /*                                                             2012-06-26 前原有字段                     */



        

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ShippingName { get; set; } 

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ShippingTel { get; set; }

        /// <summary>
        /// 收货人地址
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收货人国家
        /// </summary>
        public string ShippingCountry { get; set; }


	}
}
