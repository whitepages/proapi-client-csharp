using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Associations;
using Durability = ProApiLibrary.Data.Entities.Durability;
using EntityId = ProApiLibrary.Data.Entities.EntityId;

namespace ProApiLibraryTests.TestCases.DataTests.AssociationTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class BusinessAssociationTest
	{
		[TestMethod]
		public void EntityResolution()
		{
			var assoc = this.DefaultAssociation;
			var entity = assoc.Entity;
			Assert.IsNotNull(entity);
			Assert.AreEqual(TestDictionaryFactory.BusinessId, entity.Id);
			Assert.AreEqual(entity, assoc.Business);
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void EntityIdTypeConstraint()
		{
			var id = new EntityId(EntityId.EntityType.Phone, Guid.NewGuid(), Durability.Durable);
			var assoc = new BusinessAssociation(id, new ResponseDictionary(null));
		}

		protected BusinessAssociation DefaultAssociation
		{
			get
			{
				var assoc = new BusinessAssociation(TestDictionaryFactory.BusinessId, TestDictionaryFactory.SampleDictionary);
				return assoc;
			}
		}
	}
}
