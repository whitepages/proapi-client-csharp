using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="TQ"></typeparam>
	public abstract class WhereQueryToProApi20UriEncoder<TQ> : QueryToProApi20UriEncoder<TQ> where TQ: EntityQuery
	{
		private const string StreetLine1Key = "street_line_1";
		private const string StreetLine2Key = "street_line_2";
		private const string CityKey = "city";
		private const string StateCodeKey = "state_code";
		private const string PostalCodeKey = "postal_code";
		private const string CountryCodeKey = "country_code";
		private const string LatitudeKey = "lat";
		private const string LongitudeKey = "lon";
		private const string RadiusKey = "radius";

		protected void AddWhereQueryParams(ref UriQueryParameters parms, WhereQuery query) 
		{
			if (query != null) 
			{
				parms.Put(StreetLine1Key, query.StreetLine1);
				parms.Put(StreetLine2Key, query.StreetLine2);
				parms.Put(CityKey, query.City);
				parms.Put(StateCodeKey, query.StateCode);
				parms.Put(PostalCodeKey, query.PostalCode);
				parms.Put(CountryCodeKey, query.CountryCode);
				parms.Put(LatitudeKey, query.Latitude);
				parms.Put(LongitudeKey, query.Longitude);
				parms.Put(RadiusKey, query.Radius);
			}
		}
	}
}
