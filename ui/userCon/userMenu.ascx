<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userMenu.ascx.cs" Inherits="userCon_userMenu" %>
<ul class="left_help">
    <li><a href="UserOrder.aspx"><img src="images/user1.gif"/>Order Management</a></li>
	<li><a href="UserInfo.aspx"><img src="images/user2.gif"/>Personal Information</a></li>
    <li><a href="UserInfo.aspx?flg=1"><img src="images/user8.gif"/>Change Password</a></li>
    <li style=" padding:2px;">
        <asp:ImageButton ID="ImgBtnAout" runat="server" 
            ImageUrl="../images/login_out.gif" width="77" height="21" 
            onclick="ImgBtnAout_Click"/></li>
</ul>    