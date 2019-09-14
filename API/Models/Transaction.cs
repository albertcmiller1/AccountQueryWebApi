using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [Name("Check Number")]
        public int? CheckNumber { get; set; }

        [NumberStyles(NumberStyles.Currency)]
        public double Amount { get; set; }
        [NumberStyles(NumberStyles.Currency)]
        public double Balance { get; set; }
        public string TransactionType { get; set; }
    }
}
