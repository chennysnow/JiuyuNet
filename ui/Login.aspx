<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register src="userCon/productType.ascx" tagname="productType" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.ul{padding-left:10px;}
.ul li{clear:both;margin-top:5px;color:#aaa; line-height:20px;}
.ul div{color:#333;}
.find{width:700px;margin-left:20px;}
.find div{margin-top:5px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="indexLeft">
    <uc1:productType ID="productType1" runat="server" />
    </div>
<div class="indexRight" style="background-color:#fff;padding-bottom:100px;">
<h1>&nbsp;&nbsp;&nbsp;<font color="#aa0000">Login</font> or Create a account</h1>
    <form id="form1" runat="server">
<div style="margin-left:20px;width:340px;float:left;_margin-left:10px;">
<fieldset>
<legend><b>Login</b></legend>
<ul class="ul">
<li>If you have an account with 
<%= op.staValue.companyName %>, please Login. 
</li>
<li><div>Email Address:<font color="red">*</font></div><asp:TextBox ID="txtUserName" runat="server" Width="260px"></asp:TextBox>
</li>
<li><div>Password:<font color="red">*</font></div><asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="260px"></asp:TextBox>
</li>
<li><div>Code:<font color="red">*</font></div><asp:TextBox ID="txtCode" Width="70px" runat="server" CssClass="validate"></asp:TextBox>
</li>
<li><div>&nbsp;</div>
<asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/btn-login.gif" onclick="btnLogin_Click" />
<div>&nbsp;</div><div>&nbsp;</div></li>
</ul>
</fieldset>
</div>
<div style="margin-right:30px;width:340px;float:right;_margin-right:15px;">
<fieldset>
<legend><b>Create a account</b></legend>
<ul class="ul">
<li><div>Email Address:<font color="red">*</font></div><asp:TextBox ID="txtUserName_r" runat="server" Width="260px"></asp:TextBox>
</li>
<li><div>Password:<font color="red">*</font></div><asp:TextBox ID="txtPassword_r" TextMode="Password" runat="server" Width="260px"></asp:TextBox>
</li>
<li><div>Confirm Password:<font color="red">*</font></div><asp:TextBox ID="txtPassword_r_2" TextMode="Password" runat="server" Width="260px"></asp:TextBox>
</li>
<li><div>Code:<font color="red">*</font></div><asp:TextBox ID="txtCode_r" Width="70px" runat="server" CssClass="validate"></asp:TextBox>
</li>
<li><div>&nbsp;</div>
<asp:ImageButton ID="btnRegister" runat="server" ImageUrl="~/images/btn-register.gif" OnClientClick="return register();" onclick="btnRegister_Click" />
<div>&nbsp;</div>
</li>
</ul>
</fieldset>
</div>
<div class="find cl">&nbsp;
<fieldset><legend>Forgot your password?</legend>
<div>Enter your email address below and we'll send you an email message containing your new password.</div>
<div>Email:<asp:TextBox ID="txtFindPassword" runat="server" Width="220px"></asp:TextBox></div>
<div> Code:<asp:TextBox ID="txtCode_find" Width="70px" runat="server" CssClass="validate"></asp:TextBox> 
<asp:Button ID="btnFind" runat="server" Text="Find Password" onclick="btnFind_Click" /></div>

</fieldset>
      <script type="text/javascript">
          function register() {
              if (!isEmpty("ctl00_ContentPlaceHolder1_txtUserName_r", "用户名不能为空")) return false;
              if (!isEmpty("ctl00_ContentPlaceHolder1_txtPassword_r", "密码不能为空")) return false;
              if (!isEmpty("ctl00_ContentPlaceHolder1_txtPassword_r_2", "重复不能为空")) return false;
              if (!isEmpty("ctl00_ContentPlaceHolder1_txtCode_r", "验证码不能为空")) return false;
              if (!isEmail($("#ctl00_ContentPlaceHolder1_txtUserName_r").val()) || $("#ctl00_ContentPlaceHolder1_txtUserName_r").val() == '') {
                  showAlert("请输入正确的邮箱!",true);
                  return false;
              }
              if ($("#ctl00_ContentPlaceHolder1_txtPassword_r").val() != $("#ctl00_ContentPlaceHolder1_txtPassword_r_2").val()) {
                  showAlert("重复密码错误!",true);
                  return false;
              }
          }
          initInputText(".validate", "Click Here!");
      </script>
</form>
</div>
</div>
</asp:Content>

