using System.Collections.Generic;
using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    public class OrderBook
    {
        [JsonProperty("lastUpdateId")]
        public long LastUpdateId { get; set; }
        [JsonProperty("bids")]
        [JsonConverter(typeof(Utils.Converter.TradePrice))]
        public IEnumerable<TradePrice> Bids { get; set; }
        [JsonProperty("asks")]
        [JsonConverter(typeof(Utils.Converter.TradePrice))]
        public IEnumerable<TradePrice> Asks { get; set; }
    }
}
