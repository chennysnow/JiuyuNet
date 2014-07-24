<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="admin_imgManage_left" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    body{font-size:12px; line-height:160%;}
   .ulDir { width: 180px; margin-left: 15px;padding-bottom:10px;}
   .ulDir span { font-size: 11px; cursor: pointer; color: #838383; float: right; width: 50px; display: inline-block; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" form="form1">
<div style="background-color:#eee;border:1px solid #ddd;width:178px;padding:10px 10px 50px 10px;">
<h1>文件夹</h1>
<ul class="ulDir">
<asp:Literal ID="liDir" runat="server"></asp:Literal>
</ul>
<fieldset>
    <legend>添加目录</legend>
<div><asp:TextBox ID="txtDir" runat="server" Width="90px"></asp:TextBox> <asp:Button ID="btnAdd" 
        runat="server" Text="添加" onclick="btnAdd_Click" /></div>
        </fieldset>
        <br /> 
<fieldset>
    <legend>搜索图片</legend>
 <div>
 <select id="dropList"><asp:Literal ID="liDropList" runat="server"></asp:Literal></select>
 <input type="text" id="txtSeaKey" style="width:90px;" title="输入部分文件名"/> <input type="button" value="搜索" onclick="search()" />
</div>
 </fieldset><br />
 <fieldset>
    <legend>上传图片</legend>
    <div>
    <select id="dropFileUpload" name="dropFileUpload">
    <asp:Literal ID="liFileUpload" runat="server"></asp:Literal>
    </select><br />
    <asp:FileUpload ID="fileAdd" runat="server" Width="160px"/>
    <br />
    <input name="check" type="checkbox" value="1"/> 是否打水印&nbsp;
    <asp:Button ID="btnFile" runat="server" Text="上传" 
            onclick="btnFile_Click" /></div>
            <p><a href="demoupload.aspx" target="list">批量上传</a></p>
    
    </fieldset>
</div>
</form>
<script type="text/javascript">
    function del(file) {
        if (confirm("确认要删除(" + file + ")里的所有文件吗?")) {
            window.location.href = "left.aspx?del="+file;
        }
    }
    function search() {
        if ($("#txtSeaKey").val() != "") {
            window.open("list.aspx?file="+$("#dropList").val()+"&seaKey=" + $("#txtSeaKey").val(),"list");
        }
        else {
            alert("搜索名称不能为空");
        }
    }
</script>
</asp:Content>

