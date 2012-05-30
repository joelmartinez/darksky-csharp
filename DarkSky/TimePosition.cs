using System;

namespace DarkSky
{
	public struct TimePosition : IEquatable<TimePosition>
	{
		public double Latitude;
		public double Longitude;
		public DateTime Time;
		
		
		public override bool Equals (object obj)
		{
			if (obj == null || typeof(TimePosition) != obj.GetType()) return false;
			
			return this.Equals ((TimePosition)obj);
		}
		
		public bool Equals(TimePosition other)
		{
			return this.Longitude == other.Longitude && this.Latitude == other.Latitude && this.Time == other.Time;
		}
		
		public override int GetHashCode ()
		{
			return this.Longitude.GetHashCode () ^ this.Latitude.GetHashCode() ^ this.Time.GetHashCode();
		}
		
		public override string ToString ()
		{
			return string.Format ("{0},{1},{2}", this.Latitude, this.Longitude, this.Time);
		}
	}
}

