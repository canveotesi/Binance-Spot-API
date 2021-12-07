using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class Filter
    {
        [JsonProperty("filterType")]
        public string FilterType { get; set; }
        [JsonProperty("minPrice")]
        public double minPrice { get; set; }
        [JsonProperty("maxPrice")]
        public double MaxPrice { get; set; }
        [JsonProperty("tickSize")]
        public double TickSize { get; set; }
        [JsonProperty("multiplierUp")]
        public double MultiplierUp { get; set; }
        [JsonProperty("multiplierDown")]
        public double MultiplierDown { get; set; }
        [JsonProperty("avgPriceMins")]
        public int AvgPriceMins { get; set; }
        [JsonProperty("minQty")]
        public double MinQty { get; set; }
        [JsonProperty("maxQty")]
        public double MaxQty { get; set; }
        [JsonProperty("stepSize")]
        public double StepSize { get; set; }
        [JsonProperty("minNotional")]
        public double MinNotional { get; set; }
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
        public double MaxPosition { get; set; }

    }
}
