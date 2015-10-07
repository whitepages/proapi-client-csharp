using System;
using System.Collections.Generic;
using System.Net;
using ProApiLibrary.Api.Exceptions;
using HttpResponse = ProApiLibrary.Api.Clients.Utils.HttpResponse;

namespace ProApiLibrary.Api.Clients.DataSources
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class HttpDataSource : IDataSource<HttpResponse, Uri>
	{
		public HttpResponse Execute(Uri uri, Client client)
		{
			try
			{
				var request = WebRequest.Create(uri);
				request.Method = "GET";
				var response = (HttpWebResponse) request.GetResponse();
				var statusCode = response.StatusCode;
				var headers = this.ConvertHeaders(response.Headers);
				var body = response.GetResponseStream();

				return new HttpResponse(statusCode, uri, headers, body);
			}
			catch (WebException e)
			{
				var webResponse = e.Response as HttpWebResponse;
				if (webResponse != null)
				{
					var response = webResponse;
					return new HttpResponse(response.StatusCode, uri, this.ConvertHeaders(response.Headers), response.GetResponseStream());
				}
				throw new DataSourceException(e);
			}
		}

		protected IDictionary<String, List<String>> ConvertHeaders(WebHeaderCollection coll)
		{
			var dict = new Dictionary<String, List<String>>();

			foreach (var key in coll.AllKeys)
			{
				var val = coll[key];
				if (dict.ContainsKey(key))
				{
					dict[key].Add(val);
				}
				else
				{
					dict.Add(key, new List<string> {val});
				}
			}
			return dict;
		}
	}
}
