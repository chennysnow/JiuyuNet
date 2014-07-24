var lan = getLan();
var CookName = "userCart";
var cartCount = 0; //总数量
//取得一个cookie的值
var cookies = new function () {
    this.GetExpDate = function (days, hours, minutes) { var expDate = new Date(); if (typeof (days) == "number" && typeof (hours) == "number" && typeof (hours) == "number") { expDate.setDate(expDate.getDate() + parseInt(days)); expDate.setHours(expDate.getHours() + parseInt(hours)); expDate.setMinutes(expDate.getMinutes() + parseInt(minutes)); return expDate.toGMTString(); } }
    this.get = function (name) { if (name == "undefined" || name == null || name == "") { name = CookName; } var ck = document.cookie; var exp1 = new RegExp(name + "=.*?(?=;|$)"); var mch = ck.match(exp1); return mch ? decodeURIComponent(mch[0].substring(name.length + 1)) : null; }
    //name   Cookie名称　value  Cookie值　expires 时间 path　能被访问的路径 domain　能被访问的域名 secure传送是否加密两个值：空,secure
    this.set = function (value, name, expires, path, domain, secure) {
        if (name == "undefined" || name == null || name == "")//默认用cookName
        { name = CookName; }
        var expDate = new Date();
        expDate.setHours(expDate.getHours() + 24);
        document.cookie = name + "=" + escape(value) +
            ((expires) ? "; expires=" + expires : ";expires=" + expDate.toGMTString()) +
            (";path=/") +
            ((domain) ? "; domain=" + domain : "") +
            ((secure) ? "; secure" : "");
    }
    //删除一个cookie(使cookie过期)
    this.del = function (name, path, domain) {
        if (name == "undefined" || name == null || name == "")//默认用cookName
        { name = CookName; }
        if (this.get(name)) {
            document.cookie = name + "=" +
                ("; path=/") +
                ((domain) ? "; domain=" + domain : "") +
                "; expires=Thu, 01-Jan-70 00:00:01 GMT";
        }
    }
}

function read() {
    var ck = cookies.get();
    var count = 0;
    if (ck!=""&&ck != "0" && ck != null)//去null操作
    {
        arr = ck.split("@");
        for (var i = 0; i < arr.length; i++) {
            var arrHash = arr[i].split("|");
            count += parseInt(arrHash[1]);
        }
    }
    $("#cartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
    $("#OncartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
}
read(); //加载
welcome();

/////////////////加入购物车//修改数量//////////////////
function addCart(id, num) {//直接购物车修改
    num = num < 1 ? 1 : num;
    var ck = cookies.get();
    var arr = new Array();
    var flg = true;
    var count = num;
    //alert(ck + "," + num);
    if (ck!=""&& ck != "0" && ck != null)//去null操作
    {
        arr = ck.split("@");
        for (var i = 0; i < arr.length; i++) {
            var arrHash = arr[i].split("|");
            count += parseInt(arrHash[1]);
            if (arrHash[0] == id)//判断是否存在
            {
                arrHash[1] = parseInt(arrHash[1]) + parseInt(num);
                flg = false;
                arr[i] = arrHash.join("|");
            }
        }
    }
    if (flg) {
        arr.push(id + "|" + num);
    }
    cookies.set(arr.join("@"));
    if (lan == 1)
        alertC.show("Successfully add!",true);
    else
        alertC.show("添加成功!",true);
    $("#cartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
    $("#OncartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
}
///////////产品页添加
function addCart_pro(id, num, flgUrl) {
    if (num < 1)
        return; 
    var ck = cookies.get();
    var arr = new Array();
    var flg = true;
    var count = parseInt(num);
    //alert(ck + "," + num);
    if (ck != "0" && ck != null)//去null操作
    {
        arr = ck.split("@");
        for (var i = 0; i < arr.length; i++) {
            var arrHash = arr[i].split("|");
            count += parseInt(arrHash[1]);
            if (arrHash[0] == id)//判断是否存在
            {
                if (flgUrl != 2)//在购物车页就直接修改  不需要累加
                    arrHash[1] = parseInt(arrHash[1]) + parseInt(num);
                else
                    arrHash[1] = num;
                flg = false;
                arr[i] = arrHash.join("|");
            }
        }
    }
    if (flg) {
        arr.push(id + "|" + num);
    }
    cookies.set(arr.join("@"));
    if (flgUrl == 0) {//判断是否是立即购买
        if (lan == 1)
            alertC.show("Successfully add!",true);
        else
            alertC.show("添加成功!",true);
        $("#cartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
        $("#OncartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
    }
    else
        if (flgUrl == 1) {//立即购买
            window.location.href = "/order/Shopping.aspx";
        }
        else
            if (flgUrl == 2) {//购物车页
                $("#cartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
                $("#OncartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
            }
    
}
///////////////////////删除一个产品///////////////////
function delCart(id)//删除一个产品  value id
{
    var ck = cookies.get();
    var arr = ck.split("@");
    for (var i = 0; i < arr.length; i++) {
        var arrHash = arr[i].split("|");
        if (arrHash[0] == id)//判断是否存在
        {
            arr.splice(i, 1); //删除一个元素
        }
    }

    if (arr == null || arr.length == 0)
    { ClearCookie(); }
    else
        cookies.set(arr.join("@"));
    $("#" + id + "").remove(); //移除当前删除的dome
    if (lan == 1)
        alert('Deleted successfully!');
    else
        alert("删除成功!");
    cartAllPrice();
}
function ClearCookie() {
    cookies.del();
    return true;
}
function addCart_shopping(id, obj) {
    var count = $(obj).val();
    var price = "0";
    addCart_pro(id, count, 2);
    $.get("/ajax/ajax.ashx", { action: "getPrice", id: id, count: count },//获取区间价格
      function (data) {
          price = data;
          $("#price" + id + "").html(data); //更新基础价格
          var total = count * parseFloat(price);
          $("#total" + id + "").html(parseInt(total * 100) / 100);
          cartAllPrice();
      });
}
//////////////////////////////+ -号
function up() {
    var a = $("#txtNum").attr("value");
        $("#txtNum").attr("value", ++a);
}
function down() {
    var a = $("#txtNum").attr("value");
    if (a > 1)
        $("#txtNum").attr("value", --a);

}
//$("#txtNum").blur(function () {
//    if (parseInt($("#txtNum").attr("value")) > parseInt($("#stock").attr("value"))) {
//        alertC.show("库存不够!", true);
//        $("#txtNum").val(1);
//    }
//})
function txtNubm() {
    //var a = $("#txtNum").attr("value");
   // if (parseInt(a) <= parseInt($("#stock").attr("value"))) {
        return $("#txtNum").attr("value");
  //  }
//    else {
//        alertC.show("库存不够!", true);
//        window.location.href = window.location.href;
//        return $("#stock").attr("value");
//    }
}
///////////////////////购物车总信息
function cartAllPrice() {
    var $price = $(".repTable [class=total]");
    var $count = $(".repTable .count");
    var $weight = $(".repTable [class=weight]");
    var price = 0, count = 0, weight = 0;
    for (var i = 0; i < $price.length; i++) {
        price += parseFloat($($price[i]).html());
        count += parseInt($($count[i]).val());
        weight += parseFloat($($weight[i]).html()) * parseInt($($count[i]).val());
    }
    weight = parseInt(weight * 1000) / 1000;
    price = parseInt(price * 100) / 100;
    $("#cartProInfo").html("<b>Total</b><br/>      weight: <span>" + weight + " Kg</span><br/>QTY: <span>" + count + "</span><br/>Price: <span>$" + price + "</span>");

    $("#cartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
    $("#OncartCount").html("Item(s)&nbsp;<span class='price'>" + count + "</span>");
}
////////////////////////////Welcome
function addFav(id) {
    val = cookies.get("favName");
    if (val != "0" && val != null)//去null操作
    {
        arr = val.split(",");
        if (arr.length >= 20)
            return alertC.show("最多只能收藏20个产品!", true); //如果超限就返回
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == id)//判断是否存在
            {
                return alertC.show("已加入收藏!", true); //如果存在就返回
            }
        }
        arr.push(id);
        val = arr.join(",");
    }
    else
        val = id;
    alertC.show("加入成功!", true);
    cookies.set(val,"favName");
}
function delFav(id) {
    val = cookies.get("favName");
    if (val != "0" && val != null)//去null操作
    {
        arr = val.split(",");
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == id)//判断是否存在
            {
                arr.splice(i, 1); //删除一个元素
                break;

            }
        }
        val = arr.join(",");
        alertC.show("删除成功!", true);
        cookies.set(val,"favName");
        window.location.href = window.location.href;
    }
}
function welcome() {
    var name = cookies.get("userName");
    if (name != null) {
        $("#loginInfo").html(name + " Welcome to back!   <a href='/user/user.aspx'><b>My Account</b></a>");
        $("#OnloginInfo").html(name + " Welcome to back!   <a href='/user/user.aspx'><b>My Account</b></a>");
    }
}