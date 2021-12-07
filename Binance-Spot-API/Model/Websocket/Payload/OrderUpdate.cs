using Binance_Spot_API.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Binance_Spot_API.Model.Websocket.Payload
{
    public class OrderUpdate : Abstract.Payload
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("c")]
        public string ClientOrderId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("S")]
        public OrderSide Side { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("o")]
        public OrderType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("f")]
        public TimeInForce TimeInForce { get; set; }
        [JsonProperty("q")]
        public double Quantity { get; set; }
        [JsonProperty("p")]
        public double Price { get; set; }
        [JsonProperty("P")]
        public double StopPrice { get; set; }
        [JsonProperty("F")]
        public double IcebergQuantity { get; set; }
        [JsonProperty("g")]
        public int OrderListId { get; set; }
        [JsonProperty("C")]
        public string OriginalClientOrderId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("x")]
        public ExecutionType CurrentExecutionType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("X")]
        public OrderStatus CurrentOrderStatus { get; set; }
        [JsonProperty("r")]
        public string RejectReason { get; set; }
        [JsonProperty("i")]
        public long OrderId { get; set; }
        [JsonProperty("l")]
        public double LastExecutedQuantity { get; set; }
        [JsonProperty("z")]
        public double CumulativeFilledQuantity { get; set; }
        [JsonProperty("L")]
        public double LastExecutedPrice { get; set; }
        [JsonProperty("n")]
        public int CommissionAmount { get; set; }
        [JsonProperty("N")]
        public string CommissionAsset { get; set; }
        [JsonProperty("T")]
        public long TransactionTime { get; set; }
        [JsonProperty("t")]
        public int TradeId { get; set; }
        [JsonProperty("w")]
        public bool IsOrderOnTheBook { get; set; }
        [JsonProperty("m")]
        public bool IsTradeMaker { get; set; }
        [JsonProperty("O")]
        public long CreationTime { get; set; }
        [JsonProperty("Z")]
        public double CumulativeTransactedQuantity { get; set; }
        [JsonProperty("Y")]
        public double QuoteAssetTransactedQuantity { get; set; }
        [JsonProperty("Q")]
        public double QuoteOrderQuantity { get; set; }
    }
}
