using Newtonsoft.Json;

namespace Binance_Spot_API.Model.General
{
    public class ServerInfo
    {
        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }
    }
}
