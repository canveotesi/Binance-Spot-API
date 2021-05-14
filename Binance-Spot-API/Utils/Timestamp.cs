using System;
using System.Collections.Generic;
using System.Text;

namespace Binance_Spot_API.Utils
{
    public class Timestamp
    {
        public static string Generate(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds().ToString();
        }
    }
}
