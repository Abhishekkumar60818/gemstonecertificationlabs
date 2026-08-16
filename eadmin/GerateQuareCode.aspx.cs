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

    string extension;
    static string FileNameUp, widthup, heightup;
    static int idup;

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

    private string ShrinkURL(string strURL)
    {

        string URL;
        URL = "http://tinyurl.com/api-create.php?url=" +
           strURL.ToLower();

        System.Net.HttpWebRequest objWebRequest;
        System.Net.HttpWebResponse objWebResponse;

        System.IO.StreamReader srReader;

        string strHTML;

        objWebRequest = (System.Net.HttpWebRequest)System.Net
           .WebRequest.Create(URL);
        objWebRequest.Method = "GET";

        objWebResponse = (System.Net.HttpWebResponse)objWebRequest
           .GetResponse();
        srReader = new System.IO.StreamReader(objWebResponse
           .GetResponseStream());

        strHTML = srReader.ReadToEnd();

        srReader.Close();
        objWebResponse.Close();
        objWebRequest.Abort();

        return (strHTML);

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {



              SliderData sdata = new SliderData();

            string filen = txtAboutOffer.Text + ".png";

            DataSet ds = sdata.getSlider("select * from slider where link='"+ filen + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                panel1.Visible = true;
            }
            else
            {

                sdata.ImageName = txtAboutOffer.Text + ".png";
                sdata.SaveQR();
                GenrateQuareCode(sdata.ImageName);
                panelMessage.Visible = true;
                Response.Redirect("GerateQuareCode.aspx");

            }

            
        }
        catch (Exception ex) { }
    }

    public void GenrateQuareCode(string crNo)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        string urlss = ShrinkURL("http://gemstonecertificationlabs.com/imagetake.aspx?slider=" + crNo);
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
            //sdata.Update(idup);

            resetup();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            BindData();
            panelMessage.Visible = true;

        }
        catch (Exception ex)
        { }
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
        for (int i = 0; i < rpSilder.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSilder.Items[i].FindControl("sliderid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from slider where id=" + chk.Text);

            }
        }
        BindData();
        panelMessage.Visible = true;
        Response.Redirect("GerateQuareCode.aspx");
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
        panel1.Visible = false;
    }
}