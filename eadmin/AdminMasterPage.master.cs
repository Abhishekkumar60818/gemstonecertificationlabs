using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!SessionVeriables.IsLogged||!SessionVeriables.IsAdmine)
       {
           Response.Redirect("Default.aspx");
           return;
       }
       SetActiveMenu();
    }

    private void SetActiveMenu()
    {
        string current = Request.Url.AbsolutePath.ToLower();

        SetMenuClass(lnkDashboard, false);
        SetMenuClass(lnkGenerateQR, false);
        SetMenuClass(lnkCertificate, false);

        if (current.EndsWith("geratequarecode.aspx"))
            SetMenuClass(lnkGenerateQR, true);
        else if (current.EndsWith("slider.aspx"))
            SetMenuClass(lnkCertificate, true);
        else
            SetMenuClass(lnkDashboard, true);
    }

    private void SetMenuClass(HtmlAnchor link, bool active)
    {
        if (link == null) return;
        link.Attributes["class"] = active ? "menu-top-active" : "menu-top";
    }
}
