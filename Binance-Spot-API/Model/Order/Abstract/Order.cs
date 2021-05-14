using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Order.Abstract
{
    public abstract class Order
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("orderListId")]
        public int OrderListId { get; set; }
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }
    }
}
