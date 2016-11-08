/*----------------------------------------------------------------
// 文件名：DeletePhoneInfo.aspx.cs
// 文件功能描述：弹出对话框，确认是否删除手机型号
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

public partial class SystemManagerForm_DeletePhoneInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
          
                if (Session.Count > 0 && Session["userID"].ToString() != "")
                { }
                else
                {
                    Response.Redirect("/loginout.aspx?method=sb");
                }
            
            string model = Request.QueryString["id"];
            Response.Write("<Script Language='JavaScript'>if ( window.confirm('确认删除？')) {  window.location.href='./Dealling.aspx?method=deletePhoneInfo&id=" + model + "' } else {window.location.href='./DisplayAllPhoneInfo.aspx' }</script>");
        }
    }
}