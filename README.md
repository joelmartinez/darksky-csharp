darksky-chsharp
===============

C# API Wrapper for the [DarkSky API](https://developer.darkskyapp.com/). Currently supported platforms are: Windows Phone, iOS, and Android via MonoTouch/Mono for Android.

Usage is very simple:

```csharp
using DarkSky;
...
var darksky = new DarkSky.Api(YOUR_API_KEY);
var orlando  = new Position { Latitude=28.5381d, Longitude=-81.3794d };
Task<FullForecast> response = darksky.Forecast(orlando);

response.ContinueWith(forecast => DisplayText(forecast.Result.HourSummary));
// displays something like "Rain starting in 3 Min, Stopping 30 Min Later"
```

Currently supported endpoints:
 - `Forecast`, and `BriefForecast` - https://developer.darkskyapp.com/docs/forecast
 - `Precipitation` - https://developer.darkskyapp.com/docs/precipitation
 - `InterestingStorms` - https://developer.darkskyapp.com/docs/interesting

Please let me know if you have any feedback either by opening [an issue](https://github.com/joelmartinez/darksky-csharp/issues), [emailing me](mailto:joelmartinez@gmail.com), [commenting on my blog](http://codecube.net), or forking this project and submitting a pull request.
