
var count=0;//总数标志
var i=0;//当前标志
var $Info=$("#Info");
var flg=null;
var pageSize=20;
function List(typ,typ_list,info)
{
    count=0;
    i=0;
    $.ajax({
            type:"POST",
            url:"Ajax_web.ashx?t=" + new Date().getTime(),
            data:"typStatic="+typ,
            success:function(p)
            {
                count=p;
                $Info.prepend("<hr/><b>"+info+"</b>:总共有:"+p+"个菜单 正在生成第一个");       
                ListFor(typ_list);
              },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });  
}
function ListFor(typ_list)
{
     $.ajax({
               type:"POST",
               url:"Ajax_web.ashx?t=" + new Date().getTime(),
               data:"typStatic="+typ_list+"&menu="+i+"",
               success: function(data)
                {
                    $Info.prepend("<br/>"+data);
                    if(++i<count)
                        {ListFor(typ_list);}
                },
                error:function(){ $Info.prepend("网络延时,请稍后重试！");}
            });  
}    
function products()
{   
    i=0;
       $.ajax({
            type:"POST",
            url:"Ajax_pro.ashx?t=" + new Date().getTime(),
            data:"typStatic=ProCount",
            success:function(p)
            {
                if (p%pageSize==0)
                    {
                         count =p/pageSize;
                    }
                    else
                    {
                        count =parseInt(p/pageSize)+1;
                    }
                $Info.prepend("<hr/><b>产品生成</b>:总共有:"+p+"条产品信息..共分"+count+"批 ");   
                 proFor();                 
              },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });    
}
function proFor()
{
 $.ajax({
            type:"POST",
            url:"Ajax_pro.ashx?t=" + new Date().getTime(),
            data:"typStatic=CreatPro&page="+i+"",
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
                if(++i<count)
                   {proFor();}
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function News()
{
$Info.prepend("<hr/><b>新闻页生成</b>");
 $.ajax({
           type:"POST",
            url:"Ajax_New.ashx?t=" + new Date().getTime(),
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function web(typ)
{
 $Info.prepend("<b>←正在生成</b><hr/>");
 $.ajax({
            type:"POST",
            url:"Ajax_web.ashx?t=" + new Date().getTime(),
            data:"typStatic="+typ+"",
            success:function(p)
            {
                $Info.prepend("<br/>" + p);
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
/*//////////////////////////////////////整站生成*/
function all() {
    sitMap();
  //NewListIndex('ProMenuCount','CreatProList','产品列表生成');
}
function sitMap() {
    $Info.prepend("←站点地图正在生成<hr/>");
    $.ajax({
        type: "POST",
        url: "Ajax_web.ashx?t=" + new Date().getTime(),
        data: "typStatic=sitmap",
        success: function (p) {
            $Info.prepend("<hr/><font style='color:red'>站点地图生成成功!</font>");
            NewsIndex();
        },
        error: function () { $Info.prepend("网络延时,请稍后重试！"); }
    });  
}
      
function productsIndex()
{   
    i=0;
       $.ajax({
            type:"POST",
            url:"Ajax_pro.ashx?t=" + new Date().getTime(),
            data:"typStatic=ProCount",
            success:function(p)
            {
                if (p%pageSize==0)
                    {
                        count =p/pageSize;
                    }
                    else
                    {
                        count =parseInt(p/pageSize)+1;
                    }
                $Info.prepend("<b>产品生成</b>:总共有:"+p+"条产品信息..共分"+count+"批<hr/> ");   
                 proForIndex();                 
              },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });    
}
function proForIndex()
{
 $.ajax({
            type:"POST",
            url:"Ajax_pro.ashx?t=" + new Date().getTime(),
            data:"typStatic=CreatPro&page="+i+"",
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
                if(++i<count)
                   {proForIndex();}
                   else
                   webIndex();
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function NewsIndex()
{
$Info.prepend("<b>新闻页生成</b><hr/>");
 $.ajax({
           type:"POST",
            url:"Ajax_New.ashx?t=" + new Date().getTime(),
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
                 productsIndex();
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function webIndex()
{
 $Info.prepend("<b>首页生成</b><hr/>");
 $.ajax({
            type:"POST",
            url:"Ajax_web.ashx?t=" + new Date().getTime(),
            data:"typStatic=index",
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
               webAbout();
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function webAbout()
{
 $Info.prepend("<b>关于我们</b><hr/>");
 $.ajax({
            type:"POST",
            url:"Ajax_web.ashx?t=" + new Date().getTime(),
            data:"typStatic=about",
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
               $Info.prepend("<font color='red'><h1>全部生成完成</h1></font><hr/>");
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}
function webContact()
{
 $Info.prepend("<b>联系我们</b><hr/>");
 $.ajax({
            type:"POST",
            url:"Ajax_web.ashx?t=" + new Date().getTime(),
            data:"typStatic=contact",
            success:function(p)
            {
               $Info.prepend("<br/>"+p);
               $Info.prepend("<font color='red'><h1>全部生成完成</h1></font><hr/>");
            },
            error:function(){ $Info.prepend("网络延时,请稍后重试！");}
        });     
}

