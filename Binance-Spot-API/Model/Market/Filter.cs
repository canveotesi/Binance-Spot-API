using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class Filter
    {
        [JsonProperty("filterType")]
        public string FilterType { get; set; }
        [JsonProperty("minPrice")]
        public decimal minPrice { get; set; }
        [JsonProperty("maxPrice")]
        public decimal MaxPrice { get; set; }
        [JsonProperty("tickSize")]
        public decimal TickSize { get; set; }
        [JsonProperty("multiplierUp")]
        public decimal MultiplierUp { get; set; }
        [JsonProperty("multiplierDown")]
        public decimal MultiplierDown { get; set; }
        [JsonProperty("avgPriceMins")]
        public int AvgPriceMins { get; set; }
        [JsonProperty("minQty")]
        public decimal MinQty { get; set; }
        [JsonProperty("maxQty")]
        public decimal MaxQty { get; set; }
        [JsonProperty("stepSize")]
        public decimal StepSize { get; set; }
        [JsonProperty("minNotional")]
        public decimal MinNotional { get; set; }
        [JsonProperty("applyToMarket")]
        public bool ApplyToMarket { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("maxNumOrders")]
        public int MaxNumOrders { get; set; }
        [JsonProperty("maxNumAlgoOrders")]
        public int MaxNumAlgoOrders { get; set; }
        [JsonProperty("maxNumIcebergOrders")]
        public int MaxNumIcebergOrders { get; set; }
        [JsonProperty("maxPosition")]
        public decimal MaxPosition { get; set; }

    }
}
