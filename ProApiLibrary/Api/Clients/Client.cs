using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// The Client class is the starting point for interaction with the Whitepages
	/// API, serving as the starting place for making requests and getting results.
	/// </summary>
	/// <remarks>
	/// <![CDATA[
	/// <p>The key steps for use of the Client are:</p>
	///
	/// <ol>
	///    <li>Instantiation of a Client,</li>
	///    <li>Creation of a <seealso cref="IQuery"/>, and</li>
	///    <li>Execution of the Query via the find methods on the Client.</li>
	/// </ol>
	///
	/// <example>For example:
	/// <code>
	/// {
	///		Client client = new Client("yourapikey");
	///
	///		PersonQuery personQuery = new PersonQuery("Rory", null, "Williams");
	///		Response<Person> = client.findPeople(personQuery);
	///
	///		List<Person> results = Response.getResults();
	///		for( Person p : results ) {
	///			System.out.println(p.getBestName());
	///		}
	/// }
	/// </code>
	/// </example>
	/// 
	/// <p>In production applications, it is typically preferable to instantiate a single
	/// Client instance per thread, repeatedly using it for sequential requests to the API.</p>
	///
	/// ]]>
	/// 
	/// <seealso cref="Config"/>
	/// <seealso cref="IQuery"/>
	/// <seealso cref="Response{T}"/>
	/// </remarks>
	public class Client
	{
		private readonly Config _config;
		private readonly IResultFinder<IPerson, PersonQuery> _personResultFinder;
		private readonly IResultFinder<IBusiness, BusinessQuery> _businessResultFinder;
		private readonly IResultFinder<IPhone, PhoneQuery> _phoneResultFinder;
		private readonly IResultFinder<ILocation, LocationQuery> _locationResultFinder;

		/// <summary>
		/// Creates a Client instance configured with the given API Key.
		/// </summary>
		/// <remarks>
		/// <seealso cref="Config"/>
		/// </remarks>
		/// <param name="apiKey">Your Whitepages API key</param>
		public Client(string apiKey)
			: this(new Config(apiKey))
		{

		}

		/// <summary>
		/// Creates a Client instance with the given Config instance.
		/// </summary>
		/// <remarks>
		/// <p>The Config instance is not duplicated, so alterations to it will
		/// affect all Client instances using it.</p>
		/// </remarks>
		/// <param name="config">The configuration instance to use</param>
		public Client(Config config)
			: this
			(
					config,
					ResultFinderFactory.DefaultPersonFinder,
					ResultFinderFactory.DefaultBusinessFinder,
					ResultFinderFactory.DefaultPhoneFinder,
					ResultFinderFactory.DefaultLocationFinder
			)
		{

		}

		/// <summary>
		/// Creates a Client instance with the given Config and ResultFinder instances.
		/// </summary>
		/// <remarks>
		/// Normally, one should use the default ResultFinders, however there are
		/// advanced cases where alternative ResultFinders may be useful, such
		/// as with custom response parsers or stubbed finders for testing.
		/// </remarks>
		///
		/// <param name="config">The configuration instance</param>
		/// <param name="personResultFinder">The ResultFinder used for FindPeople() lookups</param>
		/// <param name="businessResultFinder">The ResultFinder used for FindBusinesses() lookups</param>
		/// <param name="phoneResultFinder">The ResultFinder used for FindPhones() lookups</param>
		/// <param name="locationResultFinder">The ResultFinder used for FindLocations() lookups</param>
		private Client(Config config,
				   IResultFinder<IPerson, PersonQuery> personResultFinder,
				   IResultFinder<IBusiness, BusinessQuery> businessResultFinder,
				   IResultFinder<IPhone, PhoneQuery> phoneResultFinder,
				   IResultFinder<ILocation, LocationQuery> locationResultFinder)
		{
			_config = config;

			_personResultFinder = personResultFinder;
			_businessResultFinder = businessResultFinder;
			_phoneResultFinder = phoneResultFinder;
			_locationResultFinder = locationResultFinder;
		}

		public Config Config
		{
			get { return _config; }
		}

		/// <summary>
		/// Executes the given query and returns the response.
		/// </summary>
		/// <param name="query">The query to perform</param>
		/// <returns>The response object</returns>
		public virtual Response<IPerson> FindPeople(PersonQuery query)
		{
			return _personResultFinder.Find(query, this);
		}

		/// <summary>
		/// Executes the given query and returns the response.
		/// </summary>
		/// <param name="query">The query to perform</param>
		/// <returns>The response object</returns>
		public virtual Response<IBusiness> FindBusinesses(BusinessQuery query)
		{
			return _businessResultFinder.Find(query, this);
		}

		/// <summary>
		/// Executes the given query and returns the response.
		/// </summary>
		/// <param name="query">The query to perform</param>
		/// <returns>The response object</returns>
		public virtual Response<IPhone> FindPhones(PhoneQuery query)
		{
			return _phoneResultFinder.Find(query, this);
		}

		/// <summary>
		/// Executes the given query and returns the response.
		/// </summary>
		/// <param name="query">The query to perform</param>
		/// <returns>The response object</returns>
		public virtual Response<ILocation> FindLocations(LocationQuery query)
		{
			return _locationResultFinder.Find(query, this);
		}
	}
}
