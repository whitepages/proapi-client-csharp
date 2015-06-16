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
	public class PersonAssociationTest
	{
		[TestMethod]
		public void EntityResolution()
		{
			var assoc = this.DefaultAssociation;
			var entity = assoc.Entity;
			Assert.IsNotNull(entity);
			Assert.AreEqual(TestDictionaryFactory.PersonId, entity.Id);
			Assert.AreEqual(entity, assoc.Person);
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void EntityIdTypeConstraint()
		{
			var id = new EntityId(EntityId.EntityType.Business, Guid.NewGuid(), Durability.Durable);
			var assoc = new PersonAssociation(id, new ResponseDictionary(null));
		}

		protected PersonAssociation DefaultAssociation
		{
			get
			{
				var assoc = new PersonAssociation(TestDictionaryFactory.PersonId, TestDictionaryFactory.SampleDictionary);
				return assoc;
			}
		}
	}
}
