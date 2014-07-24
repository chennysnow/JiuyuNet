<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="admin_supply_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
             text-align:right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
   <table class="tableAdd" >
<%--            <tr>
                <td class="style1">
                                        &nbsp;</td>
                <td class="style3">
                    <asp:DropDownList ID="dropType" runat="server">
                    </asp:DropDownList>
                                   </td>
            </tr>--%>
            <tr>
                <td class="style1">
                                        供货商名称:</td>
                <td class="style3">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
           <tr>
                <td class="style1">
                                        联系人:</td>
                <td class="style3">
                    <asp:TextBox ID="txtcontactus" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    电话:</td>
                <td class="style3">
                    <asp:TextBox ID="txtphone" runat="server" MaxLength="180" Width="360px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                   地址:</td>
                <td class="style3">
                  <asp:TextBox ID="txtaddress" runat="server" MaxLength="180" Width="360px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    邮箱: </td>
                <td class="style3">
                    <asp:TextBox ID="txtmail" runat="server" MaxLength="180" Width="360px"></asp:TextBox>
                 
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;传真:</td>
                <td class="style3">
                 <%--  <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> --%>
                       <asp:TextBox ID="txtnote1" Text='' runat="server" MaxLength="180" Width="360px"></asp:TextBox>
                    
                    </td>
            </tr>
            <tr>
            <td class="style1">自定义属性:</td>
                <td class="style3">
                     
                      <ul class="ul">
                 <asp:Repeater ID="repAttr" runat="server"><ItemTemplate>
                 <li><div style=" width:150px; overflow:hidden;">
                 <input type="checkbox" name="attr" checked="checked" value="<%# Eval("id") %>"/><%# Eval("name") %>
                 </div>
             <input type="hidden" name="attrValueid" value="<%# Eval("id") %>" /><input type="text" name="attrValue" value="<%# Eval("value") %>"  style="width:264px" />
                 </li>
                </ItemTemplate></asp:Repeater>
                </ul>
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

