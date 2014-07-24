<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="brand.aspx.cs" Inherits="brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.ulBrand{margin-bottom:80px;}
.ulBrand li{float:left;margin:16px;_margin:8px;}
.ulBrand img{width:160px;height:60px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ul class="ulBrand">
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<li><a href="proSearch.aspx?brand=<%# Eval("id") %>" title="<%# Eval("nameC") %>" ><img src="<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" /></a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
</asp:Content>

