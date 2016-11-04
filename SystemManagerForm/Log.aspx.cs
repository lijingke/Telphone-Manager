﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using pdm;
public partial class SystemManagerForm_Log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string method = Request.QueryString["method"];
        switch(method)
        {
            case "user"://账号管理日志
                
                    string html = "<div class='container'><div class='span10'><table class='table table-bordered'><thead><tr><th class='span3'>操作</th><th class='span3'>时间</th></tr></thead>";
                    DataSet userDS = new DataSet();
                    string sql = "select * from UseLog where (Method='add_user' or Method='delete_user' or Method='edit_user_info') and Dealer_ID=@dealer_id";
                    System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@dealer_id", Session["UserID"]);
                    userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, us);
                    int num = 0;

                    if ((num = userDS.Tables[0].Rows.Count) > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            html = html + " <tr><td class='span2'>" + userDS.Tables[0].Rows[i]["Method"].ToString() + "</td><td class='span2'>" + userDS.Tables[0].Rows[i]["Time"].ToString() + "</td></tr>";
                        }
                        html += "</table></div></div>";
                    }
                    cont.InnerHtml = html;
                    break;
                

            case "phone"://手机信息管理日志
                string htm = "<div class='container'><div class='span10'><table class='table table-bordered'><thead><tr><th class='span2'>操作</th><th class='span2'>手机型号</th><th class='span3'>时间</th></tr></thead>";
                DataSet phonerDS = new DataSet();
                string sqlphone = "select * from UseLog where (Method='add_phone_model' or Method='edit_phone_info' or Method='delete_phone_info') and Dealer_ID=@dealer_id";
                System.Data.SqlClient.SqlParameter ph = new System.Data.SqlClient.SqlParameter("@dealer_id", Session["UserID"]);
                userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlphone, ph);
                int count = 0;

                if ((count = userDS.Tables[0].Rows.Count) > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        htm = htm + " <tr><td>" + userDS.Tables[0].Rows[i]["Method"].ToString() + "</td><td>" + userDS.Tables[0].Rows[i]["P_Model"].ToString() + "</td><td>" + userDS.Tables[0].Rows[i]["Time"].ToString() + "</td></tr>";
                    }
                    htm += "</table></div></div>";
                }
                cont.InnerHtml = htm;
                break;

            case "stock"://库存管理日志
                string ht = "<div class='container'><div class='span10'><table class='table table-bordered'><thead><tr><th class='span2'>操作</th><th class='span2'>手机型号</th><th class='span1'>数量</th><th class='span3'>时间</th></tr></thead>";
                DataSet stockDS = new DataSet();
                string sqlstock = "select * from UseLog where (Method='delivery' or Method='supply' ) and Dealer_ID=@dealer_id";
                System.Data.SqlClient.SqlParameter st = new System.Data.SqlClient.SqlParameter("@dealer_id", Session["UserID"]);
                userDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlstock,st);
                int n = 0;

                if ((n = userDS.Tables[0].Rows.Count) > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        ht = ht + " <tr><td>" + userDS.Tables[0].Rows[i]["Method"].ToString() + "</td><td>" + userDS.Tables[0].Rows[i]["P_Model"].ToString() + "</td><td>" + userDS.Tables[0].Rows[i]["Number"].ToString() + "</td><td>" + userDS.Tables[0].Rows[i]["Time"].ToString() + "</td></tr>";
                    }
                    ht += "</table></div></div>";
                }
                cont.InnerHtml = ht;
                break;

            default:
                break;
        }
    }
}