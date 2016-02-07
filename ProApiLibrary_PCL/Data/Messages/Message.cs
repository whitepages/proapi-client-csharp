using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Responses;

namespace ProApiLibrary.Data.Messages
{
	/// <summary>
	/// Messages are generated as a result of requests to the API and contain both
	/// a message body and meta data about that message
	/// </summary>
	/// <remarks>
	/// 
	/// <p>Messages are found on the <seealso cref="Response{T}"/>
	/// via the GetResponseMessages() accessor method.</p>
	/// 
	/// <p>Messages have a number of meta-data properties, including:</p>
	/// <ul>
	///     <li>Severity: the severity of the message,</li>
	///     <li>Type: the machine readable categorization of the message,,</li>
	///     <li>Code: An optional machine readable sub-categorization coding of the message, and</li>
	///     <li>Ancillary Data: An optional weakly-typed Map of data specific to the message.</li>
	/// </ul>
	/// 
	/// <seealso cref="Response{T}"/>
	/// <seealso cref="Response{T}"/>Messages
	/// </remarks>
	[DataContract]
	public class Message
	{
		public enum MessageSeverity
		{
			Error,
			Warning,
			Info,
			Debug
		}

		public enum MessageType
		{
			Unknown,
			Internal,
			Timeout,
			Debug,
			Auth,
			QuotaExceeded,
			Input,
			InputField,
			InvalidParameters,
			MissingField,
			EntityIdParse,
			EntityIdTypeMismatch,
			NonDurableEntityIdLookup
		}

		public enum MessageCode
		{
			Unknown,
			InvalidInput,
			TooShortInput,
			MissingInput,
			MissingData
		}

		private MessageSeverity _severity;
		private MessageType _messageType;
		private MessageCode? _code;
		private string _text;
		private Dictionary<string, object> _ancillaryData;

		internal Message()
		{
			// for deserialization purposes	
		}
		
		public Message(MessageSeverity messageSeverity, MessageType messageType, MessageCode? messageCode, string text)
			: this(messageSeverity, messageType, messageCode, text, new Dictionary<string, object>())
		{

		}

		public Message(MessageSeverity severity, MessageType messageType, MessageCode? code, string text,
					   Dictionary<string, object> ancillaryData)
		{
			_severity = severity;
			_messageType = messageType;
			_code = code;
			_text = text;
			_ancillaryData = ancillaryData;
		}
		
		public MessageSeverity Severity
		{
			get { return _severity; }
			set { _severity = value; }
		}

		public MessageType Type
		{
			get { return _messageType; }
			set { _messageType = value; }
		}

		public MessageCode? Code
		{
			get { return _code; }
			set { _code = value; }
		}

		[DataMember(Name="message")]
		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}

		[DataMember(Name="ancillary_data")]
		public Dictionary<string, object> AncillaryData
		{
			get { return _ancillaryData; }
			set { _ancillaryData = value; }
		}
	}
}
