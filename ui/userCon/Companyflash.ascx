<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Companyflash.ascx.cs" Inherits="userCon_Companyflash" %>
<!--JQ版-->
<div id="flash" style="visibility:hidden;">
<asp:Repeater ID="repFlash" runat="server">
<ItemTemplate>
<a href="<%# Eval("urlC") %>" target="_blank"><img src="<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" /></a>
</ItemTemplate>
</asp:Repeater>
</div>
<script src="/js/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#flash").KinSlideshow({
            moveStyle: "right",
           isHasTitleFont:false
        });
    })
</script>
<%--<script src="/js/jquery.KinSlideshow-1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#flash").KinSlideshow({
            moveStyle: "right",
            titleBar: { titleBar_height: 30, titleBar_bgColor: "#114390", titleBar_alpha: 0.5 },
            titleFont: { TitleFont_size: 12, TitleFont_color: "#FFFFFF", TitleFont_weight: "normal" },
            btn: { btn_bgColor: "#FFFFFF", btn_bgHoverColor: "#114390", btn_fontColor: "#000000",
                btn_fontHoverColor: "#FFFFFF", btn_borderColor: "#cccccc",
                btn_borderHoverColor: "#114390", btn_borderWidth: 1
            }
        });
    })
</script>--%>
<%--<!-- Flash版-->
<script type="text/javascript">
var pic_width=780;
var pic_height=200;
var button_pos=4;
var stop_time=5000;
var show_text=0;
var txtcolor="000000"; 
var bgcolor="ffffff";
var imag=new Array();
var link=new Array();
var text=new Array();
var pics='<%= img  %>';
var links='<%= link  %>';
var texts='<%= title  %>';
document.write('<object ID="focus_flash" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ pic_width +'" height="'+pic_height+'">');
document.write('<param name="movie" value="swf/playswf.swf">');
document.write('<param name="wmode" value="transparent"><param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&pic_width='+pic_width+'&pic_height='+pic_height+'&show_text='+show_text+'&txtcolor='+txtcolor+'&bgcolor='+bgcolor+'&button_pos='+button_pos+'&stop_time='+stop_time+'">');
document.write('<embed wmode="opaque" src="swf/playswf.swf" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&pic_width='+pic_width+'&pic_height='+pic_height+'&show_text='+show_text+'&txtcolor='+txtcolor+'&bgcolor='+bgcolor+'&button_pos='+button_pos+'&stop_time='+stop_time+'" quality="high" width="'+ pic_width +'" height="'+ pic_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
document.write('</object>');
</script>



<!--Js 小图,大图版
/*///////////////flash图片切换*/		 		 
.flash{width:745px;height:275px;margin-left:5px;margin-top:5px;}
#showImg{width:560px;height:275px;float:left; position:relative; overflow:hidden;}

#showImg .name{ position:absolute;top:240px;height:35px;width:100%; line-height:35px;font-size:18px;color:#fff;padding-left:10px;
               background-color:#4298D1;filter:alpha(opacity=50); z-index:9999;}       
.ul_flash{width:185px;float:right;}
.ul_flash img{width:185px;height:91px;filter:alpha(opacity=50);margin-bottom:1px;}
.ul_flash .hover{width:179px;height:85px;border:3px solid #4298D1;filter:alpha(opacity=100);}
-->
<div class="flash">
<div id="showImg">
<div class="name"></div>
<img src="" >
</div>
<ul class="ul_flash">
<asp:Repeater ID="repFlash" runat="server">
<ItemTemplate>
<li><a href="<%# Eval("urlC") %>"><img src="<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" /></a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<script type="text/javascript">
    showImg($(".ul_flash img").eq(0));
    $(".ul_flash img").hover(function () {
        showImg(this);
    });
    function showImg(obj) {
        $(".ul_flash img").removeClass("hover");
        $(obj).addClass("hover");
        $("#showImg img").attr("src", $(obj).attr("src"));
        $("#showImg div").html($(obj).attr("alt")).css({ display: "block", height: "35px" });
        //alert($("#showImg").html());
    }
</script>--%>