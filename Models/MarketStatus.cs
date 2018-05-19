using Newtonsoft.Json;

namespace Forge.Models
{
    public class MarketStatus
    {
        [JsonProperty("market_is_open")]
        public bool MarketIsOpen;
    }
}
