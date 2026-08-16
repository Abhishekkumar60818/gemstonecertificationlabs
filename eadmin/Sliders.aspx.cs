using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Sliders : System.Web.UI.Page
{
    string extension;
    static string FileNameUp, widthup, heightup;
    static int idup;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            updatePanel.Visible = false;
            fillSlider();
            panelMessage.Visible = false;

        }
    }

    private void fillSlider()
    {
        slidersData2 sdata = new slidersData2();
        DataSet ds = sdata.getsliders("select * from sliders");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSilder.DataSource = ds;
            rpSilder.DataBind();


        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            if (sliderUpload.HasFile)
            {
                extension = String.Empty;

                extension = sliderUpload.FileName.Substring(sliderUpload.FileName.LastIndexOf("."));

                string FileName = sliderUpload.FileName;

                sliderUpload.SaveAs(HttpContext.Current.Server.MapPath("~/eadmin/slider/" + FileName));
                System.Drawing.Image im = System.Drawing.Image.FromStream(sliderUpload.PostedFile.InputStream);
                slidersData2 sdata = new slidersData2();
                sdata.Section = int.Parse(cmbSiteSection.SelectedValue.ToString());
                sdata.ImageName = FileName;
                sdata.Offer = txtOffer.Text.ToString();
                sdata.AboutOffer = txtAboutOffer.Text.ToString();
                sdata.Link = txtUrl.Text.ToString().Trim();
                sdata.ImageWidth = im.PhysicalDimension.Width.ToString();
                sdata.ImageHeight = im.PhysicalDimension.Height.ToString();
                sdata.IsVisible = chkIsVisible.Checked;


                sdata.Save();
                fillSlider();
                reset();
                panelMessage.Visible = true;
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex) { }
    }
    private void reset()
    {
        txtOffer.Text = "";
        txtAboutOffer.Text = "";
        txtUrl.Text = "";
        chkIsVisible.Checked = false;
    }
    protected void rpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        updatePanel.Visible = true;
        viewPanel.Visible = false;
        slidersData2 sdata = new slidersData2(int.Parse(e.CommandArgument.ToString()));
        sliderImage.ImageUrl = "~/eadmin/slider/" + sdata.ImageName;
        cmbSiteSectionUp.SelectedValue = sdata.Section.ToString();
        chkVisibleUp.Checked = sdata.IsVisible;
        txtLinkUp.Text = sdata.Link;
        txtOfferUp.Text = sdata.Offer;
        txtAboutOfferUp.Text = sdata.AboutOffer;
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

            slidersData2 sdata = new slidersData2();
            sdata.Section = int.Parse(cmbSiteSectionUp.SelectedValue.ToString());
            sdata.ImageName = FileName;
            sdata.Offer = txtOfferUp.Text.ToString();
            sdata.AboutOffer = txtAboutOfferUp.Text.ToString();
            sdata.Link = txtLinkUp.Text.ToString().Trim();
            sdata.ImageWidth = width;
            sdata.ImageHeight = height;
            sdata.IsVisible = chkVisibleUp.Checked;
            sdata.Update(idup);

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
        txtOfferUp.Text = "";
        txtAboutOfferUp.Text = "";
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
                sdata.Delete("delete from sliders where id=" + chk.Text);

            }
        }
        fillSlider();
        panelMessage.Visible = true;
        Response.Redirect("Sliders.aspx");
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }
}