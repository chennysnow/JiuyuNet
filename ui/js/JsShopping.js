//提交订单验证
function validate() {
    if (!isEmail($("#mailC").val()) || $("#mailC").val() == '') {
        alertC.show("Please enter correct E-mail!!");
        return false;
    }
    if (!isEmpty("nameC", "Please enter name")) return false;
    if (!isEmpty("telC", "Please enter Tel")) return false;
    if (!isEmpty("addressC", "Please enter address")) return false;
    if ($("#selectPlace").val() == 0) {
        alertC.show("Please select country!");
        return false;
    }
    $express = $("#express input[type=radio]");
    flg = true;
    for (var i = 0; i < $express.length; i++) {
        if ($($express[i]).attr("checked")) {
            flg = false;
        }
    }
    if (flg) {
        alertC.show("Please select shipping methoed!");
        return false;
    }
    $payment = $("#payment input[type=radio]");
    flg = true;
    for (var i = 0; i < $payment.length; i++) {
        if ($($payment[i]).attr("checked")) {
            flg = false;
        }
    }
    if (flg) {
        alertC.show("Please select shipping payment!");
        return false;
    }
}

$("#selectPlace").change(function () {
    var id = $(this).val();
    if (id != 0) {
        //$("#addressC").val(this.options[this.selectedIndex].text + ",");
        $.getJSON("/ajax/ajax.ashx", { action: "expPrice", id: id }, function (json) {
            var $radio = $("#express input[type=radio]"); //快递ID

            for (j = 0; j < $radio.length; j++) {
                var index = $($radio[j]).val();

                $("#express .first_price")[j].innerHTML = "";
                $("#express .last_price")[j].innerHTML = "";

                $.each(json, function (i, item) {
                    if (index == item.id) {
                        $("#express .first_price")[j].innerHTML = "<font>first :$" + item.price + " </font>";
                        $("#express .last_price")[j].innerHTML = "<font>second :$" + item.price1 + " </font>";
      
                    }
                });
            }
        })
    }
    else {
        alertC.show("Please select country!");
    }

});
function payment(id) {
    window.location.href = "/Shopping/payment/" + id;
}