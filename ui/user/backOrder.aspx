<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="backOrder.aspx.cs" Inherits="user_backOrder" %>

<%@ Register Src="menu.ascx" TagName="menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/user.css" rel="stylesheet" type="text/css" />
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
    <script src="/js/JsVido.js" type="text/javascript" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="indexLeft">
        <uc1:menu ID="menu1" runat="server" />
    </div>
    <div class="indexRight">
        <div class="right_head">
            退货申请</div>
        <div class="border">
            <form id="form1" runat="server">
            <asp:Repeater ID="repRetrunOrder" runat="server" OnItemCommand="repRetrunOrder_ItemCommand">
                <HeaderTemplate>
                    <table class="repTable" cellpadding="0" cellspacing="0">
                        <tr class="repTableHead">
                            <td>
                                订单名
                            </td>
                            <td>
                                时间
                            </td>
                            <td>
                                价格
                            </td>
                            <td>
                                状态
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("orderC")%>
                        </td>
                        <td>
                            <%# Eval("timeC") %>
                        </td>
                        <td>
                            <%# Eval("priceC") %>
                        </td>
                        <td>
                            <%# staValue.retOrder[int.Parse(Eval("typ").ToString())]%>
                        </td>
                        <td>
                            <asp:ImageButton ID="LinkButton1" CommandArgument='<%# Eval("id") %>' CommandName="see"
                                runat="server" ImageUrl="~/images/detailed.gif" ToolTip="查看详情" />
                            <asp:ImageButton ID="lbtnDel" CommandArgument='<%# Eval("id") %>' CommandName="del"
                                runat="server" ImageUrl="~/images/del.gif" ToolTip="删除" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
            <hr />
            <ul class="ul">
                <li>
                    <div>
                        订单号:</div>
                    <asp:DropDownList ID="dropListBack" runat="server">
                    </asp:DropDownList>
                </li>
                <li>
                    <div>
                        退款金额:</div>
                    <asp:TextBox ID="txtPrice_return" runat="server"></asp:TextBox></li>
                <li>
                    <div>
                        退货方式:</div>
                    <asp:TextBox ID="txtMethod" runat="server" TextMode="SingleLine" Height="30px" Width="400px"></asp:TextBox></li>
                <li>
                    <div>
                        退货原因:</div>
                    <asp:TextBox ID="txtReason" runat="server" TextMode="SingleLine" Height="40px" Width="400px"></asp:TextBox></li>
                <li>
                    <div>
                        退货清单:</div>
                    <asp:TextBox ID="txtProList_return" runat="server" TextMode="SingleLine" Height="50px"
                        Width="400px"></asp:TextBox></li>
                <li>
                    <div>
                        备注:</div>
                    <asp:TextBox ID="txtMessage_return" runat="server" TextMode="SingleLine" Height="60px"
                        Width="400px"></asp:TextBox></li>
                <li>
                    <div>
                        验证码:</div>
                    <asp:TextBox ID="txtCode_return" runat="server" Width="80px" EnableViewState="false"></asp:TextBox>
                    <img src="/ajax/validate.ashx?count=5" border="0" align="absmiddle" id="Img1" style="cursor: pointer;
                        vertical-align: middle; margin-top: -2px;" onclick="this.src='/ajax/validate.ashx?count=5&t=' + new Date().getTime()" />
                </li>
                <li>
                    <div>
                        &nbsp;</div>
                    <asp:Button ID="btnOk_return" runat="server" Text="确认提交" OnClick="btnOk_return_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClear_return" runat="server" Text="清空" OnClick="btnClear_return_Click" />
                    <asp:Label ID="lbId_return" runat="server" Visible="false"></asp:Label>
                </li>
            </ul>
            </form>
        </div>
    </div>
</asp:Content>
