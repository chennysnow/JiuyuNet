<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="address.aspx.cs" Inherits="address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="formAddress" action="submit.aspx" method="post">
<fieldset>
    <legend><font size="5px" color="#6B7C07">Address And Shipping Method </font></legend>
    <div class="cart_site">
        <span>1.Edit Cart→</span><span><b>2.Address And Shipping Method →</b></span><span>3.Submit </span></div>
        <div class="Head">Address:</div>
<ul class="ulAddressInfo">
   <li><div>E-mail:</div><input type="text" name="mailC" id="mailC" value="<%= model.userName %>" />
        <br />Please enter your E-mail <font color="red">If you are a first purchase, this e-mail will be your ID, password will be sent to your email</font>
    </li>
    <li><div>Name:</div><input type="text" name="nameC" id="nameC" value="<%= model.nameC %>" />
        <br />Please enter your name
    </li>
    <li>
        <div>Tel:</div><input type="text" name="telC" id="telC" value="<%= model.telC %>" />
        <br />Please enter your Tel!! (Important)
    </li>
    <li><div>Country/Region:</div>
        <select name="selectPlace" id="selectPlace" >
        <option value="0">Select</option>
        <asp:Repeater ID="repPlace" runat="server">
        <ItemTemplate>
        <%# Eval("nameC").ToString() == model.countryC ? "<option value=\"" + Eval("nameC") + "\" selected=\"selected\">" + Eval("nameC") + "</option>" : "<option value=\"" + Eval("nameC") + "\">" + Eval("nameC") + "</option>"%>
        </ItemTemplate>
        </asp:Repeater> 
        </select>
        <br />Plase select your country
    </li>
    <li><div>Address:</div><input type="text" name="addressC" id="addressC" style="width:300px" value="<%= model.addressC %>" />
    <br />Plase enter your street address
    </li>
    </ul>
    
    <div class="Head">Select Shipping Method:</div>
    <ul class="ulPayment" id="express">
    <asp:Repeater ID="repExpress" runat="server">
    <ItemTemplate>
            <li>
            <div style="width:100px"><input type="radio" name="radioExpress" title="Click" value="<%# Eval("id") %>" id="radioExpress<%# Eval("id") %>" />
            <label for="radioExpress<%# Eval("id") %>"><%# Eval("expressName")%></label></div>
            <div style="width:120px"><img src="<%# Eval("logo") %>" /></div>
            <div style="margin-left:20px;width:300px;"><%# Eval("remark")%></div>
         
            <div class="first_price"></div>
            <div class="last_price"></div>
            </li>
    </ItemTemplate>
    </asp:Repeater>
    </ul>
        <div class="Head">Select Payment Method:</div>
    <ul class="ulPayment" id="payment">
      <asp:Repeater ID="repPayment" runat="server">
    <ItemTemplate>
            <li>
            <div style="width:100px">
            <input type="radio" name="radioPayment" title="Click" value="<%# Eval("id")%>" id="radioPayment<%# Eval("id") %>" /><%# Eval("nameC") %>
         
            <div style="width:120px"><img src="<%# Eval("imgC") %>" /></div>
            <div style="margin-left:20px;"><%# Eval("tipsC") %></div>
            </li>
    </ItemTemplate>
    </asp:Repeater>
        </ul>
        <div class="divSubmit"><br />
        <input type="button" value="back to shopping cart" class="btn_blue" onclick="window.location.href='shopping.aspx'" />
        &nbsp;&nbsp;&nbsp;&nbsp;<input type="submit" class="btn_green" value="Next" onclick="return validate()" />
        </div>
</fieldset>
</form>
 <script src="<%= op.staValue.siteUrl %>/js/JsShopping.js" type="text/javascript"></script>
 <script type="text/javascript">
    if(<%= flg %>==1)
    { $("#selectPlace").change();}
 </script>
</asp:Content>

