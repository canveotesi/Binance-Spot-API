using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class SymbolOrderBookTicker
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("bidPrice")]
        public double BidPrice { get; set; }
        [JsonProperty("bidQty")]
        public double BidQuantity { get; set; }
        [JsonProperty("askPrice")]
        public double AskPrice { get; set; }
        [JsonProperty("askQty")]
        public double AskQuantity { get; set; }
    }
}
