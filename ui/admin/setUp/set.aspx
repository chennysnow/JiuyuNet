<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="set.aspx.cs" Inherits="admin_setUp_set" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <table class="tableAdd">
            <tr>
                <td class="style1">
                    站点网址:</td>
                <td class="style3">
                   <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    公司名称:</td>
                <td class="style3">
                   <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <%-- <tr>
                <td class="style1">
                    后台管理路径:</td>
                <td class="style3">
                   <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox>
                </td>
            </tr>--%>
             <tr>
                <td class="style1">
                    产品缩略图(宽):</td>
                <td class="style3">
                   <asp:TextBox ID="txtImgWidth" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    产品缩略图(高):</td>
                <td class="style3">
                   <asp:TextBox ID="txtImgHeight" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    产品每页显示:</td>
                <td class="style3">
                   <asp:TextBox ID="txtPageSize" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
             <tr>
                <td class="style1">
                   文章每页显示:</td>
                <td class="style3">
                   <asp:TextBox ID="txtNewsSize" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
                <tr>
                <td class="style1">
                   库存报警数量:</td>
                <td class="style3">
                   <asp:TextBox ID="txtStockAlarm" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
             <tr>
                <td colspan="3">
                <h3>水印设置</h3>
                </td>
            </tr>
             <tr>
                <td class="style1">
                   水印图片:
                   </td>
                <td style="style3">
                    <asp:FileUpload ID="fileShuiYin" runat="server" />
                  <img src="/images/shuiYin.png" width="100px"/>(.png)</td>
            </tr>
               <%-- <tr>
                <td class="style1">
                   库存报警数量:</td>
                <td class="style3">
                   <asp:TextBox ID="txtStockAlarm" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>--%>
               <tr>
                <td colspan="3">
                <h3>邮件设置</h3>
                </td>
            </tr>
               <tr>
                <td class="style1">
                   Smtp服务器:</td>
                <td class="style3">
                   <asp:TextBox ID="txtSmtpServer" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="style1">
                   发送邮箱:</td>
                <td class="style3">
                   <asp:TextBox ID="txtSmtpMail" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="style1">
                   邮箱密码:</td>
                <td class="style3">
                   <asp:TextBox ID="txtSmtpPassword"  runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="style1">
                   端口号:</td>
                <td class="style3">
                   <asp:TextBox ID="txtSmtpPort" runat="server"></asp:TextBox><font color="red">只能是数字</font>
                </td>
            </tr>
              <tr>
                <td class="style1">
                   接收邮箱:</td>
                <td class="style3">
                   <asp:TextBox ID="txtReceiveMail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    在线聊天:</td>
                <td class="style3">
                    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
                       <asp:TextBox ID="txtOnline" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox> 
                </td>
            </tr>
              <tr>
                <td class="style1">
                    网站底部:</td>
                <td class="style3">
                       <asp:TextBox ID="txtBottom" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox> 
                </td>
            </tr>
                 <tr>
                <td class="style1">
                    </td>
                <td class="style3">
                <div class="center">
                <asp:Button ID="btnOk" runat="server" CssClass="btn_white" Text="保存" 
                        onclick="btnOk_Click" />
                </div>
                </td>
            </tr>
            </table>
</asp:Content>

