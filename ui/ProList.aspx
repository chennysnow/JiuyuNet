<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="ProList.aspx.cs" Inherits="ProList" Title="" EnableViewState="false" %>
<%@ MasterType VirtualPath="MasterPage.master" %>
<%@ Register Src="userCon/productType.ascx" TagName="productType" TagPrefix="uc2" %>
<%@ Register src="userCon/contact.ascx" tagname="contact" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="indexLeft">
        <uc2:productType ID="productType1" runat="server" />
        <uc1:contact ID="contact1" runat="server" />
    </div>
    <div class="indexRight">
        <form id="form1" runat="server">
        <asp:Literal ID="liMenuAbout" runat="server"></asp:Literal>
        <asp:Repeater ID="repProDisplay" runat="server">
            <HeaderTemplate><ul class="ulprodisplay"></HeaderTemplate>
            <ItemTemplate>
                 <li>
                    <a href="<%# Eval("url") %>" title="<%# Eval("nameC") %>">
                        <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>" class="img" /></a>
                    <%# Eval("nameC") %><br /><%# Eval("Characteristic") %><br />
                    <span style="line-height:25px; padding-top:3px"><%# getStar(Convert.ToInt32(Eval("star")))%></span><br />
                    <span style="color:Red; font-size:20px; font-weight:bold; line-height:25px">US$<%# Eval("strPrice") %>/Pieces</span><br />
                    <div name="dvCart" style=" background-color:#f2faff; width:205px; text-align:center; line-height:25px; margin:0 auto">
                        <%# getCart(Eval("id").ToString(),Eval("displayC").ToString()) %>
                    </div>
                 </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <input type="hidden" id="display" value="<%= display %>" />
        <div class="page">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                Width="100%"  UrlPaging="True" FirstLastButtonStyle="" CurrentPageButtonClass="page_current"
                CustomInfoClass="" CustomInfoHTML="%RecordCount% item(s) &nbsp;&nbsp; Page %CurrentPageIndex% of %PageCount%"
                FirstPageText="First" LastPageText="Last" NextPageText="Next" PrevPageText="Prev"
                ShowCustomInfoSection="Left" UrlPageIndexName="p" CustomInfoTextAlign="Left" PagingButtonLayoutType="Span" HorizontalAlign="Right"
                NumericButtonCount="5" AlwaysShow="True" CustomInfoSectionWidth="30%">
            </webdiyer:AspNetPager>
        </div>
        </form>
    </div>
    <script type="text/javascript">
        getli();
        function getli() {
            var display = document.getElementById("display").value;
            if (display.length > 0)
                getBackgroud("liNewPro");
            else 
                getBackgroud("liproduct");
        }
      
    </script>
</asp:Content>
