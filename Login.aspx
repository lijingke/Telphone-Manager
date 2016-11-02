<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登陆</title>
    <link rel="stylesheet" type="text/css" href="./assets/css/bootstrap.css"/>
    <link rel="stylesheet" type="text/css" href="./assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/font-awesome/css/font-awesome.css" />
    <style type="text/css">
    body{
		font-family: 'microsoft yahei',Arial,sans-serif;
		background-color: #222;
	}
    .redborder {
		border:2px solid #f96145;
		border-radius:2px;
	}

	.row {
		padding: 20px 0px;
	}


	.loginpanel {
		text-align: center;
		width: 300px;
		border-radius: 0.5rem;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		margin: 10px auto;
		background-color: #555;
		padding: 20px;
	}

	input {
		width: 100%;
		margin-bottom: 17px;
		padding: 15px;
		background-color: #ECF4F4;
		border-radius: 2px;
		border: none;
	}

	h2 {
		margin-bottom: 20px;
		font-weight: normal;
		color: #EFEFEF;
	}


</style>
</head>




<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
    <div class="row">
        <div class="loginpanel">
			<i class="fa fa-cog fa-spin fa-4x"></i>
            <h2>
				<i class="fa fa-quote-left "></i> 登录 <i class="fa fa-quote-right "></i>
			</h2>
            <div>
                <asp:TextBox ID="username" type="text" placeholder="登录账号" runat="server"></asp:TextBox>  
                <asp:TextBox ID="password"  type="password" placeholder="输入密码" runat="server"></asp:TextBox>
              
				<div>
					<asp:Button runat="server" ID="SignIn" Text="登陆" class="btn btn-large" OnClick="SignIn_Click" />
                    <asp:Button runat="server" ID="Reset" Text="重置" class="btn btn-large" OnClick="Reset_Click" />
				</div>
            </div>
        </div>
    </div>
</div>

    </form>
</body>
</html>
