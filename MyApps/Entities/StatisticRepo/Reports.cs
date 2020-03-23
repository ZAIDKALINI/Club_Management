using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.StatisticRepo
{
    public class Reports
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Creditor { get; set; }
        public decimal Debit { get; set; }


    }
}
