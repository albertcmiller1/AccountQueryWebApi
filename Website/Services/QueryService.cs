using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Website.Interfaces;
using Website.Models;

namespace Website.Services
{
    public class QueryService : IQueryService
    {
        public async Task<List<Transaction>> CallApi(QueryInstructions sendQI)
        {
            var result = await MyPostAsync("https://localhost:44373/api/send/Post", sendQI);

            var content = result.Content;

            string jsonContent = content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<List<Transaction>>(jsonContent);

            return res;
        }

        public async Task<HttpResponseMessage> MyPostAsync(string requestUri, QueryInstructions content)
        {
            HttpClient client = new HttpClient();

            var res = await client.PostAsync<QueryInstructions>(requestUri, content, new JsonMediaTypeFormatter());

            return res;
        }
    }
}
