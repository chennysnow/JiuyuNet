<%@ Control Language="C#" AutoEventWireup="true" CodeFile="site.ascx.cs" Inherits="userCon_site" %>
<div class="site">
&nbsp; <b>You are here:</b> <a href="<%= op.staValue.siteUrl %>">Home</a><asp:Literal ID="liSite" runat="server"></asp:Literal>
</div>