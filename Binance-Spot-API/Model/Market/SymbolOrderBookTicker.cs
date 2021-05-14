using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class SymbolOrderBookTicker
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("bidPrice")]
        public decimal BidPrice { get; set; }
        [JsonProperty("bidQty")]
        public decimal BidQuantity { get; set; }
        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }
        [JsonProperty("askQty")]
        public decimal AskQuantity { get; set; }
    }
}
