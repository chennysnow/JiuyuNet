<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="editRetOrder.aspx.cs" Inherits="admin_user_editRetOrder" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <ul class="ul">
    <li><div>状态:</div><asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></li>
    <li><div>用户名:</div><a href="User.aspx?id=<%= model.userName %>"><%= model.userName %></a></li>
    <li><div>订单号:</div><a href="EditOrder.aspx?id=<%= model.orderC %>"><%= model.orderC %></a></li>
    <li><div>时间:</div><%= model.timeC %></li>
    <li>
            <div>
                退款金额:</div>
            <asp:TextBox ID="txtPrice_return" runat="server"></asp:TextBox></li>
        <li>
            <div>
                退货方式:</div>
            <asp:TextBox ID="txtMethod" runat="server" TextMode="SingleLine" Height="30px" Width="400px"></asp:TextBox></li>
        <li>
            <div>
                退货原因:</div>
            <asp:TextBox ID="txtReason" runat="server" TextMode="SingleLine" Height="40px" Width="400px"></asp:TextBox></li>
        <li>
            <div>
                退货清单:</div>
            <asp:TextBox ID="txtProList_return" runat="server" TextMode="SingleLine" Height="50px"
                Width="400px"></asp:TextBox></li>
        <li>
            <div>
                回复/备注:</div>
            <asp:TextBox ID="txtMessage_return" runat="server" TextMode="SingleLine" Height="60px"
                Width="400px"></asp:TextBox></li>
        <li>
            <div>
                &nbsp;</div>
            <asp:Button ID="btnOk_return" runat="server" Text="确认提交" OnClick="btnOk_return_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbId_return" runat="server" Visible="false"></asp:Label>
        </li>
    </ul>
</asp:Content>
