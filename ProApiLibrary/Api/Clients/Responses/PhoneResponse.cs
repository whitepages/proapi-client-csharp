using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients.Responses
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class PhoneResponse
	{
		private IDictionary<string, BaseEntity> _serializedDictionary;
		private ResponseMessages _messages;

		[DataMember(IsRequired = false, Name = "results")]
		public string[] ResultKeys { get; set; }

		[DataMember(IsRequired=false,Name="dictionary")]
		internal IDictionary<string, BaseEntity> Dictionary
		{
			get { return _serializedDictionary ?? (_serializedDictionary = new Dictionary<string, BaseEntity>()); }
			set { _serializedDictionary = value; }
		}


		[DataMember(Name="messages")]
		public ResponseMessages ResponseMessages
		{
			get { return _messages; }
			set { _messages = value; }
		}

	}
}
