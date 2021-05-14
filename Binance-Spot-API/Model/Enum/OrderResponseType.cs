using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum OrderResponseType
    {
        [EnumMember(Value = "ACK")]
        ACK,
        [EnumMember(Value = "RESULT")]
        RESULT,
        [EnumMember(Value = "FULL")]
        FULL
    }
}
