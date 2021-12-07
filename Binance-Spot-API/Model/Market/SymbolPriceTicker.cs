using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class SymbolPriceTicker
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
