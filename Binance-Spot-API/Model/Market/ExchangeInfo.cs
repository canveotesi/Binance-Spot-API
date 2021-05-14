using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class ExchangeInfo
    {
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }
        [JsonProperty("rateLimits")]
        public IEnumerable<RateLimit> RateLimits { get; set; }
        [JsonProperty("exchangeFilters")]
        public IEnumerable<Filter> ExchangeFilters { get; set; }
        [JsonProperty("symbols")]
        public IEnumerable<Symbol> Symbols { get; set; }
    }
}
