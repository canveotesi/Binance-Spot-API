using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Market
{
    public class TradePrice
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
