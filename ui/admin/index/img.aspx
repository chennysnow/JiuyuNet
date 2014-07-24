<%@ Page Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="img.aspx.cs" Inherits="admin_index_img" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ul>
<li><img src="/images/menu_0.jpg" />(140*130)<asp:FileUpload ID="file_menu_0" runat="server" /></li>
<li><img src="/images/menu_1.jpg" />(140*130)<asp:FileUpload ID="file_menu_1" runat="server" /></li>
<li><img src="/images/menu_2.jpg" />(140*130)<asp:FileUpload ID="file_menu_2" runat="server" /></li>
</ul>
<asp:Button ID="btnEdit" 
        runat="server" Text="修改" CssClass="Btn" onclick="btnEdit_Click" />
      
</asp:Content>

