<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.info{ background-color:#fff;padding:10px;}
.info div{margin:5px 0 5px 0;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
<div class="info">
<h1>Successful!</h1>
<asp:Literal ID="liInfo" runat="server"></asp:Literal>
    <asp:LinkButton ID="lbtnSend" runat="server" onclick="lbtnSend_Click" Visible="false">If you don't receive email please click resend</asp:LinkButton>
<p>
<%--<a href="Payment.aspx">GO PAYMENT</a>--%>
</p>
</div>
</form>
</asp:Content>

