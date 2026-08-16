using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Vision_Mission : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        BindAboutUs();
    //    }

    //}
    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string str = CKEditor1.Text;
    //        string str1 = Server.HtmlDecode(str);
    //        Vision_MissionDate ad = new Vision_MissionDate();
    //        ad.about = str1;
    //        ad.update();
    //        ad.Save();
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Added.')", true);
    //        BindAboutUs();
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Try again later')", true);
    //    }
    //}
    //protected void BindAboutUs()
    //{
    //    AboutUsData ad = new AboutUsData();
    //    DataSet dt = ad.getDetails("select * from vision_mission");
    //    if (dt.Tables[0].Rows.Count > 0)
    //    {
    //        CKEditor1.Text = dt.Tables[0].Rows[0]["about"].ToString();
    //    }
    //}
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
            Vision_MissionDate ad = new Vision_MissionDate();
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
        AboutUsData ad = new AboutUsData();
        DataSet dt = ad.getDetails("select * from vision_mission");
        if (dt.Tables[0].Rows.Count > 0)
        {
            CKEditor1.Text = dt.Tables[0].Rows[0]["about"].ToString();
        }
    }
}