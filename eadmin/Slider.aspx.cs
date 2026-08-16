using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_SliderData : System.Web.UI.Page
{
   
    string extension;
    static string FileNameUp, widthup, heightup;
    static int idup;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //updatePanel.Visible = false;
            fillSlider();
            //GenrateQuareCode("GGTL104398");
            panelMessage.Visible = false;

        }
    }

    private void fillSlider()
    {
        SliderData sdata = new SliderData();
        DataSet ds = sdata.getSlider("select * from slider");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSilder.DataSource = ds;
            rpSilder.DataBind();


        }
    }
    protected void btnUpload_Click(object sender,EventArgs e)
    {
        try
        {

            
            
            int valuecount = sliderUpload.PostedFiles.Count;
            foreach (var file in sliderUpload.PostedFiles)
            {
                SliderData sdata = new SliderData();
                string extension = String.Empty;
                extension = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string FileName = file.FileName;
                string[] list = FileName.Split('.');

                file.SaveAs(HttpContext.Current.Server.MapPath("~/eadmin/slider/" + list[0] + ".png"));
                sdata.ImageName = list[0] + ".png";
                sdata.Update(sdata.ImageName);
            }
            Response.Redirect("slider.aspx");
        }
        catch (Exception ex) { }
    }

    public void GenrateQuareCode(string crNo)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode("http://gemstonecertificationlabs.com/imagetake.aspx?slider=" + crNo+".png", QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 200;
        imgBarCode.Width = 200;
        imgBarCode.BorderWidth = 4;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
               // myimg.Src = imgBarCode.ImageUrl;
                string base64 = Convert.ToBase64String(byteImage);


                //string filePath = "~/eadmin/qrimg/" + crNo + ".png";
                //File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath), byteImage);

               
                    
                       // bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        //byte[] byteImage = ms.ToArray();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                        img.Save(Server.MapPath("qrimg/") +crNo+".png", System.Drawing.Imaging.ImageFormat.Png);
                       // imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                  
                
                //File.WriteAllBytes(Server.MapPath(filePath), bytes);
                //byte[] imagebytes = Convert.FromBase64String(base64);
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes);
                //iTextSharp.text.Image watermarkQR1 = iTextSharp.text.Image.GetInstance(image);
                //watermarkQR1.SaveAs(HttpContext.Current.Server.MapPath("~/eadmin/qrimg/" + crNo + ".png"));
                //watermarkQR1.ScaleAbsoluteHeight(150);
                //watermarkQR1.ScaleAbsoluteWidth(150);
                //watermarkQR1.SetAbsolutePosition(430, 600);
                // watermarkQR.Width = 200;

            }
        }
    }



    private void reset()
    {
        txtAboutOffer.Text = "";
        chkIsVisible.Checked = false;
    }
    protected void rpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        updatePanel.Visible = true;
        viewPanel.Visible = false;
        SliderData sdata = new SliderData(int.Parse(e.CommandArgument.ToString()));
        sliderImage.ImageUrl = "~/eadmin/slider/"+sdata.ImageName;
        chkVisibleUp.Checked = sdata.IsVisible;
        txtLinkUp.Text = sdata.Link;
        FileNameUp = sdata.ImageName;
        idup = sdata.Id;


    }
    protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string FileName, width, height;
            if (sliderUploadUp.HasFile)
            {
                extension = String.Empty;
                extension = sliderUploadUp.FileName.Substring(sliderUploadUp.FileName.LastIndexOf("."));
                FileName = sliderUploadUp.FileName;

                sliderUploadUp.SaveAs(HttpContext.Current.Server.MapPath("~/eadmin/slider/" + FileName));
                System.Drawing.Image im = System.Drawing.Image.FromStream(sliderUploadUp.PostedFile.InputStream);
                width = im.PhysicalDimension.Width.ToString();
                height = im.PhysicalDimension.Height.ToString();
            }
            else
            {
                FileName = FileNameUp;
                width = widthup;
                height = heightup;
            }

            SliderData sdata = new SliderData();
            //sdata.Section = int.Parse(cmbSiteSectionUp.SelectedValue.ToString());
            sdata.ImageName = FileName;
            //sdata.Offer = txtOfferUp.Text.ToString();
            //sdata.AboutOffer = txtAboutOfferUp.Text.ToString();
            sdata.Link = txtLinkUp.Text.ToString().Trim();
            sdata.ImageWidth = width;
            sdata.ImageHeight = height;
            sdata.IsVisible = chkVisibleUp.Checked;
           // sdata.Update(idup);
           
            resetup();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            fillSlider();
            panelMessage.Visible = true;

        }
        catch (Exception ex)
        { }
    }

    private void resetup()
    {
        chkVisibleUp.Checked = false;
        txtLinkUp.Text = "";
        //txtOfferUp.Text = "";
        //txtAboutOfferUp.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        resetup();
        updatePanel.Visible = false;
        viewPanel.Visible = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpSilder.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSilder.Items[i].FindControl("sliderid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from slider where id=" + chk.Text);

            }
        }
        fillSlider();
        panelMessage.Visible = true;
        Response.Redirect("Slider.aspx");
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }
}