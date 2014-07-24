<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="order.aspx.cs" Inherits="user_order" %>

<%@ Register Src="menu.ascx" TagName="menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/user.css" rel="stylesheet" type="text/css" />
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="indexLeft">
        <uc1:menu ID="menu1" runat="server" />
    </div>
    <div class="indexRight">
        <form id="form1" runat="server">
        <asp:Panel ID="panelList" runat="server">
        <div class="right_head"><span>Order</span></div>
         <h3>&nbsp;&nbsp;Manage your information, <font color="#aa0000">orders</font></h3>
            <asp:Repeater ID="repProInfo" runat="server" OnItemCommand="repProInfo_ItemCommand"
                OnItemDataBound="repProInfo_ItemDataBound">
                <HeaderTemplate>
                    <table class="repTable" cellpadding="0" cellspacing="0">
                        <tr class="repTableHead">
                            <td>
                                No.
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                Price
                            </td>
                            <td>
                                Status
                            </td>
                            <td>
                                Operation
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
                            <%# staValue.OrderType[int.Parse(Eval("typ").ToString())]%><input type="hidden" runat="server"
                                id="typ" value='<%# Eval("typ") %>' />
                        </td>
                        <td>
                            <asp:ImageButton ID="LinkButton1" CommandArgument='<%# Eval("orderC") %>' CommandName="see"
                                runat="server" ImageUrl="~/images/detailed.gif" ToolTip="查看详情" />
                            <asp:ImageButton ID="lbtnDel" CommandArgument='<%# Eval("orderC") %>' CommandName="del"
                                runat="server" ImageUrl="~/images/del.gif" ToolTip="删除" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonClass="page_current"
                CustomInfoClass="" CustomInfoHTML="RecCount[%RecordCount%]  PageIndex/PageCount[%CurrentPageIndex%/%PageCount%]"
                CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" HorizontalAlign="Right"
                LastPageText="末页" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
                PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left"
                ShowPageIndexBox="Always" SubmitButtonText="Go" Width="95%">
            </webdiyer:AspNetPager>
        </asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">



         <div class="Head">商品列表:</div>
    <asp:Repeater ID="repOrderItem" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" cellpadding="0" class="repTable">
                <tbody>
                    <tr class="repTableHead">
                          <td>
                  商品
                </td>
                        <td>
                            名称
                        </td>
                        <td>
                            属性
                        </td>
                            <td>
                           数量
                        </td>
                        <td>
                            单价
                        </td>
                        <td>
                            折扣价
                        </td>
                    
                        <td>
                            总价
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
               <td>
                    <a href="/proShow.aspx?id=<%# Eval("ProductId") %>" target="_blank" title="<%# Eval("ProductName") %>">
                        <img src="<%# Eval("ProImgURL") %>" width="40" alt="<%# Eval("ProductName") %>" /></a>
                </td>
                <td>
                    
                        <%# Eval("ProductName")%>
              
                </td>
                <td>
                    <%# Eval("ProductNO")%>
                </td>
                <td><%# Eval("Quantity")%></td>
                <td>
                    $<%# Eval("UnitPrice")%></td>
                <td>
                    $<%# Eval("DisPrice")%>
                </td>
                
                <td>$<%# Eval("TotalAmount")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>

    <div class="Head" ><div style=" float:right; padding-right:25px;">Shipping Price: <span class="red"><asp:Literal ID="litExpPrice" runat="server"></asp:Literal></span> Products Price: <span class="red"><asp:Literal ID="litProPrice" runat="server"></asp:Literal></span> Grand-Total: <span class="red"><asp:Literal ID="litTotalPrice" runat="server"></asp:Literal></span></div></div>
   
   
   
    <div class="Head">送货信息:</div>
    <ul class="ulInfo">
                   <li><div>快递号:</div><asp:Literal ID="litExpNum" runat="server"></asp:Literal></li>
            <li><div>发货时间:</div><asp:Literal ID="kutExpTime" runat="server"></asp:Literal></li>
        <li><div>姓名:</div><asp:Literal ID="litExpName" runat="server"></asp:Literal></li>
        <li><div>电话:</div><asp:Literal ID="litExpTel" runat="server"></asp:Literal></li>
        
        <li><div>国家:</div><asp:Literal ID="litExpCountry" runat="server"></asp:Literal></li>
        <li><div>详细地址:</div><asp:Literal ID="litExpAddress" runat="server"></asp:Literal></li>
         <li><div>E-mail:</div><asp:Literal ID="litEmail" runat="server"></asp:Literal></li>
            <li><div>快递方式:</div><asp:Literal ID="litExpType" runat="server"></asp:Literal></li>
     </ul>


         
<%--    <ul class="ulInfo">
                   <li><div>Shipping Price:</div><asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
            <li><div>Products Price:</div><asp:Literal ID="Literal2" runat="server"></asp:Literal></li>
            <li><div>Grand-Total:</div><asp:Literal ID="Literal3" runat="server"></asp:Literal></li>
            </ul>
          
            <asp:Literal runat="server" ID="liTotalInfo"></asp:Literal>--%>
            <div class="total_3 clear">
                <div>
                    Remarks:<asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" MaxLength="255"
                        Height="50px" Width="400px"></asp:TextBox>
                    <div>
          <%--              Shipping Num:<asp:Literal ID="liExpressNum" runat="server"></asp:Literal>
                        Shipping Time:<asp:Literal ID="liPostTime" runat="server"></asp:Literal>--%>
                        <br />
                        <input type="hidden" id="orderId" runat="server" />
                        <asp:Panel ID="editPanel" runat="server">
                            <div class="center">
                                <asp:Button ID="btn_editOrder" runat="server" CssClass="btn_blue" Text="Submit" OnClick="btn_editOrder_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </asp:Panel>
        </form>
    </div>
</asp:Content>
