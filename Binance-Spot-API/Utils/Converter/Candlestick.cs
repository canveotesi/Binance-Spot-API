using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Binance_Spot_API.Utils.Converter
{
    public class Candlestick : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var candles = JArray.Load(reader);
            
            return new Model.Market.Candlestick { 
                OpenTime = candles.ElementAt(0).ToObject<long>(), 
                Open = candles.ElementAt(1).ToObject<double>(), 
                High = candles.ElementAt(2).ToObject<double>(), 
                Low = candles.ElementAt(3).ToObject<double>(), 
                Close = candles.ElementAt(4).ToObject<double>(), 
                Volume = candles.ElementAt(5).ToObject<double>(), 
                CloseTime = candles.ElementAt(6).ToObject<long>(), 
                QuoteAssetVolume = candles.ElementAt(7).ToObject<double>(), 
                NumberOfTrade = candles.ElementAt(8).ToObject<int>(), 
                TakerBuyBaseAssetVolume = candles.ElementAt(9).ToObject<double>(), 
                TakerBuyQuoteAssetVolume = candles.ElementAt(10).ToObject<double>()
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var candlestick = value as Model.Market.Candlestick;
            writer.WriteStartObject();
            writer.WritePropertyName("OpenTime");
            serializer.Serialize(writer, candlestick.OpenTime);
            writer.WritePropertyName("Open");
            serializer.Serialize(writer, candlestick.Open);
            writer.WritePropertyName("High");
            serializer.Serialize(writer, candlestick.High);
            writer.WritePropertyName("Low");
            serializer.Serialize(writer, candlestick.Low);
            writer.WritePropertyName("Close");
            serializer.Serialize(writer, candlestick.Close);
            writer.WritePropertyName("Volume");
            serializer.Serialize(writer, candlestick.Volume);
            writer.WritePropertyName("CloseTime");
            serializer.Serialize(writer, candlestick.CloseTime);
            writer.WritePropertyName("QuoteAssetVolume");
            serializer.Serialize(writer, candlestick.QuoteAssetVolume);
            writer.WritePropertyName("NumberOfTrade");
            serializer.Serialize(writer, candlestick.NumberOfTrade);
            writer.WritePropertyName("TakerBuyBaseAssetVolume");
            serializer.Serialize(writer, candlestick.TakerBuyBaseAssetVolume);
            writer.WritePropertyName("TakerBuyQuoteAssetVolume");
            serializer.Serialize(writer, candlestick.TakerBuyQuoteAssetVolume);
            writer.WriteEndObject();
        }
    }
}
