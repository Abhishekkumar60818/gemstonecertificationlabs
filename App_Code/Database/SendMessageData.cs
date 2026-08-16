using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for SendMessageData
/// </summary>
public class SendMessageData
{
    public SendMessageData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void sendMessage(string msg, string mobile)
    {
        string api = "http://sms.parkentechnology.com/httpapi/httpapi?";
        string token = "bc8102a0a3232754014105999abc66da";
        string senderid = "PNSHEL";
        string rmobile = mobile;
        string route = "2";
        string msgtype = "1";
        string sms = msg;

        string cont = "token=" + token + "&sender=" + senderid + "&number=" + rmobile + "&route=" + route + "&type=" + msgtype + "&sms=" + sms;
        string apiurl = api + "" + cont;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by        HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(apiurl);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex) { }
    }

    public static void sendMessageToadmin(string msg)
    {
      
        string api = "http://sms.parkentechnology.com/httpapi/httpapi?";
        string token = "bc8102a0a3232754014105999abc66da";
        string senderid = "PNSHEL";
        string rmobile = "9412257961";
        string route = "2";
        string msgtype = "1";
        string sms = msg;

        string cont = "token=" + token + "&sender=" + senderid + "&number=" + rmobile + "&route=" + route + "&type=" + msgtype + "&sms=" + sms;
        string apiurl = api + "" + cont;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by        HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(apiurl);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex) { }
    }

    public static void sendMessageToadminn(string msg)
    {

        string api = "http://sms.parkentechnology.com/httpapi/httpapi?";
        string token = "bc8102a0a3232754014105999abc66da";
        string senderid = "PNSHEL";
        string rmobile = "9460058943";
        string route = "2";
        string msgtype = "1";
        string sms = msg;

        string cont = "token=" + token + "&sender=" + senderid + "&number=" + rmobile + "&route=" + route + "&type=" + msgtype + "&sms=" + sms;
        string apiurl = api + "" + cont;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by        HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(apiurl);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex) { }
    }
}