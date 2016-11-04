using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemManagerForm_add_PhoneInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sub_Click(object sender, EventArgs e)
    {
        if ((null!=model.Text.Trim())&&(null!=color.Text.Trim())&&(null!=Deploy.Text.Trim())&&(null!=brand.Text.Trim()))
        {
            if (!(new pdm.BLL.PhoneInfo().Exists(model.Text.Trim())))
            {
                pdm.Model.PhoneInfo phone = new pdm.Model.PhoneInfo();
                phone.P_Model = model.Text;
                phone.P_Address = address.Text;
                phone.P_Color = color.Text;
                phone.P_Deploy = Deploy.Text;
                phone.P_Brand = brand.Text;
                if (new pdm.BLL.PhoneInfo().Add(phone))
                {
                    Response.Write("<script type='text/javascript'>alert('添加成功')</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败')</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('已存在该型号')</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请完善所有信息，带‘*’的为必填项')</script>");
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        model.Text = "";
        address.Text = "";
        color.Text = "";
        Deploy.Text = "";
        brand.Text = "";
    }
}