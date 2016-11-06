<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dealer_Info.aspx.cs" Inherits="SystemManagerForm_Dealer_Info" %>

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
        <asp:Label  runat="server" class="span2 ">用户名</asp:Label>
        <asp:TextBox runat="server" ID="username" type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>



         <div>
        <asp:Label  runat="server" class="span2" >经销商名称</asp:Label>
        <asp:TextBox runat="server" ID="dealer_name"  Enabled="false" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2"  >联系电话</asp:Label>
        <asp:TextBox runat="server" ID="telephone_number"  Enabled="false" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >所在省份与城市</asp:Label>
        <asp:TextBox runat="server" ID="pd" type="text"  Enabled="false" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >详细地址</asp:Label>
        <asp:TextBox runat="server" ID="addr" type="text"  Enabled="false" class="input-large span4"></asp:TextBox>
    </div>
      
   </div>
    </form>
</body>
</html>
