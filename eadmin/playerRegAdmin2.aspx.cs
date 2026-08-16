using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_playerRegAdmin2 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        fillOrders();
        
        //panelMessage.Visible = false;
    }
    private void fillOrders()
    {
        
        Player_Registrationdata sdata = new Player_Registrationdata();
        //DataSet ds = sdata.getDetails("SELECT ranking.id,ranking.Reg_Id,ranking.Types,ranking.gold,ranking.silver,ranking.brouch,ranking.img_g,ranking.img_s,ranking.img_b,p_registration.name,p_registration.Image,p_registration.fathername,p_registration.Mothername,p_registration.dob,p_registration.Couch_Name,p_registration.club_name,p_registration.Address,p_registration.Aadhar,p_registration.mobile_no,p_registration.Blood_group,p_registration.current_gurding,p_registration.Age FROM ranking INNER JOIN p_registration ON ranking.Reg_Id = p_registration.id; ");

        DataSet ds = sdata.getDetails("select * from formfill ");

        if (ds.Tables[0].Rows.Count > 0)
        {
            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
        }
    }
    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < rpTopOrer.Items.Count; i++)
    //    {
    //        CheckBox chk = (CheckBox)rpTopOrer.Items[i].FindControl("userid");
    //        if (chk.Checked)
    //        {

    //            SliderData sdata = new SliderData();
    //            sdata.Delete("delete from formfill where id=" + chk.Text);

    //        }
    //    }
        
        
    //    Response.Redirect("default.aspx");
    //}







}