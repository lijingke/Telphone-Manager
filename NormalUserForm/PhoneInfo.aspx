<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhoneInfo.aspx.cs" Inherits="SystemManagerForm_PhoneInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../assets/css/bootstrap-theme.css"/>
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="offset1">
    <div>
        <asp:Label  runat="server" class="span2 ">手机型号</asp:Label>
        <asp:TextBox runat="server" ID="model" type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>



         <div>
        <asp:Label  runat="server" class="span2" >产地</asp:Label>
        <asp:TextBox runat="server" ID="address"  type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2"  >颜色</asp:Label>
        <asp:TextBox runat="server" ID="color"  type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >配置</asp:Label>
        <asp:TextBox runat="server" ID="Deploy" type="text"  Enabled="false" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >品牌</asp:Label>
        <asp:TextBox runat="server" ID="brand" type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>
     
   </div>
    </form>
</body>
</html>
