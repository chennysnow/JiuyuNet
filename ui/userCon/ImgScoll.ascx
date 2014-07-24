<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImgScoll.ascx.cs" Inherits="userCon_ImgScoll" %>
<div class="head_bg" style="text-align:left;margin-top:5px;">&nbsp;Hot Products</div>
<dl class="dl_new_img">
    <dt class="left">
        <img src="/images/scollLeft.png" id="dl_new_up" /></dt>
    <dt class="right">
        <img src="/images/scollRight.png" id="dl_new_down" /></dt>
    <dd id="dd_new_img">
        <ul>
            <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <li><a href="<%# Eval("url") %>">
                        <img src="<%# Eval("fileName") %>/sImg<%# Eval("imgC") %>" alt="<%# Eval("nameC") %>"
                            class="img" />
                            <div><strong><%# Eval("nameC") %></strong><br /><span class="price">$<%# Eval("strPrice")%></span></div>
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </dd>
</dl>
<script type="text/javascript">
    $("#dd_new_img").Scroll({ line: 1, speed: 500, timer: 4000, vertical: false, up: "dl_new_up", down: "dl_new_down" });
</script>