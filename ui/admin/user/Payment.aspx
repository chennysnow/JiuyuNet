<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="Payment.aspx.cs" Inherits="admin_user_Payment" Title="无标题页" %>

<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div>
        <asp:Panel ID="PanelRep" runat="server">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                        <tr class="tableHead">
                            <td style="width: 100px;">
                                支付名称
                            </td>
                            <td style="width: 80px">
                                图标
                            </td>
                            <td>
                                描述
                            </td>
                            <td style="width: 80px;">
                                操作
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="menulevel">
                            <%# Eval("nameC") %>
                        </td>
                        <td>
                            <img src="<%# Eval("imgC") %>" width="80px" />
                        </td>
                        <td>
                            <%# Eval("tipsC") %>
                        </td>
                        <td class="operation">
                            <asp:LinkButton ID="lbtnEdit" CommandArgument='<%# Eval("id") %>' CommandName="edit"
                                runat="server">修改</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("id") %>' CommandName="del"
                                runat="server">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="bottom">
                <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加支付</asp:LinkButton></div>
        </asp:Panel>
    </div>
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
        <div class="bottom">
            支付名称:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            支付图标:<asp:FileUpload ID="fileAdd" runat="server" />
            <br />
            支付描述:<asp:TextBox ID="txtDescription" runat="server" Width="260px" TextMode="MultiLine"
                Height="60px"></asp:TextBox>
            <asp:Button ID="BtAddOk" runat="server" CssClass="btn_white" OnClick="BtAddOk_Click" Text="添加支付" />
            <asp:Button ID="BtRep" runat="server" CssClass="btn_white" OnClick="BtRep_Click" Text="查看全部" />
        </div>
    </asp:Panel>
    <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="bottom">
            支付名称:<asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox>
            <br />
            支付图标:<asp:FileUpload ID="fileEdit" runat="server" />
            <br />
            支付描述:<asp:TextBox ID="txtDescirptionEdit" runat="server" Height="60px" TextMode="MultiLine"
                Width="260px"></asp:TextBox>
            <asp:Button ID="BtEditOk" runat="server" CssClass="btn_white" OnClick="BtEditOk_Click"
                Text="确定修改" />
        </div>
        <br />
    </asp:Panel>
</asp:Content>
