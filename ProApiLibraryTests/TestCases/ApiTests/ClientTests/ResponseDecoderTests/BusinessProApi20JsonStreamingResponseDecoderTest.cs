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
	public class BusinessProApi20JsonStreamingResponseDecoderTest
	{
		private static Response<IBusiness> _response;
		private static IBusiness _business;

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			_response = (new ResponseDecoderHelper()).BusinessResponse;
			_business = _response.Results.First();
		}

		[TestMethod]
		public void HasResults()
		{
			Assert.AreEqual(4, _response.Results.Count());
		}

		[TestMethod]
		public void HasName()
		{
			Assert.AreEqual("Whitepages", _business.Name);
		}

		[TestMethod]
		public void HasLocationAssociations()
		{
			Assert.AreEqual(1, _business.LocationAssociations.Count());
		}

		[TestMethod]
		public void HasPhoneLocations()
		{
			Assert.AreEqual(3, _business.PhoneAssociations.Count());
		}

		[TestMethod]
		public void HasPersonAssociations()
		{
			Assert.IsNull(_business.PersonAssociations);
		}

	}
}
