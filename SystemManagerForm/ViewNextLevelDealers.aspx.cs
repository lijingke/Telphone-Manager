using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using pdm;

public partial class SystemManagerForm_ViewNextLevelDealers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string html = "";
            DataSet userDS = new DataSet();
            string sql = "select * from Users where Parent_ID = @id";
            System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@id", Session["UserID"]);
            userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, us);
            int num = 0;

            if ((num = userDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    //构造表格中数据内容
                    html += " <tr><td class='span1'>" + userDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + "</td><td class='span1'>" + userDS.Tables[0].Rows[i]["Dealer_Name"].ToString() + "</td><td class='span2' rospan='2'><a href='./Dealer_Info.aspx?id="+ userDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + "&uname="+ userDS.Tables[0].Rows[i]["Dealer_Name"].ToString()+"'><i class='fa fa-eye ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href ='./EditInfo.aspx?id=" + userDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + "&uname="+ userDS.Tables[0].Rows[i]["Dealer_Name"].ToString() + "'><i class='fa  fa-edit ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = './DeleteInfo.aspx?id=" + userDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + " '><i class='fa  fa-trash-o ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>";
                }

            }
            cont.InnerHtml = html;
        }

    }
} 