using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeQuery
{
    class QueryInstructions
    {
        public QueryInstructions(string A, DateTime FD, DateTime TD, string TT, string D, int FCN, int TCN, double FA, double TA)
        {
            Account = A;
            FromDate = FD;
            ToDate = TD;
            TransactionType = TT;
            Description = D;
            FromCheckNumber = FCN;
            ToCheckNumber = TCN;
            FromAmount = FA;
            ToAmount = TA;
        }

        public string Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; } 
        public int FromCheckNumber { get; set; }
        public int ToCheckNumber { get; set; }
        public double FromAmount { get; set; }
        public double ToAmount { get; set; } 
    }
}
