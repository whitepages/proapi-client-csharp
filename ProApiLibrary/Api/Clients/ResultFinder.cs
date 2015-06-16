using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// /// A standardized, generic implementation of <seealso cref="IResultFinder"/> that properly
	/// threads together the <seealso cref="IQueryEncoder"/>, <seealso cref="IDataSource"/>, and
	/// <seealso cref="IResponseDecoder"/> to execute a find request.
	/// </summary> 
	/// <remarks>
	/// <seealso cref="IResultFinder"/>
	/// </remarks>
	/// <typeparam name="TE">The entity type</typeparam>
	/// <typeparam name="TQ">The query type</typeparam>
	/// <typeparam name="TD">The type of data</typeparam>
	/// <typeparam name="TU">The intermediate form</typeparam>
	public class ResultFinder<TE, TQ, TD, TU> : IResultFinder<TE, TQ>
		where TE : IEntity
		where TQ : EntityQuery
		where TD : IData
	{
		private readonly IQueryEncoder<TQ, TU> _queryCoder;
		private readonly IDataSource<TD, TU> _dataSource;
		private readonly IResponseDecoder<TE, TD> _responseDecoder;

		public ResultFinder(IQueryEncoder<TQ, TU> queryCoder, IDataSource<TD, TU> dataSource, IResponseDecoder<TE, TD> responseDecoder)
		{
			_queryCoder = queryCoder;
			_dataSource = dataSource;
			_responseDecoder = responseDecoder;
		}

		public Response<TE> Find(TQ query, Client client)
		{
			var queryData = _queryCoder.Encode(query, client);
			var responseData = _dataSource.Execute(queryData, client);
			return _responseDecoder.Decode(responseData, client);
		}
	}
}
