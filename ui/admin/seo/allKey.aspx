<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="allKey.aspx.cs" Inherits="admin_seo_allKey" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<asp:TextBox ID="txtAllKey" runat="server" TextMode="MultiLine" Width="965px" Height="300px"></asp:TextBox>
<p style="margin-top:10px;">请用逗号(,)隔开</p>
<p class="center">
<asp:Button ID="btnOk" runat="server" Text="提 交" onclick="btnOk_Click" />&nbsp;&nbsp;
<input type="reset"  value="重 置" />
</p>
</asp:Content>

