using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket.Abstract
{
    public abstract class Payload
    {
        [JsonProperty("e")]
        public string EventType { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
    }
}
