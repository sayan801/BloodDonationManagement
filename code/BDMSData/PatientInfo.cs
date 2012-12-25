using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDMSData
{
    public class PatientInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string bloodGroup { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string admittedAddress { get; set; }
        public DateTime expectedDate { get; set; }
        public string assignedDonor { get; set; }
        public string donorContact { get; set; }

    }
}
