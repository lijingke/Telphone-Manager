using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using pdm;


public partial class SystemManagerForm_Delivery : System.Web.UI.Page
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
            
            ListItem mod = new ListItem();
            mod = new ListItem();
            mod.Text = "--型号--";
            mod.Value = "0";
            model.Items.Add(mod);

            ListItem dea = new ListItem();
            dea = new ListItem();
            dea.Text = "--下级经销商--";
            dea.Value = "0";
            dealer.Items.Add(dea);

            //生成手机型号下拉菜单选项
            DataSet modDS = new DataSet();
            string sql = "select Stock_Manage.P_Model,P_Brand from PhoneInfo,Stock_Manage where Stock_Manage.P_Model=PhoneInfo.P_Model and Stock_Manage.Dealer_ID=@dealer_id";
            System.Data.SqlClient.SqlParameter md = new System.Data.SqlClient.SqlParameter("@dealer_id",Session["userID"].ToString());
            modDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql,md);
            int num = 0;

            if ((num = modDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    mod = new ListItem();
                    mod.Value = modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    mod.Text = modDS.Tables[0].Rows[i]["P_Brand"].ToString() + modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    model.Items.Add(mod);
                }
            }

            //生成下级经销商下拉菜单
            DataSet dealDS = new DataSet();
            string sqlstr = "select * from Users where Parent_ID = @parent";
            System.Data.SqlClient.SqlParameter us = new System.Data.SqlClient.SqlParameter("@parent", Session["UserID"].ToString());
            dealDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlstr,us);
            int number = 0;

            if ((number= dealDS.Tables[0].Rows.Count) > 0)
            {
                for (int j = 0; j < number; j++)
                {
                    dea = new ListItem();
                    dea.Value = dealDS.Tables[0].Rows[j]["Dealer_ID"].ToString();
                    dea.Text = (new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32( dealDS.Tables[0].Rows[j]["Dealer_ID"].ToString()))).Name;
                    dealer.Items.Add(dea);
                }
            }
        }
    }

    protected void sub_Click(object sender, EventArgs e)
    {
        if((""!=num.Text.Trim())&&(dealer.SelectedValue!="0")&&(model.SelectedValue!="0"))
        {
            try
            {
                if ((Convert.ToInt32(num.Text) < (new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(Session["UserID"].ToString()), model.SelectedValue).Inventory)))//判断发货方是否有足够库存
                {
                    if ((new pdm.BLL.Stock_Manage().Exists(Convert.ToInt32(dealer.SelectedValue), model.SelectedValue)))//判断是否已经存在下级库存
                    {
                        //加下级库存，下级已有库存
                        pdm.Model.Stock_Manage del = new pdm.Model.Stock_Manage();
                        del.Dealer_ID = Convert.ToInt32(dealer.SelectedValue);
                        del.P_Model = model.SelectedValue;
                        del.Inventory = (new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(dealer.SelectedValue), model.SelectedValue).Inventory) + Convert.ToInt32(num.Text);
                        //减上级库存
                        pdm.Model.Stock_Manage sys = new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(Session["UserID"].ToString()), model.SelectedValue);
                        sys.Inventory = sys.Inventory - Convert.ToInt32(num.Text);


                        if (new pdm.BLL.Stock_Manage().Update(del)&&(new pdm.BLL.Stock_Manage().Update(sys)))
                        {
                            //添加操作日志
                            pdm.Model.UseLog log = new pdm.Model.UseLog();
                            log.Method = "delivery";
                            log.Time = DateTime.Now;
                            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                            log.P_Model = del.P_Model;
                            log.Number = Convert.ToInt32(num.Text);
                            new pdm.BLL.UseLog().Add(log);
                            Response.Write("<script type='text/javascript'>alert('发货成功')</script>");
                        }
                            
                        else
                            Response.Write("<script type='text/javascript'>alert('发货失败')</script>");

                    }
                    else
                    {
                        //加下级库存，下级暂无相应型号手机库存
                        pdm.Model.Stock_Manage del = new pdm.Model.Stock_Manage();
                        del.Dealer_ID = Convert.ToInt32(dealer.SelectedValue);
                        del.P_Model = model.SelectedValue;
                        del.Inventory = Convert.ToInt32(num.Text);

                        //减上级库存
                        pdm.Model.Stock_Manage sys = new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(Session["UserID"].ToString()), model.SelectedValue);
                        sys.Inventory = sys.Inventory- Convert.ToInt32(num.Text);
                        if (new pdm.BLL.Stock_Manage().Add(del) && (new pdm.BLL.Stock_Manage().Update(sys))) 
                        {
                            //添加操作日志
                            pdm.Model.UseLog log = new pdm.Model.UseLog();
                            log.Method = "delivery";
                            log.Time = DateTime.Now;
                            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                            log.P_Model = del.P_Model;
                            log.Number = del.Inventory;
                            new pdm.BLL.UseLog().Add(log);
                            Response.Write("<script type='text/javascript'>alert('发货成功')</script>");
                        }
                        else
                           { Response.Write("<script type='text/javascript'>alert('发货失败')</script>"); }
                    } 
                 }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('库存不足')</script>");
                }
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('出错')</script>");
            }
        }

    }

    protected void reset_Click(object sender, EventArgs e)
    {
        dealer.SelectedIndex = 0;
        model.SelectedIndex = 0;
        num.Text = "";
    }
}