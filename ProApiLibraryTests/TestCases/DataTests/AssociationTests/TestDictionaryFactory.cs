using System;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.DataTests.AssociationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public class TestDictionaryFactory
	{
		public static readonly EntityId PersonId = new EntityId(EntityId.EntityType.Person, Guid.NewGuid(), Durability.Ephemeral);

		public static readonly EntityId BusinessId = new EntityId(EntityId.EntityType.Business, Guid.NewGuid(),
		                                                          Durability.Ephemeral);

		public static readonly EntityId LocationId = new EntityId(EntityId.EntityType.Location, Guid.NewGuid(),
		                                                          Durability.Ephemeral);

		public static readonly EntityId PhoneId = new EntityId(EntityId.EntityType.Phone, Guid.NewGuid(), Durability.Ephemeral);

		public static ResponseDictionary SampleDictionary
		{
			get
			{
				var dict = new ResponseDictionary(null);
				dict.Add(new Person(PersonId));
				dict.Add(new Business(BusinessId));
				dict.Add(new Location(LocationId));
				dict.Add(new Phone(PhoneId));
				return dict;
			}
		}
	}
}
