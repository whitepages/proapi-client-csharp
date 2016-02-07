using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Response decoders transform the raw response data from a compatible
	/// DataSource instance, and return a standardized Response. For example, they
	/// may take an InputStream of JSON and parse it into native data objects
	/// </summary>
	/// <remarks>
	/// <p>ResponseDecoder is part of the ResultFinder pipeline.
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
	/// <seealso cref="IResultFinder"/>Impl
	/// <seealso cref="IQueryEncoder"/>
	/// <seealso cref="IDataSource"/>
	/// <seealso cref="Response{T}"/>
	/// </remarks>
	/// <typeparam name="TE">The type of entity you are decoding to.</typeparam>
	/// <typeparam name="TV">The raw response from an <seealso cref="IDataSource{TD,TQ}"/> instance</typeparam>
	public interface IResponseDecoder<TE, in TV>
		where TE : IEntity
	{
		Response<TE> Decode(TV responseData, Client client);
	}
}
