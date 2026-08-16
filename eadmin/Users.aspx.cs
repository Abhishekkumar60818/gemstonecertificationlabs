using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Users : System.Web.UI.Page
{
    static int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            updatePanel.Visible = false;

            fillUsers();
            panelMessage.Visible = false;
        }
        
    }

    private void fillUsers()
    {
        try
        {
            UserData udata = new UserData();
            DataSet ds = udata.getUsers("select * from users");
            rpUsers.DataSource = ds;
            rpUsers.DataBind();
            setCustomerStatus(ds);

            cmbReference.DataSource = ds;
            cmbReference.DataTextField = "name";
            cmbReference.DataValueField = "id";
            cmbReference.DataBind();
            cmbReference.Items.Insert(0,"---Reference By---");
            cmbReference.SelectedIndex = 0;

            cmbReferenceUp.DataSource = ds;
            cmbReferenceUp.DataTextField = "name";
            cmbReferenceUp.DataValueField = "id";
            cmbReferenceUp.DataBind();
            cmbReferenceUp.Items.Insert(0, "---Reference By---");
            cmbReferenceUp.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }
    protected void setCustomerStatus(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList cmbStatus = (DropDownList)rpUsers.Items[i].FindControl("cmbUserStatus");
            cmbStatus.SelectedValue = ds.Tables[0].Rows[i]["status"].ToString();
        }
    }
    protected void btnUpload_Click(object sender,EventArgs e)
    {
        try
        {
            UserData udata = new UserData(txtEmail.Text.ToString());
            if(!udata.HasValue)
            {
                udata.Name = txtName.Text.ToString();
                udata.ShopName = txtShopName.Text.ToString();
                udata.TinNumber = txtTinNumber.Text.ToString();
                udata.Mobile = txtMobile.Text.ToString();
                udata.Email = txtEmail.Text.ToString();
                udata.Password = txtPassword.Text.ToString();
                udata.State = txtState.Text.ToString();
                udata.City = txtCity.Text.ToString();
                udata.Address = txtAddress.Text.ToString();
                udata.Image = "my image";
                udata.UserType = cmbUserType.SelectedValue.ToString();
                udata.Status = 1;
                udata.OtherInfo = txtOtherOnfo.Text.ToString();
                udata.ReferenceId = int.Parse(cmbReference.SelectedValue.ToString());
                udata.Save();
                fillUsers();
                Reset();
                panelMessage.Visible = true;

            }
            else
            {
                lblShowMessage.Text = "<script>alert('Email Id already Existsss');</script>";
            }

        }
        catch (Exception ex) { }
    }

    private void Reset()
    {
        txtName.Text ="";
        txtShopName.Text ="";
        txtTinNumber.Text ="";
        txtMobile.Text ="";
        txtEmail.Text ="";
        txtPassword.Text ="";
        txtState.Text ="";
        txtCity.Text ="";
        txtAddress.Text ="";
        cmbUserTypeUp.SelectedIndex =0;
        txtOtherOnfo.Text ="";
        cmbReference.SelectedIndex = 0; ;
    }
    protected void cmbCustomerStatus_SelectedIndexChanged(object sender,EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        RepeaterItem ri = (RepeaterItem)ddl.NamingContainer;
        CheckBox chkbox = (CheckBox)rpUsers.Items[ri.ItemIndex].FindControl("userid");
        UserData udata = new UserData();
        udata.Status =int.Parse(ddl.SelectedValue);
        udata.UpdateStatus(int.Parse(chkbox.Text.ToString()));
        panelMessage.Visible = true;
    }
    protected void rpUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            string command = e.CommandName.ToString();
            if(command=="edit")
            {
                viewPanel.Visible = false;
                updatePanel.Visible = true;
                int id = int.Parse(e.CommandArgument.ToString());
                UserData udata = new UserData(id);
                txtNameUp.Text = udata.Name;
                txtShopNameUp.Text = udata.ShopName;
                txtTinNumberUp.Text = udata.TinNumber;
                txtMobileUp.Text = udata.Mobile;
                txtEmailUp.Text = udata.Email;
                txtPasswordUp.Text = udata.Password;
                txtStateUp.Text = udata.State;
                txtCityUp.Text = udata.City;                
                txtAddressUp.Text = udata.Address;
                cmbUserTypeUp.SelectedValue = udata.UserType.ToString();
                txtOtherInfoUp.Text = udata.OtherInfo;
                cmbReferenceUp.SelectedValue = udata.ReferenceId.ToString();
                userid = udata.Id;


            }
        }
        catch (Exception ex) { }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UserData udata = new UserData();
            udata.Name = txtNameUp.Text.ToString();
            udata.ShopName = txtShopNameUp.Text.ToString();
            udata.TinNumber = txtTinNumberUp.Text.ToString();
            udata.Mobile = txtMobileUp.Text.ToString();
            udata.Email = txtEmailUp.Text.ToString();
            udata.Password = txtPasswordUp.Text.ToString();
            udata.State = txtStateUp.Text.ToString();
            udata.City = txtCityUp.Text.ToString();
            udata.Address = txtAddressUp.Text.ToString();
            udata.Image = "my image";
            udata.UserType = cmbUserTypeUp.SelectedValue.ToString();            
            udata.OtherInfo = txtOtherInfoUp.Text.ToString();
            udata.ReferenceId = int.Parse(cmbReferenceUp.SelectedValue.ToString());
            udata.Update(userid);
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            fillUsers();
            panelMessage.Visible = true;

        }
        catch (Exception ex) { }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
         for (int i = 0; i < rpUsers.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpUsers.Items[i].FindControl("userid");
            if (chk.Checked)
            {

                UserData udata = new UserData();
                udata.Delete("delete from users where id=" + chk.Text);

            }
        }
        fillUsers();
        panelMessage.Visible = true;
    }
}
  