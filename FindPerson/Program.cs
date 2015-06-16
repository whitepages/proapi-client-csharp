using System;
using ExamplesLibrary;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace FindPerson
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	class Program
	{
		private const string FirstName = "Jane";
		private const string MiddleName = null;
		private const string LastName = "Smith";
		private const string City = "Seattle";
		private const string StateCode = "WA";
        private const string PostalCode = null;

		static void Main(string[] args)
		{
			var apiKey = ExampleUtils.GetApiKey(args);
			var client = new Client(apiKey);
			var query = new PersonQuery
				{
					FirstName = FirstName,
					MiddleName = MiddleName,
					LastName = LastName,
					City = City,
					StateCode = StateCode,
					PostalCode = PostalCode,
				};

			Response<IPerson> response = null;
			try
			{
				response = client.FindPeople(query);

			}
			catch (FindException)
			{
				System.Console.Out.WriteLine("FindPerson lookup for {0}; {1}; {2}; {3}; {4}; {5} failed!", FirstName, MiddleName, LastName, City, StateCode, PostalCode);
			}

			if ((response != null) && (response.IsSuccess))
			{
				var results = response.Results;

				Console.Out.WriteLine( "FindPerson lookup for {0}; {1}; {2}; {3}; {4}; {5} was successful, returning {6} root people objects{7}",
                               FirstName, MiddleName, LastName, City, StateCode, PostalCode, results.Count, System.Environment.NewLine);

				foreach ( var person in results ) {
					ExampleUtils.DumpPerson( person, 2 );
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
