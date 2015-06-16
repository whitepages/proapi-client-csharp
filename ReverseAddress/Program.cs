using ExamplesLibrary;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ReverseAddress
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	class Program
	{
		private const string StreetLine1 = "906 Dexter Ave N Apt 1328";
		private const string StreetLine2 = null;
		private const string City = "Seattle";
		private const string StateCode = "WA";
		private const string PostalCode = null;

		static void Main(string[] args)
		{
			var apiKey = ExampleUtils.GetApiKey(args);
			var client = new Client(apiKey);
			var query = new LocationQuery(StreetLine1, StreetLine2, City, StateCode, PostalCode);
			Response<ILocation> response;
			try
			{
				response = client.FindLocations(query);
			}
			catch (FindException)
			{
				System.Console.Out.WriteLine("ReverseAddress lookup for {0}; {1}; {2}; {3}; {4} failed!", StreetLine1, StreetLine2, City, StateCode, PostalCode);
				throw;
			}

			if ((response != null) && (response.IsSuccess))
			{
				var results = response.Results;
				System.Console.Out.WriteLine("ReverseAddress lookup for {0}; {1}; {2}; {3}; {4} was successful, returning {5} root location objects.{6}{6}",
					StreetLine1, StreetLine2, City, StateCode, PostalCode, results.Count, System.Environment.NewLine);

				foreach (var location in results)
				{
					ExampleUtils.DumpLocation(location, 2);
					System.Console.Out.WriteLine();
				}
			}

#if DEBUG
			System.Console.Out.WriteLine("Press the ENTER key to quit...");
			System.Console.In.ReadLine();
#endif
		}
	}
}
