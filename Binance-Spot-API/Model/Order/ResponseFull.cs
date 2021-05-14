using Binance_Spot_API.Model.Order;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance_Spot_API.Model.Order
{
    public class ResponseFull : ResponseResult
    {
        [JsonProperty("fills")]
        public IEnumerable<Fill> Fills { get; set; }
    }
}
