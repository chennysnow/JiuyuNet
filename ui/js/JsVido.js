//修改密码
function EditPass()
{
    var lan=getLan();
    if(lan==1)
    {
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtOldPass","PassWord Is Not Null")) return false;
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtPass1","PassWord Is Not Null")) return false;
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtPass2","Re-PassWord Is Not Null")) return false;
       //if(!isEmpty("txtEditCode","Code Is Not Null")) return false;
    }
    else
    {
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtOldPass","密码不能为空")) return false;
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtPass1","新密码不能为空")) return false;
       if(!isEmpty("ctl00_ContentPlaceHolder1_txtPass2","重复密码不能为空")) return false;
     //  if(!isEmpty("txtEditCode","验证码不能为空")) return false;
    }
    if($("#ctl00_ContentPlaceHolder1_txtPass1").val()!=$("#ctl00_ContentPlaceHolder1_txtPass2").val())
    {
        if(lan==1)
            alert("The Re-PassWord is Error!");
            else
            alert("重复密码错误!");
        return false;
    }
    return true;
}
function peoInfoVadio()//购物车地址
{
     var lan=getLan();
    if(!isEmail($("#ctl00_ContentPlaceHolder1_txtEmail").val())||$("#ctl00_ContentPlaceHolder1_txtEmail").val()=='')
    {
        if(lan==1)
            alert("Please enter a valid email");
            else
            alert("请输入正确的邮箱！");
          return false;
    }
  if(lan==1)
    {
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtName","Name Is Not Null!")) return false;
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtTel","Tel Is Not Null!")) return false;
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtAdd","Address Is Not Null!")) return false;
    }
    else
    {
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtName","姓名不能为空!")) return false;
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtTel","电话不能为空!")) return false;
        if(!isEmpty("ctl00_ContentPlaceHolder1_txtAdd","地址不能为空!")) return false;
     // if(!isEmpty("txtCode","验证码不能为空")) return false;
    }
   if($("#ctl00_ContentPlaceHolder1_dropPlace").val()==0)
    {   
        if(lan==1)
            alert("Please select Country!");
            else
            alert("请选择省!");
        return false;
    }
    if($("#ctl00_ContentPlaceHolder1_dropCity").val()==0)
    {   
        if(lan==1)
            alert("Please select place!");
            else
            alert("请选择市!");
        return false;
    }
    return true;
}
//////////////意见与建议
function vadio()
{
    var lan=getLan();
    if(!isEmail($("#txtEmail").val())||$("#txtEmail").val()=='')
    {
        if(lan==1)
            alert("Please enter a valid email");
            else
            alert("请填写正确的邮箱");
          return false;
    }
  if(lan==1)
    {
       if(!isEmpty("txtName","Name Is Not Null")) return false;
       if(!isEmpty("txtCode","Code Is Not Null")) return false;
    }
    else
    {
       if(!isEmpty("txtName","姓名不能为空")) return false;
       if(!isEmpty("txtCode","验证码不能为空")) return false;
    }
     $.ajax({
            type:'POST',
            beforeSend:
            function(){},
            url:'/ajax/message.ashx',
            data:"name="+$("#txtName").val()+"&email="+$("#txtEmail").val()+"&content="+$("#txtContent").val()+"&code="+$("#txtCode").val()+"&img="+$("#inquiryImg").val(),
            dataType:'html',
            error:function(){ alert("Network error, please try again later!!");window.location.href=window.location.href;},
            success:function(strHtml){
                if(strHtml!=''){
                    alert(strHtml);
                    window.location.href=window.location.href;
                }
            }
        })
}