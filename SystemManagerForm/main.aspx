<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Form_main" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <title>main</title>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" /> 
    <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../assets/font-awesome/css/font-awesome.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class=" offset2 text-center">
              <table>
                  <thead>
                      <tr>
                          <td id ="head" runat="server"></td>
                      </tr>
                  </thead>

                  <tbody>
                      <tr>
                          <td id ="city" runat="server"></td>
                      </tr>
                      <tr>
                          <td id="tianqi" runat="server"></td>
                      </tr>
                      <tr>
                          <td id="wendu" runat="server"></td>
                      </tr>
                      
                  </tbody>
              </table>  
        
        </div>
        <div class="offset2">
            <asp:Image ID="txtcityweather" runat="server"  TextMode="MultiLine"></asp:Image> 
        </div>
    </div>
    

    </form>
   
</body>
</html>
