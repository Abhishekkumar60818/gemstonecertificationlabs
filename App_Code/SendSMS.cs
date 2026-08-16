using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkenSMS
{
    public class SendSMS
    {
      public void MsgSend(string MobileNo,string Msg,string TemplateId)
        {
            HttpWebRequest request = WebRequest.Create("http://sms.par-ken.com/api/smsapi?key=e34ef4f3290cae7d976d79bbd38ee2e6&route=1&sender=TASHII&number='" + MobileNo + "&sms="+ Msg+ "&templateid=" +TemplateId) as HttpWebRequest;
            //optional
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
        }
    }
}
