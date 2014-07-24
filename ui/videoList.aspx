<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="videoList.aspx.cs" Inherits="videoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
h1{border-bottom:2px solid #aa0000;}
.ul_video{margin:10px;}
.ul_video li{margin:5px 0 5px 0;}
.ul_video li:hover{ background-color:#C7FBFB;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="indexLeft">
    <img src="images/left_top.gif" />
        <ul class="ul_left_menu">
        <li class="first">最新产品</li>
        <asp:Repeater ID="repLeftMenu" runat="server">
            <ItemTemplate>
                <li><a href="ProShow.aspx?id=<%# Eval("id") %>"><%# Eval("nameC") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
        <li class="last">&nbsp;</li>
        </ul>
        <img src="images/left_bottom.gif" />
    </div>
    <div class="indexRight">
    <h1>视频列表</h1>
        <ul class="ul_video">
        <asp:Repeater ID="repVideoList" runat="server">
            <ItemTemplate>
                <li><%# i++ %>、<a href="<%# Eval("urlC") %>"><%# Eval("nameC") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
</asp:Content>

