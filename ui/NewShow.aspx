<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewShow.aspx.cs" Inherits="CompanyNews" Title="无标题页"  EnableSessionState="False"%>
<%@ Register src="userCon/contact.ascx" tagname="contact" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
<div class="indexLeft">
     <div class="left_head"><%= category %></div>
        <ul class="ulMenuNew">
            <asp:Literal ID="liNewMenu" runat="server"></asp:Literal>
        </ul>
    <uc1:contact ID="contact1" runat="server" />
</div>
<div class="indexRight">
    <dl class="dlNews">
        <asp:Literal ID="liNews" runat="server"></asp:Literal>
    </dl>
</div>
    </form>
</asp:Content>

