using Newtonsoft.Json;

namespace Forex.Models
{
    public class MarketStatus
    {
        [JsonProperty("market_is_open")]
        public bool MarketIsOpen;
    }
}
