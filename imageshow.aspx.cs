using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class imageshow : System.Web.UI.Page
{

    int cerfiid;
    protected void Page_Load(object sender, EventArgs e)
    {
        cerfiid = int.Parse(Request.QueryString["id"]);
        takeimagevalue();
    }

    protected void takeimagevalue()
    {
        
        SliderData fd = new SliderData();
        DataSet dsSt = fd.getSlider("select * from slider where id=" + cerfiid);
       // rpthome.DataSource = dsSt;
        //rpthome.DataBind();


        
       
    }
}