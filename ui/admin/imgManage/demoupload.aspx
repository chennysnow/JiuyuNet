<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demoupload.aspx.cs" Inherits="demoupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DemoUpload</title>
    <link href="css/Upload.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="swf/swfupload.js"></script>
    <script type="text/javascript" src="js/swfupload.queue.js"></script>

    <script src="/js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/fileprogress.js"></script>

    <script type="text/javascript" src="js/filegroupprogress.js"></script>
    <script type="text/javascript" src="ckfinder/ckfinder.js"></script> 
    <script type="text/javascript" src="js/handlers.js"></script>
    <script type="text/javascript">
     var swfu;
     $(document).ready(function () {
         $("#ddlFileName").change(function () {
             var v = $("#ddlFileName option:selected").val();
             var shui = $("#cheShui").attr("checked") == "true" ? "1" : "0";
             if (swfu != null) {
                 window.location.reload();
                 return;
             }
             var settings = {
                 flash_url: "swf/swfupload.swf",
                 upload_url: "ajax.ashx?action=batch&file=" + v + "&shui=" + shui,
                 file_size_limit: "100 MB",
                 file_types: "*.*",
                 file_types_description: "All Files",
                 file_upload_limit: 100,
                 file_queue_limit: 0,
                 custom_settings: {
                     progressTarget: "divprogresscontainer",
                     progressGroupTarget: "divprogressGroup",
                     //progress object
                     container_css: "progressobj",
                     icoNormal_css: "IcoNormal",
                     icoWaiting_css: "IcoWaiting",
                     icoUpload_css: "IcoUpload",
                     fname_css: "fle ftt",
                     state_div_css: "statebarSmallDiv",
                     state_bar_css: "statebar",
                     percent_css: "ftt",
                     href_delete_css: "ftt",
                     //sum object
                     /*
                     页面中不应出现以"cnt_"开头声明的元素
                     */
                     s_cnt_progress: "cnt_progress",
                     s_cnt_span_text: "fle",
                     s_cnt_progress_statebar: "cnt_progress_statebar",
                     s_cnt_progress_percent: "cnt_progress_percent",
                     s_cnt_progress_uploaded: "cnt_progress_uploaded",
                     s_cnt_progress_size: "cnt_progress_size"
                 },
                 debug: false,

                 // Button settings
                 button_image_url: "img/TestImageNoText_65x29.png",
                 button_width: "65",
                 button_height: "29",
                 button_placeholder_id: "spanButtonPlaceHolder",
                 button_text: '<span class="theFont">上传文件</span>',
                 button_text_style: ".theFont { font-size: 12;color:#0068B7; }",
                 button_text_left_padding: 12,
                 button_text_top_padding: 3,

                 // The event handler functions are defined in handlers.js
                 file_queued_handler: fileQueued,
                 file_queue_error_handler: fileQueueError,
                 upload_start_handler: uploadStart,
                 upload_progress_handler: uploadProgress,
                 //   upload_error_handler: uploadError,
                 upload_success_handler: uploadSuccess,
                 upload_complete_handler: uploadComplete,
                 file_dialog_complete_handler: fileDialogComplete
             };
             swfu = new SWFUpload(settings);

         });
     })
       // var v=changeDropDown("ddlProductCategory");
    </script>

</head>
<body>
    <form id="frmMain" runat="server" >
    <div style="margin-top:20px;">
    <div style="font-size: 14px;">
        批量上传图片并生成商品记录(图片比例<%=op.staValue.imgWidth %>*<%= op.staValue.imgHeight%>)</div>
    <div style="float: left;">
        <span style="font-size: 14px;">选取文件夹:<asp:DropDownList ID="ddlFileName" runat="server"></asp:DropDownList>
            <asp:HiddenField ID="hdValue" runat="server" />
            <p><input type="checkbox" value="1" checked="checked" id="cheShui"/>是否生成水印</p>
        </span>
    </div>
    <span id="spanButtonPlaceHolder"></span>
    <div id="divprogresscontainer">
    </div>
    <div id="divprogressGroup">
    </div>
    </div>
    </form>
</body>
</html>
