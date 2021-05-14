using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum ExecutionType
    {
        [EnumMember(Value = "NEW")]
        NEW,
        [EnumMember(Value = "CANCELED")]
        CANCELED,
        [EnumMember(Value = "REPLACED")]
        REPLACED,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "TRADE")]
        TRADE,
        [EnumMember(Value = "EXPIRED")]
        EXPIRED
    }
}
