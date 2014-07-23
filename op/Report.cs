using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace op
{
     public class Report
    {
         /// <summary>
         /// 报表名称
         /// </summary>
         public string Caption { get; set; }

         /// <summary>
         /// x轴 名称
         /// </summary>
         public string xAxisName { get; set; }

         /// <summary>
         /// y轴 名称
         /// </summary>
         public string yAxisName { get; set; }

         /// <summary>
         /// x轴间隔多少显示一个值
         /// </summary>
         public string labelStep { get; set; }

         /// <summary>
         /// flash 绝对路径
         /// </summary>
         public string FlashURL { get; set; }

         public Report()
         {
             labelStep = "0";
             FlashURL = "/swf/Line.swf";
            
         }

         /// <summary>
         ///点的集合
         /// </summary>
         public IList<ChartLine> LineCollection { get; set; }



         public class ChartLine
         {
             public string Key{ get; set; }
             public Dictionary<string, string> Value { get; set; }
         }




         


        /// <summary>
        /// 单条线的报表
        /// </summary>
        /// <param name="caption">报表名称   （订单月报表）</param>
        /// <param name="data">数据</param>
        /// <param name="width">flash 宽度</param>
        /// <param name="height">flash 高度</param>
        public string reportOneLine(Dictionary<string, string> data, int width, int height)
        {
            int num = data.Count;
    
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("<chart  numberPrefix='$' lineColor='FF5904' showBorder='0' bgColor='ffffff' caption='" + Caption + "' xAxisName='" + xAxisName + "' yAxisName='" + yAxisName + "' decimalPrecision='0' formatNumberScale='0' labelStep='" + labelStep + "'>");

            List<string> keys = new List<string>(data.Keys);
            for (int i = 0; i < data.Count; i++)
            {

                strBuild.Append("<set label='" + keys[i] + "' value='" + data[keys[i]] + "'  />");         
            }
            strBuild.Append("</chart>");
            string strHtml = "<embed width='" + width + "' height='" + height + "' flashvars=\"chartWidth=" + width + "&amp;chartHeight=" + height + "&amp;dataXML=" + System.Web.HttpUtility.UrlEncode(strBuild.ToString(), System.Text.Encoding.UTF8) + "\" swliveconnect=\"true\" allowscriptaccess=\"always\" quality=\"high\" name=\"ChartId\" id=\"ChartId\" src='" + FlashURL + "' type=\"application/x-shockwave-flash\">";

            return strHtml;
        }
        /// <summary>
        /// 柱状报表
        /// </summary>
        /// <param name="caption">报表名称   （订单月报表）</param>
        /// <param name="data">数据</param>
        /// <param name="width">flash 宽度</param>
        /// <param name="height">flash 高度</param>
        /// <returns></returns>
        public string reportColumn2D(Dictionary<string, string> data, int width, int height)
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("<chart yAxisName='" + yAxisName + "' caption='" + Caption + "' numberPrefix='$' useRoundEdges='1' bgColor='FFFFFF,FFFFFF' labelStep='" + labelStep + "' showBorder='0'>");
            List<string> keys = new List<string>(data.Keys);
            for (int i = 0; i < data.Count; i++)
            {
                strBuild.Append("<set label='" + keys[i] + "' value='" + data[keys[i]] + "'  />");
            }
            strBuild.Append("</chart>");
            string strHtml = "<embed width='" + width + "' height='" + height + "'  flashvars=\"chartWidth=" + width + "&amp;chartHeight=" + height + "&amp;dataXML=" + System.Web.HttpUtility.UrlEncode(strBuild.ToString(), System.Text.Encoding.UTF8) + "\" swliveconnect=\"true\" allowscriptaccess=\"always\" quality=\"high\" name=\"ChartId\" id=\"ChartId\" src=\"/swf/Column2D.swf\" type=\"application/x-shockwave-flash\" />";
            return strHtml;

        }

        /// <summary>
        /// 单条线的报表
        /// </summary>
        /// <param name="caption">报表名称   （订单月报表）</param>
        /// <param name="data">数据</param>
        /// <param name="width">flash 宽度</param>
        /// <param name="height">flash 高度</param>
        public string reportOneLine( int width, int height)
        {
            if (LineCollection == null || LineCollection.Count == 0)
                return "";
            string[] color = new string[] { "F6BD0F", "8BBA00", "FF8E46", "008E8E", "D64646", "8E468E", "588526", "B3AA00", "008ED6", "9D080D", "A186BE", "AFD8F8" };
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("<chart  numberPrefix='$' lineColor='FF5904' showBorder='0' bgColor='ffffff' caption='" + Caption + "' xAxisName='" + xAxisName + "' yAxisName='" + yAxisName + "' decimalPrecision='0' formatNumberScale='0' labelStep='" + labelStep + "'>");

            //strBuild.Append("<chart canvasPadding='10' caption='Production Forecast' yAxisName='Units' bgColor='F7F7F7, E9E9E9' numVDivLines='10' divLineAlpha='30' labelPadding ='10' yAxisValuesPadding ='10' showValues='1' rotateValues='1' valuePosition='auto'>"); 


            strBuild.Append("<categories>");

             List<string> kes = new List<string>( LineCollection[0].Value.Keys);



            for (int i = 0; i < kes.Count; i++)
            {
                 strBuild.Append("<category label='"+kes[i]+"' />");
            }

            strBuild.Append("</categories>");


            for (int j = 0; j < LineCollection.Count; j++)
            {
                Dictionary<string, string> data = LineCollection[j].Value;
                List<string> keys = new List<string>(data.Keys);
                strBuild.Append("<dataset seriesName='" + LineCollection[j].Key + "' color='"+color[j]+"'>");
                for (int i = 0; i < data.Count; i++)
                {

                    strBuild.Append("<set value='" + data[keys[i]] + "'  />");
                }
                strBuild.Append("</dataset>");

            }


    
            strBuild.Append("</chart>");
            string strHtml = "<embed width='" + width + "' height='" + height + "' flashvars=\"chartWidth=" + width + "&amp;chartHeight=" + height + "&amp;dataXML=" + System.Web.HttpUtility.UrlEncode(strBuild.ToString(), System.Text.Encoding.UTF8) + "\" swliveconnect=\"true\" allowscriptaccess=\"always\" quality=\"high\" name=\"ChartId\" id=\"ChartId\" src='" + FlashURL + "' type=\"application/x-shockwave-flash\">";

            return strHtml;
        }



    }
}
