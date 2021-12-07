using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class AveragePrice
    {
        [JsonProperty("mins")]
        public int Minutes { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
