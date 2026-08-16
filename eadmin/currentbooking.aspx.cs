using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_currentbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fillOrders();

    }


    private void fillOrders()
    {
        safaribookinDate ohdata = new safaribookinDate();
        DataSet ds = ohdata.getDetails("SELECT * FROM fill_form3");
        rpTopOrer.DataSource = ds;
        rpTopOrer.DataBind();
    }
}