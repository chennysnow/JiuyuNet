<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="admin_product_edit" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<script type="text/javascript">
    var setImgObj = "";
    function BrowseServer(setImg) {
        setImgObj = setImg;
        window.open("/admin/imgManage/Default.aspx");
        return false;
    }
    function SetUrl(imgName) {
        $("#" + setImgObj).val(imgName);
        setImgObj = "";
    } 
</script> 
    <div class="center">
        <table class="tableAdd">
            <tr>
                <td class="style1">
                    类别:<font style="color:Red;">*</font></td>
                <td class="style3">
                    <asp:DropDownList ID="ddlNewsType" runat="server" Height="25px" 
                        Width="227px">
                    </asp:DropDownList>
                </td>
            </tr>
              <%--<tr>
                <td class="style1">
                    品牌:<font style="color:Red;">*</font></td>
                <td class="style3"><asp:DropDownList ID="dropBrand" runat="server"></asp:DropDownList></td>
                </tr>--%>
            <tr>
                <td class="style1">
                    标题:<font style="color:Red;">*</font></td>
                <td class="style3">
                         <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="264px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    型号:</td>
                <td class="style3">
                                     <asp:TextBox ID="txtProId" runat="server" MaxLength="40" 
                        Width="264px"></asp:TextBox>
                </td>
            </tr>
           
            <tr class="trSelect" style="display:block">
                <td class="style1">
                   自定义属性:</td>
                <td class="style3">
                <ul class="ul">
                 <asp:Repeater ID="repAttr" runat="server"><ItemTemplate>
                 <li>                 
                 <div>
                <input type="checkbox" name="attr" <%# Eval("typ").ToString()=="1"?"checked=\"checked\"":"" %> value="<%# Eval("id") %>"/><%# Eval("nameC") %>
                 </div>
                 <input type="text" name="attrValue<%# Eval("id") %>" value="<%# Eval("valueC") %>" style="width:264px" />
                </li></ItemTemplate></asp:Repeater>
                </ul>
                </td>
            </tr>
                         <tr >
                <td class="style1">
                   供应商:</td>
                <td class="style3">
                 <asp:Literal ID="Lisupply" runat="server"></asp:Literal>
              
                </td>
            </tr>
           
             <tr>
                <td class="style1">
                    网站标题:</td>
                <td class="style3">
                         <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" 
                        Width="264px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    网站关键词:</td>
                <td class="style3">
                         <asp:TextBox ID="txtKeywords" runat="server" MaxLength="200" 
                        Width="264px"></asp:TextBox>  <span onclick="allKey(this,'<%=txtKeywords.ClientID %>','getAllKey')">查看词库</span></td>
            </tr>
            <tr>
                <td class="style1">
                    网站描述:</td>
                <td class="style3">
                        <asp:TextBox ID="txtDescription" runat="server" 
                        Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    静态名称:</td>
                <td class="style3">
                        <asp:TextBox ID="txtHtmlName" runat="server" Width="160px"></asp:TextBox> 
                        </td>
            </tr>
            <tr class="trSelect">
                <td class="style1">
                    显示方式:<br /></td>
                <td class="style3">
                       <asp:CheckBoxList ID="checkDis" runat="server" RepeatDirection="Horizontal" >
                       </asp:CheckBoxList>
                      </td>
            </tr>
             <tr>
                <td class="style1">
                    价格:<font style="color:Red;">*</font></td>
                <td class="price">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                   <span onclick="addPrice()"  style="cursor:pointer;">&nbsp;&nbsp;+添加区间>></span><%--<asp:Literal
                       ID="litpriceqj" runat="server"></asp:Literal>--%>
                   
                   <asp:UpdatePanel ID="updatePanle" runat="server" UpdateMode="Always">
                   <ContentTemplate>
                   <asp:Repeater ID="repPrice" runat="server" onitemcommand="repPrice_ItemCommand"><ItemTemplate>
                   <input type="hidden" name="priId" value="<%# Eval("id") %>" />
                   <div id="price<%# i %>"><%# i+1 %>:<input type="text" name="txtMin<%# i %>" id="txtMin<%# i %>" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%# Eval("minC") %>"/>--<input type="text" name="txtMax<%# i %>" id="txtMax<%# i %>" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%# Eval("maxC") %>" />价格:<input type="text" name="txtPrice<%# i %>" id="txtPrice<%# i %>" value="<%# Eval("priceC") %>" />交货:<input type="text" name="txtDay<%# i %>" id="txtDay<%# i++ %>" value="<%# Eval("dayC") %>" />
                   <asp:LinkButton  ID="lbtnEdit" CommandArgument='<%# Eval("id")%>' CommandName="del" runat="server">删除</asp:LinkButton></div>
                   </ItemTemplate></asp:Repeater>
                   <input type="hidden" name="priCount" id="priCount" value="<%= i %>" />
                   </ContentTemplate>
                   </asp:UpdatePanel>
                    
               </td>
            </tr>
             <tr style="display:none">
                <td class="style1">
                    piece/lot:<font style="color:Red;">*</font></td>
                <td class="price">
                   <asp:TextBox ID="txtMoq" runat="server" Text="" onkeyup="value=value.replace(/[^\d]/g,'')"></asp:TextBox>kg<font style="color:Red">只能是数字</font>
               </td>
            </tr>  
            <tr>
                <td class="style1">产品特点：</td>
                <td class="style3"><asp:TextBox ID="txtChi" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
           <tr>
                <td class="style1">
                    重量:<font style="color:Red;">*</font></td>
                <td class="price">
                   <asp:TextBox ID="txtWeight" runat="server" Text="0.01" onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')"></asp:TextBox>Kg <font style="color:Red">只能是数字</font>
               </td>
            </tr>
            <tr>
                <td class="style1">
                   星级:</td>
                <td class="price">
                  <select style="width:100px" id="slstar" runat="server">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                  </select>
               </td>
            </tr> 
            <tr>
                <td class="style1">
                    库存:<font style="color:Red;">*</font></td>
               <td class="style3">
                   <asp:TextBox ID="txtStock" runat="server" Text=""></asp:TextBox><font color="red">仅描述意义</font>
               </td>
            </tr> 
            <tr>
                <td class="style1"><font style="color:Red">*</font>图片宽高比例<%=op.staValue.imgWidth%>*<%= op.staValue.imgHeight%> </td>
                <td class="style3">
                      <input type="text" name="fileImg" id="fileImg" style="width:300px" /><input type="button" value="浏览" onclick="BrowseServer('fileImg');" />
                      <font color="Red">只能上传.jpg .jpeg .bmp .gif文件</font></td>
            </tr>
            <tr>
                <td class="style1">详细图片:</td>
                <td class="style3">
                      <input id="btnAddFilePic"  onclick="addFile()" type="button" 
                          value="添加详细图片" /></td>
            </tr>
            <tr>
                <td class="style1">&nbsp;</td>
                <td class="style3">
                 <table id="tabImg"><tr></tr></table> 
                 <input type="hidden" name="moreImg" id="moreImg" value="<%= model.moreImg %>" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                <script type="text/javascript" src="../ckeditor/ckeditor.js"></script> 
                       <asp:TextBox ID="txtContent" class="ckeditor" TextMode="MultiLine" 
Text='' runat="server"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    
                    <asp:Button ID="BtOk" runat="server" Text="确定" onclick="BtOk_Click" CssClass="btn_white" />
                    &nbsp;<asp:Button ID="BtClear" runat="server" Text="返回列表" onclick="BtClear_Click" CssClass="btn_white" />
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    <script type="text/javascript">
    var arrImg="<%= model.moreImg %>".split(',');
    var sb="";
    for(i=0;i<arrImg.length;i++)
    {
        sb += "<td id='tdImg" + i + "'><img src=\"<%= model.fileName %>/sImg" + arrImg[i] + "\"/><br /><input type=\"button\" value=\"删除\" onclick=\"delImg('" + arrImg[i] + ",'," + i + ")\"/></td>";
    }
    $("#tabImg").html(sb);
    function delImg(img, i) {
        $("#moreImg").val($("#moreImg").val().replace(img, ""));
        $("#tdImg" + i + "").remove();
    }
    </script>
    </asp:Content>