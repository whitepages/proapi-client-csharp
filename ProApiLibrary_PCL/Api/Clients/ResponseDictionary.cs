using System.Linq;
using System.Collections.Generic;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	public class ResponseDictionary
	{
		private readonly Client _client;
		private readonly Dictionary<EntityId, IPerson> _personDictionary = new Dictionary<EntityId, IPerson>();
		private readonly Dictionary<EntityId, IBusiness> _businessDictionary = new Dictionary<EntityId, IBusiness>();
		private readonly Dictionary<EntityId, ILocation> _locationDictionary = new Dictionary<EntityId, ILocation>();
		private readonly Dictionary<EntityId, IPhone> _phoneDictionary = new Dictionary<EntityId, IPhone>();

		public ResponseDictionary(Client client)
		{
			_client = client;
		}

		public void Add(IPhone phone)
		{
			_phoneDictionary.Add(phone.Id, phone);
		}

		public void Add(ILocation location)
		{
			_locationDictionary.Add(location.Id, location);
		}

		public void Add(IPerson person)
		{
			_personDictionary.Add(person.Id, person);
		}

		public void Add(IBusiness business)
		{
			_businessDictionary.Add(business.Id, business);
		}

		public HashSet<EntityId> GetIds()
		{
			var set = new HashSet<EntityId>();
			set.UnionWith(_phoneDictionary.Select(x=>x.Key));
			set.UnionWith(_businessDictionary.Select(x=>x.Key));
			set.UnionWith(_personDictionary.Select(x=>x.Key));
			set.UnionWith(_locationDictionary.Select(x=>x.Key));
			return set;
		}

		public IBusiness GetBusiness(EntityId entityId)
		{
			if (_businessDictionary.ContainsKey(entityId))
			{
				return _businessDictionary[entityId];
			}

			IBusiness proxy = new BusinessProxy(entityId, _client, this);
			_businessDictionary.Add(entityId, proxy);
			return proxy;

		}

		public IPerson GetPerson(EntityId entityId)
		{
			if (_personDictionary.ContainsKey(entityId))
			{
				return _personDictionary[entityId];
			}

			IPerson proxy = new PersonProxy(entityId, _client, this);
			_personDictionary.Add(entityId, proxy);
			return proxy;

		}

		public IPhone GetPhone(EntityId entityId)
		{
			if (_phoneDictionary.ContainsKey(entityId))
			{
				return _phoneDictionary[entityId];
			}

			IPhone proxy = new PhoneProxy(entityId, _client, this);
			_phoneDictionary.Add(entityId, proxy);
			return proxy;

		}

		public ILocation GetLocation(EntityId entityId)
		{
			if (_locationDictionary.ContainsKey(entityId))
			{
				return _locationDictionary[entityId];
			}

			ILocation proxy = new LocationProxy(entityId, _client, this);
			_locationDictionary.Add(entityId, proxy);
			return proxy;

		}


	}
}
