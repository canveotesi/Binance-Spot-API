using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket.Payload
{
    public class Balance
    {
        [JsonProperty("a")]
        public string Asset { get; set; }
        [JsonProperty("f")]
        public decimal Free { get; set; }
        [JsonProperty("l")]
        public decimal Locked { get; set; }
    }
}
