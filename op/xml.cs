using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Web;
namespace op
{
    public class xml
    {
        XmlDataDocument xmlDoc = new XmlDataDocument();
        string path = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">针对哪个XML文件</param>
        public xml()
        {
            path = HttpContext.Current.Request.PhysicalApplicationPath + "xml/cart.xml";
            xmlDoc.Load(path);
        }
        public xml(string fileName)
        {
            path = HttpContext.Current.Request.PhysicalApplicationPath + "xml/" + fileName + ".xml";
            xmlDoc.Load(path);
        }
        /// <summary>
        /// 获得所有关键词
        /// </summary>
        /// <returns></returns>
        public string getAllKey(string xmlE)
        {
            XmlNode node = xmlDoc.SelectSingleNode("//boot/" + xmlE);//获取address节点的所有子节点 
            if (node != null)
            {
                XmlElement xe = (XmlElement)node;//将子节点类型转换为XmlElement类型 
                return xe.InnerText;
            }
            else
                return "";
        }
        public bool setAllKey(string key, string xmlE)
        {
            XmlNode node = xmlDoc.SelectSingleNode("//boot/" + xmlE);//获取address节点的所有子节点 
            if (node != null)
            {
                XmlElement xe = (XmlElement)node;//将子节点类型转换为XmlElement类型 
                xe.InnerText = key;
                xmlDoc.Save(path);
                return true;
            }
            else
                return false;
        }

    }
}
