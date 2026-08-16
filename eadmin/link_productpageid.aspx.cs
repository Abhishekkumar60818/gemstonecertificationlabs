using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_link_productpageid : System.Web.UI.Page
{
    static int prodcatid;
    protected void Page_Load(object sender, EventArgs e)
    {
        prodcatid = int.Parse(Request.QueryString["id"]);
        fillOrders();

    }


    private void fillOrders()
    {

        couch sdata = new couch();
        DataSet ds = sdata.getDetails("SELECT * FROM vehicaleselecteddetails where productId=" + prodcatid);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
        }
    }
}