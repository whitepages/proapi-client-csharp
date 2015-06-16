using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Data sources act as brokers of information, fetching a response of one
	/// type, using a request of another type. For example, a data source may
	/// take a URI instance, call the associated external web service, and return
	/// an InputStream containing the response body.
	/// </summary>
	/// <remarks>
	/// <p>DataSource is part of the ResultFinder pipeline.
	///  <seealso cref="IResultFinder{TE, TQ}"/> instances link
	///  together the dataflow of the conversion of a
	///  <seealso cref="IQuery" /> to a
	///  <seealso cref="Response{T}"/></p>
	///  <ol>
	///      <li>The <seealso cref="IQuery"/> is transformed to an intermediate form via a <seealso cref="IQueryEncoder"/>,</li>
	///      <li>The intermediate form is used to fetch the raw response from the data source via a <seealso cref="IDataSource"/>, and</li>
	///      <li>The raw response is transformed into a normalized <seealso cref="Response{T}"/> via a <seealso cref="IResponseDecoder"/></li>
	///  </ol>
	/// 
	///  <seealso cref="IResultFinder"/>
	///  <seealso cref="ResultFinder"/>
	///  <seealso cref="IQueryEncoder"/>
	///  <seealso cref="IDataSource"/>
	///  <seealso cref="IResponseDecoder"/>
	///  <seealso cref="Response{T}"/>
	/// </remarks>
	/// <typeparam name="TD"></typeparam>
	/// <typeparam name="TQ"></typeparam>
	public interface IDataSource<out TD, in TQ> where TD : IData
	{
		/// <summary>
		/// Transforms the query intermediate form into a raw result
		/// </summary>
		/// <param name="intermediateForm">The query intermediate form</param>
		/// <param name="client">The client performing the request</param>
		/// <returns>The raw result</returns>
		TD Execute(TQ intermediateForm, Client client);
	}
}
