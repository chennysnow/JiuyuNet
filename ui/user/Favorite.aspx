<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Favorite.aspx.cs" Inherits="user_Favorite" EnableViewState="false" %>

<%@ Register Src="menu.ascx" TagName="menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/user.css" rel="stylesheet" type="text/css" />
    <script src="/js/JsVido.js" type="text/javascript" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="indexLeft">
        <uc1:menu ID="menu1" runat="server" />
    </div>
    <div class="indexRight">
        <div class="right_head">
            我的收藏<span class="more">最多收藏20个产品</span></div>
        <ul class="ulprodisplay">
            <asp:Repeater ID="repFavorite" runat="server">
                <ItemTemplate>
                    <li><a href="ProShow.aspx?id=<%# Eval("id") %>" target="_blank">
                        <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>"
                            class="img" /></a>
                        <div>
                            商品编号:<%# Eval("proId") %><br /><%# Eval("nameC") %><br />零售价:<span class="marketPrice">￥<%# Eval("marketPrice") %></span>会员价:<span class="price">￥<%# Eval("priceC") %></span><br /><input type="button" value="购买" onclick="addCart(<%# Eval("id") %>,1)" class="btn_blue_1" />&nbsp;&nbsp;
                            <input type="button" value="删除" onclick="delFav(<%# Eval("id") %>)" class="btn_blue_1" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
