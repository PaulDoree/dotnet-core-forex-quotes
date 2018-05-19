﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
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

        public async Task<List<string>> GetSymbols()
        {
            var responseString = await GetHttpResponseContent("symbols");
            return JsonConvert.DeserializeObject<List<string>>(responseString);
        }

        public async Task<ConversionResult> Convert(string from, string to, double quantity)
        {
            var queryParams = new Dictionary<string, string>{ {"from", from }, {"to", to}, {"quantity", quantity.ToString()} };
            var responseString = await GetHttpResponseContent("convert", queryParams);
            return JsonConvert.DeserializeObject<ConversionResult>(responseString);
        }

        public async Task<List<Quote>> GetQuotes(ICollection<string> currencyPairs)
        {
            var queryParams = new Dictionary<string, string> { {"pairs", string.Join(",", currencyPairs) } };
            var responseString = await GetHttpResponseContent("quotes", queryParams);
            return JsonConvert.DeserializeObject<List<Quote>>(responseString);
        }

        private async Task<string> GetHttpResponseContent(string path, IDictionary<string, string> args = null)
        {
            var queryString = FormQueryString(args);
            var uri = new Uri(_baseUri + path + queryString);

            var response = await _httpClient.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }

        private QueryString FormQueryString(IDictionary<string, string> args)
        {
            var queryBuilder = new QueryBuilder();

            foreach (KeyValuePair<string, string> keyVal in args)
            {
               queryBuilder.Add(keyVal.Key, keyVal.Value);
            }
            queryBuilder.Add("api_key", _apiKey);

            return queryBuilder.ToQueryString();
        }
    }
}
