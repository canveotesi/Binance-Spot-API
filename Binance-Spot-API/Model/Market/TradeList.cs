using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class TradeList
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("qty")]
        public double Quantity { get; set; }
        [JsonProperty("quoteQty")]
        public double QuoteQuantity { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("isBuyerMaker")]
        public bool IsBuyerMaker { get; set; }
        [JsonProperty("isBestMatch")]
        public bool IsBestMatch { get; set; }
    }
}