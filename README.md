darksky-chsharp
===============

C# API Wrapper for the [DarkSky API](https://developer.darkskyapp.com/). Currently supported platforms are: Windows Phone, iOS, and Android via MonoTouch/Mono for Android.

Usage is very simple:

```csharp
var darksky = new DarkSky.Api(YOUR_API_KEY);

var orlando  = new Position { Latitude=28.5381f, Longitude=81.3794f };

Task<Forecast> response = darksky.Forecast(orlando);

response.ContinueWith(forecast => DisplayText(forecast.HourSummary));
// displays something like "Rain starting in 3 Min, Stopping 30 Min Later"
```
