
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Websocket
{
    public class Listenkey
    {
        [JsonProperty("listenKey")]
        public string ListenKey { get; set; }
    }
}
