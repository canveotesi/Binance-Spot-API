using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket
{
    public class TradeStreams
    {
        [JsonProperty("e")]
        public string EventType { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("a")]
        public long AggregateTradeId { get; set; }
        [JsonProperty("p")]
        public double Price { get; set; }
        [JsonProperty("q")]
        public double Quantity { get; set; }
        [JsonProperty("f")]
        public int FirstTradeId { get; set; }
        [JsonProperty("l")]
        public int LastTradeId { get; set; }
        [JsonProperty("T")]
        public long TradeTime { get; set; }
        [JsonProperty("m")]
        public bool IsBuyerMaker { get; set; }
    }
}
