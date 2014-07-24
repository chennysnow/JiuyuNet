<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bestSale.ascx.cs" Inherits="userCon_bestSale" %>
<dl class="dlBestSale">
<dt>Bestsellers</dt>
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<dd><a href="<%# Eval("url") %>">
<img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>" class="img" />
</a>
<div>
<a href="<%# Eval("url") %>" title="<%# Eval("nameC") %>"><%# Eval("nameC") %></a><br />
<span class="price">Price:<%# Eval("strPrice") %></span>
</div></dd>
</ItemTemplate>
</asp:Repeater>
</dl>