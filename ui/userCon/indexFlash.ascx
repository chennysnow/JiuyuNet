<%@ Control Language="C#" AutoEventWireup="true" CodeFile="indexFlash.ascx.cs" Inherits="userCon_indexFlash" %>
<div id="flash" style="visibility:hidden;">
<asp:Repeater ID="repFlash" runat="server">
<ItemTemplate>
<a href="<%# Eval("urlC") %>" target="_blank"><img src="<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" width="427px" height="313px"/></a>
</ItemTemplate>
</asp:Repeater>
</div>
<script src="/js/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#flash").KinSlideshow({
            moveStyle: "right",
            isHasTitleBar: false,
            isHasTitleFont: false
        });
    })
</script>