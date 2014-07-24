<%@ Page Language="C#" MasterPageFile="../MasPageAdmin.master" AutoEventWireup="true" CodeFile="post.aspx.cs" Inherits="admin_user_post" Title="无标题页" %>
<%@ MasterType VirtualPath="../MasPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .dlAdd{ overflow:hidden;}
    .dlAdd dt{height:25px; line-height:25px; background-color:#f1f1f1; text-align:left; padding-left:20px;font-weight:bolder;}
    .dlAdd dd{width:200px; padding-left:10px;float:left;}
    .dlAdd dd div{width:160px;float:left; text-align:left;}
    .dlAdd dd input{width:30px;}
   .dlAdd dd .inputPrice{width:30px;}
   input:hover{border:1px solid #aa0000;}
        #price { width: 60px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="PanelRep" runat="server">
      <asp:Repeater ID="Repeater1" runat="server" 
          onitemcommand="Repeater1_ItemCommand">
    <HeaderTemplate>
    <table class="table">
    <tr class="tableHead">
     <td style="width:80px;">状态</td>
    <td style="width:100px;">快递名称</td>
    <td style="width:80px">图标</td>
    <td>描述</td>
    
   
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
     <td class="operation">
         <%# getExporessState(Eval("expressName"),Eval("id"))%> 使用
    </td>
    <td><%# Eval("expressName")%></td>
    <td><img src="<%# Eval("logo") %>" /></td>
    <td><%# Eval("remark")%></td>
    
   
    </tr>
    </ItemTemplate>
    <FooterTemplate></table>
    </FooterTemplate>
    </asp:Repeater>
    <div class="bottom" >
     <asp:LinkButton   ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">批量保存</asp:LinkButton></div>
    </asp:Panel>
    <asp:Panel ID="PanelAdd" runat="server" Visible="false">
       <asp:Repeater ID="repPlace" runat="server">
         <HeaderTemplate>
    <dl class="dlAdd">
    <dt>地方<span style="margin-left:200px;"></span>价钱<font style="color:Red">只能是数字或小数</font></dt>
    </HeaderTemplate>
    <ItemTemplate>
    <dd class="check">
       <div><input type="checkbox" /> <%# Eval("nameC")%></div>
      <div class="inputPrice"><input type="text"  name="priceC" value="5"  />
    <input name="id" type="hidden"  value='<%# Eval("id")%>' /></div></dd>
    </ItemTemplate>
    <FooterTemplate></dl>
    </FooterTemplate>
       </asp:Repeater>
    <div class="bottom">
    <input type="checkbox" id="chkAll" />全选  价格:<input type="text" id="price" /><input type="button" id="btnSet" onclick="setPrice()" value="批量设置"/>
        <br />
    快递名称:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    续重价格:<asp:TextBox ID="txtAddWeight" runat="server"  onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" ></asp:TextBox>
        <br />
        快递图标:<asp:FileUpload ID="fileAdd" runat="server" />
        <br />
        快递描述:<asp:TextBox ID="txtDescription" runat="server" Width="260px" 
            TextMode="MultiLine" Height="60px"></asp:TextBox>
        <asp:Button ID="BtAddOk" runat="server" CssClass="btn_white" onclick="BtAddOk_Click" 
            Text="添加快递" />
        <asp:Button ID="BtRep" runat="server" CssClass="btn_white" onclick="BtRep_Click" 
            Text="查看全部" />
        </div>
    </asp:Panel>
     <asp:Panel ID="panelEdit" runat="server" Visible="false">
       <asp:Repeater ID="repEdit" runat="server">
         <HeaderTemplate>
    <dl class="dlAdd">
    <dt>地方<span style="margin-left:200px;"></span>价钱<font style="color:Red">只能是数字或小数</font></dt>
    </HeaderTemplate>
    <ItemTemplate>
    <dd class="check">
       <div><input type="checkbox" value='<%# Eval("placeId")%>' /> <%# Eval("nameC")%></div>
      <div class="inputPrice"><input type="text"  name="priceC"  value='<%# Eval("priceC")%>' />
    <input name="placeId" type="hidden" value='<%# Eval("placeId")%>' /></div></dd>
    </ItemTemplate>
    <FooterTemplate></dl>
    </FooterTemplate>
       </asp:Repeater>
            <div class="bottom">
             <input type="checkbox" id="chkAll" />全选  价格:<input type="text" id="price" /><input type="button" id="btnSet" onclick="setPrice()" value="批量设置"/>
        <br />
                        快递名称:<asp:TextBox ID="txtNameEdit" runat="server"></asp:TextBox><br />
                        续重价格:<asp:TextBox ID="txtAddWeightEdit" runat="server" onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" ></asp:TextBox><br />
                    快递图标:<asp:FileUpload ID="fileEdit" runat="server" /><br />
                        快递描述:<asp:TextBox ID="txtDescirptionEdit" runat="server" Width="260px" 
            TextMode="MultiLine" Height="60px"></asp:TextBox>

                        <asp:Button ID="BtEditOk" runat="server" CssClass="btn_white" 
                            onclick="BtEditOk_Click" Text="确定修改" />
            </div>
            
            <br />
    </asp:Panel>
       <script type="text/javascript">
       function setPrice() {
            var check=$(".check [type='checkbox']");
            var price=$(".check [type='text']");
            for(var i=0;i<check.length;i++)
            {
                if($(check[i]).attr("checked"))
                {
                    $(price[i]).attr("value",$("#price").val());
                }
            }
             check.removeAttr("checked");
        } 
        checkAll("chkAll", ".check");
       </script>
</asp:Content>
