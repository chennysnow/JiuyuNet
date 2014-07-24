function getByClass(oParent, sClass)
{
	var aEle=oParent.getElementsByTagName('*');
	var aTmp=[];
	var i=0;
	
	for(i=0;i<aEle.length;i++)
	{
		if(aEle[i].className==sClass)
		{
			aTmp.push(aEle[i]);
		}
	}
	
	return aTmp;
}
$(function ()
{
    $("#jiuyuEnlarge").append("<span class='enlarge_mark'></span><span class='enlarge_float_layer'></span>");
    $("#jiuyuEnlarge").append("<div class='enlarge_big_pic'><img  /> </div>");//把放大的图片加载进去
	var oDiv=document.getElementById('jiuyuEnlarge');
	var oMark=getByClass(oDiv, 'enlarge_mark')[0];
	var oFloat=getByClass(oDiv, 'enlarge_float_layer')[0];
	var oBig=getByClass(oDiv, 'enlarge_big_pic')[0];
	var oImg=oBig.getElementsByTagName('img')[0];
	
	oBig.style.left=oDiv.offsetWidth;//设置放大的图片与图片的距离
	$(".enlarge_mark").width(oDiv.offsetWidth);//初始化移动区域
	$(".enlarge_mark").height(oDiv.offsetHeight);
	oMark.onmouseover=function ()
	{
	    $(".enlarge_mark").width(oDiv.offsetWidth);//初始化移动区域
	    $(".enlarge_mark").height(oDiv.offsetHeight);
		oFloat.style.display='block';
		oBig.style.display='block';
		oFloat.style.width=oDiv.offsetWidth/4+"px";//放大镜框为图片的4/1
	    oFloat.style.height=oDiv.offsetWidth/4+"px";
	    $(".enlarge_big_pic").find("img").attr("src",$("#jiuyuEnlarge").attr("large"));//把放大的图片加载进去
	};
	oMark.onmouseout=function ()
	{
		oFloat.style.display='none';
		oBig.style.display='none';
	};
	
	oMark.onmousemove=function (ev)
	{
		var oEvent=ev||event;//防止事件为空
		var l=oEvent.clientX-oDiv.offsetLeft-oFloat.offsetWidth/2;//odiv.offsetLeft是相对浏览边的距离
		var t = oEvent.clientY - oDiv.offsetTop - oFloat.offsetHeight / 2 + document.documentElement.scrollTop + document.body.scrollTop; //document.documentElement.scrollTop+document.body.scrollTop兼容谷歌,IE,FF
		//document.title="X:"+l+"Y:"+t;
		//document.documentElement.scrollTop;加上滚动条的位置
		if(l<0)//限制左边不出区域
		{
			l=0;
		}
		else if(l>oMark.offsetWidth-oFloat.offsetWidth)//限制右边不出区域   其实就是DIV的宽度
		{
			l=oMark.offsetWidth-oFloat.offsetWidth;
		}
		
		if(t<0)//限制上边不出区域
		{
			t=0;
		}
		else if(t>oMark.offsetHeight-oFloat.offsetHeight)//限制下边不出区域
		{
			t=oMark.offsetHeight-oFloat.offsetHeight;
		}
		oFloat.style.left=l+'px';//放大镜的位置
		oFloat.style.top=t+'px';
		var percentX=l/(oMark.offsetWidth-oFloat.offsetWidth);//移动的比例
		var percentY=t/(oMark.offsetHeight-oFloat.offsetHeight);
		
		oImg.style.left=-percentX*(oImg.offsetWidth-oBig.offsetWidth)+'px';//大图片移动
		oImg.style.top=-percentY*(oImg.offsetHeight-oBig.offsetHeight)+'px';
	};
});