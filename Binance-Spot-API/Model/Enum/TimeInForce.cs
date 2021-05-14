using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum TimeInForce
    {
        [EnumMember(Value = "GTC")]
        GTC,
        [EnumMember(Value = "IOC")]
        IOC,
        [EnumMember(Value = "FOK")]
        FOK
    }
}
