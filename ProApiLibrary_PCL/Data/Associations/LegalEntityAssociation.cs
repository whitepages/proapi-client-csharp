using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// /// Common superclass of <seealso cref="PhoneAssociation"/> and <seealso cref="BusinessAssociation"/>; useful
	/// for Liskov substitution of these entities.
	/// <seealso cref="ILegalEntity"/>
	/// <seealso cref="Association"/>
	/// </summary>
	[DataContract]
	public abstract class LegalEntityAssociation : SerializableAssociation
	{
		internal LegalEntityAssociation()
		{
			// for deserialization purposes
		}

		internal LegalEntityAssociation(Association from)
			: base(from)
		{

		}

		internal LegalEntityAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{

		}


		protected LegalEntityAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{

		}

		protected LegalEntityAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
										 bool isHistorical, DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, isHistorical, contactCreationDate)
		{

		}


		public new bool IsHistorical { get; set; }

		public new TimePeriod ValidFor { get; set; }
	}
}
