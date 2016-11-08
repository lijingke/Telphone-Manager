/*----------------------------------------------------------------
// 文件名：add_Dealer.aspx.cs
// 文件功能描述：添加下级用户
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
using System.Data;

public partial class Form_add_Dealer : System.Web.UI.Page
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
            
            ListItem prov = new ListItem();
            prov = new ListItem();
            prov.Text = "--省份--";
            prov.Value = "0";
            Province.Items.Add(prov);

           

            //生成省份下拉菜单选项
            DataSet ProvDS = new DataSet();
            string sql = "select * from Address_code where Code < 100";
            ProvDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            int num = 0;

            if ((num = ProvDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    prov = new ListItem();
                    prov.Value = ProvDS.Tables[0].Rows[i]["Code"].ToString();
                    prov.Text = ProvDS.Tables[0].Rows[i]["A_Name"].ToString();
                    Province.Items.Add(prov);
                }
            }
        }
       
    }

    protected void reset_Click(object sender, EventArgs e)//重置按钮点击触发事件
    {
        username.Text = "";
        password.Text = "";
        password2.Text = "";
        dealer_name.Text = "";
        telephone_number.Text = "";
        addr.Text = "";
        Province.SelectedIndex = 0;
        City.Visible = false;
        County.Visible = false;
         
    }

    protected void submit_Click(object sender, EventArgs e)//提交按钮点击触发事件
    {
        pdm.Model.DealerInfo di = new pdm.Model.DealerInfo();
       
        pdm.Model.Users user = new pdm.Model.Users();
        if((null!=username.Text.Trim())&&((null!=password.Text.Trim())==(null!=password2.Text.Trim()))&&(0!=Convert.ToInt32(Province.SelectedValue))&& (0 != Convert.ToInt32(County.SelectedValue))&& (0 != Convert.ToInt32(City.SelectedValue))&& (null!= addr.Text.Trim()))
        {
            if(!(new pdm.BLL.Users().Exists(username.Text.Trim())))
            {
                user.Dealer_Name = username.Text.Trim();                    
                user.Dealer_Psw = password.Text.Trim();
                user.Parent_ID = Convert.ToInt32( Session["UserID"]);
                user.Dealer_Level = Convert.ToInt32(Session["UserLevel"]) + 1;
                try
                {   
                    //将数据写入Users表
                    new pdm.BLL.Users().Add(user);


                    //获取插入数据的Dealer_ID，存放在dealer_id中
                    DataSet userDS = new DataSet();
                    string sql = "select * from Users where Dealer_Name = @name";
                    System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@name", username.Text.Trim());
                    userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, us);
                   int dealer_id = Convert.ToInt32 (userDS.Tables[0].Rows[0]["Dealer_ID"].ToString());

                    //Response.Write("<script type='text/javascript'>alert('" + dealer_id+ "')</script>");
                    //将资料写入DealerInfo表中
                    di.Dealer_ID = dealer_id;
                    di.Name = dealer_name.Text.Trim();
                    di.Province = Convert.ToInt32( Province.SelectedValue);
                    di.City = Convert.ToInt32(City.SelectedValue);
                    di.County = Convert.ToInt32(County.SelectedValue);
                    di.Tel = Convert.ToInt32(telephone_number.Text);
                    di.Address = addr.Text;
                    new pdm.BLL.DealerInfo().Add(di);
                    Response.Write("<script type='text/javascript'>alert('添加成功')</script>");

                    //重置所有输入框
                    username.Text = "";
                    password.Text = "";
                    password2.Text = "";
                    dealer_name.Text = "";
                    telephone_number.Text = "";
                    addr.Text = "";
                    Province.SelectedIndex = 0;
                    City.Visible = false;
                    County.Visible = false;
                    
                    //添加日志记录
                    pdm.Model.UseLog log = new pdm.Model.UseLog();
                    log.Method = "add_user";
                    log.Time = DateTime.Now;
                    log.Dealer_ID =Convert.ToInt32( Session["userID"].ToString());
                    new pdm.BLL.UseLog().Add(log);

                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('添加失败，请重试')</script>");
                }

            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('用户名已存在')</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请检查信息是否有错')</script>");
        }
    }

    protected void Province_SelectedIndexChanged(object sender, EventArgs e)//省份下拉菜单选项更改触发事件
    {
        City.Visible = true;
        County.Visible = false;
        City.Items.Clear();
        County.Items.Clear();
        ListItem city = new ListItem();
        city.Text = "--城市--";
        city.Value = "0";
        City.Items.Add(city);


        DataSet cityDS = new DataSet();
        int citycode = Convert.ToInt32(Province.SelectedValue)*100;
       // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
        string sql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
        System.Data.SqlClient.SqlParameter ct = new System.Data.SqlClient.SqlParameter("@ccode", citycode);
        cityDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql,ct);
        int num = 0;


        if ((num = cityDS.Tables[0].Rows.Count) > 0)
        {
            for (int i = 0; i < num; i++)
            {
                city = new ListItem();
                city.Value = cityDS.Tables[0].Rows[i]["Code"].ToString();
                city.Text = cityDS.Tables[0].Rows[i]["A_Name"].ToString();
                City.Items.Add(city);
            }
        }
    }



    protected void City_SelectedIndexChanged(object sender, EventArgs e)//城市下拉菜单选项更改触发事件
    {
        County.Visible = true;
        County.Items.Clear();
        ListItem county = new ListItem();
        county.Text = "--县--";
        county.Value = "0";
        County.Items.Add(county);


        DataSet countyDS = new DataSet();
        int countycode = Convert.ToInt32(City.SelectedValue) * 100;
        // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
        string sql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
        System.Data.SqlClient.SqlParameter ct = new System.Data.SqlClient.SqlParameter("@ccode", countycode);
        countyDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, ct);
        int num = 0;


        if ((num = countyDS.Tables[0].Rows.Count) > 0)
        {
            for (int i = 0; i < num; i++)
            {
                county = new ListItem();
                county.Value = countyDS.Tables[0].Rows[i]["Code"].ToString();
                county.Text = countyDS.Tables[0].Rows[i]["A_Name"].ToString();
                County.Items.Add(county);
            }
        }
    

        
    }
}