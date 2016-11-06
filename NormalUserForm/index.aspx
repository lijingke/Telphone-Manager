<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Form_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" /> 
    <title></title>
</head>
<frameset rows="100px,*" frameborder="0" framespancing="0" id="top">
    <frame src="head.aspx" name="head" scrolling="no">
 
    <frameset cols="20%,*" frameborder="0"  framespacing="0" id="content">
        <frame src="left.aspx" id="leftFrame" name="left" scrolling="no">
        <frame src="main.aspx" name="right" scrolling="yes" >
    </frameset>
</html>
