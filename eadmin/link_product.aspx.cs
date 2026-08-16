using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_link_product : System.Web.UI.Page
{
    static int subcatid;
    protected void Page_Load(object sender, EventArgs e)
    {
        subcatid = int.Parse(Request.QueryString["id"]);
        fillOrders();

    }


    private void fillOrders()
    {

        couch sdata = new couch();
        DataSet ds = sdata.getDetails("SELECT * FROM product where subcategoryid=" + subcatid);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
        }
    }

}