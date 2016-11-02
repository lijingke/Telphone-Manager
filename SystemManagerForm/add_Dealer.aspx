<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_Dealer.aspx.cs" Inherits="Form_add_Dealer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../assets/css/bootstrap.css" rel="stylesheet" /> 
    <link rel="stylesheet" href="../assets/css/bootstrap-theme.css"/>
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    
    
    </style>
    <title>添加经销商信息</title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:Label  runat="server" class="span2 ">用户名</asp:Label>
        <asp:TextBox runat="server" ID="username_textbox" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2 " >密码</asp:Label>
        <asp:TextBox runat="server" ID="TextBox1" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >经销商名称</asp:Label>
        <asp:TextBox runat="server" ID="TextBox2" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2"  >联系电话</asp:Label>
        <asp:TextBox runat="server" ID="TextBox3" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >所在省份与城市</asp:Label>
        <asp:DropDownList runat="server" class="span2">
            <asp:ListItem>四川省</asp:ListItem>
        </asp:DropDownList>
             <asp:DropDownList runat="server" class="span2">
            <asp:ListItem>成都市</asp:ListItem>
        </asp:DropDownList>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >详细地址</asp:Label>
        <asp:TextBox runat="server" ID="TextBox5" type="text" class="input-large span6"></asp:TextBox>
    </div>

   
  </form>
</body>

</html>
