var file = 1;
//添加更多图片
function addFile() {
    fileid = file;
    $("#btnAddFilePic").after("<br/>&nbsp;<input type=\"text\" name=\"sonImg\" id=\"sonImg" + fileid + "\" style=\"width:300px\" /><input type=\"button\" value=\"浏 览\" onclick=\"BrowseServer('sonImg" + fileid + "');\" />");
    file = file + 1;
}
function delPriCount(index) {
    var priCount = parseInt($("#priCount").val()); //价格区间
    $("div").remove("#price" + (index) + "");
    $("#priCount").val(priCount-1);
}
function addPrice() {
    var priCount = parseInt($("#priCount").val()); //价格区间
    var min
    if ($("#txtMax" + (priCount - 1)).val() != "") {
       min= parseInt($("#txtMax" + (priCount - 1)).val()) + 1;
    }
    else
        min = "";
    $("#price" + (priCount - 1) + "").after("<div id='price" + priCount + "'>" + (priCount + 1) + ":<input type='text' name='txtMin" + priCount + "' id='txtMin" + priCount + "' value='" + min + "' />--<input type='text' name='txtMax" + priCount + "' id='txtMax" + priCount + "' />价格:<input type='text' name='txtPrice" + priCount + "' id='txtPrice" + priCount + "' />交货:<input type=\"text\" name=\"txtDay" + priCount + "\" id=\"txtDay" + priCount + "\" value=\"3 Days\" />&nbsp;&nbsp;<span style='cursor:pointer;' onclick='delPriCount(" + priCount + ")'>删除</span></div>");
    $("#priCount").val(priCount + 1);
    $("#price" + (priCount - 1) + "").focus();
}

function isEmpty(elementId, msg) {
    if ($.trim($("#" + elementId).val()) == "") {
        $("#" + elementId).focus();
        alert(msg);
        return false;
    } else {
        return true;

    }
}

function addPro() {
    if ($("#ctl00_content_ddlNewsType").val() == 0) {
        alert("请选择类别！"); $("#ctl00_content_ddlNewsType").focus(); return false;
    }
    //    for(var i=0;i<price;i++)
    //    {
           if(!isEmpty("txtMin0","最小区间不能为空")) return false;
           if(!isEmpty("txtMax0","最大区间不能为空")) return false;
           if(!isEmpty("txtPrice0","价钱不能为空")) return false;
    //    }
    if (!isEmpty("ctl00_content_txtName", "产品标题不能为空")) return false;
    //  if(!isEmpty("ctl00_ContentPlaceHolder1_txtStock","库存不能为空")) return false;
    //  if(!isEmpty("ctl00_ContentPlaceHolder1_txtWeight","重量不能为空")) return false;
    if (!isEmpty("fileImg", "主图片必须上传")) return false;

}
var showAttrFlg = true;
function showAttr() {
    if (showAttrFlg) {
        $(".trSelect").css("display", "block");
        showAttrFlg = false;
    }
    else {
        $(".trSelect").css("display", "none");
        showAttrFlg = true;
    }
}
//时间
setInterval("$('#time').html(new Date().getFullYear()+'年'+(parseInt(new Date().getMonth())+1)+'月'+new Date().getDate()+'日 '+new Date().getHours()+':'+new Date().getMinutes()+':'+new Date().getSeconds()+' 星期'+'日一二三四五六'.charAt(new Date().getDay()));", 1000);
/////////////////////////////////////////////后台导航部分
$(".ul_menu .pre").hover(function () {
    html = $(this).next("ul").html();
    $("#showMenu ul").html(html);
    $("#showMenu ul").css({ left: $(this).offset().left - $(".h").offset().left - 40 }).fadeIn(500);
    //alert($(".h").offset().left);
    // $("#showMenu").html($clone);
});
$("#showMenu ul").html($(".ul_menu ul").eq(0).html()).css({ dispaly: "", left: 0 });
/*****************************************************************
* 功能：对话框
******************************************************************/
var alertC = new function () {
    var alrCenter;
    var colseFlg = 0;
    this.show = function (str, flg) {
        $("body").append("<div class='showAlert' onclick='alertC.closeC()'><p class='close'><img src='/images/close.gif' onclick='alertC.closeC()' /></p><div class='content'>" + str + "</div><p class='tips'>2秒种后关闭此窗口!!</p></div>");
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
////////////////////词库管理部分
function allKey(afterIid, setId) {
    var $allkey = $("#allKey");
    if ($allkey.html() == null) {
        $.ajax({
            type: 'POST',
            beforeSend:
            function () { },
            url: '../ajax/get.ashx',
            data: "typ=getAllKey",
            dataType: 'html',
            error: function () { alert("Network error, please try again later!!"); window.location.href = window.location.href; },
            success: function (str) {
                var allKey = str.split(',');
                str = "";
                for (i = 0; i < allKey.length; i++) {
                    str += "<span>" + allKey[i] + "</span>&nbsp;|&nbsp;";
                }
                $(afterIid).after("<div id='allKey'><div class='close'><b>Close</b>&nbsp;双击选择关键词</div>" + str + "</div>");
                $allkey = $("#allKey");
                $allkey.css({ position: "absolute", left: $(afterIid).offset().left, width: "400px", height: "300px", backgroundColor: "#000", padding: "0px 10px", border: "2px solid #ddd", color: "#fff", overflow: "auto", opacity: 0.8 });
                $allkey.find(".close").css({ backgroundColor: "#fff", color: "#000", cursor: "pointer", height: "20px", lineHeight: "20px", textAlign: "center", marginBottom: "5px" }).click(function () {
                    $allkey.fadeOut(200);
                });
                $allkey.find("span").css({ display: "inline-block", margin: "0px 0px 5px 0px" }).dblclick(function () {
                    $("#" + setId).val($("#" + setId).val() + $(this).html() + " ");
                });
            }
        })
    }
    else {
        $allkey.fadeIn(500);
    }
}
//////////检测静态名称是否存在
function htmlName(obj,id) {
    $.ajax({
        type: 'POST',
        beforeSend:
            function () { },
        url: '../ajax/get.ashx',
        data: "typ=htmlName&htmlName=" + $("#" + id).val(),
        dataType: 'html',
        error: function () { alert("Network error, please try again later!!"); window.location.href = window.location.href; },
        success: function (str) {
            $(obj).after("<b>" + str + "</b>");
        }
    });
}