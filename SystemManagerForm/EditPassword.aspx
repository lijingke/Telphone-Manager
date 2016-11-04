<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPassword.aspx.cs" Inherits="SystemManagerForm_EditPassword" %>

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
    <div class="container">
     <div class="offset1">
    <div>
        <asp:Label  runat="server" class="span2 ">修改密码</asp:Label>
        <asp:TextBox runat="server" ID="psw" type="text" Enabled="false" class="input-large span4"></asp:TextBox>
    </div>



         <div>
        <asp:Label  runat="server" class="span2" >确认密码</asp:Label>
        <asp:TextBox runat="server" ID="confirm"  type="text" class="input-large span4"></asp:TextBox>
    </div>
      <div>
            <asp:Button ID="sub" class="btn btn-large offset2" runat="server" Text="提交" OnClick="sub_Click" />
            <asp:Button ID="reset" class="btn btn-large" runat="server" Text="重置" OnClick="reset_Click"  />
    </div>
   </div>
    </div>
    </form>
</body>
</html>
