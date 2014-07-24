<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="place.aspx.cs" Inherits="admin_user_place" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
     dl{width:100%; background-color:#eeeeee; overflow:hidden;}
     dt{width:22%;background-color:#eeeeee;padding:5px;float:left; overflow:hidden;border-bottom:solid 1px #fff;}
     dt div{width:100px; float:left;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <dl>
      <asp:Repeater ID="Repeater1" runat="server" 
          onitemcommand="Repeater1_ItemCommand">
     <ItemTemplate>
     <dt><div><%# Eval("nameC") %></div>
     <div><asp:LinkButton  ID="lbtnDel" CommandArgument='<%# Eval("id") %>' CommandName="del" runat="server">删除</asp:LinkButton></div>
     </dt>
    </ItemTemplate>
    </asp:Repeater>
    </dl>
    <div class="bottom" style="clear:both;">
        <asp:TextBox ID="txtPlace" runat="server"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" Text="添加地方" onclick="btnAdd_Click" CssClass="btn_white" />
    </div>
    <input id="maxNum" type="hidden" runat="server" />
    </asp:Content>
