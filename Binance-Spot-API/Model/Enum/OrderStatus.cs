using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum OrderStatus
    {
        [EnumMember(Value = "NEW")]
        NEW,
        [EnumMember(Value = "PARTIALLY_FILLED")]
        PARTIALLY_FILLED,
        [EnumMember(Value = "FILLED")]
        FILLED,
        [EnumMember(Value = "CANCELED")]
        CANCELED,
        [EnumMember(Value = "PENDING_CANCEL")]
        PENDING_CANCEL,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "EXPIRED")]
        EXPIRED
    }
}
