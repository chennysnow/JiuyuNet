<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="Operation.aspx.cs" Inherits="admin_static_Operation" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
.ul{color:#aaa;}
.ul li{ background-color:#f1f1f1;margin-bottom:5px;padding:5px;}
.ul li a{padding:2px; background-color:#aa0000;}
.ul li a:link,.ul li a:visited{color:#fff;}
.ul li a:hover{color:#000;}
#Info{height:800px; overflow:scroll; background:#f3f3f3; line-height:18px;padding:0px 10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <ul class="ul">
        <li>
            <div>
                整站生成:</div>
            <a href="javascript:all()">整站快速生成</a>&nbsp;|&nbsp; <a href="javascript:web('sitmap')">
                更新所有缓存</a></li>
        <li>
            <div>
                单页面生成:</div>
            <a href="javascript:web('index')">生成首页</a>&nbsp;|&nbsp; <a href="javascript:web('about')">
                生成关于我们</a>&nbsp;|&nbsp;<%--<a href="javascript:web('contact')">生成联系我们</a>--%></li>
        <%--<li>
            <div>
                列表页面生成</div>
            <a href="javascript:List('ProMenuCount','CreatProList','产品列表生成')">生成产品列表页</a>&nbsp;|&nbsp;
            <a href="javascript:List('NewMenuCount','CreatNewList','新闻列表生成')">生成新闻列表页</a></li>--%>
        <li>
            <div>
                内容页面生成:</div>
            <a href="javascript:products()">生成产品内容页</a>&nbsp;|&nbsp; <a href="javascript:News()">
                生成新闻内容页</a></li>
    </ul>
    <div id="Info">
    </div>
    <script src="../js/Ajax_web.js" type="text/javascript"></script>
</asp:Content>
