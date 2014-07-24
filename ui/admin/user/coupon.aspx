<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="coupon.aspx.cs" Inherits="admin_user_coupon" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .Btn { height: 21px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="PanelRep" runat="server">
     <table class="table">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <tr class="tableHead">
    <td>选择</td>
    <td>优惠券号</td>
    <td>优惠价格</td>
    <td style="width:40px;">状态</td>
    <td style="width:40px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/></td>
    <td><%# Eval("numC") %></td>
    <td><%# Eval("priceC")%></td>
     <td class="sort">
        <%# Eval("typ").ToString()=="0"?"已用":"未用" %>
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
         <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加优惠券</asp:LinkButton>&nbsp;|&nbsp;
          </div>
    </asp:Panel>
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
        
        <div class="tableHead">
            添加优惠券</div>
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    优惠券号:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    优惠券价格:</td>
                <td>
                   <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox> 只能是数字</td>
            </tr>
            <tr>
                <td>
                   </td>
                <td>
                    <asp:Button ID="BtAddOk" runat="server" CssClass="Btn" onclick="BtAddOk_Click" 
                        Text="添加" />
                    <asp:Button ID="BtRep" runat="server" CssClass="Btn" onclick="BtRep_Click" 
                        Text="查看" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="tableHead">优惠券修改</div>
         <table class="style1">
            <tr>
                <td>
                    优惠券名称:</td>
                <td>
                    <asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   优惠券价格:</td>
                <td>
                    <asp:TextBox ID="txtPriceEdit" runat="server"></asp:TextBox> 只能是数字</td>
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
