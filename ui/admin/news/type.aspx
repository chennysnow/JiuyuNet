<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="type.aspx.cs" Inherits="admin_news_type" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="PanelRep" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px">选择</td>
    <td style="width:30px">级别</td>
    <td>类名</td>
    <td style="width:40px;">推荐</td>
    <%--<td style="width:120px;">静态名称</td>--%>
    <td style="width:50px;">排序</td>
    <td style="width:40px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
     <td class="td_select">
                    <input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
                </td>
              
    <td class="center"><%# Eval("levelC") %></td>
    <td style="text-align:left"><%# Eval("nameC") %></td>
     <td><%# Eval("displayC").ToString()=="1"?"主导航":Eval("displayC").ToString()=="2"?"底部":"正常" %></td>
  <%-- <td><%# Eval("htmlName") %></td>--%>
    <%-- <td>
    <select name="display" >
    <option value="0" >否</option>
     <option value='1' <%# Eval("displayC").ToString() == "1"?"selected='selected'":"" %>>是</option>
    </select></td>--%>
    <td class="sort">
        <input type="text" name="sort" value="<%# Eval("sortC") %>" /> 
        <input type="hidden" name="id" value="<%# Eval("id") %>" />
    </td>
   <td>
   <asp:LinkButton ID="lbtnEdit" CommandArgument='<%# Eval("id")%>' CommandName="edi" runat="server">修改</asp:LinkButton>         
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
          <div class="bottom">
          &nbsp;<input id="chkAll" type="checkbox" />全选&nbsp;|&nbsp;
          <asp:LinkButton ID="LinkButton1" onclick="btnDel_Click" runat="server" Text="批量删除" />
          &nbsp;|&nbsp;
          <asp:LinkButton ID="lbtnTopShow" runat="server" Text="主导航显示" 
                  onclick="lbtnTopShow_Click"  />&nbsp;|&nbsp;
          <asp:LinkButton ID="lbtnBottomShow" runat="server" Text="底部显示" 
                  onclick="lbtnBottomShow_Click" />&nbsp;|&nbsp;
          <asp:LinkButton ID="ltbnNormalShow" runat="server" Text="正常显示" 
                  onclick="ltbnNormalShow_Click" />&nbsp;|&nbsp;
            <asp:LinkButton  ID="LbAdd" runat="server" Text="添加类别" onclick="LbAdd_Click" />&nbsp;|&nbsp;
            <asp:LinkButton  ID="btnSave" runat="server" Text="保存操作" onclick="btnSave_Click" />&nbsp;|&nbsp;
            </div>
          <script type="text/javascript">
              checkAll("chkAll", ".td_select");
          </script>
          </asp:Panel>
<asp:Panel ID="PanelAdd" runat="server" Visible="false">
   <ul class="ul">
   <li><div>所属分类:</div><asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></li>
    <li><div>菜单名称:</div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></li>
    <li><div>标题:</div><asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox></li>
    <li><div>关键词:</div><asp:TextBox ID="txtKeywords" runat="server" Width="200px"></asp:TextBox> <a href="#" onclick="allKey(this,'<%=txtKeywords.ClientID %>','getAllKey')">查看词库</a></li>
    <li><div>描述:</div><asp:TextBox ID="txtDescription" runat="server" Width="400px"></asp:TextBox></li>
    <%--<li><div>静态名称:</div><asp:TextBox ID="txtHtmlName" runat="server"></asp:TextBox> <a href="#" onclick="htmlName(this,'<%=txtHtmlName.ClientID %>')">检测</a></li>--%>
    <li><div>&nbsp;</div><asp:Button ID="BtAddOk" runat="server" Text="添加" onclick="BtAddOk_Click" CssClass="btn_white" />
        <asp:Button ID="BtRep" runat="server" Text="分类查看" onclick="BtRep_Click"  CssClass="btn_white" /></li>
   </ul>
</asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <ul class="ul">
        <li><div>所属分类:</div><asp:DropDownList ID="dropType_edit" runat="server"></asp:DropDownList></li>
   <li><div>菜单名称:</div><asp:TextBox ID="txtName_edit" runat="server"></asp:TextBox></li>

    <li><div>标题:</div><asp:TextBox ID="txtTitle_edit" runat="server" Width="200px"></asp:TextBox></li>
    <li><div>关键词:</div><asp:TextBox ID="txtKeywords_edit" runat="server" Width="200px"></asp:TextBox> <a href="#" onclick="allKey(this,'<%=txtKeywords_edit.ClientID %>','getAllKey')">查看词库</a></li>
    <li><div>描述:</div><asp:TextBox ID="txtDescription_edit" runat="server" Width="400px"></asp:TextBox></li>
    <%--<li><div>静态名称:</div><asp:TextBox ID="txtHtmlName_edit" runat="server"></asp:TextBox> <a href="#" onclick="htmlName(this,'<%=txtHtmlName_edit.ClientID %>')">检测</a></li>--%>
    <li><div>&nbsp;</div><asp:Button ID="BtEditOk" runat="server" Text="确定修改" onclick="BtEditOk_Click" CssClass="btn_white"  />
        <asp:Button ID="Button2" runat="server" Text="分类查看" onclick="BtRep_Click"  CssClass="btn_white" /></li>
   </ul>
    </asp:Panel>
  </asp:Content>
