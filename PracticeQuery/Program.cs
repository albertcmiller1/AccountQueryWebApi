using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PracticeQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var CSVfile = new StreamReader("download.csv"))
            {
                using (var reader = new CsvReader(CSVfile))
                {


                    var Transactions = reader.GetRecords<Transaction>().ToList();


                    var FromDate = DateTime.Parse("5/4/2019");
                    var ToDate = DateTime.Parse("5/25/2019");

                    var FromCheckNumber = int.Parse("1001");
                    var ToCheckNumber = int.Parse("1003");

                    var FromAmount = double.Parse("($100.40)", NumberStyles.Currency);
                    var ToAmount = double.Parse("$(50.40)", NumberStyles.Currency);
                    var TT = "Check";
                    var Description = "CHECK #";


                    Transactions = filterDates(Transactions, FromDate, ToDate);
                    Transactions = filterChecks(Transactions, FromCheckNumber, ToCheckNumber);
                    Transactions = filterAmount(Transactions, FromAmount, ToAmount);
                    Transactions = filterTransactionTpe(Transactions, TT);
                    Transactions = filterDescription(Transactions, Description);

                    foreach (var t in Transactions)
                    {
                        Console.WriteLine(t.Date);
                        Console.WriteLine(t.Description);
                    }
                }
            }
        }


        public static List<Transaction> filterDates(List<Transaction> List, DateTime FromDate, DateTime ToDate)
        {
            var Transactions = List;
            List<Transaction> newList = new List<Transaction> { };

            var Query =
                Transactions.Where(transaction => transaction.Date >= FromDate && transaction.Date <= ToDate)
                .OrderBy(transaction => transaction.Date);

            if (FromDate != null || ToDate != null)
            {
                foreach (var Transaction in Query)
                {
                    newList.Add(Transaction);
                }
                return newList;
            }
            return null;
        }

        public static List<Transaction> filterChecks(List<Transaction> List, int FromCheckNumber, int ToCheckNumber)
        {
            var Transactions = List;
            List<Transaction> newList = new List<Transaction> { };

            var Query =
                Transactions.Where(transaction => transaction.CheckNumber >= FromCheckNumber && transaction.CheckNumber <= ToCheckNumber)
                .OrderBy(transaction => transaction.CheckNumber);

            if (FromCheckNumber != -1 || ToCheckNumber != -1)
            {
                foreach (var Transaction in Query)
                {
                    newList.Add(Transaction);
                }
                return newList;
            }
            return null;
        }

        public static List<Transaction> filterAmount(List<Transaction> List, double FromAmount, double ToAmount)
        {
            var Transactions = List;
            List<Transaction> newList = new List<Transaction> { };

            var Query =
                Transactions.Where(transaction => transaction.Amount >= FromAmount && transaction.Amount <= ToAmount)
                .OrderBy(transaction => transaction.Amount);

            if (FromAmount != 0 || ToAmount != 0)
            {
                foreach (var Transaction in Query)
                {
                    newList.Add(Transaction);
                }
                return newList;
            }
            return null;
        }

        public static List<Transaction> filterTransactionTpe(List<Transaction> List, string TT)
        {
            var Transactions = List;
            List<Transaction> newList = new List<Transaction> { };

            var Query =
                Transactions.Where(transaction => transaction.TransactionType == TT);

            if (TT != null)
            {
                foreach (var Transaction in Query)
                {
                    newList.Add(Transaction);
                }
                return newList;
            }
            return null;
        }

        public static List<Transaction> filterDescription(List<Transaction> List, string Description)
        {
            var Transactions = List;
            List<Transaction> newList = new List<Transaction> { };

            var Query =
                Transactions.Where(transaction => transaction.Description.Contains(Description));

            if (Description != null)
            {
                foreach (var Transaction in Query)
                {
                    newList.Add(Transaction);
                }
                return newList;
            }
            return null;
        }
    }
}




















//used library called CsvHelper to help parse the CSV File
//https://joshclose.github.io/CsvHelper/examples/configuration/attributes/

//var Date = DateTime.Parse("5/4/2019");
//Console.WriteLine(Date);

//var CheckNumber = int.Parse("1001");
//Console.WriteLine(CheckNumber);

//var Amount = double.Parse("($1,000.00)".Remove('$'));
//var Amount = double.Parse("($23,515.402)", NumberStyles.Currency);
//Console.WriteLine(Amount);

//var Balance = double.Parse("$10,885.70", NumberStyles.Currency);
//Console.WriteLine(Balance);
