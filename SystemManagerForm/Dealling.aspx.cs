using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdm;

public partial class SystemManagerForm_Dealling : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string method = Request.QueryString["method"];
        string  id =Request.QueryString["id"];
   // 通过method来决定执行操作
        switch (method)
        {
            case "delete"://删除用户信息
                int dealer_id = Convert.ToInt32(id);
                if((new pdm.BLL.Users().Delete(id))&&(new pdm.BLL.DealerInfo().Delete(dealer_id))) { 
                Response.Write("<script type='text/javascript'>alert('删除成功');window.location.href='./ViewNextLevelDealers.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('删除失败');window.location.href='./ViewNextLevelDealers.aspx'</script>");
                }
                break;
            case "deletePhoneInfo"://删除手机信息
                if(new pdm.BLL.PhoneInfo().Delete(id))
                {
                    Response.Write("<script type='text/javascript'>alert('删除成功');window.location.href='./DisplayAllPhoneInfo.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('删除失败');window.location.href='./DisplayAllPhoneInfo.aspx';</script>");
                }
                break;
            case "deleteStock"://删除信息
                string model = Request.QueryString["model"];
                if(new pdm.BLL.Stock_Manage().Delete( Convert.ToInt32(id),model))
                {
                    Response.Write("<script type='text/javascript'>alert('删除成功');window.location.href='./EditStock.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('删除失败');window.location.href='./EditStock.aspx';</script>");
                }
                break;
            default:
                Response.Redirect("./main.aspx"); break;
        }

    }
}