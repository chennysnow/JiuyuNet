<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProShow.aspx.cs" Inherits="ProShow" Title="无标题页" EnableSessionState="True"
    EnableViewState="false" %>
<%@ Register Src="userCon/productType.ascx" TagName="productType" TagPrefix="uc2" %>
<%@ Register src="userCon/contact.ascx" tagname="contact" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/Enlarge.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #txtContent { width: 381px; height: 49px; }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <script src="/js/JsEnlarge.js" type="text/javascript"></script>
    <div class="indexLeft">
        <uc2:productType ID="productType1" runat="server" />
        <uc1:contact ID="contact1" runat="server" />
    </div>
    <div class="indexRight">
        <div id="pro_scroll_key">
             <ul>
                <asp:Repeater ID="repSeaKey" runat="server">
                <ItemTemplate>
               <li><a href="<%# Eval("url") %>">
               <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" /></a>
               <div><a href="<%# Eval("url") %>" title="<%# Eval("nameC") %>"><%# Eval("nameC") %></a></div>
               </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>
            <div class="border">
        <div class="left">
            <div id="jiuyuEnlarge" large="<%= model.fileName%><%= model.imgC %>">
                <img src="<%= model.fileName%><%= model.imgC %>" width="360px" id="jiuyuImg" />
            </div>
            <ul class="ulMoreImg">
            <asp:Literal ID="liMoreImg" runat="server"></asp:Literal>
            </ul>
        </div>
        <div id="pro_title">
            <h1><%= model.nameC %></h1>
            <ul>
                <li><span>Unit Price:</span><font class="price" size="3"><%= model.strPrice %></font></li>
                <table class="tbPrice">
                    <tr class="head"><td>Quantity(lots)</td><td>Price/lot</td><td>Processing time</td></tr>
                    <asp:Repeater ID="repPrice" runat="server">
                    <ItemTemplate>
                    <tr><td><%# Eval("minC") %> - <%# Eval("maxC") %></td><td>US $<%# Eval("priceC") %></td><td><%# Eval("dayC") %></td></tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </table>
                </li>
                <li><span>Item No:</span><%= model.proId %></li>
                <li><span>Category:</span><%= Categroy %></li>
                <asp:Literal ID="liAttr" runat="server"></asp:Literal>
                 <li>
                 <div id="dvcart">
                 Purchase Quantity: 
                <input id="txtNum" type="text" onkeyup="value=value.replace(/[^\d]/g,'')" style="width: 30px;"
                    value="1" size="5" />
                <img src="/images/UpDown.gif" usemap="#Map" align="absmiddle" style="cursor: pointer;vertical-align: middle;" />
                &nbsp;&nbsp;
                <input type="hidden" id="display" value="<%= model.displayC %>" />
                
            <map name="Map" id="Map">
                <area shape="rect" coords="3,0,21,8" href="javascript:up();" />
                <area shape="rect" coords="3,11,19,19" href="javascript:down();" />
            </map><br /><br />
            <input type="button" class="btn_white" onclick="addCart_pro(<%= model.id %>,txtNubm(),1)" title="Buy it now" value="buy it now" /> 
            <input type="button" title="Add Cart" onclick="addCart_pro(<%= model.id %>,txtNubm(),0)" class="btn_cart2"  value=" " /></div>
                </li>
            </ul>
        </div>
        </div>
        <div class="border">
    <!--产品描述-->
    <div class="right_head cl"><span>Description</span></div>
    <div class="description">
        <asp:Literal ID="liDescription" runat="server">
        </asp:Literal></div>
        </div>
         <!--同类推荐-->
         <div class="border">
          <div class="right_head">
        <span>Recommend</span></div>
        <ul class="ulProType">
            <asp:Repeater ID="repProType" runat="server">
            <ItemTemplate>
             <li>
        <a href="<%# Eval("url") %>">
            <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>" class="img" /></a>
            <div>
                 <a href="<%# Eval("url") %>"><%# Eval("nameC") %></a><br />
                <span class="price">Sale $<%# Eval("strPrice") %></span><br /><img alt="Add Cart" src="/images/btn-cart.gif" onclick="addCart(<%# Eval("id") %>,1)" class="btn_cart" /></div>
        </li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        </div>
    <!--产品咨询-->
    <div class="border">
    <div class="right_head cl">
        <span>Inquiry Now</span></div>
    <input type="hidden" id="inquiryImg" value="<%= model.fileName%>/sImg<%= model.imgC %>@<%= model.proId %>" />
    <ul class="ulInquiry">
        <li>
            <div>
                Name:<font style="color: Red">*</font></div>
            <input type="text" id="txtName" /></li>
        <li>
            <div>
                E-mail:<font style="color: Red">*</font></div>
            <input type="text" id="txtEmail" /></li>
        <li>
            <div>
                Content:</div>
            <textarea id="txtContent"></textarea>
        </li>
        <li>
            <div>
                Code:<font style="color: Red">*</font></div>
            <input type="text" id="txtCode" class="validate" size="10" />
            <input type="button" id="btnSubmit" value="Submit" onclick="vadio()" /></li>
    </ul>
    </div>
    </div>
    <script src="/js/jquery.marquee.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#pro_scroll_key").marquee({ direction: "left", speed: 15, step: 2, pause: 0 });
        $(function () {
            $(".ulMoreImg li img").hover(function () {
                $(".ulMoreImg li img").removeClass("imgHover");
                $(this).addClass("imgHover");
                img = $(this).attr("src").replace("/sImg", "");
                $("#jiuyuEnlarge").attr("large", img);
                $("#jiuyuImg").attr("src", img);
            });
        });
        clearMargin(5, 20, "ulProType");
        initInputText(".validate", "Click Here!");
        showCart();
        function showCart() {
            var display = document.getElementById("display").value;
            if (display.indexOf("1") > 0) {
                getBackgroud("liproduct");
            }
            else {
                var div = document.getElementById("dvcart");
                div.style.display = "none";
                getBackgroud("liNewPro");
            }
        }
    </script>
    <script src="js/JsVido.js" type="text/javascript"></script>
    <script type="text/javascript">        left_menu(<%= model.typ %>)</script>
    </form>
</asp:Content>
