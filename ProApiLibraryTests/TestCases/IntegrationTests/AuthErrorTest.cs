using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class AuthErrorTest : ResponseExceptionTest<IPerson>
	{
		[TestMethod]
		public void ExpectedErrorShouldBeThrown()
		{
			Assert.IsInstanceOfType(this.Error, this.ExpectedExceptionType);
		}

		protected override Response<IPerson> PerformQuery()
		{
			var client = new Client("ffffffffff");
			var personQuery = new PersonQuery("John", null, "Smith", null, null, "98101");
			return client.FindPeople(personQuery);
		}

		protected override Type ExpectedExceptionType
		{
			get { return typeof (AuthException); }
		}
	}
}
