using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Collections;
namespace op
{
  public class xmlPlace
    {
        XmlDataDocument xmlDoc = new XmlDataDocument();
        string path="";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">针对哪个XML文件</param>
        public xmlPlace()
        {
            path =HttpContext.Current.Request.PhysicalApplicationPath+"xml/place.xml";
            xmlDoc.Load(path); 
        }
        public xmlPlace(string xml)
        {
            path = HttpContext.Current.Request.PhysicalApplicationPath + "xml/"+xml+".xml";
            xmlDoc.Load(path);
        }
        /// <summary>
        /// 获取HASH表
        /// </summary>
        /// <param name="nodes">想获取节点的名称</param>
        /// <returns></returns>
        public Hashtable getList(string nodes)
        {
            XmlNode node=xmlDoc.SelectSingleNode(nodes);
            Hashtable hasItems = new Hashtable();
            if (node != null)
            {
                XmlNodeList nodeList = node.ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                    hasItems.Add(xe.GetAttribute("key"), xe.GetAttribute("value"));
                }
            }
            return hasItems;
        }
      /// <summary>
      /// 返回三键集合
      /// </summary>
      /// <param name="nodes"></param>
      /// <returns></returns>
        public List<mo.threItems> getModelList(string nodes)
        {
            XmlNode node = xmlDoc.SelectSingleNode(nodes);
            List<mo.threItems> modelList = new List<mo.threItems>();
            mo.threItems model = new mo.threItems();
            if (node != null)
            {
                XmlNodeList nodeList = node.ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                    model.key = xe.GetAttribute("key");
                    model.value = xe.GetAttribute("value");
                    model.tips = xe.GetAttribute("tips");
                    modelList.Add(model);
                    model = new mo.threItems();
                }
            }
            return modelList;
        }
        /// <summary>
        /// 返回邮费价格 续重价格用@隔开
        /// </summary>
        /// <param name="id">地方id</param>
        /// <returns></returns>
        public string getPostPrice(string id)
        {
            string nodes = "//boot/post";
            string str=null;
            //Hashtable hashItems = new Hashtable();
            if (xmlDoc.SelectSingleNode(nodes) == null)
                return null;
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(nodes).ChildNodes;//获取address节点的所有子节点 
            foreach (XmlNode xn in nodeList)//遍历所有子节点 
            {
                XmlNodeList nodeList_1 = (xn as XmlElement).ChildNodes;
                foreach (XmlNode xn_1 in nodeList_1)
                {
                    XmlElement x = xn_1 as XmlElement;//将子节点类型转换为XmlElement类型 
                    if (x.GetAttribute("key") == id)
                    {
                        str+=x.GetAttribute("value");
                        break;
                    }
                }
                XmlElement xe = xn as XmlElement;
                str +="@"+xe.GetAttribute("add") + ",";
            }
            return str.TrimEnd(',');
        }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="key">删除标识</param>
      /// <param name="nodeStr">删除所属节点</param>
        public void del(string key, string nodeStr)
        {
            XmlNode node = xmlDoc.SelectSingleNode(nodeStr);
            foreach (XmlNode xn in node.ChildNodes)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("key") == key)
                {
                    node.RemoveChild(xn);
                    break;
                }
            }
            xmlDoc.Save(path);
        }
        public List<mo.threItems> getAllPlace()
        {
            XmlNode node = xmlDoc.SelectSingleNode("boot");
            List<mo.threItems> modelList = new List<mo.threItems>();
            mo.threItems model = null;
            if (node != null)
            {
                XmlNodeList nodeList = node.ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                    model = new mo.threItems();
                    model.key = xe.GetAttribute("key");
                    model.value = xe.GetAttribute("value");
                    model.tips = "0";
                    modelList.Add(model);
                    XmlNodeList nodeList_place = xn.ChildNodes;
                    foreach (XmlNode xn_place in nodeList_place)
                    {
                        XmlElement xe_place = (XmlElement)xn_place;
                        model = new mo.threItems();
                        model.key = xe_place.GetAttribute("key");
                        model.value = "┝" + xe_place.GetAttribute("value");
                        model.tips = xe.GetAttribute("key");
                        modelList.Add(model);
                        //hasItems.Add(xe.GetAttribute("key")+"_" + xe_place.GetAttribute("key"), "┝" + xe_place.GetAttribute("value"));
                    }
                }
            }
            return modelList;
        }
      /// <summary>
      /// 插入
      /// </summary>
      /// <param name="value">值</param>
      /// <param name="key">键</param>
      /// <param name="boot">节点</param>
      /// <param name="creNode">所要创建的节点</param>
      /// <returns></returns>
        public bool InsertPlace(string value, string key, string boot,string creNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(boot);
            if (root != null)
            {
                XmlElement xe = xmlDoc.CreateElement(creNode);
                xe.SetAttribute("key", key);
                xe.SetAttribute("value", value);
                root.AppendChild(xe);
                xmlDoc.Save(path);
                return true;
            }
            else
                return false;
        }
        public bool InsertThre(mo.threItems model, string boot, string creNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(boot);
            if (root != null)
            {
                XmlElement xe = xmlDoc.CreateElement(creNode);
                xe.SetAttribute("key", model.key);
                xe.SetAttribute("value",model.value);
                xe.SetAttribute("tips",model.tips);
                xe.SetAttribute("add", model.add);
                root.AppendChild(xe);
                xmlDoc.Save(path);
                return true;
            }
            else
                return false;
        }
        public bool InsertThreList(List<mo.threItems> modelList, string boot, string creNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(boot);
            if (root != null)
            {
                for (int i = 0; i < modelList.Count; i++)
                {
                    XmlElement xe = xmlDoc.CreateElement(creNode);
                    xe.SetAttribute("key", modelList[i].key);
                    xe.SetAttribute("value", modelList[i].value);
                    xe.SetAttribute("tips", modelList[i].tips);
                    root.AppendChild(xe);
                }
                xmlDoc.Save(path);
                return true;
            }
            else
                return false;
        }
      /// <summary>
      /// 获取一个三键集合
      /// </summary>
      /// <param name="getNode"></param>
      /// <returns></returns>
        public mo.threItems getThreModel(string getNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(getNode);
            if (root != null) 
            {
                XmlElement xe = (XmlElement)root;
                mo.threItems model = new mo.threItems();
                model.key = xe.GetAttribute("key");
                model.value = xe.GetAttribute("value");
                model.tips = xe.GetAttribute("tips");
                model.add = xe.GetAttribute("add");
                return model;
            }
            return null;
        }
        public bool UpdataThreModel(mo.threItems model, string getNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(getNode);
            if (root != null)
            {
                XmlElement xe = (XmlElement)root;
                xe.SetAttribute("key", model.key);
                xe.SetAttribute("value", model.value);
                xe.SetAttribute("tips", model.tips);
                xmlDoc.Save(path);
                return true;
            }
            return false;
        }
        public bool UpdataThreList(List<mo.threItems> modelList, string getNode)
        {
            XmlNode root = xmlDoc.SelectSingleNode(getNode);
            if(root!=null)
            {
                XmlNodeList nodelList = root.ChildNodes;
                for (int i = 0; i < modelList.Count; i++)
                {
                    XmlElement xe =(XmlElement)nodelList[i];
                    xe.SetAttribute("key", modelList[i].key);
                    xe.SetAttribute("value", modelList[i].value);
                    // xe.SetAttribute("tips", modelList[i].tips);
                }
                xmlDoc.Save(path);
                return true;
            }
            return false;
        }
    }
}
