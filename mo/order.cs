using System;

namespace mo
{
	public class order
	{
		public order(){/*���캯��*/}

        /// <summary>
        /// �������
        /// </summary>
        public string orderC { get; set; }
        /// <summary>
        /// �µ��û�  �ջ������� ��Ҳ����վ���û�����
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// ��Ʒ��Ϣ������ ��ʹ��OrderItem��
        /// </summary>
        public string proInfo { get; set; }
        /// <summary>
        /// �ͻ���ַ��Ϣ��������
        /// </summary>
        public string addInfo { get; set; }
        /// <summary>
        /// �µ�ʱ��
        /// </summary>
        public DateTime timeC { get; set; }
        /// <summary>
        /// ֧����ʽ
        /// </summary>
        public string payName { get; set; }
        /// <summary>
        /// ��ݷ�ʽ
        /// </summary>
        public string expName { get; set; }
        /// <summary>
        /// ��ݺ�
        /// </summary>
        public string expNum { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string expTime { get; set; }
        /// <summary>
        /// �˷�
        /// </summary>
        public double expPrice { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public double priceC { get; set; }
        /// <summary>
        /// ����״̬  0�ύ�Ķ���,1׼����,2������,3�ջ�
        /// </summary>
        public int typ { get; set; }
        /// <summary>
        /// �Զ����޸ĵȱ�ע
        /// </summary>
        public string remarksC { get; set; }
        /// <summary>
        /// 1Ϊ�������
        /// </summary>
        public int curFlg { get; set; }
        /// <summary>
        /// �����,cut:���������֤���Ѽ������,  ��ʽ id,����
        /// </summary>
        public string cutCount { get; set; }
        /// <summary>
        /// ������������ expPrice  priceC
        /// </summary>
        public string totalInfo { get; set; }


        /*                                                             2012-06-26 ǰԭ���ֶ�                     */



        

        /// <summary>
        /// �ջ�������
        /// </summary>
        public string ShippingName { get; set; } 

        /// <summary>
        /// �ջ��˵绰
        /// </summary>
        public string ShippingTel { get; set; }

        /// <summary>
        /// �ջ��˵�ַ
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// �ջ��˹���
        /// </summary>
        public string ShippingCountry { get; set; }


	}
}
