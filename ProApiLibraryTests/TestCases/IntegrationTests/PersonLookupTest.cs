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
	public class PersonLookupTest : EntityLookupTest<IPerson>
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
		public void ResultShouldContainJohnSmith()
		{
			var found = this.Response.Results.Any(x => x.Name.Contains("John") && x.Name.Contains("Smith"));
			Assert.IsTrue(found, "Should find John Smith in results");
		}

		[TestMethod]
		public void ReadmeExample()
		{
			var client = new Client(ClientIntegrationTestHelper.ApiKey);
			var personQuery = new PersonQuery("Rory", null, "Williams", null, "WA", null);
			var response = client.FindPeople(personQuery);
			
			if (response != null && response.IsSuccess)
			{
				foreach (var p in response.Results)
				{
					System.Console.Out.WriteLine(p.BestName);
				}
			}
		}

		protected override Response<IPerson> PerformQuery()
		{
			return Client.FindPeople(this.Query);
		}

		protected PersonQuery Query
		{
			get
			{
				var q = new PersonQuery("John", null, "Smith", null, null, "98101");
				return q;
			}
		}
	}
}
