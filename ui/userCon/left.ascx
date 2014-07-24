<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="userCon_left" %>
<%@ OutputCache Duration="300" VaryByParam="clBuffer" %>
<dl class="dlBrand">
<dt>Brand Area</dt>
<dd>
<asp:Repeater ID="repBrand" runat="server">
<ItemTemplate>
<a href="proSearch.aspx?brand=<%# Eval("id") %>"><%# Eval("nameC") %></a>
</ItemTemplate>
</asp:Repeater>
</dd>
</dl>
<dl class="dlOrders">
<dt>Recent Orders</dt>
<dd>
<asp:Repeater ID="repOrder" runat="server">
<ItemTemplate>
<div>
<%# ope.Strsub(Eval("userName").ToString(),4) %>*****@***.com Your goods have been sent, please check
<span>Express No.<%# Eval("orderC") %></span>
</div>
</ItemTemplate>
</asp:Repeater>
</dd>
</dl>
<div class="leftNewsletter">
<p><b>Newsletter</b><br />for Wholesale</p>
<div>About the lastest offers and deals subscribe today!<br />
<input type="text" size="15" id="sendMail"/><br />
<input type="button" value="Subscribe" onclick="return regMail()"/>
</div>
</div>
<dl class="dlDownload">
<dt>Download Area <font color="#aa0000">(Update)</font></dt>
<dd>Product offer pictures,catalog,<br />cooperation..
<asp:Repeater ID="repDownload" runat="server">
<ItemTemplate>
<div><a href="<%# Eval("urlC") %>"><%# Eval("nameC") %></a></div>
</ItemTemplate>
</asp:Repeater>
</dd>
</dl>
<dl class="dlFaq">
<dt>FAQ Categories</dt>
<dd>
<asp:Repeater ID="repFaq" runat="server">
<ItemTemplate>
<div><a href="<%# Eval("htmlName") %>"><%# Eval("nameC") %></a></div>
</ItemTemplate>
</asp:Repeater><br />
<b>Ask a question?</b><br />
&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/inquiry_left.gif" />
</dd>
</dl>
<dl class="dlContact">
<dt>Contact Us</dt>
<dd><asp:Literal ID="liContact" runat="server"></asp:Literal></dd>
</dl>