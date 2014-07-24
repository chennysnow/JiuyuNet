<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="admin_news_Search" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

.table
{
	width:80%;
	background-color:#F2F2F2;
	}
.tableHead
{
	background-color:#EBEBEB;
	width:90%;
	}
a:link
{
	text-decoration: none;
	font-family:宋体;
	color:black;
	font-size:10pt;
	
}
    </style>
      <asp:Panel ID="PanelRep" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td>选择</td>
    <td>关键词</td>
    <td>点击次数</td>
    <td>操作</td>
    </tr>
    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><input id="chkId" type="checkbox" value='<%# Eval("id") %>' runat="server" />
    </td>
    <td><%# Eval("nameC")%></td>
    <td><%# Eval("countC")%></td>
   <td>
    <asp:LinkButton  ID="LinkButton1" CommandArgument='<%# Eval("id")%>' CommandName="edit" runat="server">修改</asp:LinkButton>
      <asp:LinkButton  ID="lbtnDel" CommandArgument='<%# Eval("id") %>' CommandName="del" runat="server">删除</asp:LinkButton>         
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table><div>

    </FooterTemplate>
    </asp:Repeater>
    <div class="Operation_bottom">
        <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加关键词</asp:LinkButton>
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
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
    <div class="tableHead">添加关键词</div>
        关键词:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        初始值:<asp:TextBox ID="txtCrt" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"></asp:TextBox><br />
        <asp:Button ID="BtAddOk" runat="server" Text="添加" onclick="BtAddOk_Click" CssClass="Btn"  />
        <asp:Button ID="BtRep" runat="server" Text="查看所有" onclick="BtRep_Click" CssClass="Btn"  /></asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="tableHead">修改关键词</div>
        修改关键词:<asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox><br />
        修改初始值:<asp:TextBox ID="txtCrtEdit" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"></asp:TextBox><br />
        <asp:Button ID="BtEditOk" runat="server" Text="确定修改" onclick="BtEditOk_Click" CssClass="Btn"  />
    </asp:Panel>
</asp:Content>
