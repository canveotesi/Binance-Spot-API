using Binance_Spot_API.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Binance_Spot_API.Model.Order
{
    public class CancelOrder : Abstract.Order
    {
   
        [JsonProperty("origClientOrderId")]
        public string origClientOrderId { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("origQty")]
        public double OrigQty { get; set; }
        [JsonProperty("executedQty")]
        public double ExecutedQty { get; set; }
        [JsonProperty("cummulativeQuoteQty")]
        public double CummulativeQuoteQty { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public OrderStatus Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("timeInForce")]
        public TimeInForce TimeInForce { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public OrderType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("side")]
        public OrderSide Side { get; set; }
    }
}
