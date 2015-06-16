using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// A class used internally for deserializing results
	/// </summary>
	[DataContract]
	public class SerializableAssociation : Association
	{
		internal SerializableAssociation()
		{
			// for deserialization purposes
		}

		internal SerializableAssociation(Association from) : base(from)
		{
			
		}

		internal SerializableAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{
			
		}
		protected SerializableAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{
			
		}

		protected SerializableAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
		                                 bool isHistorical, DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, isHistorical, contactCreationDate)
		{
			
		}

		public override IEntity Entity
		{
			get { return null; }
		}

		public override EntityId.EntityType? EntityIdType
		{
			get { return this.EntityId == null ? (EntityId.EntityType?)null : this.EntityId.Type; }
		}
	}
}
