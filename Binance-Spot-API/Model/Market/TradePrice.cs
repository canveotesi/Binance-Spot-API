using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Market
{
    public class TradePrice
    {
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
