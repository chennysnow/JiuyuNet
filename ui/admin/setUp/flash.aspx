<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="flash.aspx.cs" Inherits="admin_flash" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="PanelRep" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
    <td style="width:30px;">选择</td>
    <td style="width:100px">图片</td>
    <td>标题</td>
    <td>链接</td>
    <td style="width:70px">类型</td>
    <td style="width:70px">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
    </td>
    <td><img src="<%# Eval("typS").ToString()=="file"?"/uploadFile/wu.jpg\"":Eval("imgC").ToString()+"\"width=\"100\""%>  /></td>
    <td><%# Eval("nameC")%></td>
    <td><%# Eval("urlC")%></td>
    <td><%# Eval("typS") %></td>
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
    <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加记录</asp:LinkButton></div>
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
    <div class="tableHead">添加图片</div>
        <table class="style1">
        <tr>
                <td class="style2">
                    类别:</td>
                <td>
                    <asp:DropDownList ID="dropAdd" runat="server">
                    <asp:ListItem Value="flash">主页切换</asp:ListItem>
                    <asp:ListItem Value="indexImg">主页图片</asp:ListItem>
                    <asp:ListItem Value="baner">主页banner</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    标题:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                   链接1:</td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style2">
                   链接2:</td>
                <td>
                    <asp:TextBox ID="txtUrl2" runat="server"></asp:TextBox> 主页图片才有链接2,其它则不填此项
                </td>
            </tr>
            <tr>
                <td class="style2">
                    </td>
                <td>
                    <asp:FileUpload ID="fileAdd" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtAddOk" runat="server" CssClass="Btn" onclick="BtAddOk_Click" 
                        Text="添加" />
                    <asp:Button ID="BtRep" runat="server" CssClass="Btn" onclick="BtRep_Click" 
                        Text="查看所有" />
                </td>
            </tr>
        </table>
        <div><br /> 主页(980*340) 主页图片(320*225)</div>
        <br />
        </asp:Panel>
        <asp:Panel ID="panelEdit" runat="server" Visible="false">
        <div class="tableHead">修改图片信息</div>
        <table class="style1">
        <tr>
                <td class="style2">
                    类别:</td>
                <td>
                    <asp:DropDownList ID="dropEdit" runat="server">
                    <asp:ListItem Value="flash">主页切换</asp:ListItem>
                    <asp:ListItem Value="indexImg">主页图片</asp:ListItem>
                    <asp:ListItem Value="baner">主页banner</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
                <tr>
                    <td class="style2">
                         修改标题:</td>
                    <td>
                        <asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                       链接1:</td>
                    <td>
                        <asp:TextBox ID="txtUrlEdit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                <td class="style2">
                   链接2:</td>
                <td>
                    <asp:TextBox ID="txtUrlEdit2" runat="server"></asp:TextBox> 主页图片才有链接2,其它则不填此项
                </td>
            </tr>
                <tr>
                    <td class="style2">
                       </td>
                    <td>
                        <asp:FileUpload ID="fileAddEdit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="BtEditOk" runat="server" CssClass="Btn" 
                            onclick="BtEditOk_Click" Text="确定修改" />
                    </td>
                </tr>
            </table>
            <div><br /> 主页(980*340) 主页图片(320*225)</div>
            <br />
    </asp:Panel>
</asp:Content>