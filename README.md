# C# Binance-API for Spot 
Simple and understandable Binance Spot API.

## Attention (!)

When using this software, you are solely responsible and at your own risk. Please take this into consideration.

# Installation
Just download the repo and run it in Visual Studio.

# Getting Started
Login to Binance and get Api Key and Secret Key from [API manager](https://www.binance.com/tr/my/settings/api-management).

## Settings
```csharp
private static string API_KEY = "";
private static string SECRET_KEY = "";
public static Configuration config = new Configuration(API_KEY, SECRET_KEY);
public static Binance binance = new Binance(config);
```
## Some Examples

### Test Connectivity

```csharp
public void TestConnectivity()
{
    var result = binance.TestConnectivity().Result;

    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
}
```
Output:
```json
{}
```
### Get Candlestick by Symbol
```csharp
public void GetCandlesticks()
{
    var result = binance.GetCandlesticks("BTCUSDT", Model.Enum.Interval.HOUR_4).Result.ToList();
    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
}
```
Output:
```json
[
  {
    "OpenTime": 1613793600000,
    "Open": 55711.90000000,
    "High": 56144.87000000,
    "Low": 55185.98000000,
    "Close": 55207.92000000,
    "Volume": 8688.91552800,
    "CloseTime": 1613807999999,
    "QuoteAssetVolume": 484076882.16407515,
    "NumberOfTrade": 298853,
    "TakerBuyBaseAssetVolume": 4154.51253000,
    "TakerBuyQuoteAssetVolume": 231500411.70649142
  }
]
```
## License

This product is protected by [MIT License](http://opensource.org/licenses/MIT).
