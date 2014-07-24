<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="js/Ext/resources/css/ext-admin.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script src="js/Ext/ext-all.js" type="text/javascript"></script>
    
    <script src="js/Ext/ux/RowExpander.js" type="text/javascript"></script>
    <script src="js/Ext/ext-lang-zh_CN.js" type="text/javascript"></script>
    <script src="js/Ext/ExtGrid.js" type="text/javascript"></script>
    
</head>
<body style=" background-color:#ebf1f9">
    <form id="form1" runat="server">
    <div class="top" id="topInfo">
    <div class="logo" >
    <div class="logo_left"></div>
    <div class="logo_right">
    <ul>
    <li><span style=" float:left;"> 欢迎您：<span class="red">albert</span></span> <b class="b"></b><a href="/"> 前 台 </a><b class="b1"></b><a href="/admin/Default.aspx"> 首 页 </a><b class="b2"></b><a href="#"> 添加产品 </a><b class="b3"></b><a href="#"> 留言管理 </a>  </li>
    <li>电话：<span class="red">0579-8581717</span> 服务时间：8:30-17:30（周一至周六）454 </li>
    </ul>
    </div>
    </div>
        
        <div class="main_Menu">
            <ul>
                <li>商品管理</li>
                <li>订单管理</li>
                <li>客户管理</li>
                <li>支付与快递</li>
                <li>供应商</li>
                <li>新闻管理</li>
                <li>评论管理</li>
                <li>广告管理</li>
                <li>Seo优化</li>
                <li>商城配置</li>
            </ul>
        </div>
    </div>


    <div class="total_msg">
    <div class="mgstitle"><span>站点提醒<br />SITE REMIND</span> </div>
    <ul >
    <li class="msg_con"><div class="lftitle">订单<br /><span class="red">Order</span></div>
    <ul>
    <li>订单总数：<span class="red">1000</span></li>
    <li>代发货订单：<span class="red">1000</span></li>
    <li>发货中订单：<span class="red">1000</span></li>
    <li>已完成订单：<span class="red">1000</span></li>
    </ul>
    </li>
        <li class="msg_con"><div class="lftitle">会员<br /><span class="red">Member</span></div>
    <ul style="margin-top: 7px;">
    <li>会员总数：<span class="red">1000</span></li>
    <li>今日新增：<span class="red">1000</span></li>
    <li>昨日新增：<span class="red">1000</span></li>
    </ul>
    </li>
       <li class="msg_con"><div class="lftitle">商品<br /><span class="red">Goods</span></div>
    <ul>
    <li>商品总数：<span class="red">1000</span></li>
    <li>库存报警：<span class="red">1000</span></li>
    <li>缺货商品：<span class="red">1000</span></li>
    <li>库存商品：<span class="red">1000</span></li>
    </ul>
    </li>
        <li class="msg_con"><div class="lftitle">询盘<br /><span class="red">Inquity</span></div>
    <ul style="margin-top: 7px;">
    <li>留言总数：<span class="red">1000</span></li>
    <li>今日新增：<span class="red">1000</span></li>
    <li>昨日新增：<span class="red">1000</span></li>
    </ul>
    </li>
    </ul>
    
    </div>

    <div class="search_order">
    
    <ul>
    <li><span class="searCurrent">客户</span><span>订单</span><span>供应商</span></li>
    <li>
    <input class="seartxt" type="text" /><input type="button" class="searbtn" value="收索" />
    </li>
    </ul>
    </div>
    <div style=" clear:both;"></div>
    <div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

    <div class="grid_info">
    <div id="grid-example"></div></div>

    </div>
    </form>
</body>
</html>
