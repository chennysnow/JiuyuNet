var $rn = $("#ctl00_ContentPlaceHolder1_reg_name");
var $rm = $("#ctl00_ContentPlaceHolder1_reg_mail");
var $rp1 = $("#ctl00_ContentPlaceHolder1_reg_pass1");
var $rp2 = $("#ctl00_ContentPlaceHolder1_reg_pass2");
var $rk = $("#ctl00_ContentPlaceHolder1_reg_key");
function getLan()
{
    return 1;
}

$rn.keyup(function(){
	checkUser($rn.val());
})
$rm.keyup(function(){
	checkMail();
})
$rp1.keyup(function(){
	checkPass1();
})
$rp2.keyup(function(){
	checkPass2();
})
function Login() {
    if ($.trim($("#ctl00_ContentPlaceHolder1_Login_name").val()) == "") {
	    switch(getLan()){
		    case 0:
		    alert("请填写用户名");
		    break
		    case 1:
		    alert("Please enter a user name");
		    break
	    }
$("#ctl00_ContentPlaceHolder1_Login_name").focus();
	    return false;
    }
	if ($.trim($("#ctl00_ContentPlaceHolder1_Login_pass").val()) == "") {
	    switch(getLan()){
		    case 0:
		    alert("请填写密码");
		    break
		    case 1:
		    alert("Please enter a Password");
		    break
	    }
$("#ctl00_ContentPlaceHolder1_Login_pass").focus();
	    return false;
    }
    return true;
}
//用户注册格式校验
function check(){
	if($.trim($rn.val())==""){
		switch(getLan()){
			case 0:
			alert("请填写用户名");
			break
			case 1:
			alert("Please enter a user name");
			break
		}
		$rn.focus();
		return false;
	}
	/*
	if(!isName($.trim($rn.val()))){
		switch(getLan()){
			case 0:
			alert("请用字母，数字，下划线的组合，必须以字母开头");
			break
			case 1:
			alert("Please use letters, numbers, underscores the combination, you must start with a letter");
			break
		}
		return false;
	}
	*/
	if($.trim($rn.val()).length<4 || $.trim($rn.val()).length>20){
		switch(getLan()){
			case 0:
			alert("用户名长度4-20个字符");
			break
			case 1:
			alert("User name length 4-20 characters");
			break
		}
		$rn.focus();
		return false;
	}
	if($.trim($rm.val())==""){
		switch(getLan()){
			case 0:
			alert("请填写您的邮箱地址");
			break
			case 1:
			alert("Please enter a user Email");
			break
		}
		$rm.focus();
		return false;
	}
	if(!isMail($.trim($rm.val()))){
		switch(getLan()){
			case 0:
			alert("请检查您的邮箱格式");
			break
			case 1:
			alert("Please enter a valid email address");
			break
		}
		$rm.focus();
		return false;
	}
	if($.trim($rp1.val())==""){
		switch(getLan()){
			case 0:
			alert("请填写密码");
			break
			case 1:
			alert("Please enter a Password");
			break
		}
		$rp1.focus();
		return false;
	}
	if($.trim($rp1.val()).length<4){
		switch(getLan()){
			case 0:
			alert("密码不得小于4位");
			break
			case 1:
			alert("User name Password minimum length 4");
			break
		}
		$rp1.focus();
		return false;
	}
	if($.trim($rp2.val())==""){
		switch(getLan()){
			case 0:
			alert("请再次填写密码");
			break
			case 1:
			alert("Please re-enter your password");
			break
		}
		$rp2.focus();
		return false;
	}
	if($.trim($rp1.val())!=$.trim($rp2.val())){
		switch(getLan()){
			case 0:
			alert("俩次输入的密码不相同，请检查");
			break
			case 1:
			alert("Both times the password is not the same as");
			break
		}
		$rp1.focus();
		return false;
	}
	if($.trim($rk.val())==""){
		switch(getLan()){
			case 0:
			alert("请填写验证码");
			break
			case 1:
			alert("Please enter the code");
			break
		}
		$rk.focus();
		return false;
	}
	/*if($("#isck").val()=="false"){
		switch(getLan()){
			case 0:
			alert("请点击"检测用户名"按钮检查用户名是否可用");
			break
			case 1:
			alert("Please click 'check' button, check the user name exists");
			break
		}
		return false;
	}*/
	
}
//检查会员是否存在
function checkUser(name){
	if($.trim($rn.val())==""){
		$rn.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_name")
		return false;
	}
	if($.trim($rn.val()).length<4 || $.trim($rn.val()).length>20){
		$rn.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_name")
		return false;
	}
	$rn.val($rn.val().replace(/[^\w\.\/]/ig,''));//只能是字母数字下划线
	showRight("ctl00_ContentPlaceHolder1_reg_name");		
//	$.post("ajax/ckuser.aspx",{rn:name},function(data){
//		if(data=='0'){
//			showRight("reg_name")
//		}else if(data=='1'){
//			$rn.focus();
//			showWrong("reg_name")
//			return false
//		}												 
//	});
}
//检查邮箱格式
function checkMail(){
	if($.trim($rm.val())==""){
		$rm.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_mail")
		return false;
	}
	if(!isMail($.trim($rm.val()))){
		$rm.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_mail")
		return false;
	}else{
    showRight("ctl00_ContentPlaceHolder1_reg_mail")
	}	
}
//密码1
function checkPass1(){
	if($.trim($rp1.val()).length<4){
		$rp1.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_pass1")
		return false;
	}else{
    showRight("ctl00_ContentPlaceHolder1_reg_pass1")
	}
}
//密码2
function checkPass2(){
	if($.trim($rp2.val()).length<4){
		$rp2.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_pass2")
	}
	if($.trim($rp2.val())!=$.trim($rp1.val())){
		$rp2.focus();
		showWrong("ctl00_ContentPlaceHolder1_reg_pass2")
	}else{
    showRight("ctl00_ContentPlaceHolder1_reg_pass2")
	}
}
//显示状态
function showWrong(input){
	var str='<span style="color:#F00;font-weight:bold;">×</span>';
	$obj=$("#"+input);
	if($obj.next().size()!=0){
		$obj.next().html(str);
	}else{
		$obj.after(str);
	}
}
function showRight(input){
	var str='<span style="color:#0C0;font-weight:bold;">√</span>';
	$obj=$("#"+input);
	if($obj.next().size()!=0){
		$obj.next().html(str);
	}else{
		$obj.after(str);
	}
}
