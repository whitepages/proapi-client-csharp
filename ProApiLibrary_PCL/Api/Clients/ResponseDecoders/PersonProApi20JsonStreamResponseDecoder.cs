using System.Net;
using ProApiLibrary.Api.Clients.Exceptions;
using ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming;
using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients.ResponseDecoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class PersonProApi20JsonStreamResponseDecoder : ProApi20JsonStreamResponseDecoder<IPerson, HttpResponse>
	{
		public override Response<IPerson> Decode(HttpResponse responseData, Client client)
		{
			Response<IPerson> response;
			try
			{
				if (responseData.ResponseCode == HttpStatusCode.OK)
				{
					response = (new PersonResponseDecoder()).Decode(responseData.Body, client);
				}
				else
				{
					response = this.DecodeError(responseData.Body, client);
				}
			}
			catch (WebException we)
			{
				throw new ResponseDecoderException(we);
			}
			return response;
		}
	}
}
