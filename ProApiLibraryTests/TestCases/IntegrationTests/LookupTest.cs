using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="T">The type of entity you are querying</typeparam>
	public abstract class LookupTest<T> where T: IEntity
	{
		private Response<T> _response;
		private FindException _error;
		private bool _performedQuery = false;

		protected abstract Response<T> PerformQuery();
		protected Response<T> Response
		{
			get
			{
				this.EnsureResponse();
				if (_error != null)
				{
					throw _error;
				}
				return _response;

			}
		}

		protected FindException Error
		{
			get
			{
				this.EnsureResponse();
				return _error;
			}
		}

		private void EnsureResponse()
		{
			if (!_performedQuery)
			{
				try
				{
					_response = PerformQuery();
				}
				catch (FindException e)
				{
					_error = e;
				}
				_performedQuery = true;
			}
		}
	}
}
