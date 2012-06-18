using System;

namespace DarkSky
{	
	public struct Position : IEquatable<Position>
	{
		public double Latitude;
		public double Longitude;
		
		public double VectorDistanceFromSquared(ref Position other)
		{
			double lat = this.Latitude - other.Latitude;
			double lon = this.Longitude - other.Longitude;
			return (lat * lat) * (lon * lon);
		}
		
		public double VectorDistanceFrom(ref Position other)
		{
			return Math.Sqrt(this.VectorDistanceFromSquared(ref other));
		}
		
		public static double Lerp(double value1, double value2, double amount)
		{
			return value1 + (value2 - value1) * amount;
		}
		
		public Position Interpolate(Position other, double amount)
		{
			return new Position
			{
				Latitude = Lerp(this.Latitude, other.Latitude, amount),
				Longitude = Lerp(this.Longitude, other.Longitude, amount)
			};
		}
		
		#region Object overrides
		
		public override bool Equals (object obj)
		{
			if (obj == null || typeof(Position) != obj.GetType()) return false;
			
			return this.Equals ((Position)obj);
		}
		
		public bool Equals(Position other)
		{
			return this.Longitude == other.Longitude && this.Latitude == other.Latitude;
		}
		
		public override int GetHashCode ()
		{
			return this.Longitude.GetHashCode () ^ this.Latitude.GetHashCode();
		}
		
		public override string ToString ()
		{
			return string.Format ("{0},{1}", this.Latitude, this.Longitude);
		}
		
		#endregion
	}
}

