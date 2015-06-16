using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="T">The type of entity you are testing</typeparam>
	[TestClass]
	public abstract class EntityLookupTest<T> : LookupTest<T> where T: IEntity
	{	
		protected override abstract Response<T> PerformQuery();

		protected static Client Client
		{
			get { return new Client(ClientIntegrationTestHelper.ApiKey); }
		}

	}
}
