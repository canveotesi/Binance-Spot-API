using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance_Spot_API.Model.Websocket.Payload
{
    public class AccountUpdate : Abstract.Payload
    {
        [JsonProperty("u")]
        public long UpdateTime { get; set; }
        [JsonProperty("B")]
        public IEnumerable<Balance> Balances { get; set; }
    }
}
