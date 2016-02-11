using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
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
			Assert.IsFalse(this.Response.ResponseMessages.Any(x=>x.Severity == Message.MessageSeverity.Error), "Should have no Error Messages");
		}

		[TestMethod]
		public void WeCaptureInvalidAreaCodeMessage()
		{
			var query = new PhoneQuery("9991117799");
			var client = new Client(ClientIntegrationTestHelper.ApiKey);
			var response = client.FindPhones(query);
			var messages = response.ResponseMessages.ToList();
			Assert.AreEqual(1, messages.Count, "Should have 1 message");
			var message = messages.First();
			var text = message.Text;
			var expected = "qiWithPhone: invalid area code";
			Assert.AreEqual(expected, text, "Incorrect message text");
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
