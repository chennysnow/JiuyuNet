<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>
<%@ Register Src="userCon/productType.ascx" TagName="producttype" TagPrefix="uc3" %>
<%@ Register Src="userCon/flash.ascx" TagName="flash" TagPrefix="uc1" %>
<%@ Register src="userCon/contact.ascx" tagname="contact" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
.flash{ position:relative;padding:0 17px 0 17px;height:270px;border-bottom:3px solid #921B94;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="indexLeft">
        <uc3:producttype ID="producttype" runat="server" />
    </div>
    <div class="indexRight">
        <dl class="dlNews">
            <asp:Literal ID="liNews" runat="server"></asp:Literal>
        </dl>
    </div>
         <script type="text/javascript">
             getBackgroud("liabout");
    </script>
</asp:Content>
