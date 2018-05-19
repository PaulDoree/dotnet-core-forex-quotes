using Newtonsoft.Json;

namespace Forex.Models
{
    public class Quota
    {
        [JsonProperty("quota_used")]
        public int QuotaUsed;

        [JsonProperty("quota_limit")]
        public int QuotaLimit;

        [JsonProperty("quota_remaining")]
        public int QuotaRemaining;

        [JsonProperty("hours_until_reset")]
        public int HoursUntilReset;
    }
}
