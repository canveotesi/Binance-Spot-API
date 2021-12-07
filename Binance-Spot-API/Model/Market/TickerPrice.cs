using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class TickerPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("priceChange")]
        public double PriceChange { get; set; }
        [JsonProperty("priceChangePercent")]
        public double PriceChangePercent { get; set; }
        [JsonProperty("weightedAvgPrice")]
        public double WeightedAvgPrice { get; set; }
        [JsonProperty("prevClosePrice")]
        public double PrevClosePrice { get; set; }
        [JsonProperty("lastPrice")]
        public double LastPrice { get; set; }
        [JsonProperty("lastQty")]
        public double LastQuantity { get; set; }
        [JsonProperty("bidPrice")]
        public double BidPrice { get; set; }
        [JsonProperty("askPrice")]
        public double AskPrice { get; set; }
        [JsonProperty("openPrice")]
        public double OpenPrice { get; set; }
        [JsonProperty("highPrice")]
        public double HighPrice { get; set; }
        [JsonProperty("lowPrice")]
        public double LowPrice { get; set; }
        [JsonProperty("volume")]
        public double Volume { get; set; }
        [JsonProperty("quoteVolume")]
        public double QuoteVolume { get; set; }
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
