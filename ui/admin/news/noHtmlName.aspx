<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="noHtmlName.aspx.cs" Inherits="admin_news_noHtmlName" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
          <table class="tableAdd">
            <tr>
                <td class="style1">
                                        类别:</td>
                <td class="style3">
                    <%= typ %>
                                   </td>
            </tr>
            <tr>
                <td class="style1">
                                        文章标题:</td>
                <td class="style3">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
           <tr>
                <td class="style1">
                                        网站标题:</td>
                <td class="style3">
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    网站关键字:</td>
                <td class="style3">
                    <asp:TextBox ID="txtKeywords" runat="server" MaxLength="180" Width="360px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    网站描述:</td>
                <td class="style3">
                  <asp:TextBox ID="txtDescription" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    文章简介:</td>
                <td class="style3">
                    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
                       <asp:TextBox ID="txtAbout" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox>
                    
                    </td>
            </tr>
            <tr>
            <td class="style1">内容:&nbsp;</td>
                <td class="style3">
                       <asp:TextBox ID="txtContent" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                  <asp:Button ID="BtOk" runat="server" Text="确定" onclick="BtOk_Click" CssClass="btn_white" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="btnBack" class="btn_white"  type="button" value="返回列表"  onclick="window.location.href='list.aspx';" />
                </td>
            </tr>
        </table>
</asp:Content>
