<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="attrList.aspx.cs" Inherits="admin_product_attrList" %>
<%@ MasterType VirtualPath="~/admin/MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="panelList" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" >
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td style="width:150px">名称</td>
    <td>默认值</td>
    <td style="width:40px;">排序</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
    </td>
    <td><input type="text" name="nameC" value="<%# Eval("nameC") %>" /></td>
    <td><input type="text" name="valueC" value="<%# Eval("valueC") %>" style="width:500px" /></td>
    <td class="sort">
    <input type="text" name="sortC" value="<%# Eval("sortC") %>" />
    <input type="hidden" name="id" value="<%# Eval("id") %>" />
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
     <asp:Button ID="btnDel" runat="server" Text="批量删除" CssClass="btn_white" 
            onclick="btnDel_Click" />
        <asp:Button ID="btnSave" runat="server" Text="保存操作" CssClass="btn_white" 
            onclick="btnSave_Click" />
        <asp:Button ID="btnAdd" runat="server" Text="添加属性" CssClass="btn_white" 
            onclick="btnAdd_Click" />  删除属性花费时间比较长,建议尽量修改...
    </div>
</asp:Panel>
<asp:Panel ID="panelAdd" runat="server" Visible="false">
<ul class="ul">
<li><div>名称:</div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></li>
<li><div>默认值:</div><asp:TextBox ID="txtValue" Width="300px" runat="server"></asp:TextBox></li>
<li><div>&nbsp;</div><asp:Button ID="btnOk" runat="server" Text="添加" 
        CssClass="btn_white" onclick="btnOk_Click" />&nbsp;<asp:Button ID="btnBakc" 
        runat="server" Text="返回" 
        CssClass="btn_white" onclick="btnBakc_Click" /></li>
</ul>
</asp:Panel>
</asp:Content>


