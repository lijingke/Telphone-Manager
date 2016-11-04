<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delivery.aspx.cs" Inherits="SystemManagerForm_Delivery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="../assets/css/bootstrap.css" rel="stylesheet" /> 
    <link rel="stylesheet" href="../assets/css/bootstrap-theme.css"/>
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="offset1">
   
        <div>
            <asp:Label  runat="server" class="span2" >收货经销商</asp:Label>
            <asp:DropDownList runat="server" class="span3" ID="dealer"   ></asp:DropDownList>
        </div>

   <div>
        <asp:Label  runat="server" class="span2" >发货型号</asp:Label>
        <asp:DropDownList runat="server" class="span3" ID="model"   ></asp:DropDownList>
   </div>

         <div>
        <asp:Label  runat="server" class="span2" >数量</asp:Label>
        <asp:TextBox runat="server" ID="num" type="text"  class="input-large span3"></asp:TextBox>
    </div>
        <div>
            <asp:Button ID="sub" class="btn btn-large offset2" runat="server" Text="提交" OnClick="sub_Click"/>
            <asp:Button ID="reset" class="btn btn-large" runat="server" Text="重置" OnClick="reset_Click"  />
    </div>
   </div>
    </form>
</body>
</html>
