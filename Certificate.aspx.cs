using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Certificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btncheck_Click(object sender, EventArgs e)
    {
        string valuetxt = txtcertifid.Text.ToString()+ ".png";
        
        string imageva;
        SliderData ad = new SliderData();
        DataSet dsSt = ad.getSlider("select * from slider where imagename='"+ valuetxt + "'"); /*"select * from slider where imagename LIKE '%" + valuetxt + "%'"*/
        if (dsSt.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('certificate not found')</script>");   
        }
        else
        {
            imageva = dsSt.Tables[0].Rows[0]["imagename"].ToString();
            Response.Redirect("imagetake.aspx?slider=" + Server.UrlEncode(dsSt.Tables[0].Rows[0]["imagename"].ToString()));
            //Response.Redirect("imagetake.aspx?id=" + dsSt.Tables[0].Rows[0]["id"].ToString());
        }
        
    }



}