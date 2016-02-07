using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// The <seealso cref="IPerson"/> type specific <seealso cref="Association"/>
	/// </summary>
	/// <seealso cref="IPerson"/>
	/// <seealso cref="Association"/>
	[DataContract]
	public class PersonAssociation : SerializableAssociation
	{
		internal PersonAssociation()
		{
			// for deserialization purposes
		}

		internal PersonAssociation(Association from)
			: base(from)
		{

		}
		public PersonAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{

		}

		public PersonAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{

		}

		public PersonAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
								   DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, false, contactCreationDate)
		{

		}

		public IPerson Person
		{
			get { return this.ResponseDictionary.GetPerson(this.EntityId); }
		}

		public override IEntity Entity
		{
			get { return this.Person; }
		}

		public override EntityId.EntityType? EntityIdType
		{
			get { return EntityId.EntityType.Person; }
		}
	}
}
