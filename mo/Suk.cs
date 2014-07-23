using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mo
{
    public class Suk
    {

        public int Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Sku_name { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string Sku_code { get; set; }


        /// <summary>
        /// 帐套ID
        /// </summary>
        public int Group_id { get; set; }

        /// <summary>
        /// 所属3级类别
        /// </summary>
        public int CatThree { get; set; }

        /// <summary>
        /// 品牌编号
        /// </summary>
        public int Brand_id { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int Item_id { get; set; }

        /// <summary>
        /// 状态：-1-已删除、0-存盘、1-已启用(待发布)、2-已停用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string Bar_code { get; set; }

        /// <summary>
        /// Hitao售价(分)
        /// </summary>
        public int sell_price { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 保质期（数天）
        /// </summary>
        public int Guarantee_date { get; set; }

        /// <summary>
        /// 产地ID(地区ID)
        /// </summary>
        public int producer { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public int province_id { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public int city_id { get; set; }

        /// <summary>
        /// district_id
        /// </summary>
        public int district_id { get; set; }

        /// <summary>
        /// 成本价(分)
        /// </summary>
        public int cost { get; set; }

        /// <summary>
        /// 税率  0：17%、1：13%、2：6%、：4%
        /// </summary>
        public int cess { get; set; }

        /// <summary>
        /// 采购经理ID
        /// </summary>
        public int purchaser_id { get; set; }

         /// <summary>
        /// 创建人
        /// </summary>
        public string Creator_name { get; set; }
         /// <summary>
        /// 修改人
        /// </summary>
        public string Modifier_name { get; set; }
          /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

          /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Gmt_create { get; set; }



    }

}
