using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eadmin_Salt : System.Web.UI.Page
{
    static int updateid;
    string extension;
    static string FileNameUp;
    static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            updatePanel.Visible = false;
            fillSalt();
            panelMessage.Visible = false;
        }
    }

    private void fillSalt()
    {
        try
        {
            SaltData sdata = new SaltData();
            DataSet ds = sdata.getSalts("select * from saltinfo");
            rpSalt.DataSource = ds;
            rpSalt.DataBind();
        }catch(Exception ex)
        {

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            SaltData sdata = new SaltData();
            sdata.Name = txtName.Text.ToString().Trim();
            sdata.Uses = txtProductUses.Text;
            sdata.How_it_work = txtHowitWork.Text;
            sdata.Common_side_effect = txtCommonSideEffect.Text;
            sdata.Expert_advice = txtExpertAdvice.Text;
            sdata.Save();
            Reset();
            fillSalt();
            panelMessage.Visible = true;
        }catch(Exception ex){}

    }

    private void Reset()
    {
        txtName.Text = "";
        txtProductUses.Text = "";
        txtHowitWork.Text = "";
        txtCommonSideEffect.Text = "";
        txtExpertAdvice.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
  
    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (excelUpload.HasFile)
            {
                extension = String.Empty;
                extension = excelUpload.FileName.Substring(excelUpload.FileName.LastIndexOf("."));

                string FileName = excelUpload.FileName;
                excelUpload.SaveAs(HttpContext.Current.Server.MapPath("excelfile/" + FileName));
                SaltData sdata = new SaltData();
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {                   
                    sdata.Name = dt.Rows[i][0].ToString().Trim();
                    sdata.Uses = dt.Rows[i][1].ToString();
                    sdata.How_it_work = dt.Rows[i][2].ToString();
                    sdata.Common_side_effect = dt.Rows[i][3].ToString();
                    sdata.Expert_advice = dt.Rows[i][4].ToString(); 
                    sdata.Save();                
                }
                fillSalt();
                panelMessage.Visible = true;
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnExcelUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (excelUpdate.HasFile)
            {
                extension = String.Empty;
                extension = excelUpdate.FileName.Substring(excelUpdate.FileName.LastIndexOf("."));

                string FileName = excelUpdate.FileName;
                excelUpdate.SaveAs(HttpContext.Current.Server.MapPath("excelfile/" + FileName));
                
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SaltData sdata = new SaltData(int.Parse(dt.Rows[i][0].ToString().Trim()));
                    sdata.Name = dt.Rows[i][1].ToString().Trim();
                    sdata.Uses = dt.Rows[i][2].ToString();
                    sdata.How_it_work = dt.Rows[i][3].ToString();
                    sdata.Common_side_effect = dt.Rows[i][4].ToString();
                    sdata.Expert_advice = dt.Rows[i][5].ToString();
                    sdata.Update(int.Parse(dt.Rows[i][0].ToString().Trim()));
                }
                fillSalt();
                panelMessage.Visible = true;
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        string filename = "EdawaSaltData";
        SaltData sdata = new SaltData();
        DataSet ds = sdata.getSalts("select * from saltinfo");
        DataTable dt1 = ds.Tables[0];

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt1);

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        panelMessage.Visible = true;
    }
    protected void rpSalt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string cname = e.CommandName;
        if(cname=="edit")
        {
            viewPanel.Visible = false;
            updatePanel.Visible = true;
            int id = int.Parse(e.CommandArgument.ToString());
            SaltData sdata = new SaltData(id);
            txtNametUp.Text = sdata.Name;
            txtProductUsesUp.Text = sdata.Uses;
            txtHowItWorkUp.Text = sdata.How_it_work;
            txtCommonSideEffectUp.Text = sdata.Common_side_effect;
            txtExpertAdviceUp.Text = sdata.Expert_advice;
            updateid = sdata.Id;
           
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SaltData sdata = new SaltData();
            sdata.Name = txtNametUp.Text.ToString().Trim();
            sdata.Uses = txtProductUsesUp.Text;
            sdata.How_it_work = txtHowItWorkUp.Text;
            sdata.Common_side_effect = txtCommonSideEffectUp.Text;
            sdata.Expert_advice = txtExpertAdviceUp.Text;
            sdata.Update(updateid);
            fillSalt();
            viewPanel.Visible = true;
            updatePanel.Visible = false;
            panelMessage.Visible = true;

        }catch(Exception ex)
        {

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void btnCloseMessage_Click(object sender, EventArgs e)
    {
        panelMessage.Visible = false;
    }
}