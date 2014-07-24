<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasPageAdmin.master" AutoEventWireup="true" CodeFile="imgList.aspx.cs" Inherits="admin_product_imgList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
<script type="text/javascript">
    function BrowseServer(inputId) {
        var finder = new CKFinder();
        finder.basePath = '../ckfinder/'; //导入CKFinder的路径 
        finder.selectActionFunction = SetFileField; //设置文件被选中时的函数 
        finder.selectActionData = inputId; //接收地址的input ID 
        finder.popup();
    }
    //文件选中时执行 
    function SetFileField(fileUrl, data) {
        document.getElementById(data["selectActionData"]).value = fileUrl;
    } 
</script> 
 
<p>  
<strong>Selected File URL</strong><br/>  
<input id="xFilePath" name="FilePath" type="text" size="60" />  
<input type="button" value="Browse Server" onclick="BrowseServer('xFilePath');" />  
</p>  
<p>  
<strong>Selected Image URL</strong><br/>  
<input id="xImagePath" name="ImagePath" type="text" size="60" />  
<input type="button" value="Browse Server" onclick="BrowseServer( 'xImagePath' );" />  
</p>  
<ul style="width:780px;height:260px; background-color:#ccc;">
<li style="width:160px;margin:5px 15px 10px 15px;float:left;">
    <img src="图片链接" width="160px" />
    <div style="margin:5px; line-height:18px;"><a href="宝贝地址"><font color="#3366CC">标题名称</font></a>
    <br /><font color="#ccc">一口价</font>&nbsp;<font style="color:#FF6600;font-weight:bolder;">85.00元</font>
    <br />已销售:<font style="color:#CEAA00;font-weight:bolder;">123</font>件
    </div>
</li>
<li style="width:160px;margin:5px 15px 10px 15px;float:left;">
    <img src="图片链接" width="160px" />
    <div style="margin:5px; line-height:18px;"><a href="宝贝地址"><font color="#3366CC">标题名称</font></a>
    <br /><font color="#ccc">一口价</font>&nbsp;<font style="color:#FF6600;font-weight:bolder;">85.00元</font>
    <br />已销售:<font style="color:#CEAA00;font-weight:bolder;">123</font>件
    </div>
</li>
<li style="width:160px;margin:5px 15px 10px 15px;float:left;">
    <img src="图片链接" width="160px" />
    <div style="margin:5px; line-height:18px;"><a href="宝贝地址"><font color="#3366CC">标题名称</font></a>
    <br /><font color="#ccc">一口价</font>&nbsp;<font style="color:#FF6600;font-weight:bolder;">85.00元</font>
    <br />已销售:<font style="color:#CEAA00;font-weight:bolder;">123</font>件
    </div>
</li>
<li style="width:160px;margin:5px 15px 10px 15px;float:left;">
    <img src="图片链接" width="160px" />
    <div style="margin:5px; line-height:18px;"><a href="宝贝地址"><font color="#3366CC">标题名称</font></a>
    <br /><font color="#ccc">一口价</font>&nbsp;<font style="color:#FF6600;font-weight:bolder;">85.00元</font>
    <br />已销售:<font style="color:#CEAA00;font-weight:bolder;">123</font>件
    </div>
</li>
</ul>

</asp:Content>

