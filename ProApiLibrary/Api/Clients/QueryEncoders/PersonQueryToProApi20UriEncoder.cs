using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class PersonQueryToProApi20UriEncoder : WhereQueryToProApi20UriEncoder<PersonQuery>
	{
		private const string UriPath = "/2.0/person.json";

		private const string NameKey = "name";
		private const string FirstNameKey = "first_name";
		private const string MiddleNameKey = "middle_name";
		private const string LastNameKey = "last_name";
		private const string SuffixKey = "suffix";
		private const string TitleKey = "title";
		private const string UseHistoricalKey = "use_historical";
		private const string UseMetroKey = "use_metro";


		protected override UriQueryParameters QueryParams(EntityQuery query, Config config)
		{
			return QueryParams(query as PersonQuery, config);
		}

		protected UriQueryParameters QueryParams(PersonQuery query, Config config)
		{
			var parms = GetDefaultQueryParams(config);

			if (query != null) 
			{
				AddWhereQueryParams(ref parms, query);

				parms.Put(NameKey, query.Name);
				parms.Put(FirstNameKey, query.FirstName);
				parms.Put(MiddleNameKey, query.MiddleName);
				parms.Put(LastNameKey, query.LastName);
				parms.Put(SuffixKey, query.Suffix);
				parms.Put(TitleKey, query.Title);
				parms.Put(UseHistoricalKey, query.UseHistorical);
				parms.Put(UseMetroKey, query.UseMetro);
			}

			return parms;
		}

		protected override string GetUriPath()
		{
			return UriPath;
		}
	}
}
