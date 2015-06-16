using System.Runtime.Serialization;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class LatLong
	{
		private double _latitude;
		private double _longitude;
		private GeoAccuracy _geoAccuracy;

		public LatLong(double latitude, double longitude, GeoAccuracy geoAccuracy = GeoAccuracy.Unknown)
		{
			_latitude = latitude;
			_longitude = longitude;
			_geoAccuracy = geoAccuracy;
		}
		
		public double Latitude
		{
			get { return _latitude; }
			set { _latitude = value; }
		}

		public double Longitude
		{
			get { return _longitude; }
			set { _longitude = value; }
		}

		public GeoAccuracy GeoAccuracy
		{
			get { return _geoAccuracy; }
			set { _geoAccuracy = value; }
		}

		public override string ToString()
		{
			return "LatLong{" 
				+ "latitude=" + _latitude
				+ ", longitude=" + _longitude 
				+ ", geoAccuracy=" + _geoAccuracy.ToString() 
				+ "}";
        
		}
	}
}
