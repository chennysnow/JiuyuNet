<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_supply_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
 
    <asp:Panel ID="panelList" runat="server">
   
    <asp:Repeater ID="Repeater1" runat="server"  >
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td style="width:400px;">供应商名称</td>
    <td style="width:100px">联系人<datalist>
    <td style="width:100px">电话</td>
    <td style="width:100px;">邮箱</td>
    <td style="width:60px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
    </td>
    <td><%# Eval("sname") %>" </td>
    <td><%# Eval("contactus")%></td>
    <td class="sort">
  <%# Eval("phone") %>"
  
    </td>
    <td><%# Eval("mail")%> </td>
    <td><a href="edit.aspx?id=<%# Eval("id") %>">修改</a>      </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
    <asp:LinkButton ID="btnDel" Text="批量删除" onclick="btnDel_Click" runat="server" />&nbsp;|&nbsp;
  
 
    </div>
     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CurrentPageButtonClass="page_current" CustomInfoClass="" 
            CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]" 
            CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" 
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" 
            NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageSize="20" 
            PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" 
            UrlPaging="false" Width="95%">
        </webdiyer:AspNetPager>
</asp:Panel>
</asp:Content>

