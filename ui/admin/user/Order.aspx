<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="admin_user_Order" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
     <div>分类查看:<asp:DropDownList ID="ddlNewsType" runat="server" Height="20px" 
             Width="200px" AutoPostBack="True" 
             onselectedindexchanged="ddlNewsType_SelectedIndexChanged">
            </asp:DropDownList>
    </div>
     <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
        <table class="table">
        <tr class="tableHead">
        <td style="width:30px">选择</td>
        <td style="width:100px;">下单用户</td>
        <td style="width:150px;">订单号</td>
        <td style="width:150px;">下单时间</td>
        <td style="width:80px;">下单金额</td>
        <td style="width:90px;">订单状态</td>
        <td style="width:80px;">快递</td>
        <td style="width:80px;">支付</td>
        <td>备注</td>
        <td style="width:40px;">操作</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td class="td_select"><input id="chkId" type="checkbox" value='<%# Eval("orderC")%>' name="chkId" /></td>
        <td><%# Eval("userName").ToString()%></td>
        <td><%# Eval("orderC")%></a></td>
        <td><%# Eval("timeC") %></td> 
        <td><%# Eval("priceC") %></td>
        <td> <%# staValue.OrderType[int.Parse(Eval("typ").ToString())]%></td>
        <td><%# Eval("expName") %></td>
        <td><%# Eval("payName") %></td>
        <td><%# Eval("remarksC") %></td>
        <td>
          <a href='EditOrder.aspx?id=<%# Eval("orderC") %>'>编辑</a> 
        </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate></table>
    </FooterTemplate>
        </asp:Repeater>
         <div class="bottom">
       &nbsp;<input id="chkAll" type="checkbox"  />全选&nbsp;&nbsp;
        &nbsp;&nbsp;
    <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>&nbsp;&nbsp;
    <asp:DropDownList ID="dropEditOrder" runat="server">
            </asp:DropDownList>
          <asp:LinkButton ID="lbtnDisplay" runat="server" onclick="lbtnDisplay_Click">修改订单状态</asp:LinkButton>&nbsp;&nbsp;
           
          </div>
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CurrentPageButtonClass="page_current" CustomInfoClass="" 
            CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]" 
            CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" 
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" 
            NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageSize="20" 
            PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" 
            UrlPaging="false">
        </webdiyer:AspNetPager>
        <script type="text/javascript">
        checkAll("chkAll", ".td_select");
        </script>
</asp:Content>
