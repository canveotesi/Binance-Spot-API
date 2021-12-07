using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Account
{
    public class Balance
    {
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("free")]
        public double Free { get; set; }
        [JsonProperty("locked")]
        public double Locked { get; set; }
    }
}
