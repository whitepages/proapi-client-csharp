using System.Collections.Generic;
using System.Linq;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibrary.Api.Responses
{
	/// <summary>
	/// The Response is the root object for data returned from queries performed
	/// via the <seealso cref="Client"/> find methods
	/// </summary>
	/// <remarks>
	/// <![CDATA[
	/// <p>The key properties of a Response are:</p>
	/// <ul>
	///     <li>The results (via this.Results): The list of the <seealso cref="IEntity"/> instances found for the corresponding query,</li>
	///     <li>The response messages (via GetResponseMessage()): A collection of <seealso cref="Message"/> instances pertaining to the response; these may include error conditions.</li>
	/// </ul>
	/// 
	/// <p>Response success can be determined via the this.IsSuccess and this.IsFailure
	/// accessors. In the event of a failure response, the cause of the failure is
	/// recorded in the response messages.</p>
	/// 
	/// <seealso cref="Client"/>
	/// ]]>
	/// </remarks>
	/// <typeparam name="T"></typeparam>
	public class Response<T> where T : IEntity
	{
		private readonly List<T> _results;
		private readonly ResponseDictionary _dictionary;
		private ResponseMessages _messages;
		private readonly Client _client;

		protected Response()
		{

		}

		public Response(Client client, List<T> results, ResponseDictionary dictionary, ResponseMessages messages)
		{
			_client = client;
			_results = results;
			_dictionary = dictionary;
			_messages = messages;
		}

		/// <summary>
		/// Gets the list of resulting <seealso cref="IEntity"/> instances found
		/// </summary>
		/// <returns>The list of results</returns>
		public virtual List<T> Results
		{
			get { return _results; }
		}

		public ResponseDictionary ResponseDictionary
		{
			get { return _dictionary; }
		}

		/// <summary>
		/// Returns the collection of <seealso cref="Message"/> instances for this response
		/// </summary>
		/// <remarks>
		/// Messages include errors and warnings encountered during execution of the
		/// query.
		/// 
		/// @return The response messages.
		/// <seealso cref="Response{T}"/>Messages
		/// <seealso cref="Message"/>
		/// </remarks>
		public ResponseMessages ResponseMessages
		{
			get { return _messages; }
			set { _messages = value; }
		}

		/// <summary>
		/// Returns the <seealso cref="Client"/> instance used to execute the query that generated this 
		/// response. This allows follow-up requests with the same configuration
		/// </summary>
		/// <remarks>
		/// <seealso cref="Client"/>
		/// </remarks>
		/// <returns>The client used to execute this query</returns>
		public Client Client
		{
			get { return _client; }
		}

		/// <summary>
		/// Returns True if this query succeeded
		/// </summary>
		public bool IsSuccess
		{
			get { return !_messages.GetMessageList(Message.MessageSeverity.Error).Any(); }
		}

		/// <summary>
		/// Returns True if this query failed
		/// </summary>
		public bool IsFailure
		{
			get { return !IsSuccess; }
		}

	}
}
