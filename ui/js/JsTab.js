/// <reference name="MicrosoftAjax.js"/>
/*
tab标签插件 
skxc 12-11-2010
css:
<style type="text/css"></style>
.tabs_container{height:auto; border:1px solid #eaeaea; position:relative;}
.tabs_ul{position:absolute; height:auto; overflow:hidden; clear:both; display:block; width:100%;}
.tabs_ul li{display:inline; float:left; height:25px; line-height:25px; border:1px solid #eaeaea; padding:0px 5px; background:#eee;  margin-right:1px;}
.tabs_ul li.selected{background:#FFF; border-bottom:1px solid #FFF;}
.tabs_ul li.hover{background:#FFF; border-bottom:1px solid #FFF; text-decoration:underline;}
.tabs_div{padding:5px; display:none;}

html结构
<div class="test_tabs">
	<ul class='tabs_ul'>
		<li>link1< >
		<li>link2< >
		<li>link3< >	
	</ul>
	<div class="tabs_div">content1</div>
	<div class="tabs_div">content2</div>
	<div class="tabs_div">content3</div>
</div>
use:$("#test_tabs").Tabs();
parm: mouseevent (click,hover)  默认为单击事件
*/
(function($){  
	$.fn.extend({
		Tabs:function(options) {  
			//配置参数  
			var defaults = {  
				mouseevent:'click'
			}
			var options =  $.extend(defaults, options);
			return this.each(function(){  
				var o = options;
				//do
				var _this=$(this);
				var _ul=$("ul:first",_this);
				var _li=$("li",_ul);
				var _div=$('>div',_this);
				var _scroll=0;
				var _ul_height=_ul.height()-1;//-1像素 IEbug
				var cur=0;
				
				$(window).scroll(function(){_scroll=$(window).scrollTop();})
				
				_div.hide();
				_div.eq(0).show();
				_this.css('margin-top',_ul_height+'px');
				_ul.css({'top':'-'+_ul_height+'px','left':'-1px'});
				_li.css("cursor","pointer");
				_li.eq(0).addClass('selected');
				_this.addClass('tabs_container');
				
				if(o.mouseevent=='click'){
					_li.click(function(){
						var index=$(this).index();
						if(cur!=index){
							_div.eq(cur).hide(0,function(){
								_div.eq(index).show(0,function(){
									//$(window).scrollTop(_scroll);
								});
							});
							_li.eq(index).addClass('selected');
							_li.eq(cur).removeClass('selected');
							cur=index;	
						}
					});
					//添加样式
					_li.hover(function(){
						$(this).addClass('hover');
					},function(){
						$(this).removeClass('hover');
					})
				}
				//经过切换
				if(o.mouseevent=='hover'){
					_li.hover(function(){
						var index=$(this).index();
						if(cur!=index){
							_div.eq(cur).hide("fast",function(){
								_div.eq(index).show("fast",function(){
									//$(window).scrollTop(_scroll);
								});
							});
							_li.eq(index).addClass('selected');
							_li.eq(cur).removeClass('selected');
							cur=index;	
						}
					});
				}
				//do end
			});
		}
	});
})(jQuery);
