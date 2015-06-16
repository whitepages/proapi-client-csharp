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
	public class BusinessLookupTest : EntityLookupTest<IBusiness>
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
		public void ResultShouldContainBusinessName()
		{
			var found = this.Response.Results.Any(x => x.Name.Contains("Whitepages"));
			Assert.IsTrue(found, "Should find business name in results");
		}

		
		protected override Response<IBusiness> PerformQuery()
		{
			return Client.FindBusinesses(this.Query);
		}

		protected BusinessQuery Query
		{
			get
			{
				var q = new BusinessQuery("Whitepages") { City = "Seattle", StateCode = "WA" };
				return q;
			}
		}
	}
}
