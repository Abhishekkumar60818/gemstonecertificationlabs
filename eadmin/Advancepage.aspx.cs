using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Advancepage : System.Web.UI.Page
{
    static int Reg_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Reg_Id = int.Parse(Request.QueryString["id"]);
        fillOrders();

    }


    private void fillOrders()
    {

        couch sdata = new couch();
        DataSet ds = sdata.getDetails("SELECT * FROM adpayfillform where Reg_Id=" + Reg_Id);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
        }
    }
    //private void fillOrders()
    //{
    //    couch ohdata = new couch();
    //    DataSet ds = ohdata.getDetails("SELECT * FROM adpayfillform");
    //    rpTopOrer.DataSource = ds;
    //    rpTopOrer.DataBind();
    //}


}