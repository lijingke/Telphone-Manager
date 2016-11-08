/*----------------------------------------------------------------
// 文件名：return.aspx.cs
// 文件功能描述：向上级退货功能
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
public partial class NormalUserForm_return : System.Web.UI.Page
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

            //生成手机型号下拉菜单选项
            DataSet modDS = new DataSet();
            string sql = "select * from Stock_Manage where Dealer_ID = @dealer_id";
            System.Data.SqlClient.SqlParameter id = new System.Data.SqlClient.SqlParameter("@dealer_id", Session["userID"].ToString());
            modDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, id);
            int num = 0;

            if ((num = modDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    mod = new ListItem();
                    mod.Value = modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    mod.Text = new pdm.BLL.PhoneInfo().GetModel(modDS.Tables[0].Rows[i]["P_Model"].ToString()).P_Brand + modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    model.Items.Add(mod);
                }
            }
        }
    }

    protected void sub_Click(object sender, EventArgs e)
    {
        if((num.Text.Trim()!="")&&(Convert.ToInt32(num.Text.Trim())>=0)&&(model.SelectedValue!="0"))//判断选择的型号与输入的数量是否是合法值
        {
            if((Convert.ToInt32(num.Text.Trim())<=(new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(Session["userID"].ToString()),model.SelectedValue).Inventory)))//判断输入的数量是否小于等于库存
            {
                try
                {
                    //当前用户减库存
                    pdm.Model.Stock_Manage son = new pdm.Model.Stock_Manage();
                    son.Dealer_ID = Convert.ToInt32(Session["userID"]);
                    son.P_Model = model.SelectedValue;
                    son.Inventory =(new pdm.BLL.Stock_Manage().GetModel(Convert.ToInt32(Session["userID"].ToString()),model.SelectedValue).Inventory) - Convert.ToInt32(num.Text.Trim());
                    new pdm.BLL.Stock_Manage().Update(son);

                    //上级用户加库存
                    pdm.Model.Stock_Manage parent = new pdm.Model.Stock_Manage();
                    parent.Dealer_ID = (new pdm.BLL.Users().GetModel(Convert.ToInt32(Session["userID"].ToString())).Parent_ID);
                    parent.P_Model = model.SelectedValue;
                    if(new pdm.BLL.Stock_Manage().Exists(parent.Dealer_ID,parent.P_Model))
                    {
                        parent.Inventory = Convert.ToInt32(num.Text.Trim()) + (new pdm.BLL.Stock_Manage().GetModel(parent.Dealer_ID, parent.P_Model).Inventory);
                        if(new pdm.BLL.Stock_Manage().Update(parent))
                        {

                            //添加操作日志
                            pdm.Model.UseLog log = new pdm.Model.UseLog();
                            log.Method = "return";
                            log.Time = DateTime.Now;
                            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                            log.P_Model = model.SelectedValue;
                            log.Number = Convert.ToInt32(num.Text.Trim());
                            new pdm.BLL.UseLog().Add(log);
                            Response.Write("<script type='text/javascript'>alert('退货成功');</script>");
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('退货失败');</script>");
                        }
                    }
                    else
                    {//库存中上级没有该型号的记录
                        parent.Inventory = Convert.ToInt32(num.Text.Trim());
                        if (new pdm.BLL.Stock_Manage().Add(parent))
                        {

                            //添加操作日志
                            pdm.Model.UseLog log = new pdm.Model.UseLog();
                            log.Method = "return";
                            log.Time = DateTime.Now;
                            log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
                            log.P_Model = model.SelectedValue;
                            log.Number = Convert.ToInt32(num.Text.Trim());
                            new pdm.BLL.UseLog().Add(log);
                            Response.Write("<script type='text/javascript'>alert('退货成功');</script>");
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('退货失败');</script>");
                        }

                    }


                }
                catch
               {
                    Response.Write("<script type='text/javascript'>alert('出错');</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('数量超过已有库存');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请输入正确的型号与数量');</script>");
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        model.SelectedIndex = 0;
        num.Text = "";
    }
}