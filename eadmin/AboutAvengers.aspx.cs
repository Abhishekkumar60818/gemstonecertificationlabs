using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_AboutAvengers : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCRS();
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string str = CKEditor1.Text;
            string str1 = Server.HtmlDecode(str);
            AboutUs_Avengers ad = new AboutUs_Avengers();
            ad.about = str1;
            ad.update();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Added.')", true);
            BindCRS();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Try again later')", true);
        }
    }
    protected void BindCRS()
    {
        AboutUs_Avengers ad = new AboutUs_Avengers();
        DataSet dt = ad.getAbout_Avengers("select * from tourpackage");
        if (dt.Tables[0].Rows.Count > 0)
        {
            CKEditor1.Text = dt.Tables[0].Rows[0]["about"].ToString();
        }
    }

}