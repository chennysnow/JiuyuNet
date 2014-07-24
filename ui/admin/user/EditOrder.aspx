<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="EditOrder.aspx.cs" Inherits="admin_user_EditOrder" Title="无标题页" %>

<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">

    function volidNum(o,oldPrice) {
        if (isNaN($(o).val())) {

            if ($(o).val().substring($(o).val().length - 1) == ".")
                return;
            $(o).val(oldPrice);
            return;
        }
        getinfo();
    }
    function volidQuantity(o, oldPrice) {
        $(o).val($(o).val().replace(/[^\d]/g, ''));
        getinfo();
    }
    function ExpPrice(o) {
        if (isNaN($(o).val())) {
            $(o).val($(o).val().replace(/[^\d]/g, ''));
            return;
        }
        var exp = parseFloat($(o).val());

        $("#<%=txtPrice.ClientID %>").val(exp + parseFloat($("#<%=txtProPrice.ClientID %>").val()));
    }


    function getinfo() {

        var totalPrice = 0;
        $(".unitPrict").each(function (i, a) {
            var b = parseFloat($(a).val());
            var quantry = parseInt($(a).parent().next()[0].firstChild.value);
            totalPrice = totalPrice + b * quantry;
            $(a).parent().next().next().text("$" + b * quantry);
        });
        var ExPrice = parseFloat($("#<%=txtExPrice.ClientID %>").val());
        $("#<%=txtProPrice.ClientID %>").val(totalPrice);
        $("#<%=txtPrice.ClientID %>").val(totalPrice + ExPrice);
    }




</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">

    <div class="Head">基本信息:</div>

        <ul class="ulInfo">
       
        <li><div>订单状态:</div><asp:Literal ID="litOrderState" runat="server"></asp:Literal></li>
        <li><div>下单时间:</div> <asp:Literal ID="liOrderTime" runat="server"></asp:Literal></li>
        

     </ul>

        <div class="Head">送货信息:</div>
    <ul class="ulInfo">
       
        <li><div>姓名:</div><asp:Literal ID="litExpName" runat="server"></asp:Literal></li>
        <li><div>电话:</div><asp:Literal ID="litExpTel" runat="server"></asp:Literal></li>
        
        <li><div>国家:</div><asp:Literal ID="litExpCountry" runat="server"></asp:Literal></li>
        <li><div>详细地址:</div><asp:Literal ID="litExpAddress" runat="server"></asp:Literal></li>
         <li><div>E-mail:</div><asp:Literal ID="litEmail" runat="server"></asp:Literal></li>
            <li><div>快递方式:</div><asp:Literal ID="litExpType" runat="server"></asp:Literal></li>
     </ul>

    <div class="Head">商品列表:</div>
    <asp:Repeater ID="repOrderItem" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" cellpadding="0" class="repTable">
                <tbody>
                    <tr class="repTableHead">
                      <td>
                  商品
                </td>

                        <td>
                            名称
                        </td>
                        <td>
                            属性
                        </td>
                        <td>
                            单价
                        </td>
                        <td>
                            折扣价
                        </td>
                        <td>
                           数量
                        </td>
                        <td>
                            总价
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                 <td>
                    <a href="/proShow.aspx?id=<%# Eval("ProductId") %>" target="_blank" title="<%# Eval("ProductName") %>">
                        <img src="<%# Eval("ProImgURL") %>" width="40" alt="<%# Eval("ProductName") %>" /></a>
                </td>
                <td>
             
                        <%# Eval("ProductName")%>
          
                </td>
                <td>
                    <%# Eval("ProductNO")%>
                </td>
                <td>
                    $<%# Eval("UnitPrice")%></td>
                <td>
                    $<input type="text" class="unitPrict" style="width: 50px;" onblur="getinfo()" onkeyup="volidNum(this,<%# Eval("DisPrice")%>)" name="DiscountPrice" value="<%# Eval("DisPrice")%>" />
                </td>
                <td><input type="text"  style="width: 50px;" onblur="getinfo()" onkeyup="volidQuantity(this,<%# Eval("Quantity")%>)" name="ProQuantity" value="<%# Eval("Quantity")%>"</td>
                <td>$<%# Eval("TotalAmount")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>

 

    <div class="clearfix"></div>
 <div class="Head">修改订单:</div>
    <ul class="ulInfo">
            <li><div>快递号:</div><asp:TextBox ID="txtPostNum" runat="server"></asp:TextBox></li>
            <li><div>发货时间:</div><asp:TextBox ID="txtPostTime" runat="server" Width="100px"></asp:TextBox></li>
            <li><div>运费:</div><asp:TextBox ID="txtExPrice" runat="server" onblur="ExpPrice(this)" ></asp:TextBox></li>
            <li><div>商品总价:</div><asp:TextBox ID="txtProPrice" runat="server" Width="100px"></asp:TextBox></li>
           <li><div>订单总金额:</div><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></li>
          <li><div>订单状态:</div>
            <asp:DropDownList ID="dropType" runat="server" Width="106px">
            </asp:DropDownList></li>
             <li style=" width:800px; height:85px;"><div>备注:</div><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"
            MaxLength="200" Width="553px" Height="80px"></asp:TextBox>
            </li>
            <li>    <div >&nbsp;</div>
    <asp:Button ID="btnOk" runat="server" Text="提 交" OnClick="btnOk_Click" /></li>
    </ul>

    <div class="cl">
        &nbsp;</div>
</asp:Content>
