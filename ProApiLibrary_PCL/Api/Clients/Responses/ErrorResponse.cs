using System.Runtime.Serialization;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients.Responses
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class ErrorResponse
	{
		[DataMember(Name="error")]
		public Error Error { get; set; }

	}
}
