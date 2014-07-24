<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="userCon_top" %>
<%@ OutputCache Duration="600" VaryByParam="clBuffer" %>
<div class="top">
    <div class="top_keywords">
        <div style="padding-left:30px; float:left; width:460px"><asp:Literal ID="liTopKeyword" runat="server"></asp:Literal></div>
       <div class="searchLogin">
            <div id="loginInfo">
                Welcome! <a href="/login.aspx" rel="nofollow">Sign in</a> or <a href="/login.aspx"
                    rel="nofollow">Register</a></div>
        </div>
        <div style="float:right; width:200px;">
            <img src="/images/cart.gif" style="vertical-align:middle; margin-top:-3px; width:32px; height:28"/>
            <a href="/order/shopping.aspx">Shopping Cart
                <span id="cartCount">0</span></a>
        </div>
    </div>
    <div style="width:1002px; height:73px">
    <div class="top_logo">
        <a class="logo" href="/" title="<%= op.staValue.companyName %>"><img src="/images/logo.jpg" /></a>
    </div>
    <div class="top_contact">
        <asp:Literal ID="liContact" runat="server"></asp:Literal>
    </div>
    </div>
    <div class="dvMenu">
        <ul class="top_menu">
            <li id="liindex"><a href="/index.html">Home</a></li>
            <li id="liproduct"><a href="/prolist.html">Products</a></li>
            <li id="liNewPro"><a href="/prolist.html?display=new">New Products</a></li>
            <li id="limessage"><a href="/message.html">Feedback</a></li>
            <li id="liabout"><a href="/about.html">About Us</a></li>
            <li id="licontact"><a href="/contactus.html">Contact</a></li>
        </ul>
    </div>
    <div class="dvSearch">
        <div style="float:left; width:220px;">
            <div style="width:26px;height:24px; padding-left:30px; padding-top:5px; float:left; z-index:2; position:absolute;"><img src="/images/searchbiaoimg.jpg" /></div>
            <div style="width:180px; height:28px; float:left; padding-top:3px; z-index:1; position:absolute; padding-left:26px;"><input id="seaKey" type="text" style="width:180px; height:26px; line-height:26px; padding-left:26px; border:1px solid #026af2" /></div>
        </div>
        <div style="background:url(/images/searchebtnimg.jpg) no-repeat; cursor:pointer; height:26px; width:63px;float:left;margin-left:245px; _margin-left:30px; margin-top:6px" onclick="return search()"></div>    
        <div style="width:658px; float:right; text-align:left; overflow:hidden; font-weight:bold; ">Keywords:&nbsp;<asp:Literal ID="likeywords" runat="server"></asp:Literal></div>
    </div>
</div>

