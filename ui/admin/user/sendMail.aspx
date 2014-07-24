<%@ Page Title="" Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="sendMail.aspx.cs" Inherits="admin_user_sendMail" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.ulprodisplay{padding-top:10px;padding-bottom:10px;margin-bottom:10px; font-family:Arial;}
.ulprodisplay li{float:left;width:130px;margin-right:10px; overflow:hidden;padding-bottom:10px; height:190px; }
.ulprodisplay li .img{width:130px;}
.ulprodisplay a{ font-family:Arial;}
.ulprodisplay li:hover{ background-color:#f3f3f3;}
.ulprodisplay div{width:130px;color:#838383;margin-top:5px;line-height:16px;}
.ulprodisplay p{height:30px; line-height:15px; overflow:hidden;}
</style>
	<script type="text/javascript" src="/js/jquery.ui.core.js"></script>
    <link href="/css/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function checkAll(elementId, obj) {
      
        }

        $(function () {

            $("#con_form").dialog("destroy");
            $("#con_form").dialog({
                autoOpen: false,
                width: 740,
                modal:true
                //            height: 300,
                //           

            });

            $("#addUser").click(function () {
                $("#con_form").dialog("open");
            });

            $("#chkAll").click(function () {
                if ($(this).attr("checked")) {
                    $(".td_select input[type=checkbox]").attr("checked", "true");
                } else {
                    $(".td_select input[type=checkbox]").removeAttr("checked");
                }
            });

            $("#userSuimt").click(function () {
                var res = "";
                $(".td_select input[type=checkbox]").each(function (i, o) {

                    if ($(o).attr("checked") == "checked")
                        res += $(o).val() + ";";

                });
                if (res.length > 0)
                    res = res.substring(0, res.length - 1);

                $("#<%=txtRecipient.ClientID%>").val(res);
                $("#con_form").dialog("close");
            });


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <table class="tableAdd">
  <tr>
            <td class="style1">
                公司名称:
            </td>
            <td class="style3">
                <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="180" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                邮件主题:
            </td>
            <td class="style3">
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="180" Width="360px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="style1">
                收件人:
            </td>
            <td class="style3">
                <asp:TextBox ID="txtRecipient" runat="server" Width="500px" TextMode="MultiLine" Height="50"></asp:TextBox><a id="addUser" href="javascript:void(0);" >选择用户</a>  多个收件人,用分号(;)隔开
            </td>
        </tr>
        <tr>
            <td class="style1">
                推广产品:
            </td>
            <td class="style3">
              <asp:Repeater ID="repProDisplay" runat="server">
    <HeaderTemplate>
        <ul class="ulprodisplay">
    </HeaderTemplate>
    <ItemTemplate>
          <li>
        <a href="<%# Eval("url") %>" title="<%# Eval("nameC") %>">
            <img src="<%= op.staValue.siteUrl %><%# Eval("fileName") %><%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" class="img" id="img_<%# Eval("id") %>"/></a>
            <div>
                <p><a href="<%# Eval("url") %>"><%# Eval("nameC") %></a></p>
                <span class="price">US $<%# Eval("strPrice") %></span></div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul></FooterTemplate>
</asp:Repeater>
            </td>
        </tr>
        <tr>
            <td class="style1">
                内容:&nbsp;
            </td>
            <td class="style3">
            <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
                <asp:TextBox ID="txtContent" class="ckeditor" TextMode="MultiLine" Text='' runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="BtOk" runat="server" Text="确定" OnClick="BtOk_Click" CssClass="btn_white" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnBack" class="btn_white" type="button" value="返回列表" onclick="window.location.href='list.aspx';" />
            </td>
        </tr>
    </table>



    <div id="con_form">
       <asp:Repeater ID="Repeater1" runat="server" >
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
    </tr>
    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="td_select"><input type="checkbox" value="<%# Eval("userName") %>" name="chkId" />
    </td>
    <td style="text-align:left;"><%# Eval("userName") %></td>
        <td><%# Eval("nameC") %></td>
    <td><%# Eval("telC") %></td>
    <td><%# Eval("addressC") %></td>
    <td><%# Eval("timeC") %></td>
    <td><%# Eval("typ").ToString()=="1"?"审核":"普通" %></td>
    <td>$<%# Eval("integralC") %></td>
    <td class="sort"><%# Eval("levelC") %></td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
      &nbsp;<input id="chkAll" type="checkbox"  /><label style=" cursor:pointer" for="chkAll">全选</label> &nbsp;|&nbsp;
    <label style="cursor:pointer" id="userSuimt" >确定</label>

   
</div></div>


</asp:Content>

