using System;

/// <summary>
/// Summary description for MailManager
/// </summary>
public class MailManager
{
    public MailManager()
    {
        
        //
        // TODO: Add constructor logic here
        //
    }

    #region OTP mail

    public bool SendOrderStatus(string email, int orderno, string status)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("SalesMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(email, "Order Status", GetEmailOtpBody(orderno, status));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetEmailOtpBody(int orderno, string status)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/orderstatus.html"));
        EmailBody = EmailBody.Replace("__orderno__", orderno.ToString());
        EmailBody = EmailBody.Replace("__status__", status);


        return EmailBody;
    }

    #endregion




    #region Billing mail

    public bool SendBillingMail(UserData User, string invoice, string invoicedate, string address, string total, string deliveryCharge, string totalBill, string item, string paymetoptions)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("SalesMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Bill For Your Order at PanchSheelBooks Bell", GetEmailBillBody(User.Name , invoice, invoicedate, address, total, deliveryCharge, totalBill, item, paymetoptions));
            IsSuccess = mail.SendMail("shankarkumawatk427@gmail.com", "Bill For Your Order at shankarkumawatk427@gmail.com", GetEmailBillBody(User.Name ,invoice, invoicedate, address, total, deliveryCharge, totalBill, item, paymetoptions));
            // if (!IsSuccess)
            //info@panchsheelbooks.com
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }




    private string GetEmailBillBody(string UserName, string invoice, string invoicedate, string address, string total, string deliveryCharge, string totalBill, string item, string paymetoption)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/billing.html"));
        EmailBody = EmailBody.Replace("_address_", address);
        EmailBody = EmailBody.Replace("_invoice_", invoice);
        EmailBody = EmailBody.Replace("_invoicedate_", invoicedate);
        EmailBody = EmailBody.Replace("_paymentmethod_", paymetoption);
        EmailBody = EmailBody.Replace("_items_", item);
        EmailBody = EmailBody.Replace("_amountdue_", totalBill);
        EmailBody = EmailBody.Replace("_total_", total);
        EmailBody = EmailBody.Replace("_delivery_charge", deliveryCharge);
        EmailBody = EmailBody.Replace("_amount_", totalBill);

        return EmailBody;
    }

    #endregion



    #region Register mail

    public bool SendRegisterMail(UserData User)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("AccountMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Panchsheel Books ", GetEmailRegisterBody(User.Name));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetEmailRegisterBody(string username)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/register.html"));
        EmailBody = EmailBody.Replace("__username__", username);
       
        return EmailBody;
    }

    #endregion

    #region Forget Password mail

    public bool SendForgetPassMail(UserData User)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("InfoMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Your Panchsheel Books Password", GetForgetPassBody(User));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetForgetPassBody(UserData User)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/forget_password.html"));
        EmailBody = EmailBody.Replace("_Name_", User.Name);
        EmailBody = EmailBody.Replace("_email_", User.Email);
        EmailBody = EmailBody.Replace("_password_", User.Password);
        return EmailBody;
    }

    #endregion

}

public class Feedback
{
    public string Name;
    public string Email;
    public string Subject;
    public string Message;
}