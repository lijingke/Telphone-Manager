using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using pdm;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void SignIn_Click(object sender, EventArgs e)
    {
        if(null!=username.Text.Trim()&&null!=password.Text.Trim())
        {
            try
            {
                //根据输入框中的用户名来取出一个Dataset，搜索语句采用传参的方式
                DataSet userDS = new DataSet();
                string sql = "select * from Users where Dealer_Name = @name";
                pdm.BLL.DealerInfo dealer = new pdm.BLL.DealerInfo();
                System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@name", username.Text.Trim());
                userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, us);
                
                //判断是否密码是否正确
                if (userDS.Tables[0].Rows.Count > 0)
                {

                    if (userDS.Tables[0].Rows[0]["Dealer_Psw"].ToString() == password.Text.Trim())
                    {
                       
                        Session["UserID"] = userDS.Tables[0].Rows[0]["Dealer_ID"].ToString();
                        Session["UserName"] = userDS.Tables[0].Rows[0]["Dealer_Name"].ToString();
                        Session["UserLevel"] = userDS.Tables[0].Rows[0]["Dealer_Level"].ToString();
                        Session["Parent"] = userDS.Tables[0].Rows[0]["Parent_ID"].ToString();
                       
                        if (int.Parse(userDS.Tables[0].Rows[0]["Parent_ID"].ToString())==-1)
                        {
                            //添加操作日志
                            pdm.Model.UseLog log = new pdm.Model.UseLog();
                            log.Method = "login";
                            log.Time = DateTime.Now;
                            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());                           
                            new pdm.BLL.UseLog().Add(log);
                            Response.Write("<script type='text/javascript'>alert('登陆成功');window.location.href='./SystemManagerForm/index.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('登陆成功');window.location.href='./NormalUserForm/index.aspx'</script>");
                        }
                        
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('请检查用户名或密码是否正确')</script>");
                    }
                }
                
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('登陆失败')</script>");
            }
        }
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        username.Text = "";
        password.Text = "";
    }
}