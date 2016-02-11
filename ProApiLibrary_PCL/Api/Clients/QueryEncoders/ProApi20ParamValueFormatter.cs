using System;
using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.QueryEncoders
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class ProApi20ParamValueFormatter : IParamValueFormatter
	{
		private const string ResponseTypeRegularValue = null;
		private const string ResponseTypeLiteValue = "lite";
		private const string ResponseTypeCallerIdValue = "caller_id";

		public string Format(string s)
		{
			return s;
		}

		public string Format(double? d)
		{
			return d.HasValue ? d.Value.ToString("0.000000") : null;
		}

		public string Format(bool? b)
		{
			return b.HasValue ? (b.Value ? "true" : "false") : null;
		}

		public string Format(object o)
		{
			if (o == null)
			{
				return null;
			}
			throw new Exception(
				String.Format("Cannot format unknown object {0} as query parameter value: {1}",
				              o.GetType(),
				              o));
		}

		public string Format(PhoneQuery.PhoneResponseType? responseType)
		{
			if (responseType == null)
			{
				return null;
			}
			switch (responseType.Value)
			{
				case PhoneQuery.PhoneResponseType.Regular:
					{
						return ResponseTypeRegularValue;
					}
				case PhoneQuery.PhoneResponseType.Lite:
					{
						return ResponseTypeLiteValue;
					}
				case PhoneQuery.PhoneResponseType.CallerId:
					{
						return ResponseTypeCallerIdValue;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}
