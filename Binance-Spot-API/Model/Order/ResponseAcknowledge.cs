using Newtonsoft.Json;

namespace Binance_Spot_API.Model.Order
{
    public partial class ResponseAcknowledge : Abstract.Order
    {
        [JsonProperty("transactTime")]
        public long TransactionTime { get; set; }
    }
}
