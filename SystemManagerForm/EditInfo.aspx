<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditInfo.aspx.cs" Inherits="SystemManagerForm_EditInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改资料</title>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" /> 
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
        <asp:TextBox runat="server" ID="dealer_name" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2"  >联系电话</asp:Label>
        <asp:TextBox runat="server" ID="telephone_number" type="text" class="input-large span4"></asp:TextBox>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >所在省份与城市</asp:Label>
        <asp:DropDownList runat="server" class="span2" ID="Province"  AutoPostBack="true" OnSelectedIndexChanged="Province_SelectedIndexChanged" ></asp:DropDownList>
        <asp:DropDownList runat="server"  Visible="false" class="span2" ID="City" AutoPostBack="true" OnSelectedIndexChanged="City_SelectedIndexChanged"> </asp:DropDownList>
         <asp:DropDownList runat="server"  Visible="false" class="span2" ID="County"> </asp:DropDownList>
    </div>

         <div>
        <asp:Label  runat="server" class="span2" >详细地址</asp:Label>
        <asp:TextBox runat="server" ID="addr" type="text"  class="input-large span4"></asp:TextBox>
    </div>
        <div>
            <asp:Button ID="sub" class="btn btn-large offset2" runat="server" Text="提交" OnClick="sub_Click"  />
            <asp:Button ID="reset" class="btn btn-large" runat="server" Text="重置" OnClick="reset_Click" />
    </div>
   </div>
    </form>
</body>
</html>
