using System;
using System.Collections.Generic;
using System.Text;

namespace Binance_Spot_API.Utils
{
    public static class GetEnumMember
    {
        public static string GetMemberAttr(this Enum enumItem)
        {
            var memInfo = enumItem.GetType().GetMember(enumItem.ToString());
            var attr = memInfo[0].GetCustomAttributes(false);
            return attr == null || attr.Length == 0 ? null : ((System.Runtime.Serialization.EnumMemberAttribute)attr[0]).Value.ToString();
        }
    }
}
