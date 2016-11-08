/*----------------------------------------------------------------
// 文件名：Dealling.aspx.cs
// 文件功能描述：根据get方法传过来的参数，删除指定的内容
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

public partial class SystemManagerForm_Dealling : System.Web.UI.Page
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
        string method = Request.QueryString["method"];
        string  id =Request.QueryString["id"];
   // 通过method来决定执行操作
        switch (method)
        {
            case "delete"://删除用户信息及该用户所有库存
                int dealer_id = Convert.ToInt32(id);
                if((new pdm.BLL.Users().Delete(dealer_id))&&(new pdm.BLL.DealerInfo().Delete(dealer_id))) {
                   
                    
                    //添加操作日志
                    pdm.Model.UseLog log = new pdm.Model.UseLog();
                    log.Method = "delete_user";
                    log.Time = DateTime.Now;
                    log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                    new pdm.BLL.UseLog().Add(log);

                    

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
                    //添加操作日志
                    pdm.Model.UseLog log = new pdm.Model.UseLog();
                    log.Method = "delete_phone_info";
                    log.Time = DateTime.Now;
                    log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                    log.P_Model = id;
                    new pdm.BLL.UseLog().Add(log);
                    Response.Write("<script type='text/javascript'>alert('删除成功');window.location.href='./DisplayAllPhoneInfo.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('删除失败');window.location.href='./DisplayAllPhoneInfo.aspx';</script>");
                }
                break;
            case "deleteStock"://删除库存
                string model = Request.QueryString["model"];
                if(new pdm.BLL.Stock_Manage().Delete( Convert.ToInt32(id),model))
                {
                    //添加操作记录
                    pdm.Model.UseLog log = new pdm.Model.UseLog();
                    log.Method = "delete_stock";
                    log.Time = DateTime.Now;
                    log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                    log.P_Model = model;
                    new pdm.BLL.UseLog().Add(log);
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