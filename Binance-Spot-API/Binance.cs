using Binance_Spot_API.Interface;
using Binance_Spot_API.Model.Account;
using Binance_Spot_API.Model.Enum;
using Binance_Spot_API.Model.General;
using Binance_Spot_API.Model.Market;
using Binance_Spot_API.Model.Order.Abstract;
using Binance_Spot_API.Model.Order;
using Binance_Spot_API.Model.Websocket.Payload;
using Binance_Spot_API.Model.Websocket;
using Binance_Spot_API.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Binance_Spot_API
{
    public class Binance : IBinance
    {
        /// <summary>
        /// Http Operations Configuration.
        /// </summary>
        private Configuration _httpConfiguration = null;

        /// <summary>
        /// Constructor method for Binance API.
        /// </summary>
        /// <param name="httpConfiguration"></param>
        public Binance(Configuration httpConfiguration)
        {
            _httpConfiguration = httpConfiguration;
        }

        #region Market Data Operations
        /// <summary>
        /// Test Connectivity.
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> TestConnectivity()
        {
            return await _httpConfiguration.SendAsyncRequest<dynamic>(HttpMethod.Get, Endpoint.TestConnectivity);
        }

        /// <summary>
        /// Check Server Time.
        /// </summary>
        /// <returns></returns>
        public async Task<ServerInfo> CheckServerTime()
        {
            return await _httpConfiguration.SendAsyncRequest<ServerInfo>(HttpMethod.Get, Endpoint.CheckServerTime);
        }

        /// <summary>
        /// Exchange Info
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> ExchangeInformation()
        {
            return await _httpConfiguration.SendAsyncRequest<dynamic>(HttpMethod.Get, Endpoint.ExchangeInformation);
        }

        /// <summary>
        /// Get Order Book.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="limit">Default 100; max 5000. Valid limits:[5, 10, 20, 50, 100, 500, 1000, 5000]</param>
        /// <returns></returns>
        public async Task<OrderBook> GetOrderBook(string symbol, int limit = 100)
        {
            var parameters = $"symbol={symbol.ToUpper()}&limit={limit}";

            return await _httpConfiguration.SendAsyncRequest<OrderBook>(HttpMethod.Get, Endpoint.OrderBook, parameters);
        }

        /// <summary>
        /// Get recent trades.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TradeList>> GetRecentTradeList(string symbol, int limit = 1000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&limit={limit}";

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<TradeList>>(HttpMethod.Get, Endpoint.RecentTradesList, parameters);
        }

        /// <summary>
        /// Get older market trades.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TradeList>> GetHistoricalTrades(string symbol, int limit = 1000, long? fromId = null)
        {
            var parameters = $"symbol={symbol.ToUpper()}&limit={limit}" + (fromId > 0 ? $"&fromId={fromId}" : "");

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<TradeList>>(HttpMethod.Get, Endpoint.OldTradeLookup, parameters, false);
        }

        /// <summary>
        /// Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="fromId">id to get aggregate trades from INCLUSIVE.</param>
        /// <param name="startTime">Timestamp in ms to get aggregate trades from INCLUSIVE.</param>
        /// <param name="endTime">Timestamp in ms to get aggregate trades until INCLUSIVE.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregateTradeList>> GetAggregateTradeList(string symbol, long? fromId = null, DateTime? startTime = null, DateTime? endTime = null, int limit = 1000)
        {
            var parameters = $"symbol={symbol.ToUpper()}" +
                (fromId > 0 ? $"&fromId={fromId}" : "") +
                (startTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(startTime.Value)}" : "") +
                (endTime.HasValue ? $"&endTime={Utils.Timestamp.Generate(endTime.Value)}" : "") +
                $"&limit={limit}";

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<AggregateTradeList>>(HttpMethod.Get, Endpoint.AggregateTradesList, parameters, false);
        }

        /// <summary>
        /// Get Kline/Candlestick Data
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="interval">Kline/candlestick bars for a symbol.</param>
        /// <param name="startTime">Start date of chart data.</param>
        /// <param name="endTime">End date of chart data.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Model.Market.Candlestick>> GetCandlesticks(string symbol, Interval interval, DateTime? startTime = null, DateTime? endTime = null, int limit = 1000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&interval={interval.GetMemberAttr()}" + 
                (startTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(startTime.Value)}" : "") +
                (endTime.HasValue ? $"&endTime={Utils.Timestamp.Generate(endTime.Value)}" : "") +
                $"&limit={limit}";

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<Model.Market.Candlestick>>(HttpMethod.Get, Endpoint.Candlestick, parameters, false);
        }

        /// <summary>
        /// Current average price for a symbol.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <returns></returns>
        public async Task<AveragePrice> GetCurrentAveragePrice(string symbol)
        {
            var parameters = $"symbol={symbol.ToUpper()}";

            return await _httpConfiguration.SendAsyncRequest<AveragePrice>(HttpMethod.Get, Endpoint.CurrentAveragePrice, parameters, false);
        }

        /// <summary>
        /// 24 hour rolling window price change statistics. Careful when accessing this with no symbol.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <returns></returns>
        public async Task<TickerPrice> Get24HrTickerPriceChangeStatistics(string symbol)
        {
            var parameters = $"symbol={symbol.ToUpper()}";

            return await _httpConfiguration.SendAsyncRequest<TickerPrice>(HttpMethod.Get, Endpoint.HR24TickerPriceChange, parameters, false);
        }

        /// <summary>
        /// Latest price for a symbol.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <returns></returns>
        public async Task<SymbolPriceTicker> GetSymbolPriceTicker(string symbol)
        {
            var parameters = $"symbol={symbol.ToUpper()}";

            return await _httpConfiguration.SendAsyncRequest<SymbolPriceTicker>(HttpMethod.Get, Endpoint.SymbolPriceTicker, parameters, false);
        }

        /// <summary>
        /// Best price/qty on the order book for a symbol.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <returns></returns>
        public async Task<SymbolOrderBookTicker> GetSymbolOrderBookTicker(string symbol)
        {
            var parameters = $"symbol={symbol.ToUpper()}";

            return await _httpConfiguration.SendAsyncRequest<SymbolOrderBookTicker>(HttpMethod.Get, Endpoint.OrderBookTicker, parameters, false);
        }
        #endregion

        #region Websocket Operations
        /// <summary>
        /// The Aggregate Trade Streams push trade information that is aggregated for a single taker order.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="msgHandler">Callback for response message.</param>
        public void GetAggregateTradeStreams(string symbol, Configuration.WebSocketMessageHandler<TradeStreams> msgHandler)
        {
            var finalEndpoint = symbol.ToLower() + "@aggTrade";
            
            _httpConfiguration.ConnectToWebSocketMarketStreams(finalEndpoint, msgHandler);
        }

        /// <summary>
        /// The Trade Streams push raw trade information; each trade has a unique buyer and seller.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="msgHandler"></param>
        public void GetTradeStreams(string symbol, Configuration.WebSocketMessageHandler<TradeStreams> msgHandler)
        {
            var finalEndpoint = symbol.ToLower() + "@trade";

            _httpConfiguration.ConnectToWebSocketMarketStreams(finalEndpoint, msgHandler);
        }

        /// <summary>
        /// The Kline/Candlestick Stream push updates to the current klines/candlestick every second.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="interval">Kline/Candlestick chart intervals. [1m,3m,5m,15m,30m,1h,2h,4h,6h,8h,12h,1d,3d,1w,1M]</param>
        /// <param name="msgHandler">Callback for response message.</param>
        public void GetKlineCandlestickStreams(string symbol, Interval interval, Configuration.WebSocketMessageHandler<Model.Websocket.Candlestick> msgHandler)
        {
            var finalEndpoint = symbol.ToLower() + $"@kline_{interval.GetMemberAttr()}";

            _httpConfiguration.ConnectToWebSocketMarketStreams(finalEndpoint, msgHandler);
        }

        /// <summary>
        /// Top bids and asks.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="msgHandler">Callback for response message.</param>
        /// <param name="level">Valid are 5, 10, or 20.</param>
        public void GetDepthStreams(string symbol, Configuration.WebSocketMessageHandler<OrderBook> msgHandler, int level = 5)
        {
            var finalEndpoint = symbol.ToLower() + $"@depth{level}";

            _httpConfiguration.ConnectToWebSocketMarketStreams(finalEndpoint, msgHandler);
        }

        /// <summary>
        /// Start a new user data stream. The stream will close after 60 minutes unless a keepalive is sent. If the account has an active listenKey, that listenKey will be returned and its validity will be extended for 60 minutes.
        /// </summary>
        /// <returns></returns>
        public async Task<Listenkey> CreateListenKey()
        {
            var response = await _httpConfiguration.SendAsyncRequest<Listenkey>(HttpMethod.Post, Endpoint.UserDataStream);

            return response;
        }

        /// <summary>
        /// Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes. It's recommended to send a ping about every 30 minutes.
        /// </summary>
        /// <param name="listenKey">The key we created earlier in the CreateListenKey func.</param>
        /// <returns></returns>
        public async Task<dynamic> KeepAliveListenKey(string listenKey)
        {
            var parameters = $"listenKey={listenKey}";

            var response = await _httpConfiguration.SendAsyncRequest<dynamic>(HttpMethod.Put, Endpoint.UserDataStream, parameters);

            return response;
        }

        /// <summary>
        /// Close out a user data stream.
        /// </summary>
        /// <param name="listenKey">The key we created earlier in the CreateListenKey func.</param>
        /// <returns></returns>
        public async Task<dynamic> DeleteListenKey(string listenKey)
        {
            var parameters = $"listenKey={listenKey}";

            var response = await _httpConfiguration.SendAsyncRequest<dynamic>(HttpMethod.Delete, Endpoint.UserDataStream, parameters);

            return response;
        }

        /// <summary>
        /// Listen to user data payloads.
        /// </summary>
        /// <param name="listenKey">User listen key.</param>
        /// <param name="AccountUpdateMessageHandler">Callback for account update payload response message.</param>
        /// <param name="BalanceUpdateMessageHandler">Callback for balance update payload response message.</param>
        /// <param name="OrderUpdateMessageHandler">Callback for order update payload response message.</param>
        public void ListenPayload(string listenKey, Configuration.WebSocketMessageHandler<AccountUpdate> AccountUpdateMessageHandler, Configuration.WebSocketMessageHandler<BalanceUpdate> BalanceUpdateMessageHandler, Configuration.WebSocketMessageHandler<OrderUpdate> OrderUpdateMessageHandler)
        {
            _httpConfiguration.ConnectToUserDataStreams<AccountUpdate>(listenKey, AccountUpdateMessageHandler, BalanceUpdateMessageHandler, OrderUpdateMessageHandler);
        }
        #endregion

        #region Spot/Account Trade
        /// <summary>
        /// Test new order creation and signature/recvWindow long. Creates and validates a new order but does not send it into the matching engine.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="side">Order Side [BUY, SELL]</param>
        /// <param name="type">Order Type [LIMIT, MARKET, STOP_LOSS , STOP_LOSS_LIMIT, TAKE_PROFIT, TAKE_PROFIT_LIMIT, LIMIT_MAKER]</param>
        /// <param name="price">The price of the coin at the time the order is entered.</param>
        /// <param name="quantity">The quantity of assets to buy or sell in the limit order.</param>
        /// <param name="quoteOrderQty">MARKET orders using quoteOrderQty specifies the amount the user wants to spend (when buying) or receive (when selling) the quote asset; the correct quantity will be determined based on the market liquidity and quoteOrderQty.
        /// Using BTCUSDT as an example:
        /// On the BUY side, the order will buy as many BTC as quoteOrderQty USDT can.
        /// On the SELL side, the order will sell as much BTC needed to receive quoteOrderQty USDT.
        /// </param>
        /// <param name="icebergQty">A conditional order to buy or sell a large amount of assets in smaller predetermined quantities in order to conceal the total order quantity.</param>
        /// <param name="stopPrice">When the asset’s price reaches the given stop price, the stop-limit order is executed to buy or sell the asset at the given limit price or better.</param>
        /// <param name="orderResponseType">ACK, RESULT or FULL; MARKET and LIMIT order types default to FULL, all other orders default to ACK.</param>
        /// <param name="timeInForce">Any order with an icebergQty MUST have timeInForce set to GTC.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000</param>
        /// <returns></returns>
        public async Task<dynamic> TestNewOrder(string symbol, OrderSide side, OrderType type, double? price = null, double? quantity = null, double? quoteOrderQty = null, double? icebergQty = null, double? stopPrice = null, OrderResponseType? orderResponseType = OrderResponseType.ACK, TimeInForce timeInForce = TimeInForce.GTC, long? recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&side={side.GetMemberAttr()}&type={type.GetMemberAttr()}&recvWindow={recvWindow}"
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT) ? $"&timeInForce={timeInForce.GetMemberAttr()}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.MARKET || type == OrderType.STOP_LOSS || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT || type == OrderType.TAKE_PROFIT_LIMIT || type == OrderType.LIMIT_MAKER) && quantity > 0 ? $"&quantity={quantity}" : "")
                + ((type == OrderType.MARKET) && quoteOrderQty > 0 ? $"&quoteOrderQty={quoteOrderQty}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT || type == OrderType.LIMIT_MAKER) && price > 0 ? $"&price={price}" : "")
                + ((type == OrderType.STOP_LOSS || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT || type == OrderType.TAKE_PROFIT_LIMIT) && stopPrice > 0 ? $"&stopPrice={stopPrice}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT) && icebergQty > 0 ? $"&icebergQty={icebergQty}" : "")
                + ((orderResponseType.HasValue) ? $"&newOrderRespType={orderResponseType.GetMemberAttr()}" : "");


            return await _httpConfiguration.SendAsyncRequest<dynamic>(HttpMethod.Post, Endpoint.TestOrder, parameters, true);
        }

        /// <summary>
        /// Send new order.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="side">Order Side [BUY, SELL]</param>
        /// <param name="type">Order Type [LIMIT, MARKET, STOP_LOSS , STOP_LOSS_LIMIT, TAKE_PROFIT, TAKE_PROFIT_LIMIT, LIMIT_MAKER]</param>
        /// <param name="price">The price of the coin at the time the order is entered.</param>
        /// <param name="quantity">The quantity of assets to buy or sell in the limit order.</param>
        /// <param name="quoteOrderQty">MARKET orders using quoteOrderQty specifies the amount the user wants to spend (when buying) or receive (when selling) the quote asset; the correct quantity will be determined based on the market liquidity and quoteOrderQty.
        /// Using BTCUSDT as an example:
        /// On the BUY side, the order will buy as many BTC as quoteOrderQty USDT can.
        /// On the SELL side, the order will sell as much BTC needed to receive quoteOrderQty USDT.
        /// </param>
        /// <param name="icebergQty">A conditional order to buy or sell a large amount of assets in smaller predetermined quantities in order to conceal the total order quantity.</param>
        /// <param name="stopPrice">When the asset’s price reaches the given stop price, the stop-limit order is executed to buy or sell the asset at the given limit price or better.</param>
        /// <param name="orderResponseType">ACK, RESULT or FULL; MARKET and LIMIT order types default to FULL, all other orders default to ACK.</param>
        /// <param name="timeInForce">Any order with an icebergQty MUST have timeInForce set to GTC.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<Order> NewOrder(string symbol, OrderSide side, OrderType type, double? price = null, double? quantity = null, double? quoteOrderQty = null, double? icebergQty = null, double? stopPrice = null, OrderResponseType? orderResponseType = OrderResponseType.ACK, TimeInForce timeInForce = TimeInForce.GTC, long? recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&side={side.GetMemberAttr()}&type={type.GetMemberAttr()}&recvWindow={recvWindow}"
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT) ? $"&timeInForce={timeInForce.GetMemberAttr()}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.MARKET || type == OrderType.STOP_LOSS || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT || type == OrderType.TAKE_PROFIT_LIMIT || type == OrderType.LIMIT_MAKER) && quantity > 0 ? $"&quantity={quantity}" : "")
                + ((type == OrderType.MARKET) && quoteOrderQty > 0 ? $"&quoteOrderQty={quoteOrderQty}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT || type == OrderType.LIMIT_MAKER) && price > 0 ? $"&price={price}" : "")
                + ((type == OrderType.STOP_LOSS || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT || type == OrderType.TAKE_PROFIT_LIMIT) && stopPrice > 0 ? $"&stopPrice={stopPrice}" : "")
                + ((type == OrderType.LIMIT || type == OrderType.STOP_LOSS_LIMIT || type == OrderType.TAKE_PROFIT_LIMIT) && icebergQty > 0 ? $"&icebergQty={icebergQty}" : "")
                + ((orderResponseType.HasValue) ? $"&newOrderRespType={orderResponseType.GetMemberAttr()}" : "");


            switch (orderResponseType)
            {
                case OrderResponseType.RESULT:
                    return await _httpConfiguration.SendAsyncRequest<ResponseResult>(HttpMethod.Post, Endpoint.Order, parameters, true);
                case OrderResponseType.FULL:
                    return await _httpConfiguration.SendAsyncRequest<ResponseFull>(HttpMethod.Post, Endpoint.Order, parameters, true);
                default:
                    return await _httpConfiguration.SendAsyncRequest<ResponseAcknowledge>(HttpMethod.Post, Endpoint.Order, parameters, true);
            }
        }

        /// <summary>
        /// Cancel an active order. Either orderId or origClientOrderId must be sent.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="orderId"></param>
        /// <param name="origClientOrderId"></param>
        /// <param name="newClientOrderId">Used to uniquely identify this cancel. Automatically generated by default.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<CancelOrder> CancelOrder(string symbol, long? orderId = null, string origClientOrderId= null, string newClientOrderId = null, long recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}" 
                + (orderId > 0 ? $"&orderId={orderId}" : "")
                + (!string.IsNullOrWhiteSpace(origClientOrderId) ? $"&origClientOrderId={origClientOrderId}" : "")
                + (!string.IsNullOrWhiteSpace(newClientOrderId) ? $"&newClientOrderId={newClientOrderId}" : "");

            return await _httpConfiguration.SendAsyncRequest<CancelOrder>(HttpMethod.Delete, Endpoint.Order, parameters, true);
        }

        /// <summary>
        /// Check an order's status.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="orderId">The ID of the order to be checked.</param>
        /// <param name="origClientOrderId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<QueryOrder> QueryOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}"
                + (orderId > 0 ? $"&orderId={orderId}" : "")
                + (!string.IsNullOrWhiteSpace(origClientOrderId) ? $"&origClientOrderId={origClientOrderId}" : "");

            return await _httpConfiguration.SendAsyncRequest<QueryOrder>(HttpMethod.Get, Endpoint.Order, parameters, true);
        }

        /// <summary>
        /// Get all open orders on a symbol. Careful when accessing this with no symbol. If the symbol is not sent, orders for all symbols will be returned in an array.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<QueryOrder>> GetOpenOrders(string symbol = null, long recvWindow = 5000)
        {
            var parameters = (!string.IsNullOrWhiteSpace(symbol) ? $"symbol={symbol.ToUpper()}" : "") + $"&recvWindow={recvWindow}";

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<QueryOrder>>(HttpMethod.Get, Endpoint.OpenOrders, parameters, true);
        }

        /// <summary>
        /// Get all account orders; active, canceled, or filled.
        /// NOTES:
        /// If orderId is set, it will get orders >= that orderId. Otherwise most recent orders are returned.
        /// For some historical orders cummulativeQuoteQty will be < 0, meaning the data is not available at this time.
        /// If startTime and/or endTime provided, orderId is not required.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="orderId">Order ID of Transaction.</param>
        /// <param name="startTime">Transactions start time.</param>
        /// <param name="endTime">Transactions end time.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<QueryOrder>> GetAllOrders(string symbol, long? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int limit = 1000, long recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}&limit={limit}"
                +(orderId > 0 ? $"&orderId={orderId}" : "")
                +(startTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(startTime.Value)}" : "")
                +(endTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(endTime.Value)}" : "");

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<QueryOrder>>(HttpMethod.Get, Endpoint.AllOrders, parameters, true);
        }

        /// <summary>
        /// Get current account information.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<AccountInformation> GetAccountInformation(long recvWindow = 5000)
        {
            var parameters = $"recvWindow={recvWindow}";

            return await _httpConfiguration.SendAsyncRequest<AccountInformation>(HttpMethod.Get, Endpoint.AccountInformation, parameters, true);
        }

        /// <summary>
        /// Get trades for a specific account and symbol.
        /// </summary>
        /// <param name="symbol">Symbol of Coin.</param>
        /// <param name="startTime">Transactions start time.</param>
        /// <param name="endTime">Transactions end time.</param>
        /// <param name="fromId">TradeId to fetch from. Default gets most recent trades.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<AccountTradeList>> GetAccountTradeList(string symbol, DateTime? startTime = null, DateTime? endTime = null, long? fromId = null, int limit = 1000, long recvWindow = 5000)
        {
            var parameters = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}&limit={limit}"
                + (fromId > 0 ? $"&fromId={fromId}" : "")
                + (startTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(startTime.Value)}" : "")
                + (endTime.HasValue ? $"&startTime={Utils.Timestamp.Generate(endTime.Value)}" : "");

            return await _httpConfiguration.SendAsyncRequest<IEnumerable<AccountTradeList>>(HttpMethod.Get, Endpoint.AccountTradeList, parameters, true);
        }
        #endregion
    }
}
