<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Recommendation.ascx.cs"
    Inherits="userCon_Recommendation" %>
<div class="left_head_1">推荐商品</div>
<ul class="ul_recommend_pro">
    <asp:Repeater ID="repList" runat="server">
        <ItemTemplate>
            <li><a href="proShow.aspx?id=<%# Eval("id") %>" title="详情请击">
                <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" />
            </a>
                <div>
                    <%# Eval("nameC") %><br />
                    零售价:<span class="marketPrice">€<%# Eval("marketPrice") %></span>
                    <br />
                    会员价:<span class="price">€<%# Eval("priceC") %></span><br />
                    <input type="button" value="购买" onclick="addCart(<%# Eval("id") %>,1)" class="btn_blue_1" />
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
