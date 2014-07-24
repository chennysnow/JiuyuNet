<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default1.aspx.cs" Inherits="admin_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>网站管理系统</title>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/public.js"></script>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
    $(function() {
        //保证页面在top窗口显示
        if (window != top) {
            top.location.href = location.href;
        }
    });
    </script>
    <style type="text/css">
    .bg{ background-image:url(img/login_bg.gif);width:1003px;height:800px;margin:0 auto; position:relative;}
    .login{ position:absolute;top:270px;left:440px;}
    .login p{margin-bottom:5px;}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="bg">
      <div class="login">
                <p>用户名:<asp:TextBox ID="txtUserName" runat="server" Width="150"></asp:TextBox></p>
                <p>密&nbsp;&nbsp;&nbsp;码:<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150"></asp:TextBox></p>
                <p>验证码:<asp:TextBox ID="txtCode" runat="server" Width="70"></asp:TextBox>
                <img src="/ajax/validate.ashx?count=5" border="0" align="absmiddle" id="Img1" style="cursor: pointer;
                vertical-align: middle; margin-top: -2px;" onclick="this.src='/ajax/validate.ashx?count=5&t=' + new Date().getTime()" /></p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" 
                        Text="[登陆]" CssClass="btn_red" onclick="btnLogin_Click" />
              <input class="btn_red" type="reset" name="Submit2" value="[取消]" /></p>
      </div>                
    </div>
    </form>
</body>
</html>
