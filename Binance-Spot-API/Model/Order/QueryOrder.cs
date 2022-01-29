using Binance_Spot_API.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Binance_Spot_API.Model.Order
{
    public class QueryOrder : Abstract.Order
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("origQty")]
        public decimal OrigQty { get; set; }
        [JsonProperty("executedQty")]
        public decimal ExecutedQty { get; set; }
        [JsonProperty("cummulativeQuoteQty")]
        public decimal CummulativeQuoteQty { get; set; }
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
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }
        [JsonProperty("icebergQty")]
        public decimal IcebergQty { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }
        [JsonProperty("isWorking")]
        public bool IsWorking { get; set; }
        [JsonProperty("origQuoteOrderQty")]
        public decimal OrigQuoteOrderQty { get; set; }
    }
}
