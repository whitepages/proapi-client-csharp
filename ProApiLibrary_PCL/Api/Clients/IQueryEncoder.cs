using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Query coders serve to transform/translate a Query into an intermediate
	/// form that is compatible with the DataSource. For example, one may change
	/// the query into a URI for later execution against an external web service.
	/// </summary>
	/// <remarks>
	/// <p>QueryCoder is part of the ResultFinder pipeline.
	/// <seealso cref="IResultFinder"/> instances link
	/// together the dataflow of the conversion of a
	/// <seealso cref="IQuery"/> to a
	/// <seealso cref="Response{T}"/> via the following steps:</p>
	/// <ol>
	///     <li>The <seealso cref="IQuery"/> is transformed to an intermediate form via a <seealso cref="IQueryEncoder"/>,</li>
	///     <li>The intermediate form is used to fetch the raw response from the data source via a <seealso cref="IDataSource"/>, and</li>
	///     <li>The raw response is transformed into a normalized <seealso cref="Response{T}"/> via a <seealso cref="IResponseDecoder"/></li>
	/// </ol>
	/// 
	/// <seealso cref="IResultFinder"/>
	/// <seealso cref="ResultFinder"/>
	/// <seealso cref="IQueryEncoder"/>
	/// <seealso cref="IDataSource"/>
	/// <seealso cref="IResponseDecoder"/>
	/// <seealso cref="Response{T}"/>
	/// </remarks>
	/// <typeparam name="TQ">The query type to encode</typeparam>
	/// <typeparam name="TU">The type of the query intermediate form</typeparam>
	public interface IQueryEncoder<in TQ, out TU> where TQ : IQuery
	{
		/// <summary>
		/// Transforms the query to an intermediate form
		/// </summary>
		/// <param name="query">The query</param>
		/// <param name="client">The client performing the query</param>
		/// <returns>The query intermediate form</returns>
		TU Encode(TQ query, Client client);
	}
}
