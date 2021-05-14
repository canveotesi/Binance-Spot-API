using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class RateLimit
    {
        [JsonProperty("rateLimitType")]
        public string RateLimitType { get; set; }
        [JsonProperty("interval")]
        public string Interval { get; set; }
        [JsonProperty("intervalNum")]
        public int IntervalNum { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
