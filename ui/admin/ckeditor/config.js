/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    //config.language = 'en';
    // config.uiColor = '#AADC6E';

//    config.filebrowserBrowseUrl = "/WebConfig/ckfinder/ckfinder.html";
//    config.filebrowserImageBrowseUrl = "/WebConfig/ckfinder/ckfinder.html?Type=Images";
//    config.filebrowserFlashBrowseUrl = "/WebConfig/ckfinder/ckfinder.html?Type=Flash";
//    config.filebrowserUploadUrl = "/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
//    config.filebrowserImageUploadUrl = "/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
//    config.filebrowserFlashUploadUrl = "/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";


//    config.language = 'zh-cn';
    //    config.skin = 'v2'   location.hash +;
    config.filebrowserBrowseUrl = '/admin/imgManage/default.aspx';
    config.filebrowserImageBrowseUrl =  '/admin/imgManage/default.aspx';
    config.filebrowserFlashBrowseUrl ='/admin/imgManage/default.aspx';
    config.filebrowserUploadUrl =  '/admin/imgManage/default.aspx';
    config.filebrowserImageUploadUrl =  '/admin/imgManage/ajax.ashx?action=uploadFile';
    config.filebrowserFlashUploadUrl = '/admin/imgManage/default.aspx';

    //    filebrowserImageBrowseUrl = "/WebConfig/ckfinder/ckfinder.html?Type=Images";
    //    filebrowserFlashBrowseUrl = "/WebConfig/ckfinder/ckfinder.html?Type=Flash";
    //    filebrowserImageUploadUrl = "/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    //    filebrowserFlashUploadUrl = "/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash"
    //    filebrowserBrowseUrl : '/WebConfig/ckfinder/ckfinder.html',
    //    filebrowserImageBrowseUrl : '/WebConfig/ckfinder/ckfinder.html?Type=Images',
    //    filebrowserFlashBrowseUrl : '/WebConfig/ckfinder/ckfinder.html?Type=Flash',
    //    filebrowserUploadUrl : '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    //    filebrowserImageUploadUrl : '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
    //    filebrowserFlashUploadUrl : '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

};

//CKFinder.setupCKEditor(null, '/ckfinder/');
//CKEDITOR.replace('editor1',
//   {
//       filebrowserBrowseUrl: '/WebConfig/ckfinder/ckfinder.html',
//       filebrowserImageBrowseUrl: '/WebConfig/ckfinder/ckfinder.html?Type=Images',
//       filebrowserFlashBrowseUrl: '/WebConfig/ckfinder/ckfinder.html?Type=Flash',
//       filebrowserUploadUrl: '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
//       filebrowserImageUploadUrl: '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
//       filebrowserFlashUploadUrl: '/WebConfig/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
//   }
//);