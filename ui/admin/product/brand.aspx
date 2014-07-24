<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="brand.aspx.cs" Inherits="admin_product_brand" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="PanelRep" runat="server">
     <table class="table">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <tr class="tableHead">
    <td>选择</td>
    <td>品牌图标</td>
    <td>品牌名称</td>
    <td style="width:40px;">排序</td>
    <td style="width:40px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/></td>
    <td><img src="<%#Eval("imgC")%>" /></td>
    <td><%# Eval("nameC")%></td>
     <td class="sort">
        <input type="text" name="sort" value="<%# Eval("sortC") %>" /> 
        <input type="hidden" name="id" value="<%# Eval("id") %>" />
    </td>
   <td>
   <asp:LinkButton  ID="lbtnEdit" CommandArgument='<%# Eval("id") %>' CommandName="edit" runat="server">修改</asp:LinkButton> 
    </td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
      <div class="bottom">
         <asp:LinkButton ID="LinkButton1" onclick="btnDel_Click" runat="server" Text="批量删除" />&nbsp;|&nbsp;
         <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加品牌</asp:LinkButton>&nbsp;|&nbsp;
         <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">保存排序</asp:LinkButton>
          </div>
    </asp:Panel>
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
        
        <div class="tableHead">
            添加品牌</div>
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    品牌名称:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    品牌图标:</td>
                <td>
                   <asp:FileUpload ID="fileAdd" runat="server"/>  图标尺寸(160*60)</td>
            </tr>
            <tr>
                <td>
                   </td>
                <td>
                    <asp:Button ID="BtAddOk" runat="server" CssClass="Btn" onclick="BtAddOk_Click" 
                        Text="添加" />
                    <asp:Button ID="BtRep" runat="server" CssClass="Btn" onclick="BtRep_Click" 
                        Text="品牌查看" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="tableHead">品牌修改</div>
         <table class="style1">
            <tr>
                <td>
                    图片</td>
                <td>
                    <img id="imgEdit" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    品牌名称:</td>
                <td>
                    <asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    品牌图标:</td>
                <td>
                    <asp:FileUpload ID="fileEdit" runat="server"/>  图标尺寸(160*60)</td>
            </tr>
            <tr>
                <td>
                   </td>
                <td>
                    <asp:Button ID="BtEditOk" runat="server" CssClass="Btn" 
                        onclick="BtEditOk_Click" Text="确定修改" />
                </td>
            </tr>
        </table>
            <br />
            <br />
    </asp:Panel>
</asp:Content>