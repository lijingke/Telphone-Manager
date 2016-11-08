/*----------------------------------------------------------------
// 文件名：PhoneInfo.aspx.cs
// 文件功能描述：根据传过来的手机型号，显示手机详细信息
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
using pdm;


public partial class SystemManagerForm_PhoneInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session.Count > 0 && Session["userID"].ToString() != "")
            { }
            else
            {
                Response.Redirect("/loginout.aspx?method=sb");
            }
        }
        string mod = Request.QueryString["id"];//获取传过来的手机型号
        pdm.Model.PhoneInfo phone = new pdm.BLL.PhoneInfo().GetModel(mod);
        model.Text = phone.P_Model;
        address.Text = phone.P_Address;
        color.Text = phone.P_Color;
        Deploy.Text = phone.P_Deploy;
        brand.Text = phone.P_Brand;


    }
}