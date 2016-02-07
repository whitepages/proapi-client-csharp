using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// The <seealso cref="IBusiness"/> type specific <seealso cref="Association"/>
	/// </summary>
	/// <seealso cref="IBusiness"/>
	/// <seealso cref="Association"/>
	[DataContract]
	public class BusinessAssociation : LegalEntityAssociation
	{
		internal BusinessAssociation(Association from)
			: base(from)
		{

		}

		internal BusinessAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{

		}

		internal BusinessAssociation()
		{
			// for deserialization purposes
		}

		public BusinessAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{

		}

		public BusinessAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
								   bool isHistorical, DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, isHistorical, contactCreationDate)
		{

		}

		public IBusiness Business
		{
			get { return this.ResponseDictionary.GetBusiness(this.EntityId); }
		}

		public override IEntity Entity
		{
			get { return this.Business; }
		}

		public override EntityId.EntityType? EntityIdType
		{
			get { return EntityId.EntityType.Business; }
		}

	}
}
