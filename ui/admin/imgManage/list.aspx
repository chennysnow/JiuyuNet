<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_imgManage_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    body{font-size:12px;}
/* 分页 */
.page {width:100%;margin:0px auto 0px auto;padding:3px 0px 3px 0px;text-align:center;overflow:hidden;border:1px solid #ddd; background-color:#eee;}
.page a{border:1px solid #ccc;color:#333;	display:inline-block;text-align:center;padding:2px 5px 2px 5px;}
.page .page_a{margin:0px;}
.page a:link,  .page a:visited, .page a:hover, .page a:active {}
.page .pageBtn{height:25px;width:25px;  cursor:pointer;}
.page .page_current{border:1px solid #ccc;color:#fff;	display:inline-block;text-align:center;padding:2px 5px 2px 5px;font-weight:bolder;background-color:#aa0000;	}

.ulList{margin:10px;}
.ulList li{width:100px;float:left;margin-right:10px;height:160px; overflow:hidden;}
.ulList div{width:100px; overflow:hidden; line-height:16px;}
.ulList span{ cursor:pointer;}
.ulList img{width:100px;height:100px; cursor:pointer}
/*底部*/
.bottom{margin:10px 0px;background-color:#C97979;line-height:25px;padding:5px;border-bottom:solid 1px black;
        border-top:solid 1px black; clear:both;}
.bottom input{margin-right:10px;}
/*修改文件名*/
.divEdit{ position:absolute;top:35%;left:35%;width:300px;height:120px;padding-left:30px;background-color:#333;
          color:#fff; display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function makeThu(fileName) {
        $.get("ajax.ashx", { action: "makeThu", path: fileName }, function () {
            this.src = "/uploadFile/sImg/" + fileName;
        });
    }
</script>
<div style="margin:5px;">图片不显示请<a href="javascript:window.location.href=window.location.href"><font color="red">刷新</font></a>,再不行请上传</div>
<form id="form1" runat="server">
<div class="divEdit">
<h2>修改文件名</h2>
<input type="hidden" name="editFile" id="editFile" />
<input type="text" name="editFileName" id="editFileName" style="width:260px;" />
<asp:Button ID="btnEdit" runat="server" Text="修改" onclick="btnEdit_Click" />&nbsp;&nbsp;&nbsp;<input type="button" value="取消" onclick="closeEdit()" /></div>
<ul class="ulList">
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<li><img src="<%# Eval("allPath") %>" title="单击选中此图" onerror="makeThu('<%# Eval("pathC") %>')" onclick="retImg('<%# Eval("pathC") %>')" />
<div><%# Eval("nameC") %><br />
<input name="check" type="checkbox" value='<%# Eval("pathC") %>'/> <span onclick="editName('<%# Eval("pathC") %>')">修改名称</span>
</div></li>
</ItemTemplate>
</asp:Repeater>
</ul>
<div class="bottom">
<input id="chkAll" type="checkbox" />全选&nbsp;|&nbsp;
        <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">删除</asp:LinkButton>&nbsp;|&nbsp;
        <asp:DropDownList ID="dropList" runat="server"></asp:DropDownList>
        <asp:LinkButton ID="lbtnEditDir" runat="server" 
        onclick="lbtnEditDir_Click" >转移选中图片</asp:LinkButton>&nbsp;|&nbsp;
         <asp:LinkButton ID="lbtnMakeShui" runat="server" ToolTip="请勾选上要打水印的图片" 
        onclick="lbtnMakeShui_Click" >重新打水印</asp:LinkButton>
</div>
  <div class="page">
               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonClass="page_current"
        CustomInfoClass="" CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]"
        CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" HorizontalAlign="Right"
        LastPageText="末页" NextPageText="下一页" NumericButtonCount="5" PageSize="50" PagingButtonLayoutType="Span" 
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" 
        UrlPageIndexName="p" UrlPaging="true" Width="95%">
    </webdiyer:AspNetPager>
        </div>
</form>
<script type="text/javascript">
    function checkAll(elementId, obj) {
        $("#" + elementId).click(function () {
            if ($(this).attr("checked")) {
                $(obj + " input[type=checkbox]").attr("checked", "true");
            } else {
                $(obj + " input[type=checkbox]").removeAttr("checked");
            }
        });
    }
    function editName(fileName) {
        var str = fileName.split('/');
        if(str!=null)
        {
            $("#editFile").val(fileName);
            $("#editFileName").val(str[str.length - 1]);
            $(".divEdit").slideDown(300);
        }
    }
    function closeEdit() {
        $(".divEdit").slideUp(100);
    }
    checkAll("chkAll", ".ulList");
    function retImg(imgName) {
        if (window.top.opener != null) {
            if (window.top.opener.setImgObj == null || window.top.opener.setImgObj == "")
            { window.top.opener.CKEDITOR.tools.callFunction(<%= num %>, "/uploadFile/"+imgName+"")//fck
            }
            else
                window.top.opener.SetUrl("/"+imgName); // 在跳转的页, 调用父页的JS方法, 用于选取图片, 返回图片地址
            window.top.close();
            window.top.opener.focus();
        }
    }
</script>
</asp:Content>

