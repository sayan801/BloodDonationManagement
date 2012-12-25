using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDMSData
{
    public class FundInfo
    {
        public string id { get; set; }
        public string wellwisher_name { get; set; }
        public string contact { get; set; }
        public DateTime dod { get; set; }
        public string received_by { get; set; }
        public double amount { get; set; }
    }
}
