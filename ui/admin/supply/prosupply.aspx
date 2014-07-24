<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="prosupply.aspx.cs" Inherits="admin_supply_prosupply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="panelList" runat="server">
        <asp:DropDownList ID="dropList" runat="server" AutoPostBack="True" 
            onselectedindexchanged="dropList_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">::全部属性::</asp:ListItem>
        </asp:DropDownList>
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" >
        <HeaderTemplate>
            <table class="table">
                <tr class="tableHead">
                  
                    <td style="width: 50px;">
                        商品
                    </td>
                    <td style="text-align: left">
                        商品名称
                    </td>
                    <td>商品编号</td>
                  
                    <td style="width:50px;">
                        销量
                    </td>
                   
                     <td style="width:50px;">
                        库存
                    </td>
                    <td style="width:50px;">
                        进货价
                    </td>
                    
                 
                  
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
              
                <td>
                    <a href="/proShow.aspx?id=<%# Eval("id") %>" target="_blank" title="<%# Eval("nameC") %>">
                        <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" width="40" height="40" /></a>
                </td>
                <td style="text-align: left;">
                    <%# Eval("nameC") %>
                </td>
                <td style="text-align: left;">
                    <%# Eval("proId") %>
                </td>
              
                <td><%# Eval("sellCount") %></td>
               
                <td class="sort">
                    <input name="stockC" value="<%# Eval("stockC") %>"/></td>
                <td class="sort">
                    <input name="priceC" value="<%# Eval("priceC") %>"/></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
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

