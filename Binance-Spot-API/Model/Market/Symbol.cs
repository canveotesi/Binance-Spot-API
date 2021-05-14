using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class Symbol
    {
        [JsonProperty("symbol")]
        public string SymbolName { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }
        [JsonProperty("baseAssetPrecision")]
        public int BaseAssetPrecision { get; set; }
        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }
        [JsonProperty("quotePrecision")]
        public int QuotePrecision { get; set; }
        [JsonProperty("quoteAssetPrecision")]
        public int QuoteAssetPrecision { get; set; }
        [JsonProperty("baseCommissionPrecision")]
        public int BaseCommissionPrecision { get; set; }
        [JsonProperty("quoteCommissionPrecision")]
        public int QuoteCommissionPrecision { get; set; }
        [JsonProperty("orderTypes")]
        public IEnumerable<string> OrderTypes { get; set; }
        [JsonProperty("icebergAllowed")]
        public bool IcebergAllowed { get; set; }
        [JsonProperty("ocoAllowed")]
        public bool OcoAllowed { get; set; }
        [JsonProperty("quoteOrderQtyMarketAllowed")]
        public bool QuoteOrderQtyMarketAllowed { get; set; }
        [JsonProperty("isSpotTradingAllowed")]
        public bool IsSpotTradingAllowed { get; set; }
        [JsonProperty("isMarginTradingAllowed")]
        public bool IsMarginTradingAllowed { get; set; }
        [JsonProperty("filters")]
        public IEnumerable<Filter> Filters { get; set; }
        [JsonProperty("permissions")]
        public IEnumerable<string> Permissions { get; set; }
    }
}
