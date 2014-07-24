<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProDisplay.ascx.cs" Inherits="userCon_ProDisplay" %>
<div class="right_head">商品展示(<%= name%>)<a href="proList.aspx?typ=<%= typ %>" class="more">更多</a></div>
<asp:Repeater ID="repProDisplay" runat="server">
    <HeaderTemplate>
        <ul class="ulprodisplay">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
        <a href="ProShow.aspx?id=<%# Eval("id") %>" target="_blank">
            <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>" class="img" /></a>
            <div>
                商品编号:<%# Eval("proId") %><br />
                <%# Eval("nameC") %><br />
                零售价:<span class="marketPrice">€<%# Eval("marketPrice") %></span>
                会员价:<span class="price">€<%# Eval("priceC") %></span><br />
                  <input type="button" value="购买" onclick="addCart(<%# Eval("id") %>,1)"
                        class="btn_blue_1" />&nbsp;&nbsp;
                  <input type="button" value="收藏" onclick="addFav(<%# Eval("id") %>,1)"
                        class="btn_blue_1" />
                </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul></FooterTemplate>
</asp:Repeater>
