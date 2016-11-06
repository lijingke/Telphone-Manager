<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="Form_left" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <title>控制台</title>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" /> 
    <script src="../assets/jquery/jquery-3.1.1.min.js"></script>
   <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../assets/css/nav.css" rel="stylesheet" />
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="../assets/js/bootstrap.js"></script>
</head>
<body>

  
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                <ul id="main-nav" class="nav nav-tabs nav-stacked" style="">
                    <li class="active">
                        <a href="main.aspx" target="right">
                            <i class="icon-th-large"></i>
                            首页         
                        </a>
                    </li>
                    <li>
                        <a href="#UserSetting" class="nav-header collapsed " data-toggle="collapse">
                            <i class=" icon-user"></i>
                            账号管理
                               <span class="pull-right icon-chevron-down"></span>
                        </a>
                        <ul id="UserSetting" class="nav nav-list collapse secondmenu " style="height: 0px;">
                            <li><a href="ViewNextLevelDealers.aspx" target="right"><i class="icon-star"></i>查看下级用户账号</a></li>
                            <li><a href="EditMyInfo.aspx" target="right"><i class=" icon-pencil"></i>修改我的信息</a></li>
                            <li><a href="add_Dealer.aspx" target="right"><i class="icon-plus"></i>添加下级经销商</a></li>
                            <li><a href="EditPassword.aspx" target="right"><i class="icon-edit"></i>修改我的密码</a></li>
                            <li><a href="Log.aspx/?method=user" target="right"><i class=" icon-eye-open"></i>日志查看</a></li>
                             <li><a href="../loginout.aspx?method=loginout" target="_top"><i class="fa fa-power-off"></i>退出登陆</a></li>
                        </ul>
                    </li>

                    <li>
                        <a href="#PhoneInfo" class="nav-header collapsed " data-toggle="collapse">
                            <i class=" icon-edit"></i>
                            手机信息管理
                            <span class="pull-right icon-chevron-down "></span>        
                        </a>

                        <ul id="PhoneInfo" class="nav nav-list collapse secondmenu " style="height: 0px;">
                            <li><a href="./DisplayAllPhoneInfo.aspx" target="right"><i class="icon-star"></i>查看所有手机信息</a></li>
                            
                        </ul>
                    </li>
 
                    <li>
                        <a href="#StockManage"class="nav-header collapsed " data-toggle="collapse">
                            <i class=" icon-globe"></i>
                           库存管理
                            <span class="pull-right icon-chevron-down "></span>
                        </a>
                        <ul id="StockManage" class="nav nav-list collapse secondmenu " style="height: 0px;">
                            <li><a href="Delivery.aspx" target="right"><i class=" icon-random"></i>向下级发货</a></li>
                            <li><a href="return.aspx" target="right"><i class=" icon-shopping-cart"></i>向上级退货</a></li>
                            <li><a href="EditStock.aspx" target="right"><i class=" icon-pencil"></i>库存信息</a></li>
                            <li><a href="Log.aspx/?method=stock" target="right"><i class=" icon-eye-open"></i>日志查看</a></li>
                        </ul>
                    </li>
 
                
             
 
                </ul>
            </div>
          
        </div>
    </div>

 
</body>
</html>
