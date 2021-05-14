using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum RateLimitInterval
    {
        [EnumMember(Value = "SECOND")]
        SECOND,
        [EnumMember(Value = "MINUTE")]
        MINUTE,
        [EnumMember(Value = "DAY")]
        DAY
    }
}
