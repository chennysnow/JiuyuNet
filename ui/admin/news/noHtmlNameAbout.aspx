﻿<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="noHtmlNameAbout.aspx.cs" Inherits="admin_news_noHtmlName" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <asp:TextBox ID="txtKeywords" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    网站描述:</td>
                <td class="style3">
                  <asp:TextBox ID="txtDescription" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
            <td class="style1">内容:&nbsp;</td>
                <td class="style3">
                    <FCKeditorV2:FCKeditor ID="fckIntro" runat="server" Width="100%" Height="400px" >
                </FCKeditorV2:FCKeditor>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                  
                   <asp:Button ID="BtOk" runat="server" Text="确定" onclick="BtOk_Click" CssClass="Btn" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtClear" runat="server" Text="清空" onclick="BtClear_Click" CssClass="Btn" />
                </td>
            </tr>
        </table>
</asp:Content>
