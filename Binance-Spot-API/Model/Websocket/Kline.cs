using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket
{
    public class Kline
    {
        [JsonProperty("t")]
        public long StartTime { get; set; }
        [JsonProperty("T")]
        public long CloseTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("i")]
        public string Interval { get; set; }
        [JsonProperty("f")]
        public int FirstTradeId { get; set; }
        [JsonProperty("L")]
        public int LastTradeId { get; set; }
        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }
        [JsonProperty("c")]
        public decimal ClosePrice { get; set; }
        [JsonProperty("h")]
        public decimal HighPrice { get; set; }
        [JsonProperty("l")]
        public decimal LowPrice { get; set; }
        [JsonProperty("v")]
        public decimal BaseAssetVolume { get; set; }
        [JsonProperty("n")]
        public int NumberOfTrades { get; set; }
        [JsonProperty("x")]
        public bool IsClosed { get; set; }
        [JsonProperty("q")]
        public decimal QuoteAssetVolume { get; set; }
        [JsonProperty("V")]
        public decimal TakerBuyBaseAssetVolume { get; set; }
        [JsonProperty("Q")]
        public decimal TakerBuyQuoteAssetVolume { get; set; }
    }
}
