using ProApiLibrary.Api.Queries;

namespace ProApiLibrary.Api.Clients.Utils
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public interface IParamValueFormatter
	{
		string Format(string s);
		string Format(double? d);
		string Format(bool? b);
		string Format(object o);
		string Format(PhoneQuery.PhoneResponseType? responseType);
	}
}
