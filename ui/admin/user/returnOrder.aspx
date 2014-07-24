<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="returnOrder.aspx.cs" Inherits="admin_user_returnOrder" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<asp:DropDownList ID="dropType" runat="server" Width="160px" AutoPostBack="True" 
        onselectedindexchanged="dropType_SelectedIndexChanged"></asp:DropDownList>
  <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
        <table class="table">
        <tr class="tableHead">
        <td style="width:30px">选择</td>
        <td style="width:100px;">用户</td>
        <td style="width:120px;">订单号</td>
        <td style="width:150px;">时间</td>
        <td style="width:50px;">金额</td>
        <td>原因</td>
        <td style="width:50px;">状态</td>
        <td style="width:40px;">操作</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td class="td_select"><input id="chkId" type="checkbox" value='<%# Eval("id")%>' name="chkId" /></td>
        <td><%# Eval("userName").ToString()%></td>
        <td><%# Eval("orderC")%></a></td>
        <td><%# Eval("timeC") %></td> 
        <td><%# Eval("priceC") %></td>
        <td><%# Eval("reasonC") %></td>
        <td> <%# staValue.retOrder[int.Parse(Eval("typ").ToString())]%></td>
        <td>
          <a href='editRetOrder.aspx?id=<%# Eval("id") %>'>编辑</a> 
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

