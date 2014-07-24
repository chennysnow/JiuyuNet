<%@ Page Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="HtUser.aspx.cs" Inherits="admin_HtUser" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <ul class="ul">
   <li><div>用户名:</div><asp:TextBox ID="txtUserid" runat="server" ReadOnly="true"></asp:TextBox></li>
   <li><div>旧密码:</div><asp:TextBox  ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            Display="Dynamic" ErrorMessage="旧密码不能为空"></asp:RequiredFieldValidator></li>
   <li><div>新密码:</div><asp:TextBox  ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword"
            Display="Dynamic" ErrorMessage="新密码不能为空"></asp:RequiredFieldValidator></li>
   <li><div>重复新密码:</div><asp:TextBox  ID="txtReNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReNewPassword"
            Display="Dynamic" ErrorMessage="确认密码不能为空"></asp:RequiredFieldValidator> <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
            ControlToValidate="txtReNewPassword" Display="Dynamic" ErrorMessage="确认密码输入错误"></asp:CompareValidator>
  </li>

  <li><div>&nbsp;</div><asp:Button  ID="Button1" runat="server" Text="提交" OnClick="Button1_Click"  CssClass="btn_white"/></li>
   </ul>
</asp:Content>
