using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
public partial class admin_index : System.Web.UI.Page
{
    public int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "欢迎光临!";
        if (!IsPostBack)
        {
            binOrder();
            i = 1;
            binUser();
            binSiteRemind();
            binStockAndHot();
            if(Request.QueryString["seo"]!=null)
                binSearch();
        }
    }
    private void binOrder()
    {
        //dal.order order = new dal.order();
        dal.OrderDB order = new dal.OrderDB();
        List<mo.order> modelList = order.getModelListWhere("top 15","");
        repOrder.DataSource = modelList;
        repOrder.DataBind();
    }
    private void binUser()
    {
        dal.UserDB user = new dal.UserDB();
        //dal.UserDB user = new dal.UserDB();
        List<mo.user> modelList = user.getModelListWhere("top 15", "");
        repUser.DataSource = modelList;
        repUser.DataBind();
    }
    private void binSiteRemind()
    {
        //dal.order order = new dal.order();
        dal.OrderDB order = new dal.OrderDB();
        string count = order.getString("count(*)","");
        string count_1 = order.getString("count(*)", "where typ=0");
        string count_2 = order.getString("count(*)", "where typ=1");
        string count_3 = order.getString("count(*)", "where typ=2");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<p>订单总数:<span><a href='user/Order.aspx'>{0}</a></span></p>", count);
        sb.AppendFormat("<p>待发货订单:<span><a href='user/Order.aspx?typ=0'>{0}</a></span></p>", count_1);
        sb.AppendFormat("<p>发货中订单:<span><a href='user/Order.aspx?typ=1'>{0}</a></span></p>", count_2);
        sb.AppendFormat("<p>已完成订单:<span><a href='user/Order.aspx?typ=2'>{0}</a></span></p>", count_3);
        liOrder.Text = sb.ToString();
        sb.Length = 0;
        //会员
        //dal.user user = new dal.user();
        dal.UserDB user = new dal.UserDB();
        count = user.getString("count(*)", "");
        count_1 = user.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-1) + "#");
        count_2 = user.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-2) + "#");
        sb.AppendFormat("<p>会员总数:<span>{0}</span></p>", count);
        sb.AppendFormat("<p>今天新增:<span>{0}</span></p>", count_1);
        sb.AppendFormat("<p>昨日新增:<span>{0}</span></p>", count_2);
        liMember.Text = sb.ToString();
        sb.Length = 0;
        //dal.products pro = new dal.products();
        dal.ProductsDB pro = new dal.ProductsDB();
        count = pro.getString("count(*)", "");
        count_1 = pro.getString("count(*)", "where stockC<'10'");
        count_2 = pro.getString("count(*)", "where stockC<='0'");
        count_3 = pro.getString("count(*)", "where showC=1");
        sb.AppendFormat("<p>商品总数:<span>{0}</span></p>", count);
        sb.AppendFormat("<p>库存报警:<span>{0}</span></p>", count_1);
        sb.AppendFormat("<p>缺货商品:<span>{0}</span></p>", count_2);
        sb.AppendFormat("<p>下架商品:<span>{0}</span></p>", count_3);
        liGoods.Text = sb.ToString();
        sb.Length = 0;
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        count = news.getString("count(*)", "where typS='0'");
        count_1 = news.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-1) + "#");
        count_2 = news.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-2) + "#");
        sb.AppendFormat("<p>文章总数:<span>{0}</span></p>", count);
        sb.AppendFormat("<p>今天新增:<span>{0}</span></p>", count_1);
        sb.AppendFormat("<p>昨日新增:<span>{0}</span></p>", count_2);
        liNews.Text = sb.ToString();
        sb.Length = 0;
        //dal.message message = new dal.message();
        dal.MessageDB message = new dal.MessageDB();
        count = message.getString("count(*)", "");
        count_1 = message.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-1) + "#");
        count_2 = message.getString("count(*)", "where timeC>#" + DateTime.Now.AddDays(-2) + "#");
        sb.AppendFormat("<p>留言总数:<span>{0}</span></p>", count);
        sb.AppendFormat("<p>今天新增:<span>{0}</span></p>", count_1);
        sb.AppendFormat("<p>昨日新增:<span>{0}</span></p>", count_2);
        liInquiry.Text = sb.ToString();
    }
    private void binStockAndHot()
    {
        i = 1;
        //dal.products pro = new dal.products();
        dal.ProductsDB pro = new dal.ProductsDB();
        List<mo.products> modelList = pro.getModelListWhere("top 10", "and stockC<'" + op.staValue.stockAlarm+"'", "order by sortC ,id desc");
        repStockAlarm.DataSource = modelList;
        repStockAlarm.DataBind();
        i = 1;
        modelList = pro.getModelListWhere("top 10", "", "order by sellCount desc,id desc");
        repHotSell.DataSource = modelList;
        repHotSell.DataBind();
    }
    private void binSearch()
    {
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string str = search("http://www.google.com/search?hl=en&q=site%3A", "\\<div id=resultStats\\>(.*) results\\<nobr\\>", "UTF-8");
            sb.AppendFormat("<li>{0}</li>", str.Replace("<div id=resultStats>", "").Replace("results<nobr>", "条"));

            str = search("http://search.cn.yahoo.com/s?p=site%3A", "找到相关网页约(.*)条", "UTF-8");
            sb.AppendFormat("<li>{0}</li>", str.Replace("找到相关网页", ""));

            str = search("http://cn.bing.com/search?q=site%3A", "共 (.*) 条", "UTF-8");
            sb.AppendFormat("<li>{0}</li>", str);

            str = search("http://www.baidu.com/s?wd=site%3A", "找到相关结果数(.*)个", "gb2312");
            sb.AppendFormat("<li>{0}</li>", str.Replace("找到相关结果数", ""));

            str = search("http://www.sogou.com/web?query=site%3A", "找到约(.*)条结果", "gb2312");
            sb.AppendFormat("<li>{0}</li>", str.Replace("找到约", ""));

            str = search("http://www.youdao.com/search?q=site%3A", "共(.*)条结果", "UTF-8");
            sb.AppendFormat("<li>{0}</li>", str.Replace("共", ""));

            str = search("http://siteexplorer.search.yahoo.com/search;_ylt=A0oGk.tUzadOhqkAIBPal8kF?p=", @"Inlinks \((.*)\)", "UTF-8");
            sb.AppendFormat("<li>外链:{0}</li>", str.Replace("Inlinks", ""));
            liSearch.Text = sb.ToString();
        }
        catch { }
    }
    private string search(string url,string reg,string code)
    {
        System.Net.WebRequest wReq = System.Net.WebRequest.Create(url+op.staValue.siteUrl.Replace("http://","").TrimEnd('/'));
        System.Net.WebResponse wResp = wReq.GetResponse();
        System.IO.Stream respStream = wResp.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding(code));
        //得到临时的文本流
        string strTemp = reader.ReadToEnd();
        Regex r = new Regex(@reg.Replace("\\",@"\"));
        Match m = r.Match(strTemp);
        if (m.Success)
        {
            return m.Value;
        }
        else
            return "0";
    }
}