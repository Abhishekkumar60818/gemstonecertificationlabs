using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_vehicleselected : System.Web.UI.Page
{
    string extension;
    static int upid;
    static string fileNameUp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindState();
            fillMedicineType();
            
            updatePanel.Visible = false;
            panelMessage.Visible = false;
            
        }

    }

    private void fillMedicineType()
    {

        vehicleselectedData sdata = new vehicleselectedData();
        DataSet ds = sdata.getProduct("select * from vehicaleselecteddetails");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpMedicineType.DataSource = ds;
            rpMedicineType.DataBind();


        }
    }
    protected void rpMedicineType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            string command = e.CommandName;
            if (command == "edit")
            {
                updatePanel.Visible = true;
                viewPanel.Visible = false;
                int id = int.Parse(e.CommandArgument.ToString());
                MedicineTypeData mtdata = new MedicineTypeData(id);
                //txtNameUp.Text = mtdata.Name;
                //txtMsg.Text = mtdata.address;
                upid = mtdata.Id;
                fileNameUp = mtdata.Name;
                medicineImage.Src = "medicine/small/" + mtdata.Image;

            }
        }
        catch (Exception ex) { }
    }
    public void bindState()
    {
        try
        {
            CategoryData sdata = new CategoryData();
            DataSet dsState = sdata.getCategory("select * from category ");
            dropcat.DataSource = dsState;
            dropcat.DataValueField = "id";
            dropcat.DataTextField = "category";
            dropcat.DataBind();
            dropcat.Items.Insert(0, "----Select -----");
            dropcat.SelectedIndex = 0;

            //SubCData sdatas = new SubCData();
            //DataSet dsStates = sdatas.getSubCategory("select * from subcategory ");
            //dropsubcat.DataSource = dsState;
            //dropsubcat.DataValueField = "id";
            //dropsubcat.DataTextField = "subCategoryName";
            //dropsubcat.DataBind();

            //ProductData sdatasp = new ProductData();
            //DataSet dsStatesp = sdatasp.getProduct("select * from product ");
            //dropproduct.DataSource = dsState;
            //dropproduct.DataValueField = "id";
            //dropproduct.DataTextField = "productName";
            //dropproduct.DataBind();



        }
        catch (Exception ex)
        {

        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string fileName = "";
        try
        {
            if (imageMedicineUp.HasFile)
            {
                ImageResizeNew rmg = new ImageResizeNew();
                rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/small/" + imageMedicineUp.FileName), 108, 108);
                rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/medium/" + imageMedicineUp.FileName), 224, 224);
                rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/large/" + imageMedicineUp.FileName), 300, 300);
                rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/xlarge/" + imageMedicineUp.FileName), 500, 500);

                fileName = imageMedicineUp.FileName;
            }
            else
            {
                fileName = fileNameUp;
            }
            MedicineTypeData mtdata = new MedicineTypeData();
            //mtdata.Name = txtNameUp.Text;
            //mtdata.address = txtMsg.Text;
            
            UserData udata = new UserData(SessionVeriables.SessionEmail);
            mtdata.User_Id = udata.Id;
            mtdata.Update(upid);
            fillMedicineType();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            panelMessage.Visible = true;


        }
        catch (Exception ex)
        { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            //ImageResizeNew rmg = new ImageResizeNew();
            //rmg.GenerateThumbnails(0.5, imageMedicine.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/small/" + imageMedicine.FileName), 108, 108);
            //rmg.GenerateThumbnails(0.5, imageMedicine.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/medium/" + imageMedicine.FileName), 224, 224);
            //rmg.GenerateThumbnails(0.5, imageMedicine.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/large/" + imageMedicine.FileName), 300, 300);
            //rmg.GenerateThumbnails(0.5, imageMedicine.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/xlarge/" + imageMedicine.FileName), 2000, 2000);

           

            //string fileName = FileNameS;

            vehicleselectedData mtdata = new vehicleselectedData();
            mtdata.catid = int.Parse(dropcat.SelectedValue);
            mtdata.subcatid = int.Parse(dropsubcat.SelectedValue);
            mtdata.productid = int.Parse(dropproduct.SelectedValue);
            mtdata.product = dropsubproduct.Text;
            mtdata.seat = txtseat.Text;
            mtdata.Rent = txtrent.Text;



            mtdata.Save();
            
            fillMedicineType();
            panelMessage.Visible = true;
            Response.Redirect("vehicleselected.aspx");

        }
        catch (Exception ex)
        { }
    }

   
   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpMedicineType.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpMedicineType.Items[i].FindControl("areaid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from vehicaleselecteddetails where id=" + chk.Text);

            }
        }
        fillMedicineType();
        panelMessage.Visible = true;
        Response.Redirect("vehicleselected.aspx");
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }


    protected void fillsubcat(string sid)
    {
        try
        {
            SubCData sdataat = new SubCData();
            DataSet dsStateet = sdataat.getSubCategory("select * from subcategory where categoryid=" + sid);
            //txtdate.Text= dsStateet.Tables[0].Rows[0]["subCategoryName"].ToString();
            dropsubcat.DataSource = dsStateet;
            dropsubcat.DataValueField = "id";
            dropsubcat.DataTextField = "subCategoryName";
            dropsubcat.DataBind();
            dropsubcat.Items.Insert(0, "----Select -----");
            dropsubcat.SelectedIndex = 0;
            

        }
        catch (Exception ex)
        {

        }
    }
    protected void dropcat_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string state = dropcat.SelectedValue.ToString();
            fillsubcat(state);
        }
        catch (Exception ex)
        {

        }
    }

    protected void fillproduct(string sid)
    {
        try
        {
            ProductData sdataat = new ProductData();
            DataSet dsStateet = sdataat.getProduct("select * from product where subcategoryid=" + sid);
            //txtdate.Text= dsStateet.Tables[0].Rows[0]["subCategoryName"].ToString();
            dropproduct.DataSource = dsStateet;
            dropproduct.DataValueField = "id";
            dropproduct.DataTextField = "productName";
            dropproduct.DataBind();
            dropproduct.Items.Insert(0, "----Select -----");
            dropproduct.SelectedIndex = 0;

            

        }
        catch (Exception ex)
        {

        }
    }
    protected void dropsubcat_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string state = dropsubcat.SelectedValue.ToString();
            fillproduct(state);
        }
        catch (Exception ex)
        {

        }
    }

   
}