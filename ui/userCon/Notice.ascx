<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notice.ascx.cs" Inherits="userCon_Notice" %> 
<div id="notice">
    <ul>
    <asp:Literal ID="liNotice" runat="server"></asp:Literal>
    </ul>
</div>
<script type="text/javascript"> 
var $notice= $('#notice ul'),timer=3000; 
//mr=window.setInterval(function(){scrollup();},4000); //4000代表间隔多长时间，包括滚动的时间。160代表滚动的高度。 
       function scrollup(){ 
           for(i=0;i<1;i++){
				$notice.find("li:first").show().appendTo($notice);
			}
		$notice.css({marginTop:0});
		$notice.animate({marginTop:-30},500);
        } 
       var autoPlay =function(){timerID = window.setInterval("scrollup()",timer);};
        var autoStop=function(){window.clearInterval(timerID);};	
       var timerID=window.setInterval("scrollup()",timer);
        $notice.hover(autoStop,autoPlay);

</script>