using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Binance_Spot_API.Utils
{
    public class Signature
    {
        /// <summary>
        /// SIGNED endpoints require an additional parameter, signature, to be sent in the query string or request body.
        /// Endpoints use HMAC SHA256 signatures.The HMAC SHA256 signature is a keyed HMAC SHA256 operation.
        /// The signature is not case sensitive.
        /// </summary>
        /// <param name="secretKey">Use your secretKey as the key and totalParams as the value for the HMAC operation.</param>
        /// <param name="totalParams">totalParams is defined as the query string concatenated with the request body.</param>
        /// <returns></returns>
        public static string Generate(string secretKey, string totalParams)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            var paramBytes = Encoding.UTF8.GetBytes(totalParams);
            var secretHash = new HMACSHA256(secretBytes);
            var paramHash = secretHash.ComputeHash(paramBytes);

            return BitConverter.ToString(paramHash).Replace("-", "").ToLower();
        }
    }
}
