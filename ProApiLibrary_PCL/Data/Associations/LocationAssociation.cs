﻿using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// The <seealso cref="ILocation"/> type specific <seealso cref="Association"/>
	/// </summary>
	/// <remarks>
	/// This class also adds accessors for the contact type of the location.
	/// 
	/// <seealso cref="Location"/>
	/// <seealso cref="Association"/>
	/// </remarks>
	[DataContract]
	public class LocationAssociation : SerializableAssociation
	{
		internal LocationAssociation(Association from)
			: base(from)
		{

		}

		internal LocationAssociation(Association from, ResponseDictionary responseDictionary)
			: base(from, responseDictionary)
		{

		}

		internal LocationAssociation()
		{
			// for deserialization purposes
		}

		public LocationAssociation(EntityId entityId, ResponseDictionary responseDictionary)
			: base(entityId, responseDictionary)
		{

		}

		protected LocationAssociation(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor,
										 bool isHistorical, DateTime? contactCreationDate)
			: base(entityId, responseDictionary, validFor, isHistorical, contactCreationDate)
		{
			
		}

		public override IEntity Entity
		{
			get { return this.Location; }
		}

		public override EntityId.EntityType? EntityIdType
		{
			get { return EntityId.EntityType.Location; }
		}

		public ILocation Location
		{
			get { return this.ResponseDictionary.GetLocation(this.EntityId); }
		}


		public new bool IsHistorical { get; set; }

		public new TimePeriod ValidFor { get; set; }
	}
}
