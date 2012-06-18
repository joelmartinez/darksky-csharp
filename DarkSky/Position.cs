using System;

namespace DarkSky
{	
	public struct Position : IEquatable<Position>
	{
		public double Latitude;
		public double Longitude;
		
		public float VectorDistanceFromSquared(ref Position other)
		{
			double lat = this.Latitude - other.Latitude;
			double lon = this.Longitude - other.Longitude;
			return (lat * lat) * (lon * lon);
		}
		
		public float VectorDistanceFrom(ref Position other)
		{
			return Math.Sqrt(this.VectorDistanceFromSquared(ref other));
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

