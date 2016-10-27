using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdm;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pdm.Model.Users user = new pdm.Model.Users();
        user.Dealer_Name = "asjdlk";
        user.Dealer_Psw = "jdosja";

        new pdm.BLL.Users().Add(user);
    }
}