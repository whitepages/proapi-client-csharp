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
	public class PhoneLookupTest : EntityLookupTest<IPhone>
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
		public void ResultShouldContainPhoneNumber()
		{
			var found = this.Response.Results.Any(x => x.PhoneNumber.Contains("2069735100"));
			Assert.IsTrue(found, "Should find phone number in results");
		}

		protected override Response<IPhone> PerformQuery()
		{
			return Client.FindPhones(this.Query);
		}

		protected PhoneQuery Query
		{
			get
			{
				var q = new PhoneQuery("2069735100");
				return q;
			}
		}
	}
}
