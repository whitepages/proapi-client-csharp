using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.Utils
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class UriQueryParameters
	{
		private const string Separator = "&";
		private const string KeyValueSeparator = "=";

		private readonly Dictionary<string, string> _params;
		private readonly IParamValueFormatter _paramValueFormatter;

		public UriQueryParameters(IParamValueFormatter paramValueFormatter)
		{
			_paramValueFormatter = paramValueFormatter;
			_params = new Dictionary<string, string>();
		}

		public void Put(string key, string value)
		{
			_params.Add(key, _paramValueFormatter.Format(value));
		}

		public void Put(string key, double? value)
		{
			_params.Add(key, _paramValueFormatter.Format(value));
		}

		public void Put(string key, bool? value)
		{
			_params.Add(key, _paramValueFormatter.Format(value));
		}

		public void Put(string key, PhoneQuery.PhoneResponseType value)
		{
			_params.Add(key, _paramValueFormatter.Format(value));
		}

		public Dictionary<string, string> Params
		{
			get { return _params; }
		}

		public override string ToString()
		{
			string s;
			try
			{
				s = EncodeQueryString();
			}
			catch (Exception)
			{
				s = "Exception";
			}
			return String.Format("QueryParameters({0})", s);
		}

		public string EncodeQueryString()
		{
			var sb = new StringBuilder();
			var firstElement = true;
			foreach (var item in _params)
			{
				var value = _params[item.Key];
				var queryString = EncodeQueryString(item.Key, value);
				if (!String.IsNullOrWhiteSpace(queryString) && !firstElement)
				{
					sb.Append(Separator);
				}
				firstElement = false;
				sb.Append(queryString);

			}

			return sb.ToString();
		}

		protected internal virtual string EncodeQueryString(string key, string value)
		{
			if (String.IsNullOrWhiteSpace(key) || String.IsNullOrWhiteSpace(value))
			{
				return null;
			}
			return HttpUtility.UrlEncode(key, Encoding.UTF8) + KeyValueSeparator + HttpUtility.UrlEncode(value, Encoding.UTF8);
		}
	}
}
