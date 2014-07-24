/*
滚动插件
#index_events{height:150px; overflow:hidden; padding:1px;}
#index_events li{margin-bottom:3px;}
#events_up{background:url(../images ne.gif) no-repeat center bottom; padding-bottom:1px; text-align:center; margin-bottom:5px;}
#events_down{background:url(../images ne.gif) no-repeat center top;text-align:center; padding-bottom:5px; margin-bottom:5px; padding-top:1px; margin-top:5px;}

#scroll_left_news,#scroll_left_pro{width:150px; height:120px; overflow:hidden; position:relative; margin:0 auto; border-bottom:1px solid #5C5B5B; padding:5px 0;}
#scroll_left_filter{width:150px; overflow:hidden; position:relative; margin:0 auto; border-bottom:1px solid #5C5B5B; padding:5px 0;}
#scroll_left_news ul,#scroll_left_pro ul{position:absolute; width:20000px;}
#scroll_left_news li,#scroll_left_pro li{width:52px; height:120px; margin-right:5px; margin-left:13px; display:inline; float:left; border-bottom:1px solid #666;}

$("#index_events").Scroll({line:1,speed:500,timer:2000,up:"events_up",down:"events_down"});  //垂直滚动
$("#scroll_left_news").Scroll({line:1,speed:500,timer:5000,vertical:false}); //水平滚动
*/
(function ($) {
    $.fn.extend({
        Scroll: function (opt, callback) {
            if (!opt) { var opt = {}; }
            var _btnUp = $("#" + opt.up);
            var _btnDown = $("#" + opt.down);
            var timerID;
            var _this = $(this).find("ul:first");
            var lineH = _this.find("li:first").outerHeight(true);
            var lineW = _this.find("li:first").outerWidth(true);
            //参数
            var line = opt.line ? parseInt(opt.line, 10) : 1;
            var speed = opt.speed ? parseInt(opt.speed, 10) : 500;
            var timer = opt.timer ? parseInt(opt.timer, 10) : 3000;
            var vertical = opt.vertical == undefined ? true : false; //是否垂直 默认true
            var auto = opt.auto == undefined ? true : false; //是否自动播放 默认true
            //
            if (line == 0) line = 1;
            if (vertical == undefined) { vertical = true; }
            var upHeight = 0 - line * lineH;
            //滚动函数
            var scrollUp = function () {
                _btnDown.unbind("click", scrollUp);
                for (i = 0; i < line; i++) {
                    _this.find("li:first").show().appendTo(_this);
                }
                _this.css({ marginTop: 0 });
                _this.animate({ marginTop: upHeight }, speed, function () {
                    _btnDown.bind("click", scrollUp);
                });
            }
            var scrollDown = function () {
                _btnUp.unbind("click", scrollDown);
                for (i = 0; i < line; i++) {
                    _this.find("li:last").show().prependTo(_this);
                }
                _this.css({ marginTop: upHeight });
                _this.animate({ marginTop: 0 }, speed, function () {
                    _btnUp.bind("click", scrollDown);
                });
            }
            var scrollLeft = function () {
                _btnDown.unbind("click", scrollLeft);
                _this.animate({ left: "-" + line * lineW }, speed, function () {
                    for (i = 0; i < line; i++) {
                        var _li = _this.find("li:eq(0)");
                        var _lic = _li.clone(true);
                        _li.remove();
                        _lic.appendTo(_this).fadeTo(0, 0).fadeTo("fast", 1);
                    }
                    _this.css({ left: 0 });
                    _btnDown.bind("click", scrollLeft);
                });
            }
            var scrollRight = function () {
                _btnUp.unbind("click", scrollRight);
                var len = _this.find("li").size();
                _this.animate({ left: line * lineW }, speed, function () {
                    for (i = len; i > len - line; i--) {
                        var _li = _this.find("li:last");
                        var _lic = _li.clone(true);
                        _li.remove();
                        _lic.prependTo(_this).fadeTo(0, 0).fadeTo("fast", 1);
                    }
                    _this.css({ left: 0 });
                    _btnUp.bind("click", scrollRight);
                });
            }
            var autoPlay = function () { if (timer) { timerID = window.setInterval(scrollUp, timer); }; };
            var autoPlay_1 = function () { if (timer) { timerID = window.setInterval(scrollLeft, timer); }; };
            var autoStop = function () { if (timer) { window.clearInterval(timerID); }; };
            if (vertical) {
                //垂直滚动
                if (auto) {
                    //自动滚动	
                    if (timer) { timerID = window.setInterval(scrollUp, timer); }; 
                    _this.hover(autoStop, autoPlay).mouseout();
                    _btnUp.css("cursor", "pointer").click(scrollDown).hover(autoStop, autoPlay);
                    _btnDown.css("cursor", "pointer").click(scrollUp).hover(autoStop, autoPlay);
                } else {
                    //非自动滚动
                    _btnUp.css("cursor", "pointer").click(scrollDown);
                    _btnDown.css("cursor", "pointer").click(scrollUp);
                }
            } else {
                //水平滚动
                if (auto) {
                    //自动滚动	
                    if (timer) { timerID = window.setInterval(scrollLeft, timer); }; 
                    _this.hover(autoStop, autoPlay_1).mouseout();
                    _btnUp.css("cursor", "pointer").click(scrollRight).hover(autoStop, autoPlay_1);
                    _btnDown.css("cursor", "pointer").click(scrollLeft).hover(autoStop, autoPlay_1);
                } else {
                    //非自动滚动
                    _btnUp.css("cursor", "pointer").click(scrollRight);
                    _btnDown.css("cursor", "pointer").click(scrollLeft);
                }
            }
        }
    })
})(jQuery);
