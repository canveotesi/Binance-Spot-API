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
        public decimal Quantity { get; set; }
        [JsonProperty("p")]
        public decimal Price { get; set; }
        [JsonProperty("P")]
        public decimal StopPrice { get; set; }
        [JsonProperty("F")]
        public decimal IcebergQuantity { get; set; }
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
        public decimal LastExecutedQuantity { get; set; }
        [JsonProperty("z")]
        public decimal CumulativeFilledQuantity { get; set; }
        [JsonProperty("L")]
        public decimal LastExecutedPrice { get; set; }
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
        public decimal CumulativeTransactedQuantity { get; set; }
        [JsonProperty("Y")]
        public decimal QuoteAssetTransactedQuantity { get; set; }
        [JsonProperty("Q")]
        public decimal QuoteOrderQuantity { get; set; }
    }
}
