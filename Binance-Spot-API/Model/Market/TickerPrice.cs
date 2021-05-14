using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class TickerPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("priceChange")]
        public decimal PriceChange { get; set; }
        [JsonProperty("priceChangePercent")]
        public decimal PriceChangePercent { get; set; }
        [JsonProperty("weightedAvgPrice")]
        public decimal WeightedAvgPrice { get; set; }
        [JsonProperty("prevClosePrice")]
        public decimal PrevClosePrice { get; set; }
        [JsonProperty("lastPrice")]
        public decimal LastPrice { get; set; }
        [JsonProperty("lastQty")]
        public decimal LastQuantity { get; set; }
        [JsonProperty("bidPrice")]
        public decimal BidPrice { get; set; }
        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }
        [JsonProperty("openPrice")]
        public decimal OpenPrice { get; set; }
        [JsonProperty("highPrice")]
        public decimal HighPrice { get; set; }
        [JsonProperty("lowPrice")]
        public decimal LowPrice { get; set; }
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
        [JsonProperty("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        [JsonProperty("openTime")]
        public long OpenTime { get; set; }
        [JsonProperty("closeTime")]
        public long CloseTime { get; set; }
        [JsonProperty("firstId")]
        public int FirstId { get; set; }
        [JsonProperty("lastId")]
        public int LastId { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
