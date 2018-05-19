using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Forge.Models;

namespace Forge
{
    public class Client
    {
        private readonly string _apiKey;
        private const string _baseUri = "https://forex.1forge.com/1.0.3/";
        private static readonly HttpClient _httpClient = new HttpClient();

        public Client(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<MarketStatus> GetMarketStatus()
        {
            var responseString = await GetHttpResponseContent("market_status");
            return JsonConvert.DeserializeObject<MarketStatus>(responseString);
        }

        public async Task<Quota> GetQuota()
        {
            var responseString = await GetHttpResponseContent("quota");
            return JsonConvert.DeserializeObject<Quota>(responseString);
        }

        private async Task<string> GetHttpResponseContent(string path)
        {
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("api_key", _apiKey);
            var uri = new Uri(_baseUri + path + queryBuilder.ToQueryString());

            var response = await _httpClient.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
