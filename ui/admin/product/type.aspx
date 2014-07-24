<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="type.aspx.cs" Inherits="admin_product_type" Title="无标题页" %>
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
    <td>产品类名</td>
   <%--<td>静态名称</td>--%>
   <td style="width:30px">数量</td>
    <%--<td style="width:30px;">推荐</td>--%>
    <td style="width:40px;">排序</td>
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
   <%--<td><%# Eval("htmlName") %></td>--%>
   <td class="center"><%# Eval("countC") %></td>
    <%--<td class="sort">
    <%# Eval("displayC").ToString()=="0"?"正常":"推荐"%></td>--%>
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
         <asp:LinkButton ID="LinkButton1" onclick="btnDel_Click" runat="server" Text="批量删除" />&nbsp;|&nbsp;
        <%--  <asp:LinkButton  ID="lbtnShow" runat="server" Text="推荐" 
            onclick="lbtnShow_Click" />&nbsp;|&nbsp;
                  <asp:LinkButton  ID="lbtnHidden" runat="server" Text="正常" 
            onclick="lbtnHidden_Click" />&nbsp;|&nbsp;--%>
            <asp:LinkButton  ID="LbAdd" runat="server" Text="添加类别" onclick="LbAdd_Click" />&nbsp;|&nbsp;
            <asp:LinkButton  ID="btnSave" runat="server" Text="保存操作" onclick="btnSave_Click" />&nbsp;|&nbsp;
            <asp:LinkButton  ID="btnUpdate" runat="server" Text="更新产品数" onclick="btnUpdate_Click"/>&nbsp;|&nbsp;
            <asp:LinkButton  ID="lbtnUpdateContain" runat="server" Text="更新类别包含" 
                  onclick="lbtnUpdateContain_Click"/>
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
        </webdiyer:AspNetPager></asp:Panel>
<asp:Panel ID="PanelAdd" runat="server" Visible="false">
   <ul class="ul">
   <li><div>所属分类:</div><asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></li>
    <li><div>菜单名称:</div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></li>
    <li><div>标题:</div><asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox></li>
    <li><div>关键词:</div><asp:TextBox ID="txtKeywords" runat="server" Width="200px"></asp:TextBox> <a href="#" onclick="allKey(this,'<%=txtKeywords.ClientID %>','getAllKey')">查看词库</a></li>
    <li><div>描述:</div><asp:TextBox ID="txtDescription" runat="server" Width="400px"></asp:TextBox></li>
   <li><div>静态名称:</div><asp:TextBox ID="txtHtmlName" runat="server"></asp:TextBox> <a href="#" onclick="htmlName(this,'<%=txtHtmlName.ClientID %>')">检测</a></li>
    <li><div>推荐图片:</div><asp:FileUpload ID="fileAdd" runat="server" />(尺寸:宽790px,高不限 描述背景图)</li>
    <li><div>顶部关键词:</div><asp:TextBox ID="txtTopKey" runat="server" TextMode="MultiLine" Width="400px" Height="60px"></asp:TextBox></li>
    </ul>
     <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
     <asp:TextBox ID="txtContent" class="ckeditor" TextMode="MultiLine"  runat="server"></asp:TextBox> 
    <div>&nbsp;<asp:Button ID="BtAddOk" runat="server" Text="添加" onclick="BtAddOk_Click" CssClass="btn_white" />
        <asp:Button ID="BtRep" runat="server" Text="分类查看" onclick="BtRep_Click"  CssClass="btn_white" /></div>
   
</asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <ul class="ul">
        <li><div>所属分类:</div><asp:DropDownList ID="dropType_edit" runat="server"></asp:DropDownList></li>
    <li><div>菜单名称:</div><asp:TextBox ID="txtName_edit" runat="server"></asp:TextBox></li>
    <li><div>标题:</div><asp:TextBox ID="txtTitle_edit" runat="server" Width="200px"></asp:TextBox></li>
    <li><div>关键词:</div><asp:TextBox ID="txtKeywords_edit" runat="server" Width="200px"></asp:TextBox> <a href="#" onclick="allKey(this,'<%=txtKeywords_edit.ClientID %>','getAllKey')">查看词库</a></li>
    <li><div>描述:</div><asp:TextBox ID="txtDescription_edit" runat="server" Width="400px"></asp:TextBox></li>
     <li><div>推荐图片:</div><asp:FileUpload ID="fileEdit" runat="server" />(尺寸:宽790px,高不限 描述背景图)</li>
   <li><div>静态名称:</div><asp:TextBox ID="txtHtmlName_edit" runat="server"></asp:TextBox> <a href="#" onclick="htmlName(this,'<%=txtHtmlName_edit.ClientID %>')">检测</a></li>
    <li><div>顶部关键词:</div><asp:TextBox ID="txtTopKey_edit" runat="server" TextMode="MultiLine" Width="400px" Height="60px"></asp:TextBox></li>
    
   </ul>
   <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
     <asp:TextBox ID="txtContent_edit" class="ckeditor" TextMode="MultiLine"  runat="server"></asp:TextBox> 
   
   <div>&nbsp;<asp:Button ID="BtEditOk" runat="server" Text="确定修改" onclick="BtEditOk_Click" CssClass="btn_white"  />
        <asp:Button ID="Button2" runat="server" Text="分类查看" onclick="BtRep_Click"  CssClass="btn_white" />
   </div>
    </asp:Panel>
  </asp:Content>
