using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDMSData
{
    public class ExpenseInfo
    {
        public string id { get; set; }
        public string purpose { get; set; }
        public DateTime doe { get; set; }
        public string expensed_by { get; set; }
        public double amount { get; set; }
    }
}
