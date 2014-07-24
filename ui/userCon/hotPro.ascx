<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hotPro.ascx.cs" Inherits="userCon_hotPro" %>
<div class="left_head_1"><span style="padding-left:20px">新品上市</span></div>
<ul class="ul_hot_pro">
<asp:Repeater ID="repList" runat="server">
<ItemTemplate>
<li>
<a href="proShow.aspx?id=<%# Eval("id") %>" title="详情请击">
                    <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>" width="190px" />
                </a>
                </li>
</ItemTemplate>
</asp:Repeater>
</ul>
   <script type="text/javascript">
       showHot(0);
       function showHot(index) {
           $(".ul_hot_pro li").removeClass("select");
           var $li = $(".ul_hot_pro li").eq(index);
           
           $($li).addClass("select");
       }
//       $("#showMenu").unbind();
//       $("#showMenu").css({ display: "none" })
    </script>