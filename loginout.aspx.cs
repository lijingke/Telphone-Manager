/*----------------------------------------------------------------
// 文件名：loginout.aspx.cs
// 文件功能描述：注销登陆，清除session
//
//
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string method = Request.QueryString["method"];
        switch (method)
        {
            case "sb":
                Response.Write("<script type='text/javascript'>alert('请勿非法使用');window.location.href='Login.aspx';</script>");
                break;
            case "loginout":
                Session.Clear();
                Response.Write("<script type='text/javascript'>alert('注销成功');window.location.href='Login.aspx';</script>");
                break;
            default:
                Session.Clear();
                Response.Redirect("/Login.aspx");
                break;
        }
    }
}