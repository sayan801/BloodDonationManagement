using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDMSData
{
    public class DonorInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string bloodGroup { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime lastDonateDate { get; set; }
        public DateTime dob { get; set; }
    }
}
