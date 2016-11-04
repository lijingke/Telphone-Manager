using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemManagerForm_DeleteInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dealer_id =  Request.QueryString["id"];
        Response.Write("<Script Language='JavaScript'>if ( window.confirm('确认删除？')) {  window.location.href='./Dealling.aspx?method=delete&id=" + dealer_id + "' } else {window.location.href='./ViewNextLevelDealers.aspx' }</script>");
       
        
    }
}