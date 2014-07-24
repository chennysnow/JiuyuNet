<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="admin_Message" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="panelRep" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td style="width:40px;">产品</td>
    <td>留言内容</td>
    <td>留言人</td>
    <td>地址</td>
    <td>Mail</td>
    <td style="width:120px;">留言时间</td>
    <td style="width:40px;">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
    </td>
    <td><img src="<%# Eval("typ").ToString()=="0"?"/uploadFile/wu.jpg":Eval("product").ToString() %>" height="40" width="40" /></td>
    <td><%# ope.Strsub(Eval("contentC").ToString(), 20)%></td>
    <td><%# Eval("nameC") %></td>
    <td><%# ope.Strsub(Eval("addressC").ToString(), 20)%></td>
    <td><%# Eval("mailC") %></td>
     <td><%# Eval("timeC") %></td>
   <td>
       <asp:LinkButton  ID="LbtSee" CommandArgument='<%# Eval("id") %>' CommandName="see" runat="server">查看</asp:LinkButton>      
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table>
       </FooterTemplate>
    </asp:Repeater> 
    <div class="bottom"> &nbsp;<input id="chkAll" type="checkbox"  />全选&nbsp;&nbsp;<asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">批量删除</asp:LinkButton>
      <script type="text/javascript">
           checkAll("chkAll", ".td_select");
        </script>
    
    </div>
           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CurrentPageButtonClass="page_current" CustomInfoClass="" 
            CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]" 
            CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" 
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" 
            NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged" PageSize="10" 
            PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left" 
            ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" 
            UrlPaging="false" Width="95%">
        </webdiyer:AspNetPager>
        </asp:Panel>
    <asp:Panel ID="panelSee" runat="server" Visible="false" Width="100%" >
      <ul id="ulmessage_1">
        <li>
            留言内容：
            <asp:TextBox ID="TbContent" runat="server" Height="80px" TextMode="MultiLine" 
                Width="400px" ReadOnly="True"></asp:TextBox>               
            <asp:Image ID="Image1" runat="server" height="80" width="80" Visible="false"  /></li>
               
           <li>留言人： 
              <asp:Label ID="LbPeople" runat="server" Text=""></asp:Label>
              <span style="margin-left:30px"></span></li>
          <li>地址： 
              <asp:Label ID="LbAddress" runat="server" Text=""></asp:Label>
          </li>
           <li>Ip： 
              <asp:Label ID="lbIp" runat="server" Text=""></asp:Label>
              <span style="margin-left:30px"></span></li>
          <li>联系电话： 
              <asp:Label ID="LbTel" runat="server" Text=""></asp:Label>
              <span style="margin-left:30px;"></span></li>
          <li>E-mail： 
              <asp:Label ID="LbEmail" runat="server" Text=""></asp:Label>
          </li>
          <li>时间： 
              <asp:Label ID="lbTime" runat="server" Text=""></asp:Label>
          </li>
          <li>
              <asp:Button ID="BtnDispalyNone" runat="server" CssClass="Btn" 
                  onclick="BtnDispalyNone_Click" Text="隐藏" />
          </li>
     </ul>
     </asp:Panel>
</asp:Content>
