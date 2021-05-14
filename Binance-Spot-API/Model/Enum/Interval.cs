using System.Runtime.Serialization;

namespace Binance_Spot_API.Model.Enum
{
    public enum Interval
    {
        [EnumMember(Value = "1m")]
        MINUTE_1,
        [EnumMember(Value = "3m")]
        MINUTE_3,
        [EnumMember(Value = "5m")]
        MINUTE_5,
        [EnumMember(Value = "15m")]
        MINUTE_15,
        [EnumMember(Value = "30m")]
        MINUTE_30,
        [EnumMember(Value = "1h")]
        HOUR_1,
        [EnumMember(Value = "2h")]
        HOUR_2,
        [EnumMember(Value = "4h")]
        HOUR_4,
        [EnumMember(Value = "6h")]
        HOUR_6,
        [EnumMember(Value = "8h")]
        HOUR_8,
        [EnumMember(Value = "12h")]
        HOUR_12,
        [EnumMember(Value = "1d")]
        DAY_1,
        [EnumMember(Value = "3d")]
        DAY_3,
        [EnumMember(Value = "1w")]
        WEEK_1,
        [EnumMember(Value = "1M")]
        MONTH_1
    }
}
