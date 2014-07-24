<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true"
    CodeFile="list.aspx.cs" Inherits="admin_product_list" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div>
        分类查看:<asp:DropDownList ID="dropTyp" runat="server"  Width="120px" ></asp:DropDownList>
    <input type="text" id="seaKey" style="width:260px;" /> <input type="button" value="搜 索" onclick="return seach()" /><span
            style="margin-left: 80px;"></span>
         <asp:DropDownList ID="dropDisplay" runat="server" Width="100">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;<font color="#aa0000">显示方式,排序,等一起操作完以后请点击保存操作</font>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <HeaderTemplate>
            <table class="table">
                <tr class="tableHead">
                    <td style="width: 30px;">
                        选择
                    </td>
                    <td style="width: 40px;">
                        商品
                    </td>
                    <td style="text-align: left">
                        商品名称
                    </td>
                    <td>商品编号</td>
                    <td style="width:40px;">
                        上下架
                    </td>
                    <td style="width:40px;">权限</td>
                    <td style="width:180px;">
                        显示方式
                    </td>
                    <td style="width:40px;">
                        排序
                    </td>
                   <%-- <td style="width: 30px;">
                        权限
                    </td>--%>
                    <td style="width:40px">操作</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="td_select">
                    <input id="chkId" name="chkId" type="checkbox" value='<%# Eval("id") %>'/>
                </td>
                <td>
                    <a href="/proShow.aspx?id=<%# Eval("id") %>" target="_blank" title="<%# Eval("nameC") %>">
                        <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC").ToString() %>" width="40"
                            borer="0" /></a>
                </td>
                <td style="text-align: left;">
                    <%# Eval("nameC") %>
                </td>
                <td style="text-align: left;">
                    <%# Eval("proId") %>
                </td>
                <td class="center"><%# Eval("showC").ToString()=="1"?"上架":"下架" %></td>
                <td class="center"><%# Eval("qx").ToString()=="0"?"普通":"加密" %></td>
                <td>
                    <%# getDisplay(Eval("displayC").ToString(),Eval("id").ToString()) %>
                </td>
                <td class="sort">
                    <input name="sort" value="<%# Eval("sortC") %>"/>
                        <input type="hidden" name="id" value="<%# Eval("id") %>" />
                </td>
             <%--   <td>
                    <select name="selectQx<%# index++ %>">
                        <option value="0">普通</option>
                        <option value="1" <%# Eval("qx").ToString()=="1"?"selected='selected'":"" %>>会员</option>
                    </select>
                </td>--%>
                <td><a href="edit.aspx?id=<%# Eval("id") %>&page=<%# page %>">修改</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <div class="bottom">
        &nbsp;<input id="chkAll" type="checkbox" />全选&nbsp;|&nbsp;
        <asp:LinkButton ID="lbtnBatchDelete" runat="server" OnClick="lbtnBatchDelete_Click">删除</asp:LinkButton>&nbsp;|&nbsp;
        <asp:DropDownList ID="dropRunTyp" runat="server">
        <asp:ListItem Value="0">请选择</asp:ListItem>
        <asp:ListItem Value="1">上架</asp:ListItem>
        <asp:ListItem Value="2">下架</asp:ListItem>
        <asp:ListItem Value="3">普通产品</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="lbtnRun" runat="server" onclick="lbtnRun_Click">执行操作</asp:LinkButton>
        &nbsp;|&nbsp; <a href="batch.aspx">批量添加产品</a>&nbsp;|&nbsp; 
        <a href="add.aspx">添加产品</a><asp:Literal ID="litSMail" runat="server"></asp:Literal>&nbsp;|&nbsp;

            <asp:Button ID="btnSave" runat="server" Text="保存操作" OnClick="btnSave_Click" CssClass="Btn" />
             <asp:Button ID="btnReportOut" runat="server" Text="导出产品" OnClick="btnReportOut_Click" CssClass="Btn" /><asp:Literal ID="litRepInfo" runat="server"></asp:Literal><asp:FileUpload
                 ID="fileUp" runat="server" /> <asp:Button ID="btnRepInput" runat="server" Text="导入产品" OnClick="btnRepInput_Click" CssClass="Btn" />
    </div>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonClass="page_current"
        CustomInfoClass="" CustomInfoHTML="总共[%RecordCount%]条记录  当前页/总页[%CurrentPageIndex%/%PageCount%]"
        CustomInfoTextAlign="Left" FirstLastButtonStyle="" FirstPageText="首页" HorizontalAlign="Right"
        LastPageText="末页" NextPageText="下一页" NumericButtonCount="5"
        PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left"
        ShowPageIndexBox="Always" SubmitButtonText="Go" UrlPageIndexName="p" UrlPaging="true"
        Width="95%">
    </webdiyer:AspNetPager>
    <script type="text/javascript">
        //用于清除输入框中提示信息的方法
        checkAll("chkAll", ".td_select");
        function seach() {
         //   self.parent.Ext.MessageBox.alert('提示', '你好，我的中国'); 
            var typ = $("#ctl00_content_dropTyp").val();
            var seaKey = $("#seaKey").val();
            if (typ == 0) {
                if (seaKey == "")
                    window.location.href = "?";
                else
                    window.location.href = "?seaKey=" + seaKey;
            }
            else {
                window.location.href = "?typ=" + typ + "&seaKey=" + seaKey;
            }
            return false;
        }
        $("#ctl00_content_dropDisplay").change(function () {
            var va = $(this).val();
            if (va.indexOf("show") >= 0) {
                window.location.href = "?show=" + va.substring(va.indexOf("show") + 4);
            }
            else
                if (va == 0)
                    window.location.href = "?";
                else
                    window.location.href = "?display=" + va;
            });

            function sendMail() {
                var proId = "";
                var i = 0;
                var $select = $(".td_select input");
                for (var j = 0; j < $select.length; j++) {
                    if ($($select[j]).attr("checked")) {
                        i++;
                        proId += $($select[j]).val() + ",";
                    }
                }
                if (i < 1)
                    alert("必须勾选至少一条产品,才能继续操作");
                else {
                    window.location.href = "/admin/user/sendMail.aspx?proId=" + proId;
                }
            }
            
   
         
            

    </script>
</asp:Content>
