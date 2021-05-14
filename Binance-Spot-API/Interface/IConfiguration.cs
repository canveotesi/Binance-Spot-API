using Binance_Spot_API.Model.Websocket.Payload;
using static Binance_Spot_API.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Binance_Spot_API.Interface
{
    /// <summary>
    /// Interface of Configuration Class.
    /// </summary>
    interface IConfiguration
    {
        /// <summary>
        /// A method that handles HTTP requests asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">Known HTTP Request Methods. (GET-POST-PUT-DELETE)</param>
        /// <param name="endpoint">The endpoint to which the request is sent.</param>
        /// <param name="parameters">Parameters to be sent to this endpoint.</param>
        /// <param name="signedStatus">Endpoints use HMAC SHA256 signatures. The HMAC SHA256 signature is a keyed HMAC SHA256 operation. Use your secretKey as the key and totalParams as the value for the HMAC operation.</param>
        /// <returns></returns>
        Task<T> SendAsyncRequest<T>(HttpMethod method, string endpoint, string parameters = null, bool signedStatus = false);

        /// <summary>
        /// Connect to Binance Websocket Market Streams.
        /// </summary>
        /// <typeparam name="T">Type of stream message to return.</typeparam>
        /// <param name="streamName">Stream Name to send Web Socket.</param>
        /// <param name="webSocketMessageHandler">Callback for receive message.</param>
        void ConnectToWebSocketMarketStreams<T>(string streamName, WebSocketMessageHandler<T> webSocketMessageHandler);

        /// <summary>
        /// Connect to Binance User Data Streams.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listenKey"></param>
        /// <param name="AccountUpdateMessageHandler">Callback for outboundAccountPosition receive message.</param>
        /// <param name="BalanceUpdateMessageHandler">Callback for balanceUpdate receive message.</param>
        /// <param name="OrderUpdateMessageHandler">Callback for executionReport receive message.</param>
        void ConnectToUserDataStreams<T>(string listenKey, WebSocketMessageHandler<AccountUpdate> AccountUpdateMessageHandler, WebSocketMessageHandler<BalanceUpdate> BalanceUpdateMessageHandler, WebSocketMessageHandler<OrderUpdate> OrderUpdateMessageHandler);
    }
}
