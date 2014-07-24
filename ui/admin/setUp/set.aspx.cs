using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
public partial class admin_setUp_set : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "网站系统配制";
        if (!IsPostBack)
        {
            txtUrl.Text = op.staValue.siteUrl;
            txtCompanyName.Text = op.staValue.companyName;
           // txtAdminName.Text = op.staValue.adminUrl;
            txtImgWidth.Text = op.staValue.imgWidth.ToString();
            txtImgHeight.Text = op.staValue.imgHeight.ToString();
            txtPageSize.Text = op.staValue.pageSize.ToString();
            txtNewsSize.Text = op.staValue.newsSize.ToString();
            txtStockAlarm.Text = op.staValue.stockAlarm.ToString();

            txtSmtpServer.Text = op.staValue.stmpMail[0];
            txtSmtpMail.Text = op.staValue.stmpMail[1];
            txtSmtpPassword.Text = op.staValue.stmpMail[2];
            txtSmtpPort.Text = op.staValue.stmpMail[3];
            txtReceiveMail.Text = op.staValue.mail;

            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            txtOnline.Text = news.getString("contentC", "where typS='online'");
            txtBottom.Text = news.getString("contentC", "where typS='bottom'");
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string path = op.staValue.path + "\\web.config";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectSingleNode("//configuration/appSettings");//找到appsetting节点
        if (node != null)
        {
            XmlNode xn = node.SelectSingleNode("add [@key='companyName']");//
            if (xn != null)
            {
                XmlElement xe = (XmlElement)xn;
                xe.SetAttribute("value",txtCompanyName.Text);
            }
            xn = node.SelectSingleNode("add [@key='siteUrl']");//
            if (xn != null)
            {
                XmlElement xe = (XmlElement)xn;
                xe.SetAttribute("value",txtUrl.Text);
            }
            //xn = node.SelectSingleNode("add [@key='adminUrl']");//
            //if (xn != null)
            //{
            //    XmlElement xe = (XmlElement)xn;
            //    xe.SetAttribute("value",txtAdminName.Text);
            //}
            //if(Directory.Exists(op.staValue.path+op.staValue.adminUrl))
            //{
            //    Directory.CreateDirectory(op.staValue.path + txtAdminName.Text);
            //    Directory.Move(op.staValue.path+op.staValue.adminUrl,op.staValue.path+txtAdminName.Text);
            //}
            int intNum=0;
            bool flg = false;
            xn = node.SelectSingleNode("add [@key='imgWidth']");//
            if (xn != null)
            {
                if (int.TryParse(txtImgWidth.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.SetAttribute("value", txtImgWidth.Text);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='imgHeight']");//
            if (xn != null)
            {
                if (int.TryParse(txtImgHeight.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.SetAttribute("value", txtImgHeight.Text);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='pageSize']");//
            if (xn != null)
            {
                if (int.TryParse(txtImgHeight.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.SetAttribute("value", txtPageSize.Text);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='newsSize']");//
            if (xn != null)
            {
                if (int.TryParse(txtImgHeight.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.SetAttribute("value",txtNewsSize.Text);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='stockAlarm']");//
            if (xn != null)
            {
                if (int.TryParse(txtStockAlarm.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.SetAttribute("value",txtStockAlarm.Text);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='smtpMail']");//
            if (xn != null)
            {
                if (int.TryParse(txtSmtpPort.Text, out intNum))
                {
                    XmlElement xe = (XmlElement)xn;
                    string str = txtSmtpServer.Text + "|" + txtSmtpMail.Text + "|" + txtSmtpPassword.Text + "|" + intNum;
                    xe.SetAttribute("value", str);
                }
                else
                {
                    flg = true;
                }
            }
            xn = node.SelectSingleNode("add [@key='mail']");//
            if (xn != null)
            {
                XmlElement xe = (XmlElement)xn;
                xe.SetAttribute("value", txtReceiveMail.Text);
            }
            xmlDoc.Save(path);
            //dal.news news = new dal.news();
            MySqlDal.NewsDB news = new MySqlDal.NewsDB();
            news.UpdateString("contentC='"+txtOnline.Text+"'", "where typS='online'");
            news.UpdateString("contentC='" + txtBottom.Text + "'", "where typS='bottom'");
            if (flg)
            {
                op.staValue.divAlert(Page, "数据类型不正确!");
            }
            else
            {
                op.staValue.divAlert(Page, "保存成功!","set.aspx");
            }

        }


    }
}