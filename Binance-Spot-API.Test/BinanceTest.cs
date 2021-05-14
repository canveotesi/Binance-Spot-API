using Newtonsoft.Json;
using System;
using System.Linq;
using Binance_Spot_API.Model.Enum;
using Binance_Spot_API.Model.Websocket;
using Binance_Spot_API.Model.Market;
using Binance_Spot_API.Model.Websocket.Payload;

namespace Binance_Spot_API.Test
{
    public class BinanceTest
    {
        private static string API_KEY = "";
        private static string SECRET_KEY = "";
        public static Configuration config = new Configuration(API_KEY, SECRET_KEY);
        public static Binance binance = new Binance(config);

        #region Market Data Operations Test
        public void TestConnectivity()
        {
            var result = binance.TestConnectivity().Result;

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void CheckServerTime()
        {
            var result = binance.CheckServerTime().Result;

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void ExchangeInformation()
        {
            var result = binance.ExchangeInformation().Result;

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetOrderBook()
        {
            var result = binance.GetOrderBook("BTCUSDT").Result;

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetRecentTradeList()
        {
            var result = binance.GetRecentTradeList("BTCUSDT").Result.ToList();

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetHistoricalTrades()
        {
            var result = binance.GetHistoricalTrades("BTCUSDT").Result.ToList();

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetAggregateTradeList()
        {
            var result = binance.GetAggregateTradeList("BTCUSDT").Result.ToList();

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetCandlesticks()
        {
            var result = binance.GetCandlesticks("BTCUSDT", Model.Enum.Interval.HOUR_4).Result.ToList();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetCurrentAveragePrice()
        {
            var result = binance.GetCurrentAveragePrice("BTCUSDT").Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void Get24HrTickerPriceChangeStatistics()
        {
            var result = binance.Get24HrTickerPriceChangeStatistics("BTCUSDT").Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetSymbolPriceTicker()
        {
            var result = binance.GetSymbolPriceTicker("BTCUSDT").Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetSymbolOrderBookTicker()
        {
            var result = binance.GetSymbolOrderBookTicker("BTCUSDT").Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        #endregion

        #region Spot/Account Operations Test
        public void TestNewOrder()
        {
            var result = binance.TestNewOrder("BTCUSDT", OrderSide.BUY, OrderType.MARKET, null, null, 1000).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void NewOrder()
        {
            var result = binance.NewOrder("BTCUSDT", OrderSide.BUY, OrderType.MARKET, null, null, 1000).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void CancelOrder()
        {
            var result = binance.CancelOrder("BTCUSDT", 123456789).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void QueryOrder()
        {
            var result = binance.QueryOrder("BTCUSDT", 123456789).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetOpenOrders()
        {
            var result = binance.GetOpenOrders("BTCUSDT").Result.ToList();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetAllOrders()
        {
            var result = binance.GetAllOrders("BTCUSDT").Result.ToList();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetAccountInformation()
        {
            var result = binance.GetAccountInformation().Result;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetAccountTradeList()
        {
            var result = binance.GetAccountTradeList("BTCUSDT").Result.ToList();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        #endregion

        #region Websocket Operations Test
        private void TradeStreamsHandler(TradeStreams message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetAggregateTradeStreams()
        {
            binance.GetAggregateTradeStreams("BTCUSDT", TradeStreamsHandler);
        }

        public void GetTradeStreams()
        {
            binance.GetTradeStreams("BTCUSDT", TradeStreamsHandler);    
        }

        private void CandlesticksHandler(Model.Websocket.Candlestick message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetKlineCandlestickStreams()
        {
            binance.GetKlineCandlestickStreams("BTCUSDT", Interval.HOUR_1, CandlesticksHandler);    
        }

        private void DepthHandler(OrderBook message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void GetDepthStreams()
        {
            binance.GetDepthStreams("BTCUSDT", DepthHandler);    
        }

        private void AccountUpdateHandler(AccountUpdate message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        private void BalanceUpdateHandler(BalanceUpdate message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        private void OrderUpdateHandler(OrderUpdate message)
        {
            var result = message;
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        public void ListenPayload()
        {
            var listenKey = binance.CreateListenKey().Result.ListenKey;
            
            binance.ListenPayload(listenKey, AccountUpdateHandler, BalanceUpdateHandler, OrderUpdateHandler);
        }
        #endregion
    }
}
