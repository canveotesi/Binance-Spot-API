using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class AggregateTradeList
    {
        [JsonProperty("a")]
        public int TradeId { get; set; }
        [JsonProperty("p")]
        public decimal Price { get; set; }
        [JsonProperty("q")]
        public decimal Quantity { get; set; }
        [JsonProperty("f")]
        public int FirstTradeId { get; set; }
        [JsonProperty("l")]
        public int LastTradeId { get; set; }
        [JsonProperty("T")]
        public long Timestamp { get; set; }
        [JsonProperty("m")]
        public bool IsBuyerMaker { get; set; }
        [JsonProperty("M")]
        public bool IsBestMatch { get; set; }
    }
}