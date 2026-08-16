using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_cat_link : System.Web.UI.Page
{
    static int catid;
    protected void Page_Load(object sender, EventArgs e)
    {
        catid = int.Parse(Request.QueryString["id"]);
        fillOrders();

    }


    private void fillOrders()
    {

        couch sdata = new couch();
        DataSet ds = sdata.getDetails("SELECT * FROM subcategory where categoryid=" + catid);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
        }
    }
   

}