using System;
using System.Runtime.Serialization;
using Epoch.Extensions;

namespace DarkSky
{
	[DataContract]
	public class HourPrecipitation
	{
		[DataMember(Name="time")]
	    public int UnixTime { get; set; }
		
		public DateTime Time { get { return this.UnixTime.FromUnix(); } }
	    
		[DataMember(Name="probability")]
		public double Probability { get; set; }
		
		[DataMember(Name="intensity")]
	    public double Intensity { get; set; }
		
		[DataMember(Name="error")]
	    public double Error { get; set; }
		
		[DataMember(Name="type")]
	    public string PrecipitationType { get; set; }
		
		
	}
	
	[DataContract]
	public class DayPrecipitation
	{
		[DataMember(Name="time")]
	    public int UnixTime { get; set; }
		
		public DateTime Time { get { return this.UnixTime.FromUnix(); } }
	    
		[DataMember(Name="probability")]
		public double Probability { get; set; }
		
		[DataMember(Name="type")]
	    public string PrecipitationType { get; set; }
		
		[DataMember(Name="temp")]
	    public int Temperature { get; set; }
	}
	
	[DataContract]
	public class Forecast
	{
		[DataMember(Name="isPrecipitating")]
	    public bool IsPrecipitating { get; set; }
		
		[DataMember(Name="minutesUntilChange")]
	    public int MinutesUntilChange { get; set; }
		
		public TimeSpan TimeUntilChange { get { return new TimeSpan(0, this.MinutesUntilChange, 0); } }
		
		[DataMember(Name="currentSummary")]
	    public string CurrentSummary { get; set; }
		
		[DataMember(Name="hourSummary")]
	    public string HourSummary { get; set; }
		
		[DataMember(Name="currentTemp")]
	    public int CurrentTemperature { get; set; }
		
		[DataMember(Name="checkTimeout")]
	    public int CheckTimeout { get; set; }
	}
	
	[DataContract]
	public class FullForecast : Forecast
	{
		[DataMember(Name="timezone")]
	    public string TimeZone { get; set; }
		
		[DataMember(Name="radarStation")]
	    public string RadarStation { get; set; }
		
		[DataMember(Name="hourPrecipitation")]
	    public HourPrecipitation[] HourPrecipitation { get; set; }
		
		[DataMember(Name="dayPrecipitation")]
	    public DayPrecipitation[] DayPrecipitation { get; set; }
	}

	[DataContract]
	public class PrecipitationRoot
	{
		[DataMember(Name="precipitation")]
		public HourPrecipitation[] Precipitation {get;set;}
	}
	
	[DataContract]
	public class InterestingStormRoot
	{
		[DataMember(Name="storms")]
		public InterestingStorm[] Storms {get;set;}
	}
	
	[DataContract]
	public class InterestingStorm
	{
		[DataMember(Name="radarStation")]
		public string RadarStation {get;set;}
		
		[DataMember(Name="intensity")]
		public string Intensity {get;set;}
		
		[DataMember(Name="city")]
		public string City {get;set;}
		
		[DataMember(Name="latitude")]
		public double Latitude {get;set;}
		
		[DataMember(Name="longitude")]
		public double Longitude {get;set;}
		
		public Position Position
		{
			get { return new Position { Latitude = this.Latitude, Longitude = this.Longitude }; }
		}
	}
	
}