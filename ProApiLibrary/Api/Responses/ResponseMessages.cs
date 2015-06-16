using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProApiLibrary.Data.Messages;

namespace ProApiLibrary.Api.Responses
{
	/// <summary>
	/// Encapsulates a list of <seealso cref="Message"/> instances in order to provide methods
	/// for common operations.
	/// </summary>
	/// <seealso cref="Response{T}"/>
	/// <seealso cref="Message"/>
	public class ResponseMessages : IEnumerable<Message>
	{
		private readonly IEnumerable<Message> _messages;

		public ResponseMessages(IEnumerable<Message> messages)
		{
			_messages = messages;
		}

		/// <summary>
		/// Accessor for retrieving the list of messages
		/// </summary>
		/// <remarks>
		/// One should prefer using methods on the ResponseMessages object,
		/// when availabile. For example, rather than calling
		/// 
		/// <code>response.getResponseMessages().getMessageList().get(0)</code>
		/// 
		/// one should call
		/// 
		/// <code>response.getResponseMessages().get(0)</code> instead.
		/// </remarks>
		/// <returns>The messages in this collection as an IEnumerable{Message}</returns>
		/// <param name="severity"></param>
		/// <returns></returns>
		public IEnumerable<Message> GetMessageList(Message.MessageSeverity severity)
		{
			return _messages.Where(x => x.Severity == severity);
		}

		public IEnumerator<Message> GetEnumerator()
		{
			foreach (var m in _messages)
			{
				yield return m;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
