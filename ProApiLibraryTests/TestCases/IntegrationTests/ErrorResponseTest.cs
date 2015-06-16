using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="T">The type of entity you are querying</typeparam>
	public abstract class ErrorResponseTest<T> : LookupTest<T> where T: IEntity
	{
		protected abstract Message.MessageType ExpectedMessageType { get; }
		protected abstract override ProApiLibrary.Api.Responses.Response<T> PerformQuery();

		


	}
}
