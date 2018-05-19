using Newtonsoft.Json;

namespace Forge.Models
{
    public class Convert
    {
        [JsonProperty("value")]
        public double Value;

        [JsonProperty("text")]
        public string Text;

        [JsonProperty("timestamp")]
        public int Timestamp;
    }
}
