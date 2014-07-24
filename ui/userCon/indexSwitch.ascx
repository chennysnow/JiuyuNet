<%@ Control Language="C#" AutoEventWireup="true" CodeFile="indexSwitch.ascx.cs" Inherits="userCon_indexSwitch" %>
<div class="switch">
    <div class="switchRight">
        <asp:Literal ID="liBig" runat="server"></asp:Literal>
    </div>
    <div class="switchLeft">
        <asp:Literal ID="liSmoll" runat="server"></asp:Literal>
    </div>
</div>
<script type="text/javascript">
var $switchRight=$(".switchRight div");
var $switchLeft=$(".switchLeft div");
var switchIndex=0,switchFlg=true;
function switchOpen()
{
    $switchRight.eq(switchIndex).slideDown("700");
    $switchRight.not($switchRight.eq(switchIndex)).fadeOut("500");
    $switchLeft.not($switchRight.eq(switchIndex)).removeClass("switchOpen");
    $switchLeft.eq(switchIndex).addClass("switchOpen");
    if(switchIndex<3&&switchFlg)
    {
        switchIndex++;
        switchFlg=true;
    }
    else
    {
        if(switchIndex<=0)
            switchFlg=true;
            else
            {
                switchFlg=false;
                switchIndex--;
            }
    }
}
  var timer=5000;
  var autoPlay =function(){timerID = window.setInterval("switchOpen()",timer);};
  var autoStop=function(){window.clearInterval(timerID);};	
  var timerID=window.setInterval("switchOpen()",timer);
  $(".switchLeft div").hover(
        function(){
            switchIndex=$(this).index();
            switchOpen();
            window.clearInterval(timerID);
        },autoPlay
)
</script>