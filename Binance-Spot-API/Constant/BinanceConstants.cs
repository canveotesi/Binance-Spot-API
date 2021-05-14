namespace Binance_Spot_API.Constant
{
    /// <summary>
    /// General API Information.
    /// </summary>
    public class BinanceConstants
    {
        /// <summary>
        /// Binance base endpoint. 
        /// </summary>
        public static string BASE_ENDPOINT_URL = "https://api.binance.com";
        /// <summary>
        /// Binance websocket base endpoint.
        /// </summary>
        public static string WEBSOCKET_BASE_ENDPOINT_URL = "wss://stream.binance.com:9443/ws/";
        /// <summary>
        /// API-keys are passed into the Rest API via the X-MBX-APIKEY header.
        /// </summary>
        public static string API_KEY_HEADER = "X-MBX-APIKEY";
        /// <summary>
        /// If this option returns true, X-MBX-APIKEY is added as a header.
        /// </summary>
        public static bool ADD_DEFAULT_REQUEST_HEADERS = true;
        /// <summary>
        /// Binance API version.
        /// </summary>
        public static readonly string API_VERSION = "v3";
    }
}
