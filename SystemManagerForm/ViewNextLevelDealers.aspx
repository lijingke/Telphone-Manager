<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNextLevelDealers.aspx.cs" Inherits="SystemManagerForm_ViewNextLevelDealers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" /> 
    <link rel="stylesheet" href="../assets/css/bootstrap-theme.css"/>
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
     <link rel="stylesheet" href="../assets/font-awesome/css/font-awesome.css" />
    <style type="text/css">
         .table th, .table td { 
	text-align: center; 
	
}
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class=" span10">
            <table class="table table-bordered" >
            <thead>
                <tr>
                    <th class="span3">编号</th>
                    <th class="span3">用户名</th>
                    <th class="span4" colspan="2">操作</th>
                    </tr>
               
            </thead>
               <div id="cont" runat="server">
                   
               
          
               </div>
              
               
        </table>
        </div>
        
    </div>
       
    </form>
</body>
</html>
