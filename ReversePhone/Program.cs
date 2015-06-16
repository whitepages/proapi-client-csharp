using ExamplesLibrary;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ReversePhone
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	class Program
	{
		private const string PhoneNumber = "2069735100";

		static void Main(string[] args)
		{
			var apiKey = ExampleUtils.GetApiKey(args);
			var client = new Client(apiKey);
			var query = new PhoneQuery(PhoneNumber);
			Response<IPhone> response;
			try
			{
				response = client.FindPhones(query);
			}
			catch (FindException)
			{
				System.Console.Out.WriteLine("ReversePhone lookup for {0} failed!", PhoneNumber);
				throw;
			}

			if ((response != null) && (response.IsSuccess))
			{
				var results = response.Results;
				System.Console.Out.WriteLine("ReversePhone lookup for {0} was successful, returning {1} root phone objects.{2}{2}",
					PhoneNumber, results.Count, System.Environment.NewLine);

				foreach (var phone in results)
				{
					ExampleUtils.DumpPhone(phone, 2);
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
