using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PracticeQuery
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
//used library called CsvHelper to help parse the CSV File
//https://joshclose.github.io/CsvHelper/examples/configuration/attributes/
