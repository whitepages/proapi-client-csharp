using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class BusinessQueryToProApi20UriEncoder : WhereQueryToProApi20UriEncoder<BusinessQuery>
	{
		private const string UriPath = "/2.0/business.json";
		private const string NameKey = "name";

		protected override UriQueryParameters QueryParams(EntityQuery query, Config config)
		{
			return QueryParams(query as BusinessQuery, config);
		}

		protected UriQueryParameters QueryParams(BusinessQuery query, Config config)
		{
			var parms = GetDefaultQueryParams(config);

			if (query != null) 
			{
				AddWhereQueryParams(ref parms, query);
				parms.Put(NameKey, query.Name);
			}

			return parms;
		}

		protected override string GetUriPath()
		{
			return UriPath;
		}
	}
}
