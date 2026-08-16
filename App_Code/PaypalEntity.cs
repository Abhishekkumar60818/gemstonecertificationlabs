using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class PaypalEntity
    {
        public string Key { get; set; }
        public string Txnid { get; set; }
        public string Amount { get; set; }
        public string Productinfo { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Surl { get; set; }
        public string Furl { get; set; }
        public string Curl { get; set; }
        public string Hash { get; set; }
        public string Service_provider { get; set; }
        public string Salt { get; set; }
}
