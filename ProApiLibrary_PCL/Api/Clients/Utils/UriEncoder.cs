using System;

namespace ProApiLibrary.Api.Clients.Utils
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class UriEncoder
	{
		private const int NoPortSpecified = -1;

		public static Uri MakeUri(Uri serviceRoot, string path, UriQueryParameters queryParams)
		{
			return MakeUri(serviceRoot.Scheme, serviceRoot.Host, serviceRoot.Port, path, queryParams);
		}

		public static Uri MakeUri(string scheme, string host, int? port, string path, UriQueryParameters queryParams)
		{
			var portValue = port.HasValue ? port.Value : NoPortSpecified;
			var encodedQueryParams = queryParams.EncodeQueryString();
			const string SCHEME_DELIMITER = "://";
			var uri = String.Format("{0}{1}{2}:{3}{4}?{5}", scheme, SCHEME_DELIMITER, host, portValue, path, encodedQueryParams);
			return new Uri(uri);
		}
	}
}
