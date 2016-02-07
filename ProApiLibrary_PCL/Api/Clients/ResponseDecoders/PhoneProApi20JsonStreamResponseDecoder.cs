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
	public class PhoneProApi20JsonStreamResponseDecoder : ProApi20JsonStreamResponseDecoder<IPhone, HttpResponse>
	{
		public override Response<IPhone> Decode(HttpResponse responseData, Client client)
		{
			Response<IPhone> response;
			try
			{
				if (responseData.ResponseCode == HttpStatusCode.OK)
				{
					response = (new PhoneResponseDecoder()).Decode(responseData.Body, client);
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
