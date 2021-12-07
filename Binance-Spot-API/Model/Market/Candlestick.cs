using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Market
{
    [JsonConverter(typeof(Utils.Converter.Candlestick))]
    public class Candlestick
    {
        public long OpenTime { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public long CloseTime { get; set; }
        public double QuoteAssetVolume { get; set; }
        public int NumberOfTrade { get; set; }
        public double TakerBuyBaseAssetVolume { get; set; }
        public double TakerBuyQuoteAssetVolume { get; set; }
    }
}
