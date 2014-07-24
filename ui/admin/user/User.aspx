<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="admin_user_User" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1 { width: 500px; 
                  margin:0 auto;
                  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<asp:Panel ID="panelRep" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td>用户名</td>
    <td>姓名</td>
    <td>电话</td>
    <td>地址</td>
    <td>注册时间</td>
    <td style="width:40px">状态</td>
    <td style="width:60px">消费金额</td>
    <td style="width:40px">折扣</td>
   <%-- <td>权限</td>--%>
    <td style="width:40px;">操作</td>
    <td style="width:40px;">订单</td>
    </tr>
    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input type="checkbox" value="<%# Eval("id") %>" name="chkId" />
    </td>
    <td style="text-align:left;"><%# Eval("userName") %></td>
    <td><%# Eval("nameC") %></td>
    <td><%# Eval("telC") %></td>
    <td><%# Eval("addressC") %></td>
    <td><%# Eval("timeC") %></td>
    <td><%# Eval("typ").ToString()=="1"?"审核":"普通" %></td>
    <td>$<%# Eval("integralC") %></td>
    <td class="sort"><input type="text" name="discount" value="<%# Eval("levelC") %>" /><input type="hidden" name="id" value="<%# Eval("id") %>" /></td>
   <%-- <td><%# Eval("typ").ToString()=="0"?"普通":"会员" %></td>--%>
   <td>
       <asp:LinkButton  ID="lbtnEdit" CommandArgument='<%# Eval("id") %>' CommandName="edit" runat="server">修改</asp:LinkButton> 
    </td>
    <td><a href="Order.aspx?user=<%# Eval("userName") %>">详情</a></td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
      &nbsp;<input id="chkAll" type="checkbox"  />全选&nbsp;|&nbsp;
    <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>
    &nbsp;|&nbsp;
    <asp:LinkButton ID="lbtnUser1" runat="server" onclick="lbtnUser1_Click">审核会员</asp:LinkButton>
    &nbsp;|&nbsp;
    <asp:LinkButton ID="lbtnUser0" runat="server" onclick="lbtnUser0_Click">普通会员</asp:LinkButton>
    &nbsp;|&nbsp;
    <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存折扣</asp:LinkButton>
</div>
  <script type="text/javascript">
        checkAll("chkAll", ".td_select");
</script>
</asp:Panel>
<asp:Panel ID="panelEdit" runat="server" Visible="false">
    <table class="style1">
   <%-- <tr>
            <td>
                权限:</td>
            <td>
               <asp:DropDownList ID="dropUser" runat="server">
               <asp:ListItem Value="0">普通</asp:ListItem>
               <asp:ListItem Value="2">会员</asp:ListItem>
               </asp:DropDownList></td>
        </tr>--%>
        <tr>
            <td>
                用户名:</td>
            <td>
               <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                密码:</td>
            <td>
                 <asp:TextBox ID="txtPasswords" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                姓名:</td>
            <td>
                 <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                电话:</td>
            <td>
                 <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                地址:</td>
            <td>
                 <asp:TextBox ID="txtAddress" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                用户备注:</td>
            <td>
                 <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="确定"  CssClass="btn_white"/>&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="查看所有" CssClass="btn_white" onclick="btnBack_Click" />
            </td>
        </tr>
    </table>

</asp:Panel>
</asp:Content>