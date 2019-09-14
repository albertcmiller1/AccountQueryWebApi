using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class QueryInstructions
    {

        public string Account { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public int? FromCheckNumber { get; set; }
        public int? ToCheckNumber { get; set; }
        public double? FromAmount { get; set; }
        public double? ToAmount { get; set; }
    }
}
