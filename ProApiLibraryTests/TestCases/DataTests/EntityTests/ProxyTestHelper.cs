using System;
using System.Collections.Generic;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Exceptions;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;
using ProApiLibrary.Data.Messages;

namespace ProApiLibraryTests.TestCases.DataTests.EntityTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public class ProxyTestHelper
	{
		private readonly static string _apiKey = "mockapikey";

		public static readonly EntityId PersonId = new EntityId(EntityId.EntityType.Person, Guid.NewGuid(), Durability.Durable);

		public static readonly EntityId BusinessId = new EntityId(EntityId.EntityType.Business, Guid.NewGuid(),
		                                                          Durability.Durable);
		public static readonly EntityId LocationId = new EntityId(EntityId.EntityType.Location, Guid.NewGuid(),
		                                                          Durability.Durable);

		public static readonly EntityId PhoneId = new EntityId(EntityId.EntityType.Phone, Guid.NewGuid(), Durability.Durable);


		private readonly static IPerson _person;
		private readonly static IBusiness _business;
		private readonly static ILocation _location;
		private readonly static IPhone _phone;

		private readonly static ResponseMessages _emptyMessages = new ResponseMessages(new List<Message>());

		static ProxyTestHelper()
		{
			_person = new Person(PersonId);
			_business = new Business(BusinessId);
			_location = new Location(LocationId);
			_phone = new Phone(PhoneId);
		}

		static ResponseDictionary GetDictionary(Client client)
		{
			var dict = new ResponseDictionary(client);
			dict.Add(_person);
			dict.Add(_business);
			dict.Add(_phone);
			dict.Add(_location);
			return dict;
		}

		public IPerson Person { get { return _person; } }
		public IBusiness Business { get { return _business; } }
		public IPhone Phone { get { return _phone; } }
		public ILocation Location { get { return _location; } }

		public static PersonProxy GetPersonProxy()
		{
			return GetPersonProxy(ProxyTestHelper.EmptyClient);
		}

		public static PersonProxy GetPersonProxy(Client client)
		{
			return new PersonProxy(PersonId, client, GetDictionary(client));
		}

		public static BusinessProxy GetBusinessProxy()
		{
			return GetBusinessProxy(ProxyTestHelper.EmptyClient);
		}

		public static BusinessProxy GetBusinessProxy(Client client)
		{
			return new BusinessProxy(BusinessId, client, GetDictionary(client));
		}

		public static PhoneProxy GetPhoneProxy()
		{
			return GetPhoneProxy(ProxyTestHelper.EmptyClient);
		}

		public static PhoneProxy GetPhoneProxy(Client client)
		{
			return new PhoneProxy(PhoneId, client, GetDictionary(client));
		}

		public static LocationProxy GetLocationProxy()
		{
			return GetLocationProxy(ProxyTestHelper.EmptyClient);
		}

		public static LocationProxy GetLocationProxy(Client client)
		{
			return new LocationProxy(LocationId, client, GetDictionary(client));
		}

		public static Client Client
		{
			get { return new StubClient(_apiKey); }
		}

		public static Client EmptyClient
		{
			get
			{
				return new StubClient(_apiKey, false, true);
			}
		}

		public static Client ErrorClient
		{
			get
			{
				return new StubClient(_apiKey, true, false);
			}
		}

		public class StubClient : Client
		{
			public StubClient(string apiKey) : base(apiKey)
			{
				
			}

			public StubClient(string apiKey, bool forceErrorResult, bool forceEmptyResult) : this(apiKey)
			{
				this.ForceErrorResult = forceErrorResult;
				this.ForceEmptyResult = forceEmptyResult;
			}

			public bool ForceEmptyResult { get; set; }
			public bool ForceErrorResult { get; set; }

			public override Response<IPerson> FindPeople(PersonQuery query)
			{
				if (this.ForceErrorResult)
				{
					throw new FindException("Stubbed client always errors!");
				}

				var results = new List<IPerson>();
				if (!this.ForceEmptyResult)
				{
					results.Add(_person);
				}
				return new Response<IPerson>(this, results, GetDictionary(this), _emptyMessages);
			}

			public override Response<IBusiness> FindBusinesses(BusinessQuery query)
			{
				if (this.ForceErrorResult)
				{
					throw new FindException("Stubbed client always errors!");
				}

				var results = new List<IBusiness>();
				if (!this.ForceEmptyResult)
				{
					results.Add(_business);
				}
				return new Response<IBusiness>(this, results, GetDictionary(this), _emptyMessages);
			}

			public override Response<IPhone> FindPhones(PhoneQuery query)
			{
				if (this.ForceErrorResult)
				{
					throw new FindException("Stubbed client always errors!");
				}

				var results = new List<IPhone>();
				if (!this.ForceEmptyResult)
				{
					results.Add(_phone);
				}
				return new Response<IPhone>(this, results, GetDictionary(this), _emptyMessages);
			}

			public override Response<ILocation> FindLocations(LocationQuery query)
			{
				if (this.ForceErrorResult)
				{
					throw new FindException("Stubbed client always errors!");
				}

				var results = new List<ILocation>();
				if (!this.ForceEmptyResult)
				{
					results.Add(_location);
				}
				return new Response<ILocation>(this, results, GetDictionary(this), _emptyMessages);
			}
		}
	}
}
