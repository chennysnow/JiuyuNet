<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="userCon_search" %>
<!--搜索-->
<div class="searchCart">
    <div class="search">
        <select id="seaType" style="width: 120px">
            <option value="0">::All Categories::</option>
            <% for (int i = 0; i < modelList.Count; i++) %>
            <%{ %>
            <option value="<%= modelList[i].id %>">
                <%= modelList[i].nameC %></option>
            <%} %>
        </select>
        <input type="text" id="seaKey" value="" />
        <img src="/images/go.gif" id="btnSearch" onclick="return search()" />
    </div>
    <!--购物车-->
    <div class="cart">
        <a href="<%= op.staValue.siteUrl %>/order/shopping.aspx">Shopping Cart <span id="cartCount">0</span></a>
    </div>
</div>
