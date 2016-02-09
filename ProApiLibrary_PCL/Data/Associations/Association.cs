using System;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Data.Associations
{
	/// <summary>
	/// The root interface for all Associations
	/// </summary>
	/// <remarks>
	/// (e.g. <seealso cref="PersonAssociation"/>, <seealso cref="BusinessAssociation"/>,
	/// <seealso cref="PhoneAssociation"/>, and <seealso cref="LocationAssociation"/>).
	/// 
	/// The Whitepages API presents its data in a directed graph form, whereby:
	/// <ul>
	///     <li>Each node is an <seealso cref="IEntity"/>, and</li>
	///     <li>Each edge is an <seealso cref="Association"/>.</li>
	/// </ul>
	/// 
	/// Entities contain data intrinsic to the entity, whereas associations
	/// contain data pertaining to the relationship between its source and destination
	/// entities.
	/// 
	/// Associations are a directed edge from a source entity node to
	/// a destination entity node. Since traversal starts from the source
	/// entity, there is only one accessor on
	/// the Assocation instance, which leads to the destination entity.
	/// 
	/// <seealso cref="IEntity"/>
	/// <seealso cref="PersonAssociation"/>
	/// <seealso cref="BusinessAssociation"/>
	/// <seealso cref="PhoneAssociation"/>
	/// <seealso cref="LocationAssociation"/>
	/// </remarks>
	[DataContract]
	public abstract class Association
	{
		private ResponseDictionary _responseDictionary;

		internal Association()
		{
			// for deserialization purposes
		}

		internal Association(Association from)
		{
			this.EntityId = from.EntityId;
			this.IsHistorical = from.IsHistorical;
			this.ValidFor = from.ValidFor;
		}

		internal Association(Association from, ResponseDictionary responseDictionary)
			: this(from)
		{
			_responseDictionary = responseDictionary;
		}


		protected Association(EntityId entityId, ResponseDictionary responseDictionary)
			: this(entityId, responseDictionary, null, false, null)
		{

		}

		protected Association(EntityId entityId, ResponseDictionary responseDictionary, TimePeriod validFor, bool isHistorical,
							  DateTime? contactCreationDate)
		{
			EntityId = entityId;
			_responseDictionary = responseDictionary;
			ValidFor = validFor;
			IsHistorical = isHistorical;
			ContactCreationDate = contactCreationDate;

			ValidateEntityIdType();
		}

		protected Association(EntityId entityId, ResponseDictionary responseDictionary,
							  DateTime? contactCreationDate)
		{
			EntityId = entityId;
			_responseDictionary = responseDictionary;
			ContactCreationDate = contactCreationDate;

			ValidateEntityIdType();
		}

		[DataMember(Name = "id")]
		public EntityId EntityId { get; set; }

		/// <summary>
		/// Returns the associated entity in a way that is generic across all
		/// Association types
		/// </summary>
		/// <remarks>
		/// For strongly typed accessors, see
		/// <seealso cref="PersonAssociation"/>.Person,
		/// <seealso cref="BusinessAssociation"/>.Business,
		/// <seealso cref="PhoneAssociation"/>.Phone, and
		/// <seealso cref="LocationAssociation"/>.Location.
		/// 
		/// @return
		/// 
		/// <seealso cref="PersonAssociation"/>
		/// <seealso cref="BusinessAssociation"/>
		/// <seealso cref="PhoneAssociation"/>
		/// <seealso cref="LocationAssociation"/>
		/// </remarks>
		public abstract IEntity Entity { get; }

		public abstract EntityId.EntityType? EntityIdType { get; }

		[DataMember(Name = "valid_for")]
		protected internal TimePeriod ValidFor { get; set; }

		[DataMember(Name = "is_historical")]
		protected internal bool IsHistorical { get; set; }

		[DataMember(Name = "contact_creation_date")]
		internal long? ContactCreationDateSeconds
		{
			get
			{
				if (this.ContactCreationDate == null)
				{
					return null;
				}
				var t = this.ContactCreationDate.Value - new DateTime(1970, 1, 1);
				var secondsSinceEpoch = (long)t.TotalSeconds;
				return secondsSinceEpoch;
			}
			set
			{
				DateTime? toSet = null;
				if (value.HasValue)
				{
					var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
					toSet = epoch.AddSeconds(value.Value);
				}
				this.ContactCreationDate = toSet;
			}
		}

		public DateTime? ContactCreationDate { get; set; }

		protected internal virtual ResponseDictionary ResponseDictionary
		{
			get { return _responseDictionary; }
			set { _responseDictionary = value; }
		}

		protected void ValidateEntityIdType()
		{
			var expectedType = this.EntityIdType;
			if (this.EntityId.Type != expectedType)
			{
				throw new ArgumentException(
					String.Format(
						"EntityId of wrong type: expected {0} but got {1}",
						expectedType,
						this.EntityId.Type));
			}
		}
	}
}
