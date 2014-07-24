<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_imgManage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<frameset cols="208px,*"> 
 <frame name="left" src="left.aspx?ckNum=<%=Request.QueryString["CKEditorFuncNum"] %>" noresize="yes"  border="1px"  scrolling="auto"> 
 <frame name="list" src="list.aspx?ckNum=<%=Request.QueryString["CKEditorFuncNum"] %>">  
</frameset>
</html>
