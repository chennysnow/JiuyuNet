<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_news_list" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="h">
    <div>分类查看:<asp:DropDownList ID="ddlNewsType" runat="server" Height="20px" 
            Width="200px" AutoPostBack="True" 
            onselectedindexchanged="ddlNewsType_SelectedIndexChanged">
</asp:DropDownList>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" >
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td>标题</td>
    <td>类别</td>
    <td style="width:40px;">显示</td>
    <td style="width:40px;">排序</td>
    <td style="width:40px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
    </td>
    <td style="text-align:left;"><a href="/newShow.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("nameC") %></a></td>
    <td><%# menu.getString("nameC","where id="+Eval("typ").ToString()) %></td>
    <td class="sort"><%# Eval("showC").ToString()=="0"?"隐藏":"显示" %></td>
    <td class="sort">
    <input type="text" name="sort" value="<%# Eval("sortC") %>" />
    <input type="hidden" name="id" value="<%# Eval("id") %>" />
    </td>
   <td>
      <a class="a_backUrl" href='Edit.aspx?id=<%# Eval("id") %>'>修改</a>         
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
    <input id="chkAll" type="checkbox"  />全选&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>&nbsp;|&nbsp;
     <asp:LinkButton  ID="lbtnShow" runat="server" Text="显示" 
            onclick="lbtnShow_Click" />&nbsp;|&nbsp;
                  <asp:LinkButton  ID="lbtnHidden" runat="server" Text="隐藏" 
            onclick="lbtnHidden_Click" />&nbsp;|&nbsp;
        <a href="add.aspx">添加新闻</a>&nbsp;|&nbsp;<asp:Button ID="btnSave" runat="server" Text="保存操作" OnClick="btnSave_Click" CssClass="Btn" /></div>
           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CurrentPageButtonClass="page_current" CustomInfoClass="" 
            CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]" 
            CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" 
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" 
            NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageSize="18" 
            PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" 
            UrlPaging="false" Width="95%">
        </webdiyer:AspNetPager></div>
        <script type="text/javascript">
        checkAll("chkAll", ".td_select");
</script>
</asp:Content>
