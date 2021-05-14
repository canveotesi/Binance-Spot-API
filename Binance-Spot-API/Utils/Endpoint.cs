using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Binance_Spot_API.Constant;

namespace Binance_Spot_API.Utils
{
    public static class Endpoint
    {
        #region Market Data Endpoints
        public static readonly string TestConnectivity      = $"/api/{BinanceConstants.API_VERSION}/ping";
        public static readonly string CheckServerTime       = $"/api/{BinanceConstants.API_VERSION}/time";
        public static readonly string ExchangeInformation   = $"/api/{BinanceConstants.API_VERSION}/exchangeInfo";
        public static readonly string OrderBook             = $"/api/{BinanceConstants.API_VERSION}/depth";
        public static readonly string RecentTradesList      = $"/api/{BinanceConstants.API_VERSION}/trades";
        public static readonly string OldTradeLookup        = $"/api/{BinanceConstants.API_VERSION}/historicalTrades";
        public static readonly string AggregateTradesList   = $"/api/{BinanceConstants.API_VERSION}/aggTrades";
        public static readonly string Candlestick           = $"/api/{BinanceConstants.API_VERSION}/klines";
        public static readonly string CurrentAveragePrice   = $"/api/{BinanceConstants.API_VERSION}/avgPrice";
        public static readonly string HR24TickerPriceChange = $"/api/{BinanceConstants.API_VERSION}/ticker/24hr";
        public static readonly string SymbolPriceTicker     = $"/api/{BinanceConstants.API_VERSION}/ticker/price";
        public static readonly string OrderBookTicker       = $"/api/{BinanceConstants.API_VERSION}/ticker/bookTicker";
        #endregion

        #region Spot Account/Trade Endpoints
        public static readonly string TestOrder             = $"/api/{BinanceConstants.API_VERSION}/order/test";
        public static readonly string Order                 = $"/api/{BinanceConstants.API_VERSION}/order";
        public static readonly string OpenOrders            = $"/api/{BinanceConstants.API_VERSION}/openOrders";
        public static readonly string AllOrders             = $"/api/{BinanceConstants.API_VERSION}/allOrders";
        public static readonly string NewOCO                = $"/api/{BinanceConstants.API_VERSION}/order/oco";
        public static readonly string OrderListOCO          = $"/api/{BinanceConstants.API_VERSION}/orderList";
        public static readonly string AllOrderListOCO       = $"/api/{BinanceConstants.API_VERSION}/allOrderList";
        public static readonly string OpenOrderListOCO      = $"/api/{BinanceConstants.API_VERSION}/openOrderList";
        public static readonly string AccountInformation    = $"/api/{BinanceConstants.API_VERSION}/account";
        public static readonly string AccountTradeList      = $"/api/{BinanceConstants.API_VERSION}/myTrades";
        #endregion

        #region User Data Streams Endpoints
        public static readonly string UserDataStream        = $"/api/{BinanceConstants.API_VERSION}/userDataStream";
        #endregion
    }
}
