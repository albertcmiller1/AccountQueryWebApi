using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using API.Models;
using CsvHelper;
using System.Globalization;

namespace API
{
    public class Parse
    {

        public static List<Transaction> filter(QueryInstructions QI)
        {
            using (var CSVfile = new StreamReader("TransactionInfo.csv"))
            {
                using (var reader = new CsvReader(CSVfile))
                {
                    var Transactions = reader.GetRecords<Transaction>().ToList();

                    Transactions = filterDates(Transactions, QI.FromDate, QI.ToDate);
                    Transactions = filterChecks(Transactions, QI.FromCheckNumber, QI.ToCheckNumber);
                    Transactions = filterAmount(Transactions, QI.FromAmount, QI.ToAmount);
                    Transactions = filterTransactionTpe(Transactions, QI.TransactionType);
                    Transactions = filterDescription(Transactions, QI.Description);

                    return Transactions;
                }
            }
        }
        

        public static List<Transaction> filterDates(List<Transaction> Transactions, DateTime? FromDate, DateTime? ToDate)
        {
            if (FromDate == null || ToDate == null) return Transactions;

            return Transactions.Where(transaction => transaction.Date >= FromDate && transaction.Date <= ToDate)
                    .OrderBy(transaction => transaction.Date).ToList();
        }

        public static List<Transaction> filterChecks(List<Transaction> Transactions, int? FromCheckNumber, int? ToCheckNumber)
        {
            if (FromCheckNumber == null || ToCheckNumber == null) return Transactions;

            return Transactions.Where(transaction => transaction.CheckNumber >= FromCheckNumber && transaction.CheckNumber <= ToCheckNumber)
                   .OrderBy(transaction => transaction.CheckNumber).ToList();
        }

        public static List<Transaction> filterAmount(List<Transaction> Transactions, double? FromAmount, double? ToAmount)
        {
            if (FromAmount == null && ToAmount == null) return Transactions;

            return Transactions.Where(transaction => transaction.Amount >= FromAmount && transaction.Amount <= ToAmount)
                .OrderBy(transaction => transaction.Amount).ToList();
        }

        public static List<Transaction> filterTransactionTpe(List<Transaction> Transactions, string TT)
        {
            if (string.IsNullOrEmpty(TT)) return Transactions;

            return Transactions.Where(transaction => transaction.TransactionType == TT).ToList();
        }

        public static List<Transaction> filterDescription(List<Transaction> Transactions, string Description)
        {
            if (string.IsNullOrEmpty(Description)) return Transactions;

            return Transactions.Where(transaction => transaction.Description.Contains(Description)).ToList();
        }
    }
}
