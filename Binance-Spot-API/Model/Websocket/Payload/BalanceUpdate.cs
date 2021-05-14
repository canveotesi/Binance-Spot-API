using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket.Payload
{
    public class BalanceUpdate : Abstract.Payload
    {
        [JsonProperty("a")]
        public string Asset { get; set; }
        [JsonProperty("d")]
        public decimal BalanceDelta { get; set; }
        [JsonProperty("T")]
        public long ClearTime { get; set; }
    }
}
