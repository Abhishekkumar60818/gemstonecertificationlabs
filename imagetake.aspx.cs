using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class imagetake : System.Web.UI.Page
{
    string cerfiid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cerfiid = Request.QueryString["slider"];
            takeimagevalue();
        }
    }

    protected void takeimagevalue()
    {
        if (string.IsNullOrEmpty(cerfiid))
        {
            rpthome.DataSource = null;
            rpthome.DataBind();
            return;
        }

        SliderData fd = new SliderData();
        DataSet dsSt = fd.GetSliderByImageName(cerfiid.Trim());
        rpthome.DataSource = dsSt;
        rpthome.DataBind();
    }
}
