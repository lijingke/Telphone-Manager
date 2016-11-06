using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemManagerForm_EditPhoneInfo : System.Web.UI.Page
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
            
            string mod = Request.QueryString["id"];
            Session["phone"] = mod;
            pdm.Model.PhoneInfo phone = new pdm.BLL.PhoneInfo().GetModel(mod);
            model.Text = phone.P_Model;
            address.Text = phone.P_Address;
            color.Text = phone.P_Color;
            brand.Text = phone.P_Brand;
            Deploy.Text = phone.P_Deploy;
        }
       

    }

    protected void sub_Click(object sender, EventArgs e)
    {

        if((""!=color.Text.Trim())&&(""!=Deploy.Text.Trim())&&(""!=brand.Text.Trim()))
        {
            pdm.Model.PhoneInfo phone = new pdm.Model.PhoneInfo();
            phone.P_Model= Session["phone"].ToString();
            Session.Remove("phone");
            phone.P_Address = address.Text.Trim();
            phone.P_Color = color.Text.Trim();
            phone.P_Deploy = Deploy.Text.Trim();
            phone.P_Brand = brand.Text.Trim();

            try
            {
                if((new pdm.BLL.PhoneInfo().Update(phone)))
                {
                    //添加操作日志
                    pdm.Model.UseLog log = new pdm.Model.UseLog();
                    log.Method = "edit_phone_info";
                    log.Time = DateTime.Now;
                    log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                    log.P_Model = phone.P_Model;
                    
                    new pdm.BLL.UseLog().Add(log);

                    Response.Write("<script type='text/javascript'>alert('更新成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('更新失败')</script>");
                }
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('更新失败')</script>");
            }


        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请完善所有信息，带‘*’的为必填项')</script>");
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        address.Text = "";
        color.Text = "";
        Deploy.Text = "";
        brand.Text = "";
    }
}