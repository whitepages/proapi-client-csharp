using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Queries;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.QueryEncoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="TQ">The specific type of WhereQuery object to use</typeparam>
	[TestClass]
	public class WhereQueryToProApi20UriEncoderTests<TQ> : QueryToProApi20UriEncoderTests<TQ> where TQ: WhereQuery
	{
		private static string _streetLine1 = "76 Totter's Lane";
		private static string _streetLine1Encoded = "76+Totter%27s+Lane";
		private static string _streetLine2 = "Ste 2";
		private static string _streetLine2Encoded = "Ste+2";
		private static string _city = "Sebastopol";
		private static string _stateCode = "CA";
		private static string _postalCode = "95472";
		private static string _countryCode = "USA";

		private static string _latitude = "47.7233526";
		private static string _latitudeEncoded = "47.723353";
		private static string _longitude = "-122.1943964";
		private static string _longitudeEncoded = "-122.194396";
		private static string _radius = "1";
		private static string _radiusEncoded = "1.000000";

		[TestMethod]
		public void StreetLine1Parameter()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsTrue(uri.Query.Contains("street_line_1=" + _streetLine1Encoded));
		}

		[TestMethod]
		public void StreetLine2Parameter()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsTrue(uri.Query.Contains("street_line_2=" + _streetLine2Encoded));
		}

		[TestMethod]
		public void CityParameter()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsTrue(uri.Query.Contains("city=" + _city));
		}

		[TestMethod]
		public void StateCodeParameter()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsTrue(uri.Query.Contains("state_code=" + _stateCode));
		}

		[TestMethod]
		public void PostalCodeParameter()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsTrue(uri.Query.Contains("postal_code=" + _postalCode));
		}

		[TestMethod]
		public void NoNearbyParametersOnLocation()
		{
			var uri = Encoder.Encode(DefaultLocationQuery, Client);
			Assert.IsFalse(uri.Query.Contains("lat"));
			Assert.IsFalse(uri.Query.Contains("long"));
			Assert.IsFalse(uri.Query.Contains("radius"));
		}

		[TestMethod]
		public void LatitudeParameter()
		{
			var uri = Encoder.Encode(DefaultNearbyQuery, Client);
			Assert.IsTrue(uri.Query.Contains("lat=" + _latitudeEncoded));
		}

		[TestMethod]
		public void LongitudeParameter()
		{
			var uri = Encoder.Encode(DefaultNearbyQuery, Client);
			Assert.IsTrue(uri.Query.Contains("lon=" + _longitudeEncoded));
		}

		[TestMethod]
		public void RadiusParameter()
		{
			var uri = Encoder.Encode(DefaultNearbyQuery, Client);
			Assert.IsTrue(uri.Query.Contains("radius=" + _radiusEncoded));
		}

		[TestMethod]
		public void NoLocationParametersOnNearby()
		{
			var uri = Encoder.Encode(DefaultNearbyQuery, Client);
			Assert.IsFalse(uri.Query.Contains("street_line_1"));
			Assert.IsFalse(uri.Query.Contains("street_line_2"));
			Assert.IsFalse(uri.Query.Contains("city"));
			Assert.IsFalse(uri.Query.Contains("state_code"));
			Assert.IsFalse(uri.Query.Contains("postal_code"));
			Assert.IsFalse(uri.Query.Contains("country_code"));

		}

		private TQ DefaultLocationQuery
		{
			get
			{
				var query = DefaultQuery;
				query.StreetLine1 = _streetLine1;
				query.StreetLine2 = _streetLine2;
				query.City = _city;
				query.StateCode = _stateCode;
				query.PostalCode = _postalCode;
				query.CountryCode = _countryCode;
				return query;
			}
		}


		private TQ DefaultNearbyQuery
		{
			get
			{
				var query = DefaultQuery;
				query.Latitude = double.Parse(_latitude);
				query.Longitude = double.Parse(_longitude);
				query.Radius = double.Parse(_radius);
				return query;
			}
		}
	}
}
