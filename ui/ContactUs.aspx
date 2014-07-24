<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="无标题页" %>
<%@ MasterType VirtualPath="MasterPage.master" %>
<%@ Register src="userCon/productType.ascx" tagname="productType" tagprefix="uc1" %>
<%@ Register src="userCon/hotPro.ascx" tagname="hotPro" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="indexLeft">
     <uc1:productType ID="productType1" runat="server" />    
</div>
<div class="indexRight">
        <dl class="dlNews">
            <asp:Literal ID="liNews" runat="server" ></asp:Literal>
        </dl>
</div>
         <script type="text/javascript">
             getBackgroud("licontact");
    </script>
</asp:Content>

