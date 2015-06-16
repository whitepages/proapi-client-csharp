using System;
using ExamplesLibrary;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace FindBusiness
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	class Program
	{
		private const string Name = "Toyota";
		private const string City = "Seattle";
		private const string StateCode = "WA";
		private const string PostalCode = null;

		static void Main(string[] args)
		{
			var apiKey = ExampleUtils.GetApiKey(args);
			var client = new Client(apiKey);
			var query = new BusinessQuery
			{
				Name = Name,
				City = City,
				StateCode = StateCode,
				PostalCode = PostalCode,
			};

			Response<IBusiness> response = null;
			try
			{
				response = client.FindBusinesses(query);

			}
			catch (FindException)
			{
				Console.Out.WriteLine("FindBusiness lookup for {0}; {1}; {2}; {3} failed!", Name, City, StateCode, PostalCode);
			}

			if ((response != null) && (response.IsSuccess))
			{
				var results = response.Results;
				Console.Out.WriteLine(
					"FindBusiness lookup for {0}; {1}; {2}; {3} was successful, returning {4} root business objects{5}{5}",
					Name, City, StateCode, PostalCode, results.Count, System.Environment.NewLine);

				foreach (var business in results)
				{
					ExampleUtils.DumpBusiness(business, 2);
					Console.Out.WriteLine();
				}
			}

#if DEBUG
			System.Console.Out.WriteLine("Press the ENTER key to quit...");
			System.Console.In.ReadLine();
#endif
		}
	}
}
