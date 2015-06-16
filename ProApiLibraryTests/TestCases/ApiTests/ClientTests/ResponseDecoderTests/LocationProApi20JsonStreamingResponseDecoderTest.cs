using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.ResponseDecoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class LocationProApi20JsonStreamingResponseDecoderTest
	{
		private static Response<ILocation> _response;
		private static ILocation _location;

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			_response = (new ResponseDecoderHelper()).LocationResponse;
			_location = _response.Results.First();
		}

		[TestMethod]
		public void HasResults()
		{
			Assert.AreEqual(1, _response.Results.Count());
		}

		[TestMethod]
		public void HasAddress()
		{
			Assert.AreEqual("1301 5th Ave Ste 1600, Seattle WA 98101-2625", _location.Address);
		}

		[TestMethod]
		public void HasNoLocationAssociations()
		{
			Assert.IsNull(_location.LocationAssociations);
		}

		[TestMethod]
		public void HasNoPeopleAssociations()
		{
			Assert.IsNull(_location.PersonAssociations);
		}

		[TestMethod]
		public void HasNoBusinessAssociations()
		{
			Assert.IsNull(_location.BusinessAssociations);
		}

		[TestMethod]
		public void HasNoPhoneAssociations()
		{
			Assert.IsNull(_location.PhoneAssociations);
		}

		[TestMethod]
		public void HasDeliverable()
		{
			Assert.IsTrue(_location.IsDeliverable.Value);
		}

		[TestMethod]
		public void HasDeliveryPoint()
		{
			Assert.AreEqual(Location.LocationDeliveryPoint.MultiUnit, _location.DeliveryPoint);
		}

		[TestMethod]
		public void HasLatitude()
		{
			Assert.AreEqual(47.608624, _location.LatLong.Latitude, 0.000001);
		}

		[TestMethod]
		public void HasLongitude()
		{
			Assert.AreEqual(-122.334442, _location.LatLong.Longitude, 0.000001);
		}

		[TestMethod]
		public void HasGeoAccuracy()
		{
			Assert.AreEqual(GeoAccuracy.Rooftop, _location.LatLong.GeoAccuracy);
		}

	}
}
