using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Order
{
    public class Fill
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        [JsonProperty("commission")]
        public decimal Commission { get; set; }
        [JsonProperty("commissionAsset")]
        public string CommissionAsset { get; set; }

    }
}
