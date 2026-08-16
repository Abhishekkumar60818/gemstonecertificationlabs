using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
        if (SessionVeriables.IsLogged && SessionVeriables.IsAdmine && SessionVeriables.UserRole == "Admin")
        {
            Response.Redirect("Home.aspx");
        }
        if (SessionVeriables.IsLogged && !SessionVeriables.IsAdmine && SessionVeriables.UserRole == "Wholesale")
        {
            Response.Redirect("UserHome.aspx");
        }
        if (SessionVeriables.IsLogged && SessionVeriables.UserRole != "Admin" && SessionVeriables.UserRole != "Wholesale")
        {

            lblMessage.Text = "<div class='alert alert-danger' role='alert'>Client And Admin can't be Login on Same System at a time Please logout Client from website</div>  <a href='Logout.aspx'>Click Here To Logout</a>";
        }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
       if(txtEmail.Text!=""&&txtPassword.Text!=""&&cmbUserRole.SelectedIndex>0)
       {
           UserData udata = new UserData(txtEmail.Text.ToString().Trim(),txtPassword.Text.ToString().Trim(),cmbUserRole.SelectedValue.ToString().Trim());
           if(udata.HasValue&&udata.UserType=="admin")
           {
               SessionVeriables.UserId = udata.Id;
               SessionVeriables.SessionEmail = udata.Email;
               SessionVeriables.IsLogged = true;
               SessionVeriables.IsAdmine = true;
               SessionVeriables.UserRole = "Admin";
               Response.Redirect("Home.aspx");
           }
           else if(udata.HasValue&&udata.UserType!="admin")
           {
               SessionVeriables.UserId = udata.Id;
               SessionVeriables.SessionEmail = udata.Email;
               SessionVeriables.IsLogged = true;
               SessionVeriables.IsAdmine = false;
               SessionVeriables.UserRole = "Wholesale";
               Response.Redirect("UserHome.aspx");
           }
           else
           {
               Response.Write("<script>alert('Invalid Email And Password Please Try Again !');</script>");
           }
           
       }
       else
       {
           Response.Write("<script>alert('Please fill Email and Password field and Select User Role !');</script>");
       }

    }
}