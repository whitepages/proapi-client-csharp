using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using Durability = ProApiLibrary.Data.Entities.Durability;
using EntityId = ProApiLibrary.Data.Entities.EntityId;
using LocationAssociation = ProApiLibrary.Data.Associations.LocationAssociation;

namespace ProApiLibraryTests.TestCases.DataTests.AssociationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class LocationAssociationTest
	{
		[TestMethod]
		public void EntityResolution()
		{
			var assoc = this.DefaultAssociation;
			var entity = assoc.Entity;
			Assert.IsNotNull(entity);
			Assert.AreEqual(TestDictionaryFactory.LocationId, entity.Id);
			Assert.AreEqual(entity, assoc.Location);
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void EntityIdTypeConstraint()
		{
			var id = new EntityId(EntityId.EntityType.Business, Guid.NewGuid(), Durability.Durable);
			var assoc = new LocationAssociation(id, new ResponseDictionary(null));
		}

		protected LocationAssociation DefaultAssociation
		{
			get
			{
				var assoc = new LocationAssociation(TestDictionaryFactory.LocationId, TestDictionaryFactory.SampleDictionary);
				return assoc;
			}
		}
	}
}
