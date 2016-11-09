/*----------------------------------------------------------------
// 文件名：DisplayAllPhoneInfo.aspx.cs
// 文件功能描述：显示所有手机型号信息
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
using System.Data;
using pdm;
public partial class SystemManagerForm_DisplayAllPhoneInfo : System.Web.UI.Page
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
            
            string html = "";
            DataSet phoneDS = new DataSet();
            string sql = "select * from PhoneInfo";
            phoneDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            int num = 0;

            if ((num = phoneDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    //构造表格中数据内容
                    html += " <tr><td class='span1'>" + phoneDS.Tables[0].Rows[i]["P_Model"].ToString() + "</td><td class='span1'>" + phoneDS.Tables[0].Rows[i]["P_Brand"].ToString() + "</td><td class='span2' rospan='2'><a href='./PhoneInfo.aspx?id=" + phoneDS.Tables[0].Rows[i]["P_Model"].ToString() + "'><i class='fa fa-eye ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href ='./EditPhoneInfo.aspx?id=" + phoneDS.Tables[0].Rows[i]["P_Model"].ToString() + "'><i class='fa  fa-edit ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = './DeletePhoneInfo.aspx?id=" + phoneDS.Tables[0].Rows[i]["P_Model"].ToString() + " '><i class='fa  fa-trash-o ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>";
                }

            }
            allinfo.InnerHtml = html;
        }

    }
}