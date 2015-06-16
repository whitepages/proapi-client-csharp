using System;

namespace ProApiLibraryTests.TestCases.IntegrationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public class ClientIntegrationTestHelper
	{
		private readonly static string _apiKey;

		static ClientIntegrationTestHelper()
		{
			_apiKey = System.Configuration.ConfigurationManager.AppSettings["api.key"];
			if (String.IsNullOrWhiteSpace(_apiKey))
			{
				throw new Exception("No API key found; expected to find it in the app.config configuration settings file.");
			}
		}

		public static string ApiKey
		{
			get { return _apiKey; }
		}
	}
}
