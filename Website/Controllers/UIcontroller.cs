using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Interfaces;
using Website.Models;

namespace Website.Controllers
{
    [Route("api/PUT")]
    public class UIcontroller : Controller
    {
        private IQueryService _queryService;

        public UIcontroller(IQueryService QueryService)
        {
            _queryService = QueryService;
        }

        [HttpPut("sendToFilter")]
        public async Task<List<Transaction>> Put([FromBody] QueryInstructions newQI)
        {
            if (newQI == null)
            {
                newQI = new QueryInstructions();
            }
            var updatedAccountList = await _queryService.CallApi(newQI);

            return updatedAccountList;
        }
    }
}