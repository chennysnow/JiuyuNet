<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="box.aspx.cs" Inherits="order_box" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= op.staValue.siteUrl %>/css/shopping.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ul_box { width: 970px; overflow: hidden; line-height: 18px; }
        .ul_box li { float: left; border: 2px solid #ccc; margin: 10px 10px 10px 10px; padding: 10px 0px 10px 10px; width: 450px; overflow: hidden; background-color: #f1f1f1; }
        .ul_box li:hover { border: 2px solid #ff0000; }
        .ul_box li .img { float: left; margin-right: 20px; }
        .ul_box li .info { float: left; width: 250px; }
        .ul_box li p { margin-top: 10px; }
        .ul_box .ti { height: 30px; overflow: hidden; border-bottom: 1px solid #ccc; }
        .ul_box .ti h2 { float: left; width: 180px; overflow: hidden; margin: 0px; }
        .ul_box .ti div { float: right; width: 60px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend><font size="5px" color="#85427F">选择包装</font></legend>
        <div class="cart_site">
            <span>1.编辑购物车→</span><span><b>2.选择包装→</b></span><span>3.收货信息→</span><span>4.确认提交</span></div>
            <label id="lbInfo" runat="server" visible="false"><hr /><h1>没有合适的包装,详情请联系我们!!!</h1></label>
        <ul class="ul_box">
            <asp:Repeater ID="repBoxList" runat="server">
                <ItemTemplate>
                    <li>
                        <img src="<%= op.staValue.siteUrl %><%# Eval("imgC") %>" alt="<%# Eval("nameC") %>"
                            class="img" />
                        <div class="info">
                            <div class="ti">
                                <h2>
                                    <%# Eval("nameC") %></h2>
                                <div>
                                    <input type="radio" name="box" value="<%# Eval("id") %>" />选择</div>
                            </div>
                            <p>
                                体积:<%# Eval("sizeC") %><span style="margin-right: 30px;"></span>价格:<span class="price">￥<%# Eval("priceC") %></span><span
                                    style="margin-right: 30px;"></span>重量:<%# Eval("weightC") %>Kg</p>
                            <p>
                                描述:<%# Eval("aboutC") %></p>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="divSubmit">
            <input type="button" value="返回购物车" class="btn_blue" onclick="window.location.href='shopping.aspx'" />
            &nbsp;&nbsp;&nbsp;&nbsp;<input type="button" class="btn_green" value="下一步" onclick="next(<%= Request.QueryString["count"] %>)" />
        </div>
        <script type="text/javascript">
            function next(count) {
                id = 0;
                var radios = document.getElementsByName("box");
                for (var i = 0; i < radios.length; i++) {
                    if (radios[i].checked == true) {
                        id = radios[i].value;
                        break;
                    }
                }
                // smoke=1;
                //                    if (id == 0)
                //                        showAlert("必须选择一个包装!", true);
                //                    else
                    window.location.href = "address.aspx?box=" + id + "&count=" + count; //+"smoking="+smoke;
            }
        </script>
    </fieldset>
</asp:Content>
