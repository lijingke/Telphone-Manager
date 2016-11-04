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