<%@ Page Language="C#"MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="link.aspx.cs" Inherits="admin_link" Title="无标题页" %>
<%@ MasterType VirtualPath="MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
 <asp:Panel ID="PanelRep" runat="server">
      分类查看:<asp:DropDownList ID="dropBin" runat="server" Width="200px" 
            AutoPostBack="True" onselectedindexchanged="dropBin_SelectedIndexChanged">
            <asp:ListItem Value="all">::全部::</asp:ListItem>
            <asp:ListItem Value="Rec">网站头部</asp:ListItem>
            <asp:ListItem Value="top">搜索推荐</asp:ListItem>
            <asp:ListItem Value="bottom">友情链接</asp:ListItem>
            </asp:DropDownList><br />
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td>选择</td>
    <td>网站名称</td>
    <td>网站地址</td>
    <td>所属类别</td>
    <td>操作</td>
    </tr>
    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input name="chkId" id="chkId" type="checkbox" value='<%# Eval("id") %>' />
    </td>
    <td><%# Eval("nameC")%></td>
    <td><%# Eval("urlC")%></td>
    <td><%# strTyp(Eval("typS").ToString())%></td>
   <td>
    <asp:LinkButton  ID="LinkButton1" CommandArgument='<%# Eval("id")%>' CommandName="edit" runat="server">修改</asp:LinkButton>       
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table>
   
    </FooterTemplate>
    </asp:Repeater>
     <div class="bottom">
     <input id="chkAll" type="checkbox"  />全选&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加链接</asp:LinkButton></div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CurrentPageButtonClass="page_current" CustomInfoClass="" 
            CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]" 
            CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" 
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" 
            NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageSize="15" 
            PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" 
            UrlPaging="false" Width="95%">
        </webdiyer:AspNetPager>
        <script type="text/javascript">
            checkAll("chkAll", ".td_select");
</script>
    </asp:Panel>
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
    <div class="tableHead">添加链接</div>
        链接分类:<asp:DropDownList ID="dropType" runat="server" Width="200px">
            <asp:ListItem Value="Rec">网站头部</asp:ListItem>
            <asp:ListItem Value="top">搜索推荐</asp:ListItem>
            <asp:ListItem Value="bottom">友情链接</asp:ListItem>
        </asp:DropDownList><br />
        网站名称:<asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox><br />
         网站地址:<asp:TextBox ID="txtUrl" runat="server" Width="200px"></asp:TextBox><br />
         网站logo:<asp:FileUpload ID="fileShuiYin" runat="server" /><br />
        <asp:Button ID="BtAddOk" runat="server" Text="添加" onclick="BtAddOk_Click" CssClass="Btn"  />
        <asp:Button ID="BtRep" runat="server" Text="查看所有" onclick="BtRep_Click" CssClass="Btn"  /></asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="tableHead">修改链接</div>
            链 接 分 类:<asp:DropDownList ID="dropTypeEdit" runat="server" Width="200px">
             <asp:ListItem Value="Rec">网站头部</asp:ListItem>
            <asp:ListItem Value="top">搜索推荐</asp:ListItem>
            <asp:ListItem Value="bottom">友情链接</asp:ListItem>
            </asp:DropDownList><br />
        修改网站名称:<asp:TextBox ID="txtNameEdit" runat="server" Width="200px"></asp:TextBox><br />
        修改网站地址:<asp:TextBox ID="txtUrlEdit" runat="server" Width="200px"></asp:TextBox><br />
        网站logo:<asp:FileUpload ID="fuLogoEdit" runat="server" /><br /><input type="hidden" id="hiLogo" runat="server" />
        <asp:Button ID="BtEditOk" runat="server" Text="确定修改" onclick="BtEditOk_Click" CssClass="Btn"  />
    </asp:Panel>

</asp:Content>
