using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket
{
    public class Candlestick
    {
        [JsonProperty("e")]
        public string EventType { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("k")]
        public Kline Kline { get; set; }
    }
}
