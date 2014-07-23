using System;

namespace mo
{
	public class OrderItem
	{
        /// <summary>
        /// ���
        /// </summary>
        public int ID { get; set; }
	
        /// <summary>
        /// �������
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// �Ϲ�����
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// �Ϲ�����
        /// </summary>
        public Decimal UnitPrice { get; set; }

        /// <summary>
        /// ��Ʒ·��
        /// </summary>
        public string HtmlName { get; set; }


        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// ��Ʒ���ID
        /// </summary>
        public string ProClassId { get; set; }

        /// <summary>
        /// ��Ʒ�ͺ�
        /// </summary>
        public string ProductNO { get; set; }
        
        /// <summary>
        /// �ܼ� �Ϲ�����*�Ϲ�����
        /// </summary>
        public Decimal TotalAmount { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// �ۿ���
        /// </summary>
        public double Discounte { get; set; }

        /// <summary>
        /// �ۿ۽��
        /// </summary>
        public double DisPrice { get; set; } 

        /// <summary>
        /// ��ƷͼƬ·��
        /// </summary>
        public string ProImgURL { get; set; }
        /// <summary>
        /// ��Ʒ״̬  0��ʼֵ  1�Ѹ���
        /// </summary>
        public int ProState { get; set; } 
        

	}
}
