<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="User.aspx.cs" Inherits="User" Title="Member Center" %>

<%@ Register Src="menu.ascx" TagName="menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/user.css" rel="stylesheet" type="text/css" />
    <script src="/js/JsVido.js" type="text/javascript" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="indexLeft">
        <uc1:menu ID="menu1" runat="server" />
    </div>
    <div class="indexRight">
    <div class="right_head"> <span>Change your profile</span></div>
    <div class="border">
            <p><b>Update your profile</b>&nbsp;<font color="red">*</font> indicates required fields</p>
        <ul class="ul">
            <li>
                <div>
                    Name:<font color="red">*</font></div>
                <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox></li>
            <li>
                <div>
                    Tel:<font color="red">*</font></div>
                <asp:TextBox ID="txtTel" runat="server" MaxLength="30"></asp:TextBox></li>
                <li><div>Country/Region:</div>
                <asp:DropDownList ID="dropCountry" runat="server">
                </asp:DropDownList>
                </li>
            <li>
                <div>
                    Address:<font color="red">*</font></div>
                <asp:TextBox ID="txtAdd" runat="server" MaxLength="100"></asp:TextBox> </li>
            <li>
                <div>
                    Remarks:<font color="red">*</font></div>
                <asp:TextBox ID="txtDescript" runat="server" TextMode="MultiLine" MaxLength="255"
                    Width="330px" Height="50px"></asp:TextBox></li>
            <li>
                <div>
                    &nbsp;</div>
                <asp:Button ID="btn_userInfo_ok" runat="server" Text="Save of change" OnClick="btn_userInfo_ok_Click" />
            </li>
        </ul>
    </div>
    </div>
    </form>
</asp:Content>
