using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// The <seealso cref="IPhone"/> type specific <seealso cref="Association"/>
	/// </summary>
	/// <remarks>
	/// <p>This class also adds accessors for the contact type of the location.</p>
	/// 
	/// <seealso cref="IPhone"/>
	/// <seealso cref="Association"/>
	/// </remarks>
	[DataContract]
	public class PhoneAssociation : SerializableAssociation
	{
		internal PhoneAssociation(Association from)
			: base(from)
		{

		}

		internal PhoneAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{

		}

		internal PhoneAssociation()
		{

		}

		public PhoneAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{

		}

		public PhoneAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
								   bool isHistorical, DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, isHistorical, contactCreationDate)
		{
			
		}

		public IPhone Phone
		{
			get { return this.ResponseDictionary.GetPhone(this.EntityId); }
		}

		public override IEntity Entity
		{
			get { return this.Phone; }
		}

		public override EntityId.EntityType? EntityIdType
		{
			get { return EntityId.EntityType.Phone; }
		}
		
		public new bool IsHistorical { get; set; }

		public new TimePeriod ValidFor { get; set; }
	}
}
