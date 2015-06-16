using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Associations;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.DataTests.EntityTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class BaseEntityTests
	{
		private static readonly EntityId _entityId = new EntityId(EntityId.EntityType.Person, Guid.NewGuid(),
		                                                          Durability.Durable);

		private static readonly EntityId _associatedPhoneId = new EntityId(EntityId.EntityType.Phone, Guid.NewGuid(), Durability.Durable);

		private BaseEntity _entity;
		private Phone _associatedPhone;

		[TestInitialize]
		public void MakeEntity()
		{
			_associatedPhone = new Phone(_associatedPhoneId);
			var dict = new ResponseDictionary(null);
			dict.Add(_associatedPhone);
			_entity = new Person(_entityId)
				{
					BusinessAssociations = null,
					LocationAssociations = new List<LocationAssociation>(),
					PhoneAssociations = new List<PhoneAssociation>
						{
							new PhoneAssociation(_associatedPhoneId, dict)
						}
				};
		}

		[TestMethod]
		public void ItShouldWorkWithAssociations()
		{
			var assocs = _entity.PhoneAssociations.ToList();
			Assert.AreEqual(1, assocs.Count);
			Assert.AreEqual(_associatedPhoneId, assocs.First().EntityId);
		}

		[TestMethod]
		public void ItShouldAllowEmptyAssociations()
		{
			Assert.AreEqual(0, _entity.LocationAssociations.Count());
		}

		[TestMethod]
		public void ItShouldAllowNullAssociations()
		{
			Assert.IsNull(_entity.BusinessAssociations);
		}

		[TestMethod]
		public void ItShouldResolveAssociations()
		{
			var phones = _entity.Phones.ToList();
			Assert.AreEqual(1, phones.Count);
			Assert.AreEqual(_associatedPhoneId, phones.First().Id);
		}

		[TestMethod]
		public void ItShouldResolveEmptyAssociations()
		{
			Assert.AreEqual(0, _entity.LocationAssociations.Count());
		}

		[TestMethod]
		public void ItShouldAggregateNullAndEmptyAssociations()
		{
			var assocs = _entity.Associations.ToList();
			Assert.AreEqual(1, assocs.Count);
			Assert.AreEqual(_associatedPhoneId, assocs.First().EntityId);
		}

		[TestMethod]
		public void ItShouldAggregateResolvedNullAndEmptyAssociations()
		{
			var entities = _entity.Entities.ToList();
			Assert.AreEqual(1, entities.Count);
			Assert.AreEqual(_associatedPhoneId, entities.First().Id);
		}

	}
}
