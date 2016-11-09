/*----------------------------------------------------------------
// 文件名：Dealer_Info.aspx.cs
// 文件功能描述：查看用户详细信息
//
//
// 创建标识：
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

public partial class SystemManagerForm_Dealer_Info : System.Web.UI.Page
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
        }//验证身份

        pdm.Model.DealerInfo di =  new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Request.QueryString["id"]));
        username.Text = Request.QueryString["uname"];
        dealer_name.Text = di.Name;
        telephone_number.Text = di.Tel.ToString();
        addr.Text = di.Address;
        string province = new pdm.BLL.Address_code().GetModel( Convert.ToInt32( di.Province)).A_Name;
        string city = new pdm.BLL.Address_code().GetModel(Convert.ToInt32(di.City)).A_Name;
        string county = new pdm.BLL.Address_code().GetModel(Convert.ToInt32(di.County)).A_Name;
        pd.Text = province + city + county;
    }
}