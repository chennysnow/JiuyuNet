/****************************************************************
*
*屏蔽网页js出错
*****************************************************************/
//window.onerror=function(){return true;}
///语言版本  1英语 0 中文
function getLan()
{
    return 1;
}

/*****************************************************************
* 功能：搜索提示字符串
* 参数：
elementId:要提示的元素id
text:提示文字
******************************************************************/
function initInputText(elementId, text) {
    var obj = $(elementId);
    if ($.trim(obj.val()) == "") {
        obj.val(text).css({ color: "#aaa" });
    }
    obj.focus(function () {
        if ($.trim(obj.val()) == text) {
            $(this).val("").css({ color: "#000" });
        }
    });
    obj.blur(function () {
        if ($.trim(obj.val()) == "") {
            $(this).val(text);

        }
    });
}

/*****************************************************************
* 功能：选择所有checkbox
* 参数：
elementId:触发全选事件的元素
obj:包含checkbox的容器
******************************************************************/
function checkAll(elementId, obj) {
    $("#" + elementId).click(function() {
        if ($(this).attr("checked")) {
            $(obj + " input[type=checkbox]").attr("checked", "true");
        } else {
            $(obj + " input[type=checkbox]").removeAttr("checked");
        }
    });
}

/*****************************************************************
*功能:获取dropDown的值 操作dropDrownLis
*参数:
elementId:触发dropDown的元素id
******************************************************************/
function changeDropDown(elementId)
{
$("#"+elementId).change(function() {
                var v = $("#"+elementId +" option:selected").val();
                var t = $("#"+elementId +" option:selected").text();
                 return v;
            });
}
/*****************************************************************
* 功能：测试元素的值是否为空
* 参数：
elementId:触发全选事件的元素
msg:提示信息
******************************************************************/
function isEmpty(elementId, msg) {
    if ($.trim($("#" + elementId).val()) == "") {
        $("#" + elementId).focus();
        alertC.show(msg, true);
        return false;
    } else {
        return true;
    }
}

/*****************************************************************
* 功能：判断字符串是否为Email格式
******************************************************************/
function isEmail(val) {
    if (/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(val)) {
        return true;
    } else {
        return false;
    }
}

/*****************************************************************
* 功能：收藏本页
******************************************************************/
function add_favorite() {
    var title = document.title;
    var url = window.location.href;
    if (document.all) {
        window.external.AddFavorite(url, title);
    } else if (window.sidebar) {
        window.sidebar.addPanel(title, url, "");
    }
}

/*****************************************************************
* 功能：设为首页
******************************************************************/
function set_first(url) {
    if (document.all) {
        document.body.style.behavior = 'url(#default#homepage)';
        document.body.setHomePage(url);
    }
    else if (window.sidebar) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
            }
        }
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
        prefs.setCharPref('browser.startup.homepage', url);
    }
}
/*****************************************************************
* 功能：设置文字大小
******************************************************************/
function doZoom(size) {
    zoom.style.fontSize = size + 'px';
}

/*****************************************************************
* 功能：获取日期星期
* 参数：
******************************************************************/
function today() {
    var now = new Date();
    var strDate = "";
    strDate += now.getYear() + "年" + (now.getMonth() + 1) + "月" + now.getDate() + "日";
    strDate += " 星期" + "日一二三四五六".split("")[now.getDay()];
    document.write(strDate);
}
/*****************************************************************
* 功能：左边主菜单
******************************************************************/
function left_menu(typ) {
    if (typ == null) {
        var url = window.location.href;
        if (url.indexOf("typ=") > 0) {
            url = url.substring(url.indexOf("typ=") + 4);
            var $inA = $("#menuId" + url);
            $inA.addClass("on");
            if ($inA.parents("dt").html() == null)//dt dd下标算在一起,所以/2
            {
                if ($inA.parents("dd").html() != null)
                {show = ($inA.parents("dd").index() - 1) / 2;}
                else
                { show = $inA.index() / 2;}
            }
            else
            { show = $inA.parents("dt").index() / 2; }
            $(".slider dd").eq(show).show();
            //            $dt.eq(show).addClass("dt_on");
            //            $dt.eq(show).css('cursor', 'default');
        }
    } else {
        var $inA = $("#menuId" + typ);
        $inA.addClass("on");
        if ($inA.parents("dt").html() == null)//dt dd下标算在一起,所以/2
        {
            if ($inA.parents("dd").html() != null)
                show = ($inA.parents("dd").index() - 1) / 2;
            else
                show = $inA.index() / 2;
        }
        else
        { show = $inA.parents("dt").index() / 2; }
        $(".slider dd").eq(show).show();
    }
//    var $dt = $('.slider dt');
//    var $dd = $('.slider dd');
//    var $inA = $(".slider a[href='" + window.location.href + "']");
//    $inA.css({ color: "#aa0000" });
//    var show = 0;
//    if ($inA.parents("dt").html() == null)//dt dd下标算在一起,所以/2
//        show = ($inA.parents("dd").index() - 1) / 2;
//    else
//        show = $inA.parents("dt").index() / 2;
//    $dd.eq(show).show();
//    $dt.eq(show).addClass("dt_on");
//    $dt.eq(show).css('cursor', 'default');
//    //单击事件
//    $dt.click(function () {
//        flag = $dt.index(this);
//        $dd.not($dd.eq(show)).slideUp();
//        $dd.eq(flag).slideDown();
//        $dt.eq(flag).css('cursor', 'default').addClass('dt_on');
//        $dt.not($dt.eq(flag)).css('cursor', 'pointer').removeClass('dt_on');
//    });
}
/*****************************************************************
* 功能：去外层边距
******************************************************************/
function clearMargin(row, count, css) {
    css = css == null ? "ulprodisplay" : css;
    count = parseInt(count / row);
    for (i = 1; i <= count; i++) {
        $("." + css + " li").eq((row * i) - 1).css("margin-right", "0px")
    }
}
/*****************************************************************
* 功能：对话框
******************************************************************/
var alertC = new function () {
    var alrCenter;
    var colseFlg = 0;
    this.show = function (str, flg) {
        $("body").append("<div class='showAlert' onclick='alertC.closeC()'><p class='close'><img src='/images/close.gif' onclick='alertC.closeC()' /></p><div class='content'>" + str + "</div><p class='tips'>Close window after 2 seconds!!</p></div>");
        var $alert = $(".showAlert");
        bodyH = $("body").height();
        bodyW = $("body").width();
        //document.title = bodyH + ",scroll:" + document.documentElement.scrollTop;
        bodyH = bodyH < 800 ? 800 : bodyH;
        h = document.documentElement.scrollTop + 300 - ($alert.height() / 2);
        w = (bodyW - $alert.width()) / 2;
        ///h = (bodyH -document.documentElement.scrollTop) / 2;
        $alert.css({ left: w, top: h });
        if (flg != null) {
            $("body").append("<div id='bigDiv'></div>"); //大div
            $("#bigDiv").css({ width: bodyW, height: bodyH, opacity: '0.5', background: '#000', position: 'absolute', left: '0', top: '0', zIndex: '999' });
        }
        alrCenter = setInterval("alertC.centerC()", 500);
    }
    this.centerC = function () {//始终在中间
        var $alert = $(".showAlert");
        h = document.documentElement.scrollTop + 300 - ($alert.height() / 2);
        w = (bodyW - $alert.width()) / 2;
        $alert.css({ left: w, top: h });
        if (colseFlg++ == 4)
            alertC.closeC();
    }
    this.closeC = function () {
        $("#bigDiv,.showAlert").remove();
        clearInterval(alrCenter);
        colseFlg = 0;
    }
}