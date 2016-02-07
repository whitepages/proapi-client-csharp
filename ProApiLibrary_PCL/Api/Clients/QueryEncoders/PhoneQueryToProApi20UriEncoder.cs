using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class PhoneQueryToProApi20UriEncoder : QueryToProApi20UriEncoder<PhoneQuery>
	{
		private const string UriPath = "/2.0/phone.json";
		private const string PhoneKey = "phone_number";
		private const string ResponseTypeKey = "response_type";

		protected override UriQueryParameters QueryParams(EntityQuery query, Config config)
		{
			return QueryParams(query as PhoneQuery, config);
		}

		protected UriQueryParameters QueryParams(PhoneQuery query, Config config)
		{
			var parms = GetDefaultQueryParams(config);

			if (query != null) 
			{
				parms.Put(PhoneKey, query.PhoneNumber);
				parms.Put(ResponseTypeKey, query.ResponseType);
			}

			return parms;
		}

		protected override string GetUriPath()
		{
			return UriPath;
		}
	}
}
