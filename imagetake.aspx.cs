using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class imagetake : System.Web.UI.Page
{
    string cerfiid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cerfiid = Request.QueryString["slider"].ToString();
            takeimagevalue();
        }
    }

    protected void takeimagevalue()
    {

        SliderData fd = new SliderData();
        DataSet dsSt = fd.getSlider("select * from slider where imagename='" + cerfiid + "'");
        rpthome.DataSource = dsSt;
        rpthome.DataBind();




    }
}
