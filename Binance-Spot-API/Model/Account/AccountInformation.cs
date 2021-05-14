using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Binance_Spot_API.Model.Account
{
    public class AccountInformation
    {
        [JsonProperty("makerCommission")]
        public int MakerCommission { get; set; }
        [JsonProperty("takerCommission")]
        public int TakerCommission { get; set; }
        [JsonProperty("buyerCommission")]
        public int BuyerCommission { get; set; }
        [JsonProperty("sellerCommission")]
        public int SellerCommission { get; set; }
        [JsonProperty("canTrade")]
        public bool CanTrade { get; set; }
        [JsonProperty("canWithdraw")]
        public bool CanWithdraw { get; set; }
        [JsonProperty("canDeposit")]
        public bool CanDeposit { get; set; }
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }
        [JsonProperty("accountType")]
        public string AccountType { get; set; }
        [JsonProperty("balances")]
        public IEnumerable<Balance> Balances { get; set; }
        [JsonProperty("permissions")]
        public IEnumerable<string> Permissions { get; set; }
    }
}
