using Newtonsoft.Json;

namespace Forex.Models
{
    public class Quote
    {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("price")]
        public double Price;

        [JsonProperty("bid")]
        public double Bid;

        [JsonProperty("ask")]
        public double Ask;

        [JsonProperty("timestamp")]
        public int Timestamp;
    }
}
