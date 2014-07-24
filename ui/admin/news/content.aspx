<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="content.aspx.cs" Inherits="admin_news_content" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="center">
                    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
                       <asp:TextBox ID="txtContent" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox> <br />
                      <asp:Button ID="BtOk" runat="server" Text="确定" onclick="BtOk_Click" CssClass="btn_white" />
                   &nbsp;  &nbsp; &nbsp; <asp:Button ID="BtClear" runat="server" Text="清空" onclick="BtClear_Click" CssClass="btn_white" /> 
                   
    </div>
</asp:Content>
