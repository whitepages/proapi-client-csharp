using System.IO;
using Newtonsoft.Json;
using ProApiLibrary.Api.Clients.Responses;

namespace ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class ErrorResponseDecoder
	{
		public virtual ErrorResponse Decode(Stream stream)
		{
			using (var sr = new StreamReader(stream))
			{
				var json = sr.ReadToEnd();
				var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(json);

				return errorResponse;

			}
		} 
	}
}
