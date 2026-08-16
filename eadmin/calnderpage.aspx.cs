using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_calnderpage : System.Web.UI.Page
{
    string extension;
    static int upid;
    static string fileNameUp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillMedicineType();
            updatePanel.Visible = false;
            panelMessage.Visible = false;
        }

    }

    private void fillMedicineType()
    {

        calendrData sdata = new calendrData();
        DataSet ds = sdata.getMedicineType("select * from calender_db");
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
                calendrData mtdata = new calendrData(id);
                //txtNameUp.Text = mtdata.Name;
                //txtMsg.Text = mtdata.address;
                upid = mtdata.Id;
                //fileNameUp = mtdata.Name;
                //medicineImage.Src = "medicine/small/" + mtdata.Image;

            }
        }
        catch (Exception ex) { }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //string fileName = "";
        try
        {
            //if (imageMedicineUp.HasFile)
            //{
            //    ImageResizeNew rmg = new ImageResizeNew();
            //    rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/small/" + imageMedicineUp.FileName), 108, 108);
            //    rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/medium/" + imageMedicineUp.FileName), 224, 224);
            //    rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/large/" + imageMedicineUp.FileName), 300, 300);
            //    rmg.GenerateThumbnails(0.5, imageMedicineUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/eadmin/medicine/xlarge/" + imageMedicineUp.FileName), 500, 500);

            //    fileName = imageMedicineUp.FileName;
            //}
            //else
            //{
            //    fileName = fileNameUp;
            //}
            calendrData mtdata = new calendrData();
            //mtdata.Name = txtNameUp.Text;
            //mtdata.address = txtMsg.Text;
            //mtdata.Status = 1;
            //mtdata.Image = fileName;
            UserData udata = new UserData(SessionVeriables.SessionEmail);
            //mtdata.User_Id = udata.Id;
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

            //extension = imageMedicine.FileName.Substring(imageMedicine.FileName.LastIndexOf("."));
            //string FileNameS = imageMedicine.FileName;
            //imageMedicine.SaveAs(HttpContext.Current.Server.MapPath("~/eadmin/medicine/xlarge/" + FileNameS));
            //extension = String.Empty;

            //extension = imageMedicine.FileName.Substring(imageMedicine.FileName.LastIndexOf("."));

            //string fileName = FileNameS;

            calendrData mtdata = new calendrData();
            //mtdata.address = txtMsg.Text;
            //mtdata.Status = 1;
            //mtdata.Image = FileNameS;
            UserData udata = new UserData(SessionVeriables.SessionEmail);
            //mtdata.User_Id = udata.Id;
            mtdata.Save();
            Reset();
            fillMedicineType();
            panelMessage.Visible = true;

        }
        catch (Exception ex)
        { }
    }

    private void Reset()
    {
        //txtName.Text = "";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpMedicineType.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpMedicineType.Items[i].FindControl("areaid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from calender_db where id=" + chk.Text);

            }
        }
        fillMedicineType();
        panelMessage.Visible = true;
        Response.Redirect("calnderpage.aspx");
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }
}