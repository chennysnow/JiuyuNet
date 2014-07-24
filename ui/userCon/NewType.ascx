<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewType.ascx.cs" Inherits="userCon_NewType" %>

<script type="text/javascript">
$(function(){
//初始化变量
var flag = 0;
var $dt = $('.slider dt');
var $dd = $('.slider dd');
//初始化状态
$dd.eq(<%= show %>).show();
$dt.eq(<%= show %>).css('cursor','default');
//单击事件
$dt.click(function(){
	
 flag = $dt.index(this);									
 $dd.not($dd.eq(flag)).slideUp();					
 $dd.eq(flag).slideDown();							
 $dt.eq(flag).css('cursor','default').addClass('slider_open');			
$dt.not($dt.eq(flag)).css('cursor','pointer').removeClass('slider_open');	
  });
});
</script>
<div class="proHead">&nbsp;&nbsp;News</div>
<dl class="slider">
<asp:Literal ID="LiProtype" runat="server"></asp:Literal>
</dl>