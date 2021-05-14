using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Account
{
    public class AccountTradeList
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("orderListId")]
        public int OrderListId { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        [JsonProperty("quoteQty")]
        public decimal QuoteQuantity { get; set; }
        [JsonProperty("commission")]
        public decimal Commission { get; set; }
        [JsonProperty("commissionAsset")]
        public string CommissionAsset { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("isBuyer")]
        public bool IsBuyer { get; set; }
        [JsonProperty("isMaker")]
        public bool IsMaker { get; set; }
        [JsonProperty("isBestMatch")]
        public bool IsBestMatch { get; set; }
    }
}
