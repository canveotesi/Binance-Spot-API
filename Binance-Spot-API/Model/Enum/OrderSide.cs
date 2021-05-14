using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum OrderSide
    {
        [EnumMember(Value = "BUY")]
        BUY,
        [EnumMember(Value = "SELL")]
        SELL
    }
}
