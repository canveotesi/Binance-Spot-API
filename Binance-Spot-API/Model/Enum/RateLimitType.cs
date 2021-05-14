using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum RateLimitType
    {
        [EnumMember(Value = "REQUEST_WEIGHT")]
        REQUEST_WEIGHT,
        [EnumMember(Value = "ORDERS")]
        ORDERS,
        [EnumMember(Value = "RAW_REQUESTS")]
        RAW_REQUESTS
    }
}
