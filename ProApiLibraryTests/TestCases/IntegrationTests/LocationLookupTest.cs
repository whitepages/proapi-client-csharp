using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class LocationLookupTest : EntityLookupTest<ILocation>
	{
		[TestMethod]
		public void ResultShouldNotBeEmpty()
		{
			Assert.IsTrue(this.Response.Results.Any(), "Should contain results");
		}

		[TestMethod]
		public void SuccessShouldBeTrue()
		{
			Assert.IsTrue(this.Response.IsSuccess, "Should be successful");
		}

		[TestMethod]
		public void ResultShouldHaveNoErrorMessage()
		{
			Assert.IsFalse(this.Response.ResponseMessages.GetMessageList(Message.MessageSeverity.Error).Any(), "Should have no Error Messages");
		}

		[TestMethod]
		public void ResultShouldContainStreetNumber()
		{
			var found = this.Response.Results.Any(x => x.Name.Contains("1301"));
			Assert.IsTrue(found, "Should find street number in results");
		}

		[TestMethod]
		public void ResultShouldContainPhoneNumber()
		{
			var found = this.Response.Results.First();
			var business = found.Businesses.First();
			var phone = business.Phones.First();
			var expected = "2065057500";
			Assert.AreEqual(expected, phone.PhoneNumber, "Phone should be present");
		}

		protected override Response<ILocation> PerformQuery()
		{
			return Client.FindLocations(this.Query);
		}

		protected LocationQuery Query
		{
			get
			{
				var q = new LocationQuery("1301 5th Ave", "Ste 1600", "Seattle", "WA", null);
				return q;
			}
		}
	}
}
