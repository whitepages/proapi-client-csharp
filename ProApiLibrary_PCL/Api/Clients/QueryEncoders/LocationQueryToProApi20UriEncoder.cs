using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class LocationQueryToProApi20UriEncoder : WhereQueryToProApi20UriEncoder<LocationQuery>
	{
		private const string UriPath = "/2.0/location.json";

		protected override UriQueryParameters QueryParams(EntityQuery query, Config config)
		{
			return QueryParams(query as LocationQuery, config);
		}

		protected UriQueryParameters QueryParams(LocationQuery query, Config config)
		{
			var parms = GetDefaultQueryParams(config);

			if (query != null) 
			{
				AddWhereQueryParams(ref parms, query);
			}

			return parms;
		}

		protected override string GetUriPath()
		{
			return UriPath;
		}
	}
}
