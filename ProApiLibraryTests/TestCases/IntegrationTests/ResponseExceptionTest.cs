using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="T">The type of entity you are querying</typeparam>
	[TestClass]
	public abstract class ResponseExceptionTest<T> : LookupTest<T> where T: IEntity
	{
		protected abstract Type ExpectedExceptionType { get; }
		protected override abstract Response<T> PerformQuery();
	}
}
