using Binance_Spot_API.Constant;
using Binance_Spot_API.Interface;
using Binance_Spot_API.Model.Websocket.Payload;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using WebSocketSharp;

namespace Binance_Spot_API
{
    /// <summary>
    /// General Configuration.
    /// </summary>
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// Binance API Key
        /// </summary>
        private string _apiKey;

        /// <summary>
        /// Binance Secret Key
        /// </summary>
        private string _secretKey;

        /// <summary>
        /// Provides a class for sending HTTP requests and receiving HTTP responses from a resource defined by URI.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// List of Web Sockets opened.
        /// </summary>
        private List<WebSocket> _socketList;

        /// <summary>
        /// Handles the message returned from the Web Socket.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public delegate void WebSocketMessageHandler<T>(T message);
        

        /// <summary>
        /// HTTP Operations Constructor Method.
        /// </summary>
        /// <param name="apiKey">Your API Key on Binance.</param>
        /// <param name="secretKey">Your Secret Key on Binance.</param>
        public Configuration(string apiKey, string secretKey)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BinanceConstants.BASE_ENDPOINT_URL);

            if(BinanceConstants.ADD_DEFAULT_REQUEST_HEADERS)
            {
                _httpClient.DefaultRequestHeaders.Add(BinanceConstants.API_KEY_HEADER, _apiKey);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            _socketList = new List<WebSocket>();
        }

        /// <summary>
        /// A method that handles HTTP requests asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">Known HTTP Request Methods. (GET-POST-PUT-DELETE)</param>
        /// <param name="endpoint">The endpoint to which the request is sent.</param>
        /// <param name="parameters">Parameters to be sent to this endpoint.</param>
        /// <param name="signedStatus">Endpoints use HMAC SHA256 signatures. The HMAC SHA256 signature is a keyed HMAC SHA256 operation. Use your secretKey as the key and totalParams as the value for the HMAC operation.</param>
        /// <returns></returns>
        public async Task<T> SendAsyncRequest<T>(HttpMethod method, string endpoint, string parameters = null, bool signedStatus = false)
        {
            string targetURI = endpoint + (!string.IsNullOrWhiteSpace(parameters) ? $"?{parameters}" : "");

            if(signedStatus && !string.IsNullOrWhiteSpace(parameters))
            {
                parameters += $"&timestamp={Utils.Timestamp.Generate(DateTime.Now)}";

                targetURI = endpoint + $"?{parameters}&signature={Utils.Signature.Generate(_secretKey, parameters)}";
            }

            HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(method, targetURI)).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                
                return JsonConvert.DeserializeObject<T>(content);
            }
            
            throw new Exception(content);
        }

        /// <summary>
        /// Connect to Binance Websocket Market Streams.
        /// </summary>
        /// <typeparam name="T">Type of stream message to return.</typeparam>
        /// <param name="streamName">Stream Name to send Web Socket.</param>
        /// <param name="webSocketMessageHandler">Callback for receive message.</param>
        public void ConnectToWebSocketMarketStreams<T>(string streamName, WebSocketMessageHandler<T> webSocketMessageHandler)
        {
            var targetURI = BinanceConstants.WEBSOCKET_BASE_ENDPOINT_URL + streamName;
            
            var ws = new WebSocket(targetURI);

            ws.OnMessage += (sender, e) =>
            {
                var responseData = JsonConvert.DeserializeObject<T>(e.Data);

                webSocketMessageHandler(responseData);
            };

            ws.OnError += (sender, e) =>
            {
                _socketList.Remove(ws);
            };

            ws.OnClose += (sender, e) =>
            {
                _socketList.Remove(ws);
            };
            
            ws.Connect();
            _socketList.Add(ws);
        }

        /// <summary>
        /// Connect to Binance User Data Streams.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listenKey"></param>
        /// <param name="AccountUpdateMessageHandler">Callback for outboundAccountPosition receive message.</param>
        /// <param name="BalanceUpdateMessageHandler">Callback for balanceUpdate receive message.</param>
        /// <param name="OrderUpdateMessageHandler">Callback for executionReport receive message.</param>
        public void ConnectToUserDataStreams<T>(string listenKey, WebSocketMessageHandler<AccountUpdate> AccountUpdateMessageHandler, WebSocketMessageHandler<BalanceUpdate> BalanceUpdateMessageHandler, WebSocketMessageHandler<OrderUpdate> OrderUpdateMessageHandler)
        {
            var targetURI = BinanceConstants.WEBSOCKET_BASE_ENDPOINT_URL + listenKey;

            var ws = new WebSocket(targetURI);

            ws.OnMessage += (sender, e) =>
            {
                var payload = JsonConvert.DeserializeObject<dynamic>(e.Data);

                switch (payload.e.Value)
                {
                    case "outboundAccountPosition":
                        var AccountUpdate = JsonConvert.DeserializeObject<AccountUpdate>(e.Data);
                        AccountUpdateMessageHandler(AccountUpdate);
                        break;
                    case "balanceUpdate":
                        var BalanceUpdate = JsonConvert.DeserializeObject<BalanceUpdate>(e.Data);
                        BalanceUpdateMessageHandler(BalanceUpdate);
                        break;
                    case "executionReport":
                        var OrderUpdate = JsonConvert.DeserializeObject<OrderUpdate>(e.Data);
                        OrderUpdateMessageHandler(OrderUpdate);
                        break;
                }
            };

            ws.OnError += (sender, e) =>
            {
                _socketList.Remove(ws);
            };

            ws.OnClose += (sender, e) =>
            {
                _socketList.Remove(ws);
            };

            ws.Connect();
            _socketList.Add(ws);
        }
    }
}
