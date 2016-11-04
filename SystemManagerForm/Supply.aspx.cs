using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using pdm;
public partial class SystemManagerForm_Supply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListItem mod = new ListItem();
            mod = new ListItem();
            mod.Text = "--型号--";
            mod.Value = "0";
           model.Items.Add(mod);



            //生成手机型号下拉菜单选项
            DataSet modDS = new DataSet();
            string sql = "select * from PhoneInfo";
            modDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            int num = 0;

            if ((num = modDS.Tables[0].Rows.Count) > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    mod = new ListItem();
                    mod.Value = modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    mod.Text = modDS.Tables[0].Rows[i]["P_Brand"].ToString()+modDS.Tables[0].Rows[i]["P_Model"].ToString();
                    model.Items.Add(mod);
                }
            }
        }
    }

    protected void sub_Click(object sender, EventArgs e)
    {
        int dealer_id = Convert.ToInt32(Session["UserID"].ToString());//
        if(model.SelectedValue!="0")
        {
            pdm.Model.Stock_Manage stock = new pdm.Model.Stock_Manage();
            stock.Dealer_ID = dealer_id;
            stock.P_Model = model.SelectedValue;
            stock.Inventory = Convert.ToInt32(num.Text);
            if(new pdm.BLL.Stock_Manage().Exists(dealer_id, model.SelectedValue))//判断是否存在库存信息，如果有则更新若无则添加
            {
                int i = new pdm.BLL.Stock_Manage().GetModel(dealer_id, model.SelectedValue).Inventory;
                stock.Inventory += i;
                if(new pdm.BLL.Stock_Manage().Update(stock))
                    Response.Write("<script type='text/javascript'>alert('进货成功');</script>");
                else
                    Response.Write("<script type='text/javascript'>alert('进货失败');</script>");
            }
            else
            {
                if (new pdm.BLL.Stock_Manage().Add(stock))
                    Response.Write("<script type='text/javascript'>alert('进货成功');</script>");
                else
                    Response.Write("<script type='text/javascript'>alert('进货失败');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择进货的手机型号');</script>");
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        model.SelectedIndex = 0;
        num.Text = "";
    }
}