<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="filterKey.aspx.cs" Inherits="admin_seo_filterKey" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.ulFileKey{width:500px;margin:10px auto 10px auto;}
.ulFileKey li{margin-bottom:5px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

<ul class="ulFileKey">
<li><b>历史关键词列表:</b><input id="btnAddFilePic" onclick="addFileKey()" type="button" value="添加过滤词" /></li>
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<li id="li<%# i %>">过滤词:<input type="text" name="nameC" value="<%# Eval("nameC") %>" />
链接:<input type="text" name="urlC" value="<%# Eval("urlC") %>" /> <a href="javascript:delFileKey('li<%# i++ %>')">移除</a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
<div style="width:500px;margin:10px auto;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnOk" runat="server" Text="保存过滤词" onclick="btnOk_Click" />&nbsp;&nbsp;
<asp:DropDownList ID="dropList" runat="server">
<asp:ListItem Value="0">请选择操作</asp:ListItem>
<asp:ListItem Value="newsFilter">文章过滤</asp:ListItem>
<asp:ListItem Value="newsFilterCantel">取消文章链接过滤</asp:ListItem>
<asp:ListItem Value="newsFilterCantelKey">取消文章关键字过滤</asp:ListItem>
<asp:ListItem Value="proFilter">产品描述过滤</asp:ListItem>
<asp:ListItem Value="proFilterCantel">取消产品链接过滤</asp:ListItem>
<asp:ListItem Value="proFilterCantelKey">取消产品关键字过滤</asp:ListItem>
</asp:DropDownList>
<asp:Button ID="btnRun" runat="server" Text="执行操作" onclick="btnRun_Click" /></div>
<script type="text/javascript">
    var i=<%= i %>;
    function addFileKey() {
        $(".ulFileKey").append("<li id=\"li"+i+"\">过滤词:<input type=\"text\" name=\"nameC\"/> 链接:<input type=\"text\" name=\"urlC\" /> <a href=\"javascript:delFileKey('li"+i+"')\">移除</a></li>");
        i++;
    }
    function delFileKey(na) {
        $("#"+na).remove();
       
    }
</script>
</asp:Content>

