using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
			HttpResponse httpResponse = null;
			try
			{
				var request = (HttpWebRequest)WebRequest.Create(uri);
				request.Method = "GET";

				try
				{
					var t = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse,
						request.EndGetResponse, null)
						.ContinueWith(task =>
						{
							var response = (HttpWebResponse) task.Result;

							var statusCode = response.StatusCode;
							var headers = this.ConvertHeaders(response.Headers);
							var body = response.GetResponseStream();

							httpResponse = new HttpResponse(statusCode, uri, headers, body);
						});
					// wait for the task to complete;
					t.Wait();

				}
				catch (System.AggregateException agg)
				{
					foreach (var exc in agg.InnerExceptions)
					{
						var inner = exc.InnerException;
						if (inner is WebException)
						{
							throw inner;
						}
					}
				}
				
				/*
				 * var response = (HttpWebResponse) await Task.Factory
					.FromAsync<WebResponse>(request.BeginGetResponse,
						request.EndGetResponse, null);
				*/

				//var response = (HttpWebResponse) request.GetResponse();

				return httpResponse;
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
