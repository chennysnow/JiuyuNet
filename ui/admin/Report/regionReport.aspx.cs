using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySqlDal;
using System.Data;

public partial class admin_Report_regionReport : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            report();
        }

        int select = 0;
        if (Request.QueryString["ctg"] != null)
        {
            int.TryParse(Request.QueryString["ctg"], out select);
        }

    }



    private void report()
    {
        string reportType = Request.QueryString["type"];
        string proClass = Request.QueryString["ctg"];
        if (string.IsNullOrEmpty(reportType))
        {
            dateReport(DateTime.Now, proClass);
            return;
        }
        switch (reportType)
        {
            case "0":
                dateReport(DateTime.Now, proClass);
                break;
            case "1":
                dateReport(DateTime.Now.AddDays(-1), proClass);
                break;
            case "2":
                weekReport(proClass);
                break;
            case "3":
                monthReport(proClass);
                break;
            case "4":
                ThmonthReport(proClass, 3);
                break;
            case "5":
                ThmonthReport(proClass, 6);
                break;
            case "6":
                ThmonthReport(proClass, 12);
                break;

            default:
                break;
        }




    }
    /// <summary>
    /// 日报表
    /// </summary>
    private void dateReport(DateTime date, string proClass)
    {
        op.Report rep = new op.Report();
        OrderItemDB itemdb = new OrderItemDB();
        string where = " where timeC BETWEEN '" + date.ToShortDateString() + "' And '" + date.AddDays(1).ToShortDateString() + "'";
        string sql = "SELECT DATE_FORMAT(TimeC,'%Y-%m-%d %H') AS 'CreateDate',COUNT(1) as 'Quantity',(CASE typ WHEN 1 THEN  priceC ELSE 0 END) as 'SellAmount', (CASE typ WHEN 0 THEN priceC ELSE 0 END) AS 'Unpaid', (CASE typ WHEN -1 THEN priceC ELSE 0 END) AS 'RefundAmount',shippingCountry from `order` " + where + " GROUP BY DATE_FORMAT(TimeC,'%Y-%m-%d %H'),shippingCountry";
        DataTable dt = OrderDB.SqlTable(sql);
        if (dt == null)
            return;
        repReport.DataSource = dt;
        repReport.DataBind();

        List<op.Report.ChartLine> col = new List<op.Report.ChartLine>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int j = 0; j < 24; j++)
            {
                data.Add(j.ToString(), "0");
            }
            op.Report.ChartLine c = new op.Report.ChartLine();
            c.Value = data;
            c.Key = dt.Rows[i]["shippingCountry"].ToString();
            bool fg = true;

            for (int j = 0; j < col.Count; j++)
            {
                if (col[j].Key == c.Key)
                {
                    col[j].Value[DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).Hour.ToString()] = (Decimal.Parse(col[j].Value[DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).Hour.ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                    fg = false;
                }
            }

            if (i == 0 || fg)
            {
                data[DateTime.Parse(dt.Rows[i]["CreateDate"].ToString() + ":00:00").Hour.ToString()] = (Decimal.Parse(data[DateTime.Parse(dt.Rows[i]["CreateDate"].ToString() + ":00:00").Hour.ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                col.Add(c);

            }
        }
        rep.LineCollection = col;
        rep.Caption = DateTime.Now.ToShortDateString() + "报表";
        rep.xAxisName = "小时";
        rep.yAxisName = "金额";
        if (Request.QueryString["repType"] == null || Request.QueryString["repType"] == "0")
            rep.FlashURL = "/swf/MSLine.swf";
        else
            rep.FlashURL = "/swf/MSColumn2D.swf";
        litReport.Text = rep.reportOneLine(800, 350);
    }

    /// <summary>
    /// 周报表
    /// </summary>
    private void weekReport(string proClass)
    {


        OrderItemDB itemdb = new OrderItemDB();
        string where = "where timeC BETWEEN '" + DateTime.Now.AddDays(-6).ToShortDateString() + "' And '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'";
        string sql = "SELECT DATE_FORMAT(TimeC,'%Y-%m-%d') AS 'CreateDate',COUNT(1) as 'Quantity',(CASE typ WHEN 1 THEN  priceC ELSE 0 END) as 'SellAmount', (CASE typ WHEN 0 THEN priceC ELSE 0 END) AS 'Unpaid', (CASE typ WHEN -1 THEN priceC ELSE 0 END) AS 'RefundAmount',shippingCountry from `order` " + where + " GROUP BY DATE_FORMAT(TimeC,'%Y-%m-%d'),shippingCountry";
        DataTable dt = OrderDB.SqlTable(sql);
        if (dt == null)
            return;
        repReport.DataSource = dt;
        repReport.DataBind();

        op.Report rep = new op.Report();
        List<op.Report.ChartLine> col = new List<op.Report.ChartLine>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int j = 0; j < 7; j++)
            {
                data.Add(DateTime.Now.AddDays(j - 6).ToString("yyyy-MM-dd"), "0");
            }
            op.Report.ChartLine c = new op.Report.ChartLine();
            c.Value = data;
            c.Key = dt.Rows[i]["shippingCountry"].ToString();
            bool fg = true;

            for (int j = 0; j < col.Count; j++)
            {
                if (col[j].Key == c.Key)
                {
                    col[j].Value[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(col[j].Value[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                    fg = false;
                }
            }

            if (i == 0 || fg)
            {
                data[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(data[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                col.Add(c);

            }
        }
        rep.LineCollection = col;
        rep.Caption = "周报表";
        rep.xAxisName = "天";
        rep.yAxisName = "金额";
        if (Request.QueryString["repType"] == null || Request.QueryString["repType"] == "0")
            rep.FlashURL = "/swf/MSLine.swf";
        else
            rep.FlashURL = "/swf/MSColumn2D.swf";
        litReport.Text = rep.reportOneLine(800, 350);
    }

    /// <summary>
    /// 最近30天报表
    /// </summary>
    private void monthReport(string proClass)
    {

        string where = " where timeC BETWEEN '" + DateTime.Now.AddDays(-29).ToShortDateString() + "' And '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'";

        string sql = "SELECT DATE_FORMAT(TimeC,'%Y-%m-%d') AS 'CreateDate',COUNT(1) as 'Quantity',(CASE typ WHEN 1 THEN  priceC ELSE 0 END) as 'SellAmount', (CASE typ WHEN 0 THEN priceC ELSE 0 END) AS 'Unpaid', (CASE typ WHEN -1 THEN priceC ELSE 0 END) AS 'RefundAmount',shippingCountry from `order` " + where + " GROUP BY DATE_FORMAT(TimeC,'%Y-%m-%d'),shippingCountry";

        DataTable dt = OrderDB.SqlTable(sql);
        if (dt == null)
            return;
        repReport.DataSource = dt;
        repReport.DataBind();
        op.Report rep = new op.Report();
        List<op.Report.ChartLine> col = new List<op.Report.ChartLine>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int j = 0; j < 30; j++)
            {
                data.Add(DateTime.Now.AddDays(j - 29).ToString("yyyy-MM-dd"), "0");
            }
            op.Report.ChartLine c = new op.Report.ChartLine();
            c.Value = data;
            c.Key = dt.Rows[i]["shippingCountry"].ToString();
            bool fg = true;

            for (int j = 0; j < col.Count; j++)
            {
                if (col[j].Key == c.Key)
                {
                    col[j].Value[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(col[j].Value[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                    fg = false;
                }
            }

            if (i == 0 || fg)
            {
                data[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(data[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                col.Add(c);

            }
        }
        rep.LineCollection = col;
        rep.Caption = "月报表";
        rep.xAxisName = "月份";
        rep.yAxisName = "金额";
        if (Request.QueryString["repType"] == null || Request.QueryString["repType"] == "0")
            rep.FlashURL = "/swf/MSLine.swf";
        else
            rep.FlashURL = "/swf/MSColumn2D.swf";
        litReport.Text = rep.reportOneLine(800, 350);
    }

    /// <summary>
    /// 月报表
    /// </summary>
    /// <param name="proClass"></param>
    private void ThmonthReport(string proClass, int month)
    {

        string where = " where timeC BETWEEN '" + DateTime.Now.AddMonths(-month + 1).ToString("yyyy-MM-01") + "' And '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'";

        string sql = "SELECT DATE_FORMAT(TimeC,'%Y-%m') AS 'CreateDate',COUNT(1) as 'Quantity',(CASE typ WHEN 1 THEN  priceC ELSE 0 END) as 'SellAmount', (CASE typ WHEN 0 THEN priceC ELSE 0 END) AS 'Unpaid', (CASE typ WHEN -1 THEN priceC ELSE 0 END) AS 'RefundAmount',shippingCountry from `order` " + where + " GROUP BY DATE_FORMAT(TimeC,'%Y-%m'),shippingCountry";

        DataTable dt = OrderDB.SqlTable(sql);
        if (dt == null)
            return;
        repReport.DataSource = dt;
        repReport.DataBind();



        op.Report rep = new op.Report();
        List<op.Report.ChartLine> col = new List<op.Report.ChartLine>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int j = 0; j < month; j++)
            {
                data.Add(DateTime.Now.AddMonths(j - month + 1).ToString("yyyy-MM"), "0");
            }

            op.Report.ChartLine c = new op.Report.ChartLine();
            c.Value = data;
            c.Key = dt.Rows[i]["shippingCountry"].ToString();
            bool fg = true;

            for (int j = 0; j < col.Count; j++)
            {
                if (col[j].Key == c.Key)
                {
                    col[j].Value[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(col[j].Value[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                    fg = false;
                }
            }

            if (i == 0 || fg)
            {
                data[dt.Rows[i]["CreateDate"].ToString()] = (Decimal.Parse(data[dt.Rows[i]["CreateDate"].ToString()]) + decimal.Parse(dt.Rows[i]["SellAmount"].ToString())).ToString();
                col.Add(c);

            }



            //已支付
            //if (list[i].ProState == 1)
            //{
            //    data[list[i].timeC.Hour.ToString()] = (Decimal.Parse(data[list[i].timeC.Hour.ToString()]) + list[i].TotalAmount).ToString();
            //}
        }
        rep.LineCollection = col;


        rep.Caption = "月报表";
        rep.xAxisName = "月份";
        rep.yAxisName = "金额";
        if (Request.QueryString["repType"] == null || Request.QueryString["repType"] == "0")
            rep.FlashURL = "/swf/MSLine.swf";
        else
            rep.FlashURL = "/swf/MSColumn2D.swf";
        litReport.Text = rep.reportOneLine(800, 350);

    }
}