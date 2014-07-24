<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="KeyWords.aspx.cs" Inherits="admin_KeyWords" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Repeater ID="repList" runat="server">
<HeaderTemplate>
<table class="table">
        <tr class="tableHead">
            <td>
                标题
            </td>
            <td>关键字</td>
            <td>描述</td>
            <td>类型</td>
            <td>解释</td>
        </tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
                <td>
                <input type="hidden" name="id" value="<%# Eval("id") %>" />
                   <input type="text" name="titleC" value="<%# Eval("titleC") %>" style="width:210px" />
                </td>
                <td>
                 <input type="text" name="keywordsC" value="<%# Eval("keywordsC") %>"  style="width:260px"/>
                </td>
                <td>
                <input type="text" name="descriptionC" value="<%# Eval("descriptionC") %>"  style="width:310px"/>
                </td>
                <td><%# Eval("typS") %>
                <input type="hidden" name="typS" value="<%# Eval("typS") %>" />
                </td>
                <td><%# Eval("tipsC") %>
                <input type="hidden" name="tipsC" value="<%# Eval("tipsC") %>" />
                </td>
            </tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
       <div class="bottom"><asp:Button ID="btnOk" runat="server" Text="保存更改" 
               CssClass="btn_white" onclick="btnOk_Click" /></div>
</asp:Content>
