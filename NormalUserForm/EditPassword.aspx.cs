using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdm;
public partial class SystemManagerForm_EditPassword : System.Web.UI.Page
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
    }
    protected void sub_Click(object sender, EventArgs e)
    {
        if(oldpassword.Text==(new pdm.BLL.Users().GetModel(Convert.ToInt32(Session["userID"].ToString()))).Dealer_Psw)
        {
            if (("" != psw.Text.Trim()) && ("" != confirm.Text.Trim())&&(psw.Text.Trim()==confirm.Text.Trim()))
            {
                pdm.Model.Users user = new pdm.BLL.Users().GetModel(Convert.ToInt32(Session["userID"].ToString()));
                user.Dealer_Psw = psw.Text.Trim();

                try
                {
                    if ((new pdm.BLL.Users().Update(user)))
                    {
                        Response.Write("<script type='text/javascript'>alert('更新成功')</script>");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('更新失败')</script>");
                    }
                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('数据写入失败')</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('两次输入的密码不一致')</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('原密码错误')</script>");
        }
        

    }

    protected void reset_Click(object sender, EventArgs e)
    {
        psw.Text = "";
        confirm.Text = "";
    }
}