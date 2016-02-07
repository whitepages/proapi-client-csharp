using System;
using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="TQ"></typeparam>
	public abstract class QueryToProApi20UriEncoder<TQ> : IQueryEncoder<TQ, Uri> where TQ : EntityQuery
	{
		private const string ApiKeyKey = "api_key";
		private const string EntityUriPathRoot = "/2.0/entity";
		private const string TypeSuffixJson = ".json";

		protected abstract UriQueryParameters QueryParams(EntityQuery query, Config config);

		protected abstract string GetUriPath();

		public Uri Encode(TQ query, Client client)
		{
			if (client == null)
			{
				throw new QueryEncoderException("No client object given");
			}
			else if (client.Config == null)
			{
				throw new QueryEncoderException("No configuration object found on client");
			}
			else if (client.Config.ApiKey == null)
			{
				throw new QueryEncoderException("No API Key configured on client");
			}

			return MakeUri(query, client.Config);
			
		}

		protected Uri MakeUri(TQ query, Config config)
		{
			try 
			{
				var id = (query == null) ? null : query.Id;
				return (id == null) ? FindEntitiesUri(query, config) : FindByIdUri(query, config);
			} 
			catch (Exception  e) 
			{
				throw new QueryEncoderException(e);
			}
		}

		protected UriQueryParameters GetDefaultQueryParams(Config config)
		{
			var parms = new UriQueryParameters(new ProApi20ParamValueFormatter());
			if (config != null)
			{
				parms.Put(ApiKeyKey, config.ApiKey);
			}
			return parms;
		}

		protected Uri FindEntitiesUri(TQ query, Config config)
		{
			Uri serviceRoot = config.ServiceRoot;
			String uriPath = GetUriPath();
			UriQueryParameters queryParams = QueryParams(query, config);
			return UriEncoder.MakeUri(serviceRoot, uriPath, queryParams);
		}

		protected Uri FindByIdUri(TQ query, Config config) 
		{
			Uri serviceRoot = config.ServiceRoot;
			var entityUriPath = EntityUriPathRoot + "/" + query.Id + TypeSuffixJson;
			UriQueryParameters queryParams = GetDefaultQueryParams(config);
			return UriEncoder.MakeUri(serviceRoot, entityUriPath, queryParams);
		}
	}
}
