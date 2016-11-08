/*----------------------------------------------------------------
// 文件名：EditStockInfo.aspx.cs
// 文件功能描述：通过传过来的参数，修改相应的库存信息
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

public partial class SystemManagerForm_EditStockInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {//将型号显示出来
            if (Session.Count > 0 && Session["userID"].ToString() != "")
                { }
                else
                {
                    Response.Redirect("/loginout.aspx?method=sb");
                }
             
            Session["tempid"] = Request.QueryString["id"];
            Session["tempmodel"] = Request.QueryString["model"];
            model.Text = new pdm.BLL.PhoneInfo().GetModel(Session["tempmodel"].ToString()).P_Brand+ Session["tempmodel"].ToString();
           
               

        }

    }

    protected void sub_Click(object sender, EventArgs e)
    {

        //Response.Write("<script type='text/javascript'>alert('" + Session["tempid"] + "');</script>");
        pdm.Model.Stock_Manage stock = new pdm.Model.Stock_Manage();
        stock.Dealer_ID = Convert.ToInt32(Session["tempid"].ToString());
        stock.P_Model = Session["tempmodel"].ToString();
        Session.Remove("tempmodel");
        Session.Remove("tempid");
        if (Convert.ToInt32(num.Text)>=0)
        {
            stock.Inventory = Convert.ToInt32(num.Text);
        }
        if(new pdm.BLL.Stock_Manage().Update(stock))
        {
            //添加操作日志
            pdm.Model.UseLog log = new pdm.Model.UseLog();
            log.Method = "edit_Stock";
            log.Time = DateTime.Now;
            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
            log.P_Model = stock.P_Model;
            log.Number = Convert.ToInt32(num.Text);
            new pdm.BLL.UseLog().Add(log);
            Response.Write("<script type='text/javascript'>alert('修改成功');window.location.href='./EditStock.aspx';</script>");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('修改失败');window.location.href='./EditStock.aspx';</script>");
        }



    }

    protected void reset_Click(object sender, EventArgs e)
    {

    }
}