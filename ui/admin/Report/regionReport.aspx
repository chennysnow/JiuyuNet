<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regionReport.aspx.cs" Inherits="admin_Report_regionReport" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="/admin/css/admin_v1.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript" >
        var type;
        var repType = 0;
        $(document).ready(function () {
            var url = window.location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            if (typeof (paraString) == "object" && paraString.length > 0) {
                var paraObj;
                for (i = 0; i < paraString.length; i++) {
                    var j = paraString[i];
                    if (j.substring(0, j.indexOf("=")) == "type")
                        paraObj = j.substring(j.indexOf("=") + 1, j.length);
                    if (j.substring(0, j.indexOf("=")) == "repType") {
                        if (j.substring(j.indexOf("=") + 1, j.length) == "1") {
                            $("#repType").val("折线图");
                            repType = 1;
                        }
                        else
                            repType = 0;

                    }

                }

                $(".menu1 a").each(function (i, o) {
                    if ($(o).attr("class") == "click")
                        $(o).removeClass("click");
                    if (i.toString() == paraObj) {
                        $(o).addClass("click");
                        type = i;
                    }

                });



                $("#repType").click(function () {

                    if ($("#repType").val() == "柱状图") {
                        window.location.href = "?type=" + type + "&repType=1";
                        $("#repType").val("折线图");
                    }
                    else {
                        window.location.href = "?type=" + type + "&repType=0";
                        $("#repType").val("柱状图");
                    }


                });


            }

        })
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title">区域销售报表</div>
    <div class="menu1">
    <ul >
        
        <li><a href="?type=0" class="click" >今天</a></li>
        <li><a href ="?type=1" >昨天</a></li>
        <li><a href="?type=2" >近7天</a></li>
        <li><a href="?type=3" >近30天</a></li>
        <li><a href="?type=4" >三个月</a></li>
        <li><a href="?type=5" >半年</a></li>
        <li><a href="?type=6" >一年</a></li>
     </ul>

   
    </div>

    <input value="柱状图" id="repType" type="button" />
    <br />
    <div class="content">
    <asp:literal ID="litReport" runat="server"></asp:literal>
    <div class="tb-void">

    <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <th>
                            时间
                        </th>
                              <th>
                            区域
                        </th>
                        <th>
                           订单数量
                        </th>
                        <th>
                            已付款额
                        </th>
                        <th>
                            未付款金额
                        </th>
                        <th>
                            已退款金额
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="repReport" runat="server">
                        <ItemTemplate>
                            <tr style='<%# Container.ItemIndex%2==1?"background-color:#F7F7F7": "" %>'>
                         
                                <td>
                                     <%#  Eval("CreateDate")%>
                                </td>
                                  <td>
                                     <%#  Eval("shippingCountry")%>
                                </td>
                                <td>
                                    <%# Eval("Quantity")%>
                                </td>
                           
                                <td>
                                    <%# Eval("SellAmount")%>
                                </td>
                                <td>
                                    <%# Eval("Unpaid ")%>
                                </td>
                                 <td>
                                    <%# Eval("RefundAmount")%>
                                </td>
                   
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </tbody>
            </table>

            </div>

    </div>
    </form>
</body>
</html>
