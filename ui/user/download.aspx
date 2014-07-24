<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="download.aspx.cs" Inherits="user_download" %>

<%@ Register src="menu.ascx" tagname="menu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

.ulDownload{ list-style-type:decimal; list-style-position:inside;margin-left:30px;}
.ulDownload li{margin-top:10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="indexLeft">
    <uc1:menu ID="menu1" runat="server" />
    </div>
<div class="indexRight">
<div class="right_head"> <span>Download Area</span></div>
    <div class="border">
    <ul class="ulDownload">
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<li><a href="<%# Eval("urlC") %>"><%# Eval("nameC") %></a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
</div>
</asp:Content>

