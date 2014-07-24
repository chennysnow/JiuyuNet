<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Password.aspx.cs" Inherits="user_Password" %>

<%@ Register src="menu.ascx" tagname="menu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link href="/css/user.css" rel="stylesheet" type="text/css" />
    <script src="/js/JsVido.js" type="text/javascript" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="indexLeft">
    <uc1:menu ID="menu1" runat="server" />
    </div>
<div class="indexRight">
    <form id="form1" runat="server">
      <div class="right_head"> <span>Change Password</span></div>
    <div class="border">
    <ul class="ul">
        <li>
            <div>
                Password:</div>
            <asp:TextBox ID="txtOldPass" runat="server" MaxLength="30" TextMode="Password"></asp:TextBox> </li>
        <li>
            <div>
                New-Password:</div>
            <asp:TextBox ID="txtPass1" runat="server" MaxLength="30" TextMode="Password"></asp:TextBox> </li>
        <li>
            <div>
                Confirm Password:</div>
            <asp:TextBox ID="txtPass2" runat="server" MaxLength="30" TextMode="Password"></asp:TextBox></li>
        <li>
            <div>
                &nbsp;</div>
            <asp:Button ID="btn_edit_password" runat="server" CssClass="btn_submit" Text="Save of change"
                OnClientClick="return EditPass()" OnClick="btn_edit_password_Click" />
        </li>
    </ul>
    </div>
    </form>
 </div>
</asp:Content>
