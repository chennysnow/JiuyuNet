<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="NewList.aspx.cs" Inherits="CompanyNewList" Title="ÎÞ±êÌâÒ³" EnableSessionState="False"%>
<%@ MasterType VirtualPath="MasterPage.master" %>
<%@ Register src="userCon/site.ascx" tagname="site" tagprefix="uc1" %>
<%@ Register src="userCon/productType.ascx" tagname="productType" tagprefix="uc3" %>
<%@ Register src="userCon/contact.ascx" tagname="contact" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
<div class="indexLeft">
    <uc3:productType ID="productType1" runat="server" />
    <uc2:contact ID="contact1" runat="server" />
</div>
<div class="indexRight">
<div class="left_head">&nbsp;&nbsp;&nbsp;<%= category%></div>
    <ul class="ulNewList">
    <asp:Repeater ID="RepList" runat="server" >
    <ItemTemplate>
    <li><a href="<%# Eval("url") %>"><%# Eval("nameC")%></a><span class="dateStr">[<%# Eval("timeC") %>]</span>
        <div><%# Eval("aboutC") %></div>
    </li>
    </ItemTemplate>
    </asp:Repeater></ul>
     <div class="page">
           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                Width="100%"  UrlPaging="True" FirstLastButtonStyle="" CurrentPageButtonClass="page_current"
                CustomInfoClass="" CustomInfoHTML="%RecordCount% item(s) &nbsp;&nbsp; Page %CurrentPageIndex% of %PageCount%"
                FirstPageText="First" LastPageText="Last" NextPageText="Next" PrevPageText="Prev"
                ShowCustomInfoSection="Left" EnableUrlRewriting="true"
                UrlPageIndexName="p" CustomInfoTextAlign="Left" PagingButtonLayoutType="Span" HorizontalAlign="Right"
                NumericButtonCount="5" AlwaysShow="True" CustomInfoSectionWidth="30%">
            </webdiyer:AspNetPager>
        </div>
</div>
</form>
<script type="text/javascript">
    $(".ulNewList li:last").css({border:"none"});
</script>
</asp:Content>

