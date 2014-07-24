<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="admin_index" EnableViewState="false" %>

<%@ MasterType VirtualPath="~/admin/MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ul_order { border: 1px solid #ccc; border-bottom: none; }
        .ul_order li { clear: both; border-bottom: 1px solid #ccc; height: 20px; line-height: 20px; }
        .ul_order li div { float: left; margin-right: 5px; border-right: 1px solid #ccc; }
        
        .ul_siteRemind { height: 100px; overflow: hidden; background-color: #F7F6F7; }
        .ul_siteRemind li { width: 170px; float: left; margin-right: 10px; margin-left: 10px; }
        .ul_siteRemind li .left { float: left; background: url(img/bg_4.gif) no-repeat; width: 60px; text-align: center; height: 80px; font-size: 14px; padding-top: 15px; }
        .ul_siteRemind li .left span { display: block; color: red; font-family: Arial; font-size: 11px; }
        .ul_siteRemind li .right { padding-top: 10px; margin-left: 10px; }
        .ul_siteRemind li .right p { border-bottom: 1px solid #ccc; width: 90px; }
        .tb_stock { width: 380px; border: 1px solid #ccc; border-bottom: none; background-color: #F6F6F6; }
        .tb_stock .head { background: url(img/menu-bg.gif) repeat-x 0px -20px; }
        .tb_stock td { border-bottom: 1px solid #ccc;border-right:1px solid #ccc; }
        .ul_search{height:260px;background:url(img/search-bg.gif) no-repeat left top; background-color:#F6F6F6;padding:0px 0px 0px 80px;
                    overflow:hidden;}
        .ul_search li{margin-top:10px;padding-bottom:3px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div>
        <div style="width: 490px; float: left;">
            <!--最新订单-->
            <div class="site">
                <span>&nbsp;&nbsp;</span>最新订单 <font color="#DD5954"><b>New Order</b></font></div>
            <ul class="ul_order">
                <asp:Repeater ID="repOrder" runat="server">
                    <ItemTemplate>
                        <li>
                            <div style="width: 20px; text-align: center;">
                                <%# i++ %></div>
                            <div style="width: 150px;">
                                <a href='user/EditOrder.aspx?id=<%# Eval("orderC") %>'s><%# Eval("orderC") %></a></div>
                            <div style="width: 50px; color: #aa0000;">
                                ￥<%# Eval("priceC") %></div>
                            <div style="padding: 0 5px 0 3px;">
                                <%# Eval("timeC") %></div>
                            <div style="float: right; border-right: none; width: 120px; overflow: hidden;">
                                <%# Eval("userName") %></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--最新会员-->
        <div style="width: 475px; float: right;">
            <div class="site">
                <span>&nbsp;&nbsp;</span>最新会员</div>
            <ul class="ul_order">
                <asp:Repeater ID="repUser" runat="server">
                    <ItemTemplate>
                        <li>
                            <div style="width: 20px; text-align: center;">
                                <%# i++ %></div>
                            <div style="width: 300px">
                               <a href="user/User.aspx"> <%# Eval("userName") %></a></div>
                            <div style="padding: 0 5px 0 3px; float: right; border-right: none;">
                                <%# Eval("timeC") %></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--站点提醒-->
        <div class="site cl">
            <span>&nbsp;&nbsp;</span>站点提醒 <font color="#DD5954"><b>Site Remind</b></font></div>
        <ul class="ul_siteRemind">
            <li>
                <div class="left">
                    订单<span>ORDER</span></div>
                <div class="right">
                    <asp:Literal ID="liOrder" runat="server"></asp:Literal>
                </div>
            </li>
            <li>
                <div class="left">
                    会员<span>MEMBER</span></div>
                <div class="right">
                    <asp:Literal ID="liMember" runat="server"></asp:Literal>
                </div>
            </li>
            <li>
                <div class="left">
                    商品<span>GOODS</span></div>
                <div class="right">
                    <asp:Literal ID="liGoods" runat="server"></asp:Literal>
                </div>
            </li>
            <li style="display:none">
                <div class="left">
                    新闻<span>NEWS</span></div>
                <div class="right">
                    <asp:Literal ID="liNews" runat="server"></asp:Literal>
                </div>
            </li>
            <li>
                <div class="left">
                    询盘<span>INQUIRY</span></div>
                <div class="right">
                    <asp:Literal ID="liInquiry" runat="server"></asp:Literal>
                </div>
            </li>
        </ul>
        <!--存库报警-->
        <div style="width: 380px; float: left;">
            <div class="site">
                <span>&nbsp;&nbsp;</span>库存报警 <font color="#DD5954"><b>Stock Alarm</b></font></div>
            <table class="tb_stock">
                <tr class="head">
                    <td style="width: 30px">
                        序号
                    </td>
                    <td>
                        产品名称
                    </td>
                    <td style="width: 80px;text-align:center;">
                        剩余数量
                    </td>
                </tr>
                <asp:Repeater ID="repStockAlarm" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="center">
                                <%# i++ %>
                            </td>
                            <td>
                                <a href="Product/edit.aspx?id=<%# Eval("id") %>">
                                    <%# Eval("nameC") %></a>
                            </td>
                            <td class="center">
                                <%# Eval("stockC") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <!--热卖产品-->
        <div style="width: 570px; float: right;">
            <div style="float: left;width:380px;">
                <div class="site">
                    <span>&nbsp;&nbsp;</span>热卖产品 <font color="#DD5954"><b>Hot Sell</b></font></div>
                <table class="tb_stock">
                    <tr class="head">
                        <td style="width: 30px">
                            序号
                        </td>
                        <td>
                            产品名称
                        </td>
                        <td style="width: 80px;text-align:center;">
                            售出数量
                        </td>
                    </tr>
                    <asp:Repeater ID="repHotSell" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="center">
                                    <%# i++ %>
                                </td>
                                <td>
                                    <a href="/proShow.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <%# Eval("nameC") %></a>
                                </td>
                                <td class="center">
                                    <%# Eval("sellCount") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div style="float:right;width:180px">
            <div class="site"> <span>&nbsp;&nbsp;</span>搜索引擎收入 <font color="#DD5954"><b>Domain</b></font><a href="index.aspx?seo=1">显示</a></div>
            <ul class="ul_search">
             <asp:Literal ID="liSearch" runat="server"></asp:Literal>
            </ul>
            </div>
        </div>
          <div class="bottom_menu" style="margin:0px;clear:both;text-align:center;font-size:14px;font-weight:bolder;color:red;">
            <font color="#333">服务时间</font> SERVICE TIME
            服务时间:2011年12月11日
            <a href="http://jiuyu.org/contact/">我想续签</a>
          </div>
        <div class="cl">
            <asp:Literal ID="liTest" runat="server"></asp:Literal></div>
    </div>
</asp:Content>
