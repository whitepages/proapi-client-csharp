using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The standard concrete implementation of the <seealso cref="IPhone"/> <seealso cref="IEntity"/>
	/// </summary>
	/// <remarks>
	/// <seealso cref="IPhone"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	[DataContract]
	public class Phone : BaseEntity, IPhone
	{
		private ILocation _bestLocation;
		private LocationAssociation _bestLocationAssociation;

		public Phone()
		{
			
		}

		public Phone(EntityId entityId) : base(entityId)
		{
			
		}

		public override string Name
		{
			get { return this.PhoneNumber; }
			set { this.PhoneNumber = value; }
		}

		public static int? GetSpamScore(Reputation reputation)
		{
			return reputation != null ? reputation.SpamScore : null;
		}

		[DataMember(Name="line_type")]
		public LineType? LineType { get; set; }
		[DataMember(Name="phone_number")]
		public string PhoneNumber { get; set; }
		[DataMember(Name="country_calling_code")]
		public string CountryCallingCode { get; set; }
		[DataMember(Name="extension")]
		public string Extension { get; set; }
		[DataMember(Name="carrier")]
		public string Carrier { get; set; }
		[DataMember(Name="reputation")]
		public Reputation Reputation { get; set; }
		[DataMember(Name="do_not_call")]
		public bool? DoNotCall { get; set; }
		[DataMember(Name="is_prepaid")]
		public bool? IsPrepaid { get; set; }
		[DataMember(Name="is_valid")]
		public bool? IsValid { get; set; }

		[DataMember(Name="best_location_association")]
		public LocationAssociation BestLocationAssociation
		{
			get { return _bestLocationAssociation; }
			set
			{
				_bestLocationAssociation = value;
				_bestLocationAssociation.ResponseDictionary = this.ResponseDictionary;
				_bestLocation = null;
			}
		}

		[DataMember(Name="best_location")]
		internal LocationAssociation SerializedBestLocation
		{
			get { return null; }
			set
			{
				_bestLocationAssociation = value;
				if (_bestLocationAssociation != null)
				{
					_bestLocationAssociation.ResponseDictionary = this.ResponseDictionary;
				}
				_bestLocation = null;
			}
		}

		public ILocation BestLocation
		{
			get
			{
				if (_bestLocation == null && _bestLocationAssociation != null)
				{
					_bestLocationAssociation.ResponseDictionary = this.ResponseDictionary;
					_bestLocation = _bestLocationAssociation.Location;
				}
				return _bestLocation;
			}
			set { _bestLocation = value; }
		}

		[DataMember(Name="belongs_to")]
		protected internal IEnumerable<SerializableAssociation> BelongsTo
		{
			get { return null; }
			set
			{
				if (value != null)
				{
					foreach (var v in value)
					{
						if (v.EntityIdType == EntityId.EntityType.Person)
						{
							AddPersonAssociation(new PersonAssociation(v, this.ResponseDictionary));
						}
						else if (v.EntityIdType == EntityId.EntityType.Business)
						{
							AddBusinessAssociation(new BusinessAssociation(v, this.ResponseDictionary));
						}
						
					}
				}
			}
		}

		[DataMember(Name="associated_locations")]
		protected internal IList<LocationAssociation> SerializedAssociatedLocations
		{
			get { return null; }
			set
			{
				if (value != null)
				{
					foreach (var v in value)
					{
						AddLocationAssociation(v);
					}
				}
			}
		}

	}
}
