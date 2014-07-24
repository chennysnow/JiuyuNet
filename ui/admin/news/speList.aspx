<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="speList.aspx.cs" Inherits="admin_news_speList" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server" >
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td>标题</td>
    <td style="width:100px">所属类别</td>
    <td style="width:120px">上传时间</td>
    <td style="width:30px;">操作</td>
    </tr>
    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><input id="chkId" type="checkbox" value='<%# Eval("id") %>' runat="server" />
    </td>
    <td style="text-align:left;"><%# Eval("nameC") %></td>
    <td><%#Eval("typS")%></td>
     <td><%# Eval("timeC") %></td>
   <td>
      <a class="a_backUrl" href="<%# getUrl(Eval("typS").ToString())+"?id="+Eval("id") %>">修改</a>        
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table><div class="bottom">&nbsp;
        </div></FooterTemplate>
    </asp:Repeater>
</asp:Content>