using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.Data;
using System.Text;

public partial class admin_ExtJson : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string res = "";
            string type = Request.QueryString["type"];
            if (string.IsNullOrEmpty(type))
                return;
            switch (type)
            {
                case "orderSubmint":
                case "orderPayed":
                case "orderRefund":
                case "orderRefunded":
                case "orderExpand":
                case "orderDel":
                    res = GetOrderInfo(type);
                    break;
                default:
                    break;
            }


           
            //res = new op.ExtTree().CreateExtTreeJSON();

            HttpContext.Current.Response.Write(res);
            HttpContext.Current.Response.End();
        }

        

    }

    string dataFormat = " [company:{0}, 71.72, 0.02, 0.03, '9/1 12:00am'],";
    private string GetOrderInfo(string type)
    {
        string ret = "";
        if (type == "orderSubmint")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderSubmint" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        else if (type == "orderPayed")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderPayed" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        else if (type == "orderRefund")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderRefund" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        else if (type == "orderRefunded")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderRefunded" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        else if (type == "orderDel")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderDel" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        else if (type == "orderExpand")
        {
            for (int i = 0; i < 20; i++)
            {
                ret += "{company:'orderExpand" + i + "',price:71.72,change:0.02,pctChange:0.03,lastChange:'9/1 12:00am'},";
            }
        }
        if (ret != "")
        {
            ret = "{\"items\":[" + ret.TrimEnd(',') + "]}";
        }


        return ret;
    }
  



}

