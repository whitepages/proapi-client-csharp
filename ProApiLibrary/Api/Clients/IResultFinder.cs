using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// IResultFinder instances link together the datafolow of the conversion of an IQuery to an Response{T}
	/// </summary>
	/// <remarks>
	/// <seealso cref="ResultFinder{TE,TQ,TD,TU}"/> instances link
	/// together the dataflow of the conversion of a
	/// <seealso cref="IQuery"/> to a
	/// <seealso cref="Response{T}"/> via the following steps:
	/// <ol>
	///     <li>The <seealso cref="IQuery"/> is transformed to an intermediate form via a <seealso cref="IQueryEncoder"/>,</li>
	///     <li>The intermediate form is used to fetch the raw response from the data source via a <seealso cref="IDataSource"/>, and</li>
	///     <li>The raw response is transformed into a normalized <seealso cref="Response{T}"/> via a <seealso cref="IResponseDecoder"/></li>
	/// </ol>
	/// 
	/// <seealso cref="IResultFinder"/>
	/// <seealso cref="IResultFinder"/>Impl
	/// <seealso cref="IQueryEncoder"/>
	/// <seealso cref="IDataSource"/>
	/// <seealso cref="IResponseDecoder"/>
	/// <seealso cref="Response{T}"/>
	/// </remarks>
	/// <typeparam name="TE"></typeparam>
	/// <typeparam name="TQ"></typeparam>
	public interface IResultFinder<TE, in TQ>
		where TE : IEntity
		where TQ : EntityQuery
	{
		/// <summary>
		/// Executes the given Query, returning a Response
		/// </summary>
		/// <param name="query">The query to perform</param>
		/// <param name="client">The client object to use</param>
		/// <returns>The Response object</returns>
		Response<TE> Find(TQ query, Client client);
	}
}
