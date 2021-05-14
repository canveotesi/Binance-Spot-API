using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum OrderType
    {
        [EnumMember(Value = "LIMIT")]
        LIMIT,
        [EnumMember(Value = "MARKET")]
        MARKET,
        [EnumMember(Value = "STOP_LOSS")]
        STOP_LOSS,
        [EnumMember(Value = "STOP_LOSS_LIMIT")]
        STOP_LOSS_LIMIT,
        [EnumMember(Value = "TAKE_PROFIT")]
        TAKE_PROFIT,
        [EnumMember(Value = "TAKE_PROFIT_LIMIT")]
        TAKE_PROFIT_LIMIT,
        [EnumMember(Value = "LIMIT_MAKER")]
        LIMIT_MAKER
    }
}
