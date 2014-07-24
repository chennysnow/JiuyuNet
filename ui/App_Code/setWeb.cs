using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Collections;
public class setWeb
{
    System.Text.Encoding code = System.Text.Encoding.GetEncoding("utf-8");
    string url = "http://" + HttpContext.Current.Request.Url.Authority + "/";
    public string clBuffer = "1";
    public setWeb()
    {
        if (HttpContext.Current.Request.Cookies["buffer"] != null)
            clBuffer = HttpContext.Current.Request.Cookies["buffer"].Value;
    }
    /// <summary>   
    /// 生成静态页面  
    /// </summary>   
    /// <param name="aspName">请求的URL</param>   
    /// <param name="htmlName">静态文件名</param>   
    public bool Create(string aspName, string htmlName)
    {

        string strFilePage;
        strFilePage = op.staValue.path + htmlName;
        aspName = url + (aspName.IndexOf(".aspx?") > 0 ? aspName + "&clBuffer=" + clBuffer : aspName + "?clBuffer=" + clBuffer);
        StreamWriter sw = null;
        //获得aspx的静态html   
        try
        {
            if (File.Exists(strFilePage))
            {
                File.Delete(strFilePage);
            }
            sw = new StreamWriter(strFilePage, false, code);
            System.Net.WebRequest wReq = System.Net.WebRequest.Create(aspName);
            System.Net.WebResponse wResp = wReq.GetResponse();
            System.IO.Stream respStream = wResp.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(respStream, code);
            //得到临时的文本流
            string strTemp = reader.ReadToEnd();
            //Regex r1 = new Regex("<input type=\"hidden\" name=\"__EVENTTARGET\".*/>", RegexOptions.IgnoreCase);
            //Regex r2 = new Regex("<input type=\"hidden\" name=\"__EVENTARGUMENT\".*/>", RegexOptions.IgnoreCase);
            //Regex r3 = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\".*/>", RegexOptions.IgnoreCase);
            //Regex r4 = new Regex("<form .*id=\"form1\">", RegexOptions.IgnoreCase);
            //Regex r5 = new Regex("</form>");
            //Regex r6 = new Regex("<input type=\"hidden\" name=\"__EVENTVALIDATION\".*/>", RegexOptions.IgnoreCase);
            //strTemp = r1.Replace(strTemp, "");
            //strTemp = r2.Replace(strTemp, "");
            //strTemp = r3.Replace(strTemp, "");
            //strTemp = r4.Replace(strTemp, "");
            //strTemp = r5.Replace(strTemp, "");
            //strTemp = r6.Replace(strTemp, "");
            sw.Write(strTemp);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
            HttpContext.Current.Response.End();
            return false;//生成到出错   
        }
        finally
        {
            sw.Flush();
            sw.Close();
            sw = null;
        }
        return true;
    }
    /// <summary>
    /// 读取母板页
    /// </summary>
    /// <param name="path"></param>
    /// <param name="master"></param>
    /// <returns></returns>
    public string ReadMaster(string masterPage)
    {
        StreamReader sr = null;
        string strMaster = "";
        try
        {
            sr = new StreamReader(op.staValue.path + masterPage, code);
            strMaster = sr.ReadToEnd();
            return strMaster;
        }
        catch
        {
            if (sr != null)
                sr.Close();
            return "";
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
    /// <summary>
    /// 写html文件
    /// </summary>
    /// <param name="str">html字符串</param>
    /// <param name="path">写入的文件路径</param>
    /// <param name="pageName">写入的文件名字</param>
    /// <returns></returns>
    public void WriterPage(string str, string pageName)
    {
        StreamWriter sw = null;
        try
        {
            if (File.Exists(op.staValue.path + pageName))
            {
                File.Delete(op.staValue.path + pageName);
            }
            sw = new StreamWriter(op.staValue.path + pageName, false, code);
            sw.Write(str);
            sw.Flush();
        }
        catch (Exception ex)
        {
            if (sw != null)
                sw.Close();
            HttpContext.Current.Response.Write(ex.Message);
            HttpContext.Current.Response.End();
        }
        finally
        {
            if (sw != null)
                sw.Close();
        }
    }
    //dal.menu menu = new dal.menu();
    dal.MenuDB menu = new dal.MenuDB();
    //dal.products pro = new dal.products();
    dal.ProductsDB pro = new dal.ProductsDB();
    /// <summary>
    /// 生成站点地图
    /// </summary>
    public void webSite()
    {
        XmlDataDocument xmlDoc = new XmlDataDocument();
        xmlDoc.Load(HttpContext.Current.Request.PhysicalApplicationPath + "sitemap.xml");
        XmlNode node = xmlDoc.SelectSingleNode("boot");
        XmlElement proNode = xmlDoc.CreateElement("menu");
        proNode.SetAttribute("url", "prolist.aspx");
        proNode.SetAttribute("title", "Products");
        proNode.SetAttribute("description", "Products");
        proNode.SetAttribute("href", "/proList.html");
        product(xmlDoc, proNode, 1);
        node.RemoveAll();//清空
        List<mo.menu> modelMenu = menu.getModelListWhere("where typ=2");
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        for (int i = 0; i < modelMenu.Count; i++)
        {
            XmlElement xe = xmlDoc.CreateElement("news");//创建车
            xe.SetAttribute("url", "newlist.aspx?typ=" + modelMenu[i].id);
            xe.SetAttribute("title", modelMenu[i].nameC);
            xe.SetAttribute("description", modelMenu[i].nameC);
            xe.SetAttribute("href", "/newlist.html?typ=" + modelMenu[i].id);
            List<mo.news> modeNews = news.getModelListWhere("and typ=" + modelMenu[i].id);
            for (int j = 0; j < modeNews.Count; j++)
            {
                XmlElement xe_news = xmlDoc.CreateElement("items");
                xe_news.SetAttribute("url", "newshow.aspx?id=" + modeNews[j].id);
                xe_news.SetAttribute("title", modeNews[j].nameC);
                xe_news.SetAttribute("description", modeNews[j].nameC);
                xe_news.SetAttribute("href", modeNews[j].url);
                xe.AppendChild(xe_news);
            }
            node.AppendChild(xe);
        }
        node.AppendChild(proNode);
        //特殊文章
        List<mo.news> modelSpeNews = news.getModelListWhere("and typS<>'0'");
        for (int i = 0; i < modelSpeNews.Count; i++)
        {
            XmlElement xe = xmlDoc.CreateElement("news");//创建车
            xe.SetAttribute("url", "newshow.aspx?id=" + modelSpeNews[i].id);
            xe.SetAttribute("title", modelSpeNews[i].nameC);
            xe.SetAttribute("description", modelSpeNews[i].nameC);
            xe.SetAttribute("href", modelSpeNews[i].url);
            node.AppendChild(xe);
        }
        xmlDoc.Save(HttpContext.Current.Request.PhysicalApplicationPath + "sitemap.xml");

    }
    private void product(XmlDataDocument xmlDoc, XmlElement proNode, int typ)
    {
        List<mo.menu> modelMenu = menu.getModelListWhere("where typ=" + typ);
        if (modelMenu.Count <= 0)
            return;
        for (int i = 0; i < modelMenu.Count; i++) //一级
        {
            XmlElement xe = xmlDoc.CreateElement("menu_" + modelMenu[i].levelC);//创建车
            xe.SetAttribute("url", "prolist.aspx?typ=" + modelMenu[i].id);
            xe.SetAttribute("title", modelMenu[i].nameC);
            xe.SetAttribute("description", modelMenu[i].nameC);
            xe.SetAttribute("href", "/prolist.html?typ=" + modelMenu[i].id);

            List<mo.products> modelPro = pro.getModelListWhere("and typ=" + modelMenu[i].id);
            for (int iP = 0; iP < modelPro.Count; iP++)
            {
                XmlElement xe_p = xmlDoc.CreateElement("product");
                xe_p.SetAttribute("url", "proshow.aspx?id=" + modelPro[iP].id);
                xe_p.SetAttribute("title", modelPro[iP].nameC);
                xe_p.SetAttribute("description", modelPro[iP].nameC);
                xe_p.SetAttribute("href", modelPro[iP].url);
                xe.AppendChild(xe_p);
            }
            proNode.AppendChild(xe);
            product(xmlDoc, xe, modelMenu[i].id);
        }
    }
    /// <summary>
    /// 更新文章,产品数量
    /// </summary>
    /// <param name="typ"></param>
    public void updateCount(int typ)
    {
        op.staValue sta = new op.staValue();
        List<mo.menu> modelList = sta.getMenuList(typ);
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        //dal.products pro = new dal.products();
        dal.ProductsDB pro = new dal.ProductsDB();
        foreach (mo.menu model in modelList)
        {
            string count = "0";
            if (typ == 2)
            {
                count = news.getString("count(*)", "where typ=" + model.id + " and showC=1");
            }
            else
            {
                count = pro.getString("count(*)", "where addType like '%," + model.id + ",%'");
            }
            menu.UpdateString("countC=" + count, "where id=" + model.id);
        }
    }
    /// <summary>
    /// 更新子包含菜单
    /// </summary>
    public void updateContainId()
    {
        List<mo.menu> menuTest = menu.getModelListWhere("where typ=1");
        for (int j = 0; j < menuTest.Count; j++)
        {
            int typ = menuTest[j].id;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("," + typ + ",");
            menuContainId(typ, sb);
            //更新
            menu.UpdateString("sonId='" + sb.ToString().Trim(',') + "',preId='" + menuTest[j].id + "'", "where id=" + menuTest[j].id);
            updatePreId(menuTest[j].id, "," + menuTest[j].id);
        }
    }
    private void menuContainId(int typ, System.Text.StringBuilder sb)
    {
        List<mo.menu> modelList = menu.getModelListWhere("where typ=" + typ);
        if (modelList.Count <= 0)
        {
            return;
        }
        for (int i = 0; i < modelList.Count; i++)
        {
            sb.Append(modelList[i].id + ",");
            menuContainId(modelList[i].id, sb);
            string allId = sb.ToString();
            int index = allId.IndexOf("," + modelList[i].id + ",");
            if (index >= 0)
            {
                // string preId = pre;//allId.Substring(0,allId.IndexOf(","+modelList[i].typ+","));//父树
                allId = allId.Substring(index);//截取掉之前所有找到的,也就是父树...
                //更新
                menu.UpdateString("sonId='" + allId.Trim(',') + "'", "where id=" + modelList[i].id);
            }
        }
    }
    private string updatePreId(int id, string pre)
    {
        List<mo.menu> modelList = menu.getModelListWhere("where typ=" + id);
        if (modelList.Count <= 0)
        {
            int ind = pre.LastIndexOf(',');
            if (ind >= 0)
            {
                pre = pre.Substring(0, ind);
            }
            return pre;
        }
        for (int i = 0; i < modelList.Count; i++)
        {
            pre += "," + modelList[i].id;
            menu.UpdateString("preId='" + pre.Trim(',') + "'", "where id=" + modelList[i].id);
            pre = updatePreId(modelList[i].id, pre);
        }
        return "";
    }
    /// <summary>
    /// 更新缓存依赖文件 
    /// </summary>
    /// <param name="filePath"></param>
    public void updateCacheFile()
    {
        System.IO.StreamWriter sw = System.IO.File.CreateText(op.staValue.path + "/updateTime.txt");
        sw.Write(DateTime.Now.ToString());
        sw.Close();
        sw.Dispose();
    }
}