<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Submit.aspx.cs" Inherits="Submit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= op.staValue.siteUrl %>/css/shopping.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class='Head'>
        Products Information:</div>
    <asp:Repeater ID="repProList" runat="server">
        <HeaderTemplate>
            <table class='repTable' cellpadding='0' cellspacing='0'>
                <tr class='repTableHead'>
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
                        Total
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="<%# Eval("htmlName") %>" target="_blank">
                        <%# Eval("nameC") %>
                </td>
                <td>
                    <%# Eval("proId") %>
                </td>
              
                <td>
                    $<%# Eval("priceC") %></td>
                <td>
                    <%# Eval("displayC") %>
                </td>
                <td>
                    $<%# int.Parse(Eval("displayC").ToString())*double.Parse(Eval("priceC").ToString()) %>
                </td>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="liTotal" runat="server"></asp:Literal>
    <input type="hidden" id="count" />
    <asp:Literal ID="liAddress" runat="server"></asp:Literal>
    <asp:Literal ID="liTotalInfo" runat="server"></asp:Literal>
    <div class="divSubmit">
    <p>Coupon Code (optional):<asp:TextBox ID="txtCoupon" runat="server"></asp:TextBox>
        <asp:Button ID="btnCoupon" runat="server" Text="APPLY" 
            onclick="btnCoupon_Click" /></p>
        <p>Remarks:<asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="360px" Height="60px"></asp:TextBox></p>
        <p><input type="button" value="Back" class="btn_blue" onclick="window.location.href='address.aspx'" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit Your Order" CssClass="btn_green"
            OnClick="btnSubmit_Click" /></p>
    </div>
    </form>
</asp:Content>
