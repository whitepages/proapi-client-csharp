using System;
using System.Collections.Generic;
using System.IO;
using ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibrary.Api.Clients.ResponseDecoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="TT">The entity class type you are decoding to</typeparam>
	/// <typeparam name="TD">The source data type you are decoding from</typeparam>
	public abstract class ProApi20JsonStreamResponseDecoder<TT, TD> : IResponseDecoder<TT, TD> where TT : IEntity
	{
		public abstract Response<TT> Decode(TD responseData, Client client);
		protected Response<TT> DecodeError(Stream responseBody, Client client)
		{
			var errorResponse = (new ErrorResponseDecoder()).Decode(responseBody);
			var message = this.ReadError(errorResponse.Error);

			var messages = new List<Message>(new[] { message });


			var response = new Response<TT>(client, new List<TT>(), new ResponseDictionary(client), messages);
			return response;
		}

		protected Message ReadError(Error error)
		{
			var message = new Message(Message.MessageSeverity.Error, this.ReadErrorType(error.Name, error.Message), null, error.Message);
			return message;
		}

		protected Message.MessageType ReadErrorType(string typeName, string message)
		{
			if (String.IsNullOrWhiteSpace(typeName))
			{
				throw new ResponseException(message);
			}

			switch (typeName)
			{
				case "InternalError":
					{ throw new InternalException(message); }
				case "TimeoutError":
					{ throw new TimeoutException(message); }
				case "AuthError":
					{ throw new AuthException(message); }
				case "QuotaExceededError":
					{ throw new QuotaExceededException(message); }
				case "InputError":
					{ return Message.MessageType.Input; }
				case "InputFieldError":
					{ return Message.MessageType.InputField; }
				case "InvalidParametersError":
					{ return Message.MessageType.InvalidParameters; }
				case "MissingFieldError":
					{ return Message.MessageType.MissingField; }
				case "EntityIDParseError":
					{ return Message.MessageType.EntityIdParse; }
				case "EntityIDTypeMismatchError":
					{ return Message.MessageType.EntityIdTypeMismatch; }
				case "NonDurableEntityIDLookupError":
					{ return Message.MessageType.NonDurableEntityIdLookup; }
				default:
					{ throw new ResponseException(message); }
			}
		}
	}
}
