using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.ResponseDecoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class PhoneProApi20JsonStreamingResponseDecoderTest
	{
		private static Response<IPhone> _response;
		private static IPhone _phone;

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			_response = (new ResponseDecoderHelper()).PhoneResponse;
			_phone = _response.Results.First();
		}

		[TestMethod]
		public void HasResults()
		{
			Assert.AreEqual(1, _response.Results.Count());
		}

		[TestMethod]
		public void HasNumber()
		{
			Assert.AreEqual("8003361327", _phone.PhoneNumber);
		}

		[TestMethod]
		public void HasLocationAssociations()
		{
			Assert.AreEqual(1, _phone.LocationAssociations.Count());
		}

		[TestMethod]
		public void HasLocations()
		{
			Assert.AreEqual(EntityId.FromString("Location.0a48926c-b02c-468e-ba80-18cc77dfa3fc.Durable"), _phone.Locations.First().Id);
		}

		[TestMethod]
		public void HasNoPeopleAssociations()
		{
			Assert.IsNull(_phone.PersonAssociations);
		}

		[TestMethod]
		public void HasNoPeople()
		{
			Assert.IsNull(_phone.People);
		}

		[TestMethod]
		public void HasBusinessAssociations()
		{
			Assert.AreEqual(1, _phone.BusinessAssociations.Count());
		}

		[TestMethod]
		public void HasBusinesses()
		{
			Assert.AreEqual(EntityId.FromString("Business.545ac847-02be-4f1c-8139-9e7b97b18003.Durable"), _phone.Businesses.First().Id);
		}

		[TestMethod]
		public void HasNoPhoneAssociations()
		{
			Assert.IsNull(_phone.PhoneAssociations);
		}

		[TestMethod]
		public void HasBestLocationAssociation()
		{
			Assert.AreEqual(EntityId.FromString("Location.0a48926c-b02c-468e-ba80-18cc77dfa3fc.Durable"), _phone.BestLocationAssociation.EntityId);
		}

		[TestMethod]
		public void HasLineType()
		{
			Assert.AreEqual(LineType.TollFree, _phone.LineType);
		}

		[TestMethod]
		public void HasDoNotCall()
		{
			Assert.IsNotNull(_phone.DoNotCall);
			Assert.IsFalse(_phone.DoNotCall.Value);
		}

		[TestMethod]
		public void HasSpamScore()
		{
			Assert.AreEqual(0, _phone.Reputation.Level);
		}

		[TestMethod]
		public void Proxy_works()
		{
			Assert.IsTrue(_phone.Locations.First().IsProxy);
			Assert.IsFalse(_phone.Locations.First().IsLoaded);
			Assert.IsInstanceOfType(_phone.Locations.First(), typeof(LocationProxy));
		}
	}
}
