using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DarkSky
{
	public class Api
	{
		string apikey;
		
		public Api(string key)
		{
			this.apikey = key;
		}
		
		public Task<FullForecast> Forecast(Position position)
		{
			//https://api.darkskyapp.com/v1/forecast/APIKEY/LAT,LON
			string url = "https://api.darkskyapp.com/v1/forecast/{0}/{1},{2}";
			url = string.Format(url, apikey, position.Latitude, position.Longitude);
				
			return WebHelper.Json<FullForecast>(url);
		}
		
		public Task<Forecast> BriefForecast(Position position)
		{
			//https://api.darkskyapp.com/v1/brief_forecast/APIKEY/LAT,LON
			string url = "https://api.darkskyapp.com/v1/forecast/{0}/{1},{2}";
			url = string.Format(url, apikey, position.Latitude, position.Longitude);
				
			return WebHelper.Json<Forecast>(url);
		}
		
		public Task<HourPrecipitation[]> Precipitation(params TimePosition[] values)
		{
			//https://api.darkskyapp.com/v1/precipitation/APIKEY/LAT1,LON1,TIME1;LAT2,LON2,TIME2;...
			string url = "https://api.darkskyapp.com/v1/precipitation/{0}/{1}";
			
			var stringLocations = values.Select(v => v.ToString()).ToArray();
			string locations = string.Join(";", stringLocations);
			
			url = string.Format(url, apikey, locations);
			
			return WebHelper.Json<PrecipitationRoot>(url)
				.ContinueWith<HourPrecipitation[]>(response => response.Result.Precipitation);
		}
		
		public Task<InterestingStorm[]> InterestingStorms()
		{
			//https://api.darkskyapp.com/v1/interesting/APIKEY
			string url = "https://api.darkskyapp.com/v1/interesting/{0}";
			url = string.Format(url, apikey);
			
			return WebHelper.Json<InterestingStormRoot>(url)
				.ContinueWith<InterestingStorm[]>(r => r.Result.Storms);
		}
	}
}

