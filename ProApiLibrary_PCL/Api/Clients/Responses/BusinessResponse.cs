using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibrary.Api.Clients.Responses
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class BusinessResponse
	{
		private IDictionary<string, BaseEntity> _serializedDictionary;
		private IEnumerable<Message> _messages;

		[DataMember(IsRequired = false, Name = "results")]
		public string[] ResultKeys { get; set; }

		[DataMember(IsRequired=false,Name="dictionary")]
		internal IDictionary<string, BaseEntity> Dictionary
		{
			get { return _serializedDictionary ?? (_serializedDictionary = new Dictionary<string, BaseEntity>()); }
			set { _serializedDictionary = value; }
		}

		[DataMember(Name="messages")]
		public IEnumerable<Message> ResponseMessages
		{
			get { return _messages; }
			set { _messages = value; }
		}


	}
}
