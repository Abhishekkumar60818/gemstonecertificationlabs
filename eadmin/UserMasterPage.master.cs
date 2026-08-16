using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!SessionVeriables.IsLogged||SessionVeriables.IsAdmine)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
