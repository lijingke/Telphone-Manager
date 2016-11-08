/*----------------------------------------------------------------
// 文件名：EditStock.aspx.cs
// 文件功能描述：显示库存信息，并且显示修改删除的按钮
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
using System.Data;
using pdm;
public partial class SystemManagerForm_EditStock : System.Web.UI.Page
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
            DataSet stockDS = new DataSet();
            string sql = "select * from Stock_Manage where Dealer_ID = @id";
            System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@id", Session["UserID"]);
            stockDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, us);
            int num = 0;

            if ((num = stockDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    //构造表格中数据内容
                    html += " <tr><td class='span1'>" + new pdm.BLL.PhoneInfo().GetModel(stockDS.Tables[0].Rows[i]["P_Model"].ToString()).P_Brand + stockDS.Tables[0].Rows[i]["P_Model"].ToString() + "</td><td class='span1'>" + stockDS.Tables[0].Rows[i]["Inventory"].ToString() + "</td><td class='span2' rospan='2'><a href ='./EditStockInfo.aspx?id=" + stockDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + "&model=" + stockDS.Tables[0].Rows[i]["P_Model"].ToString() + "'><i class='fa  fa-edit ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = './DeleteStockInfo.aspx?id=" + stockDS.Tables[0].Rows[i]["Dealer_ID"].ToString() + "&method=deleteStock&model="+stockDS.Tables[0].Rows[i]["P_Model"].ToString() + "'><i class='fa  fa-trash-o ' style='color:#3F444D'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>";
                }

            }
            else
            {
                html += " <tr><td class='span1'>无</td><td class='span1'>无</td><td class='span2' rospan='2'>无</td></tr>";
            }
            cont.InnerHtml = html;
        }
    }
}