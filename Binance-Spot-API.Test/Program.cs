using Newtonsoft.Json;
using System;
using System.Linq;

namespace Binance_Spot_API.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinanceTest test = new BinanceTest();

            test.TestConnectivity();
        }
    }
}
