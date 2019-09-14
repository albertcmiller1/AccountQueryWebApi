using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? CheckNumber { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
    }
}
