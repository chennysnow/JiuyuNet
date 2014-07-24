<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_index"  EnableViewState="false"%>
<%@ Register src="userCon/top.ascx" tagname="top" tagprefix="uc5" %>
<%@ Register src="userCon/bottom.ascx" tagname="bottom" tagprefix="uc10" %>
<%@ Register src="userCon/piao.ascx" tagname="piao" tagprefix="uc3" %>
<%@ Register src="userCon/productType.ascx" tagname="productType" tagprefix="uc2" %>
<%@ Register src="userCon/left.ascx" tagname="left" tagprefix="uc4" %>
<%@ Register src="userCon/flash.ascx" tagname="flash" tagprefix="uc6" %>
<%@ Register src="userCon/bestSale.ascx" tagname="bestSale" tagprefix="uc7" %>
<%@ Register src="userCon/ImgScoll.ascx" tagname="ImgScoll" tagprefix="uc1" %>
<%@ Register Src="userCon/indexFlash.ascx" TagName="indexFlash" TagPrefix="uc8" %>
<%@ Register Src="userCon/Login.ascx" TagName="Login" TagPrefix="uc9" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
     <link rel="shortcut icon" href="/images/favicon.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="/css/index_1.css" rel="stylesheet" type="text/css" />
    <link href="/css/Master.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/public.js" type="text/javascript"></script>
    <script src="/js/JsScorll.js" type="text/javascript"></script>
    <script src="/js/JsCook.js" type="text/javascript"></script>
    </head>
<body>

     <form id="form1" runat="server">
     <uc5:top ID="top1" runat="server" />
     <div style="height:5px"></div>
     <uc6:flash ID="flash1" runat="server" />

     <div class="h">
         <div style="height:5px"></div>
         <div class="indexLeft">
            <div style="width:198px; height:366px; overflow:hidden">
            <uc2:productType ID="producttype" runat="server" />
            </div>
         </div>   
         <div class="indexRight">
            <div class="IndexCompany"></div>
            <div style="height:5px"></div>
            <div>
                <div style="width:427px; height:330px; float:left">
                   <uc8:indexFlash ID="indexFlash" runat="server" />
                </div>
                <div style="width:345px; height:312px; overflow:hidden; float:right; line-height:22px; padding-top:10px; text-indent:2em">
                      <asp:Literal ID="liAbout" runat="server"></asp:Literal>
                </div>
            </div>
         </div>
         <div style="width:990px; height:240px; overflow:hidden">
              <asp:Literal ID="liNewPro" runat="server"></asp:Literal>
         </div>
         <div style="width:990px; height:240px; overflow:hidden">
              <asp:Literal ID="liEffect" runat="server"></asp:Literal>
         </div>
           <div style="width:990px; height:240px; overflow:hidden">
              <asp:Literal ID="liCustom" runat="server"></asp:Literal>
         </div>
         <div class="IndexProList"></div>
         <div style="height:auto; padding-top:10px; width:990px; margin:0 auto;">
            <asp:Repeater ID="repProDisplay" runat="server">
            <HeaderTemplate><ul class="IndexProUL"></HeaderTemplate>
            <ItemTemplate>
                 <li><a href="<%# Eval("url") %>" title="<%# Eval("nameC") %>">
                    <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" alt="<%# Eval("nameC") %>" width="215px" height="342px"/></a><br />
                    <%# Eval("nameC") %><br /><%# Eval("Characteristic") %><br />
                    <span style="line-height:25px; padding-top:3px"><%# getStar(Convert.ToInt32(Eval("star")))%></span><br />
                    <span style="color:Red; font-size:20px; font-weight:bold; line-height:25px">US$<%# Eval("strPrice") %>/Pieces</span><br />
                    <div style=" background-color:#f2faff; width:205px; text-align:center; line-height:25px; margin:0 auto">
                        <span>Order:<input type="text"  id="txtOrder<%=++index %>" style="width:60px"/>Pieces</span><br />
                        <img src="images/addcartbg.jpg" alt="Add Cart" onclick="addCart(<%# Eval("id") %>,getCount(<%=index %>))" style="cursor:pointer"/>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
         </div>
         <div class="IndexPartner"></div>
         <div class="Partner">
           <span style="width:900px; margin:0 auto; line-height:30px; padding-left:30px; padding-right:30px;">
            <asp:Literal ID="liPartner" runat="server"></asp:Literal>
           </span>
         </div>
         <div style="width:990px; margin:0 auto; margin-top:3px">
            <asp:Literal ID="liPartnerHasImg" runat="server"></asp:Literal>
         </div>

         <uc10:bottom ID="bottom1" runat="server" />
     </div>
    <uc3:piao ID="piao1" runat="server" />
    <uc9:Login ID="Login" runat="server" />
    <script src="/js/JsBottom.js" type="text/javascript"></script>  
    <script src="/js/JsCook.js" type="text/javascript"></script>
    </form>
    <script type="text/javascript">
        function getCount(index) {
            var txtid = "#txtOrder" + index;
            var count = $(txtid).val();
            return count;
        }
        getBackgroud("liindex");
    </script>
</body>
</html>
