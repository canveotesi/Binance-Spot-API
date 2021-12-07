using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Binance_Spot_API.Utils.Converter
{
    public class TradePrice : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var items = JArray.Load(reader);

            var tradePriceList = new List<Model.Market.TradePrice>();

            foreach(var item in items)
            {
                var price = item[0].ToObject<double>();
                var quantity = item[1].ToObject<double>();

                tradePriceList.Add(new Model.Market.TradePrice { Price = price, Quantity = quantity });
            }

            return tradePriceList;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken jToken = JToken.FromObject(value);

            jToken.WriteTo(writer); 
        }
    }
}
