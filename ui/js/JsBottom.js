//$("input[type='text']").focus(function () {
//    $(this).addClass("input_border");
//}).blur(function () { $(this).removeClass("input_border"); });
read();
function read()
{
    online();
    onlogin();
}
function showTime()
{
 var now=new Date();
 var year=now.getYear();
 var month=now.getMonth()+1;
 var day=now.getDate();
 var hours=now.getHours();
 var minutes=now.getMinutes();
 $("#time").html(""+year+"/"+month+"/"+day);
 }
 //在线聊天
 function online() {
     $("#online").hover(function () {
         $("#online_menu").css({ display: "none" });
         $("#online_content").css({ display: "block" });
     }, function () {
         $("#online_menu").css({ display: "block" });
         $("#online_content").css({ display: "none" })
     });
     setInterval("online_top()", 500);
 }
 function onlogin() {
     $("#onLogin").hover(function () {
         $("#onLogin_menu").css({ display: "none" });
         $("#onLogin_content").css({ display: "block" });
     }, function () {
         $("#onLogin_menu").css({ display: "block" });
         $("#onLogin_content").css({ display: "none" })
     });
     setInterval("online_top()", 500);
 }
 function online_top() {
     var h = (document.documentElement.scrollTop || document.body.scrollTop) + 200;
     $("#online").animate({ top: h }, { queue: false, duration: 500 });
     $("#onLogin").animate({ top: h }, { queue: false, duration: 500 });
 }

/*///////////////////////////搜索*/
 initInputText("#seaKey", "Enter keywords");
 $("#seaKey").keydown(function (event) {
        var keyCode = event.which || event.keyCode//ff兼容
        if (keyCode == 13) {
            search();
        }
    });
function search() {
    var stxt = $.trim($("#seaKey").val());
    var typ=$("#seaType").val();
    if (stxt == "" || stxt == "Enter keywords") {
        alert("Enter keywords to search !");
        window.location.href = window.location.href;
        return false;
    }
    window.location.href = "/ProSearch.html?typ=" + typ + "&Search=" + stxt + "";
    return false;
}
/*///////////////////////////友情链接*/
function youqin(){
    if($("#youqin").val()!="0")
    {
        window.location.href=$("#youqin").val();
    }
}
 function loginOut() {
     var expDate = new Date();
     expDate.setDate(expDate.getYear() - 1);
     document.cookie = "userName=" + "; expires=" + expDate.toGMTString()+";path=/;";
   //  alert(document.cookie.toString());
     window.location.href = "/index.aspx";
 }

 /////////////////////////////////////验证码图片
 $(".validate").focus(function () {
     $(this).after(" <img src=\"/ajax/validate.ashx?count=5\"  onclick=\"this.src='/ajax/validate.ashx?count=5&t=' + new Date().getTime()\" class='imgValidate' alt='验证码,单击刷新' />").unbind();
 });
 function regMail() {
     if ($("#sendMail").val() != "") {
         $.get("/ajax/ajax.ashx", { action: "regMail", mail: $("#sendMail").val() }, function () { alertC.show("Thank you for your attention!",true); });
         
     }
     else {
         alertC.show("The E-mail can not be empty!",true);
     }
     return false;
 }
 function getBackgroud(page) {
     var li = document.getElementById(page);
     li.className = "";
     li.className = "dark";
 }
