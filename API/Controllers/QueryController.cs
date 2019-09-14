using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/send")]
    public class SendTransactions : Controller
    {
        [HttpGet("test")]
        public string atest()
        {
            return "bonk";
        }

        // POST api/<controller>
        [HttpPost("Post")]
        public List<Transaction> Post([FromBody] QueryInstructions incomingQI)
        {

            var Transactions = Parse.filter(incomingQI);

            return Transactions;
        }
    }
}
