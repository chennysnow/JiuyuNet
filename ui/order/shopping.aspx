<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shopping.aspx.cs" Inherits="shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="<%= op.staValue.siteUrl %>/css/shopping.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
    <fieldset>
    <legend><font size="5px" color="#6B7C07">Shopping Cart</font></legend>
    <div class="cart_site">
        <span><b>1.Edit Cart→</b></span><span>2.Address Review And Shipping Method →</span><span>3.Submit</span></div>
    <table class="repTable" cellpadding="0" cellspacing="0">
        <tr class="repTableHead">
            <td class="imgShopping">
            </td>
            <td>
                Description
            </td>
            <td>
                Item #
            </td>
            <td>
               Price
            </td>
            <td>
                QTY
            </td>
                 <td>
                Weight
            </td>
            <td>
                Total
            </td>
            <td>
                Remove
            </td>
        </tr>
       <asp:Repeater ID="repList" runat="server">
       <ItemTemplate>
            <tr id="<%# Eval("id") %>">
                <td>
                    <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC") %>" width="70px" />
                </td>
                <td style="text-align: left;">
                    <a href="<%# Eval("url") %>" target="_blank"><%# Eval("nameC") %></a>
                </td>
                <td><%# Eval("proId") %></td>
                </td>
                <td>
                    $<font id='price<%# Eval("id") %>'><%# Eval("priceC") %></font></td>
                <td>
                    <input class="count" value="<%# Eval("displayC") %>" type="text" onkeyup="value=value.replace(/[^\d]/g,'');addCart_shopping(<%# Eval("id") %>,this)"  style="width:20px;"/>
                </td>
                  <td class="weight"><%# Eval("WeightC")%></td>
                </td>
                <td>
                    $<font id='total<%# Eval("id") %>' class="total"><%# int.Parse(Eval("displayC").ToString()) * double.Parse(Eval("priceC").ToString())%></font></td>
                <td>
                    <a href='javaScript:delCart(<%# Eval("id") %>)' title="Remove">
                        <img src="<%= op.staValue.siteUrl %>/images/del.gif" /></a>
                </td>
            </tr>
       </ItemTemplate>
       </asp:Repeater>
       
    </table>
    <div class="cart_bottom_info">
        <div class="left" style="margin-top: 20px; text-align: left;">
<%--            <font color="#aa0000">If you have already registered with <%= op.staValue.siteUrl %>,Please Log in! <a href="/Login.aspx">Click here</a></font><br />
            <br />
--%>            <a href="<%= op.staValue.siteUrl %>/index.aspx">
                <img src="<%= op.staValue.siteUrl %>/images/continue.gif" /></a>
        </div>
        <div class="right" style="text-align: left">
            <div id="cartProInfo">
            </div>
            <div><hr />
                <img src="/images/btn-checkout.gif" style="cursor: pointer;" alt="Checkout" onclick="window.location.href='address.aspx'" />
        </div>
    </div>
</fieldset>
</form>
<script type="text/javascript" >
    setTimeout("cartAllPrice()", 1000);
</script>
</asp:Content>

