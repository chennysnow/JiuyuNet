function MessageVerify()
{
    var lan=getLan();
    if(!isEmail($("#txtEmail").val())||$("#txtEmail").val()=='')
    {
        alert("Please enter a valid email");
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
            url:'ajax/message.ashx',
            data:"name="+$("#txtName").val()+"&email="+$("#txtEmail").val()+"&content="+$("#txtContent").val()+"&code="+$("#txtCode").val()+"&img="+$("#inquiryImg").val(),
            dataType:'html',
            error:function(){ alert("Network error, please try again later!!");window.location.href=window.location.href;},
            success:function(strHtml){
                if(strHtml!=''){
                    alert(strHtml);
                     window.location.reload(); 
                }
            }
        })
}