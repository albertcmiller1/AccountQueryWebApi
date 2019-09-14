using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Interfaces
{
    public interface IQueryService
    {
        Task<List<Transaction>> CallApi(QueryInstructions sendQI);
    }
}
