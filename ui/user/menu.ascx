<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="user_menu" %>
<div class="left_head_1" style="padding-left:20px">My Account</div>
<ul class="ul_user_menu">
    <li>
        <a href="user.aspx">Account Settings</a></li>
    <li>
        <a href="password.aspx">Change Password</a></li>
    <li><a href="/order/Shopping.aspx">Shopping Cart</a></li>
    <li>
        <a href="order.aspx">View Orders</a></li>
    <li><a href="javascript:loginOut();">Logout</a></li>
</ul>
<div class="left_head_1" style="padding-left:20px">Search for orders</div>
<ul class="ul_user_menu">
    <li>
    Order number:<br /><br />
    <input type="text" id="seaOrderKey" style="width:120px;" /><br />
    <input type="button" id="btn_seaOrder" value="Search" onclick="seaOrder()"/>
    </li></ul>
<div class="left_head_1" style="padding-left:20px">Need help</div>
<ul class="ul_user_menu">
<li>
If you have questions or need help with your account, you may <a href="/ContactUs.html">contact us</a> to assist you. 
</li>
</ul>
<script type="text/javascript">
    function seaOrder() {
        window.location.href = "order.aspx?order="+$("#seaOrderKey").val();
    }
</script>