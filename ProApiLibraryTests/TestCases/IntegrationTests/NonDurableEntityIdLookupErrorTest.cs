using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class NonDurableEntityIdLookupErrorTest : ErrorResponseTest<IPerson>
	{
		[TestMethod]
		public void ItShouldBeFailureResponse()
		{
			Assert.IsTrue(this.Response.IsFailure, "Should be failure response");
		}

		[TestMethod]
		public void ItShouldHaveAppropriateErrorMessage()
		{
			var messages = Response.ResponseMessages.GetMessageList(Message.MessageSeverity.Error).ToList();
			Assert.IsTrue(messages.Any(), "Should have one or more error messages");

			var expectedTypeFound = false;
			foreach (var m in messages)
			{
				if (m.Type == this.ExpectedMessageType)
				{
					expectedTypeFound = true;
					break;
				}
			}

			Assert.IsTrue(expectedTypeFound, "should find message of type " + this.ExpectedMessageType);

		}

		[TestMethod]
		public void ItShouldHaveNoResults()
		{
			Assert.AreEqual(0, this.Response.Results.Count, "Should have no results; found " + this.Response.Results.Count);
		}

		protected override ProApiLibrary.Data.Messages.Message.MessageType ExpectedMessageType
		{
			get { return Message.MessageType.NonDurableEntityIdLookup; }
		}

		protected override ProApiLibrary.Api.Responses.Response<IPerson> PerformQuery()
		{
			var client = new Client(ClientIntegrationTestHelper.ApiKey);
			var query = new PersonQuery(EntityId.FromString("Person.3a366a38-d82c-4e0d-a206-12242a881953.Ephemeral"));
			return client.FindPeople(query);
		}
	}
}
