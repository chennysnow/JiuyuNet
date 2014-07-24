<%@ Control Language="C#" AutoEventWireup="true" CodeFile="flash.ascx.cs" Inherits="userCon_flash" %>
<style>
.slide-pic { padding:10px 0px 10px 0px; HEIGHT: 520px}
.slide-pic A#prev {DISPLAY: block; BACKGROUND: url(images/slide.png) no-repeat; MARGIN: 0px; OVERFLOW: hidden; WIDTH: 130px; TEXT-INDENT: -9999em; HEIGHT: 14px; outline: none}
.slide-pic A#next {DISPLAY: block; BACKGROUND: url(images/slide.png) no-repeat; MARGIN: 0px; OVERFLOW: hidden; WIDTH: 130px; TEXT-INDENT: -9999em; HEIGHT: 14px; outline: none;}
.slide-pic A#prev {BACKGROUND-POSITION: center 0px}
.slide-pic A#next {BACKGROUND-POSITION: center -20px}
.slide-pic A#prev:hover {BACKGROUND-POSITION: center -40px}
.slide-pic A#next:hover {BACKGROUND-POSITION: center -60px}
.slide-pic A.gray#prev {BACKGROUND-POSITION: center -80px}
.slide-pic A.gray#next {BACKGROUND-POSITION: center -100px}
.slide-pic .pic-container {MARGIN: 5px 0px; OVERFLOW: hidden; WIDTH: 130px; HEIGHT: 450px; }
.slide-pic .pic-container ul{width:130px; height:450px}
.slide-pic UL {WIDTH: 130px; height:460px;margin:0 auto}
.slide-pic UL LI {PADDING-BOTTOM: 5px; CURSOR: pointer; list-style:none }
.slide-pic UL LI P {BORDER-RIGHT: #fff 5px solid; BORDER-TOP: #fff 5px solid; OVERFLOW: hidden; BORDER-LEFT: #fff 5px solid; WIDTH: 118px; BORDER-BOTTOM: #fff 5px solid; HEIGHT:70px}
.slide-pic UL LI.hover P {BORDER-LEFT-COLOR: #bbbbbb; BORDER-BOTTOM-COLOR: #bbbbbb; BORDER-TOP-COLOR: #bbbbbb; BORDER-RIGHT-COLOR: #bbbbbb}
.slide-pic UL LI P IMG {WIDTH: 118px; HEIGHT: 80px}
.slide-pic UL LI.cur P {BORDER-LEFT-COLOR: #2c2c2c! important; BORDER-BOTTOM-COLOR: #2c2c2c! important; BORDER-TOP-COLOR: #2c2c2c! important; BORDER-RIGHT-COLOR: #2c2c2c! important}

</style>
<div class="l_flash_pic">
	<div id="ifocus">
		<div id="ifocus_pic">
			<div id="ifocus_piclist" style="left:0; top:0;">
                <a href="#" id="linka"><img alt="" id="dailyImage" src="<%= flashModel.imgC %>"></a>
			</div>
		</div>
		<div id="ifocus_btn">
			<DIV class="slide-pic" id=slidePic>
                <A class=gray id=prev hideFocus href="javascript:;"></A>
                <DIV class="pic-container">
                        <asp:Repeater ID="repSmalImg" runat="server">
                    <HeaderTemplate><ul style="width:130px; height:460px"></HeaderTemplate>
                    <ItemTemplate>
                        <LI  style="height:115px; ">
                        <P>
                                <img id="img<%= index++ %>" src="<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" link='<%# Eval("urlC") %>' width="118px" height="120px" /></P>
                        </LI>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>
                </div>
                <A id=next hideFocus href="javascript:;">后移</A>
            </div>
		</div>
	</div>	
</div>

<SCRIPT type=text/javascript>
    var areaDailyList = [];
    jQuery(function () {
        if (!$('#slidePic')[0])
            return;
        var i = 0, p = $('#slidePic ul'), pList = $('#slidePic ul li'), len = pList.length;
        var elePrev = $('#prev'), eleNext = $('#next');
        var w = 100, num = 3;
        p.css('width', w * len);
        if (len <= num)
            eleNext.addClass('gray');
        function prev() {
            if (elePrev.hasClass('gray')) {
                return;
            }
            p.animate({
                marginTop: -(--i) * w
            }, 500);
            if (i < len - num) {
                eleNext.removeClass('gray');
            }
            if (i == 0) {
                elePrev.addClass('gray');
            }
        }
        function next() {
            if (eleNext.hasClass('gray')) {
                //alert('已经是最后一张了');
                return;
            }
            //p.css('margin-left',-(++i) * w);

            p.animate({
                marginTop: -(++i) * w
            }, 500);
            if (i != 0) {
                elePrev.removeClass('gray');
            }
            if (i == len - num) {
                eleNext.addClass('gray');
            }
        }
        elePrev.bind('click', prev);
        eleNext.bind('click', next);
        pList.each(function (n, v) {
            var liclick = $(this).click(function () {
                if (n - i == 2) {
                    next();
                }
                if (n - i == 0) {
                    prev()
                }
                $('#slidePic ul li.cur').removeClass('cur');
                $(this).addClass('cur');
                show(n);
            }).mouseover(function () {
                $(this).addClass('hover');
            }).mouseout(function () {
                $(this).removeClass('hover');
            });
        });
        function show(i) {
            var imgid = "img" + i;
            var title = document.getElementById(imgid).alt;
            var imgsrc = document.getElementById(imgid).src;
            var link = document.getElementById(imgid).link;
            $('#dailyTitle').html(title);
            $('#dailyImage').attr('src', imgsrc);
            $('#linka').attr('href', link);
        }

        function change() {
            if (i < len - 1) {
                next();
                if (i < 0)
                    return;
                pList[i].click();
                i = i + 1;
            }
            else {
                i = -1;
            }
            setTimeout(change, 5000);
        }
        setTimeout(change, 5000);
    });
</SCRIPT>

