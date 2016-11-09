/*----------------------------------------------------------------
// 文件名：main.aspx.cs
// 文件功能描述：登陆后的欢迎界面
//
//
// 创建标识：
//
// 修改标识：Hu Junyuan 2016-11-09
// 修改描述：使用WebService获取天气情况
//
//----------------------------------------------------------------*/

using System;
using WeatherService;
public partial class Form_main : System.Web.UI.Page
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

        WeatherService.WeatherWS w = new WeatherService.WeatherWS();
        string[] res = new string[23];
        string ct =new pdm.BLL.Address_code().GetModel(Convert.ToInt32( new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"])).City)).A_Name;
        string cityname = ct.Remove(ct.IndexOf("市",1));
        res = w.getWeather(cityname, "");
       
        txtcityweather.ImageUrl = "~/images/" + res[15].Remove(res[10].IndexOf("g"), 3) + "png";
        head.InnerHtml = "<h2>你好啊"+new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"])).Name+"</h2>";
        city.InnerHtml="<h3><i class='fa fa-quote-left fa-1x'></i>"+ct+ "<i class='fa fa-quote-right fa-1x'></h3>";
        wendu.InnerHtml = "<i class='fa fa-thermometer-half fa-2x'></i><h5>"+res[4].Substring(7)+"</h5>";
        tianqi.InnerHtml="<h4>"+ res[12].Substring(res[12].IndexOf("日")+2)+"</h4>";
    }


   
}