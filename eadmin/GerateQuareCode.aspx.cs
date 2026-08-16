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

public partial class eadmin_GerateQuareCode : System.Web.UI.Page
{
    const int DefaultPageSize = 10;

    private int idup
    {
        get { return ViewState["updId"] == null ? 0 : (int)ViewState["updId"]; }
        set { ViewState["updId"] = value; }
    }

    private string FileNameUp
    {
        get { return ViewState["updFile"] == null ? "" : ViewState["updFile"].ToString(); }
        set { ViewState["updFile"] = value; }
    }

    private string widthup
    {
        get { return ViewState["updW"] == null ? "" : ViewState["updW"].ToString(); }
        set { ViewState["updW"] = value; }
    }

    private string heightup
    {
        get { return ViewState["updH"] == null ? "" : ViewState["updH"].ToString(); }
        set { ViewState["updH"] = value; }
    }

    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 1 : (int)ViewState["CurrentPage"]; }
        set { ViewState["CurrentPage"] = value; }
    }

    private int PageSize
    {
        get { return ViewState["PageSize"] == null ? DefaultPageSize : (int)ViewState["PageSize"]; }
        set { ViewState["PageSize"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentPage = 1;
            PageSize = DefaultPageSize;
            ddlPageSize.SelectedValue = PageSize.ToString();
            panelMessage.Visible = false;
            panel1.Visible = false;
        }
        BindData();
    }

    private void BindData()
    {
        SliderData sdata = new SliderData();
        DataSet dsCount = sdata.getSlider("select count(*) as cnt from slider");
        int totalCount = 0;
        if (dsCount.Tables[0].Rows.Count > 0)
            totalCount = int.Parse(dsCount.Tables[0].Rows[0]["cnt"].ToString());

        int totalPages = totalCount == 0 ? 1 : (int)Math.Ceiling((double)totalCount / PageSize);
        if (CurrentPage > totalPages) CurrentPage = totalPages;
        if (CurrentPage < 1) CurrentPage = 1;

        int offset = (CurrentPage - 1) * PageSize;
        DataSet ds = sdata.getSlider("select * from slider order by id desc limit " + PageSize + " offset " + offset);
        rpSilder.DataSource = ds;
        rpSilder.DataBind();

        int start = totalCount == 0 ? 0 : (CurrentPage - 1) * PageSize + 1;
        int end = totalCount == 0 ? 0 : Math.Min(CurrentPage * PageSize, totalCount);
        lblInfo.Text = "Showing " + start + " to " + end + " of " + totalCount.ToString("N0") + " entries";

        rptPages.DataSource = PaginationHelper.BuildPages(CurrentPage, totalPages);
        rptPages.DataBind();

        btnPrev.Enabled = CurrentPage > 1;
        btnNext.Enabled = CurrentPage < totalPages;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string certNo = SanitizeFileName(txtAboutOffer.Text.Trim());
            if (string.IsNullOrEmpty(certNo))
            {
                ShowError("Please enter a valid Certificate No.");
                return;
            }

            string imageName = certNo + ".png";
            SliderData sdata = new SliderData();

            if (sdata.RowExists(imageName))
            {
                DataSet existing = sdata.GetSliderByImageName(imageName);
                if (existing.Tables[0].Rows.Count > 0)
                    imageName = existing.Tables[0].Rows[0]["imagename"].ToString();
            }
            else
            {
                sdata.ImageName = imageName;
                sdata.SaveQR();
            }

            GenrateQuareCode(imageName);
            Response.Redirect("GerateQuareCode.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            ShowError("Error: " + ex.Message);
        }
    }

    public void GenrateQuareCode(string crNo)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        string urlss = "http://gemstonecertificationlabs.com/imagetake.aspx?slider=" + Server.UrlEncode(crNo);
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(urlss, QRCodeGenerator.ECCLevel.L);
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
                img.Save(Server.MapPath("qrimg/") + crNo , System.Drawing.Imaging.ImageFormat.Png);
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
        sliderImage.ImageUrl = "~/eadmin/slider/" + sdata.ImageName;
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
                string baseName = System.IO.Path.GetFileNameWithoutExtension(sliderUploadUp.FileName);
                FileName = SanitizeFileName(baseName) + ".png";

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
            if (idup > 0)
            {
                SliderData existing = new SliderData(idup);
                sdata.Offer = existing.Offer;
                sdata.AboutOffer = existing.AboutOffer;
                sdata.Section = existing.Section;
            }
            sdata.ImageName = FileName;
            sdata.Link = string.IsNullOrEmpty(txtLinkUp.Text.Trim()) ? FileName : txtLinkUp.Text.Trim();
            sdata.ImageWidth = width;
            sdata.ImageHeight = height;
            sdata.IsVisible = chkVisibleUp.Checked;
            if (idup > 0) sdata.Update(idup);

            resetup();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            BindData();
            panelMessage.Visible = true;

        }
        catch (Exception ex)
        {
            ShowError("Update Error: " + ex.Message);
        }
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageSize = int.Parse(ddlPageSize.SelectedValue);
        CurrentPage = 1;
        BindData();
    }

    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CurrentPage = int.Parse(e.CommandArgument.ToString());
        BindData();
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (CurrentPage > 1)
        {
            CurrentPage--;
            BindData();
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        BindData();
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
        try
        {
            for (int i = 0; i < rpSilder.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpSilder.Items[i].FindControl("sliderid");
                bool isChecked = chk != null && chk.Checked;
                if (!isChecked && chk != null)
                {
                    isChecked = !string.IsNullOrEmpty(Request.Form[chk.UniqueID]);
                }
                if (isChecked)
                {
                    int id;
                    if (int.TryParse(chk.Text, out id))
                    {
                        SliderData sdata = new SliderData();
                        sdata.DeleteById(id);
                    }
                }
            }
            Response.Redirect("GerateQuareCode.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            ShowError("Delete Error: " + ex.Message);
        }
    }

    private void ShowError(string msg)
    {
        string js = "alert('" + msg.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ") + "');";
        ClientScript.RegisterStartupScript(this.GetType(), "apperror", js, true);
    }

    private string SanitizeFileName(string name)
    {
        if (string.IsNullOrEmpty(name)) return "";
        name = name.Trim();
        name = name.Replace("..", "");
        char[] invalid = { '/', '\\', ':', '*', '?', '"', '<', '>', '|' };
        foreach (char c in invalid)
            name = name.Replace(c.ToString(), "");
        return name.Trim();
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
        panel1.Visible = false;
    }
}