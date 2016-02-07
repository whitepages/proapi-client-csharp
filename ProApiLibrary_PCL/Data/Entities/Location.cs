using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// /// The standard concrete implementation of the <seealso cref="Location"/> <seealso cref="IEntity"/>.
	/// </summary>
	/// <remarks>
	/// <seealso cref="Location"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	[DataContract]
	public class Location : BaseEntity, ILocation
	{
		public enum LocationType
		{
			LatLong,
			Address,
			State,
			City,
			County,
			Neighborhood,
			PostalCode,
			Country,
			ZipPlus4,
			CityPostalCode
		}

		public enum LocationNotReceivingMailReason
		{
			Vacant,
			NewConstruction,
			Rural
		}

		public enum AddressUsage
		{
			Residential,
			Business
		}

		public enum LocationAddressType
		{
			Firm,
			GeneralDelivery,
			HighRise,
			PoBox,
			RuralRoute,
			Street
		}

		public enum LocationDeliveryPoint
		{
			CommercialMailDrop,
			PoBoxThrowback,
			PoBox,
			MultiUnit,
			SingleUnit
		}

		public Location()
		{

		}

		public Location(EntityId entityId)
			: base(entityId)
		{

		}

		[DataMember(Name = "valid_for")]
		public TimePeriod ValidFor { get; set; }
		[DataMember(Name = "is_historical")]
		public bool IsHistorical { get; set; }
		[DataMember(Name = "contact_type")]
		public string ContactType { get; set; }
		[DataMember(Name = "contact_creation_date")]
		internal long? ContactCreationDate { get; set; }
		[DataMember(Name = "type")]
		public LocationType? Type { get; set; }
		[DataMember(Name = "address")]
		public string Address { get; set; }
		[DataMember(Name = "standard_address_line1")]
		public string StandardAddressLine1 { get; set; }
		[DataMember(Name = "standard_address_line2")]
		public string StandardAddressLine2 { get; set; }
		[DataMember(Name = "standard_address_location")]
		public string StandardAddressLocation { get; set; }
		[DataMember(Name = "city")]
		public string City { get; set; }
		[DataMember(Name = "state_code")]
		public string StateCode { get; set; }
		[DataMember(Name = "postal_code")]
		public string PostalCode { get; set; }
		[DataMember(Name = "country_code")]
		public string CountryCode { get; set; }
		[DataMember(Name = "apt_type")]
		public string AptType { get; set; }
		[DataMember(Name = "zip_4")]
		public string Zip4 { get; set; }
		[DataMember(Name = "house")]
		public string House { get; set; }
		[DataMember(Name = "street_name")]
		public string StreetName { get; set; }
		[DataMember(Name = "street_type")]
		public string StreetType { get; set; }
		[DataMember(Name = "pre_dir")]
		public string PreDir { get; set; }
		[DataMember(Name = "post_dir")]
		public string PostDir { get; set; }
		[DataMember(Name = "apt_number")]
		public string AptNumber { get; set; }
		[DataMember(Name = "box_number")]
		public string BoxNumber { get; set; }

		[DataMember(Name = "is_receiving_mail")]
		public bool? IsReceivingMail { get; set; }
		public LocationNotReceivingMailReason? NotReceivingMailReason { get; set; }

		[DataMember(Name = "usage")]
		public AddressUsage? Usage { get; set; }

		[DataMember(Name = "address_type")]
		public LocationAddressType? AddressType { get; set; }

		[DataMember(Name = "lat_long", IsRequired=false)]
		public LatLong LatLong { get; set; }

		[DataMember(Name = "is_deliverable")]
		public bool? IsDeliverable { get; set; }

		[DataMember(Name = "delivery_point")]
		public LocationDeliveryPoint? DeliveryPoint { get; set; }
		
		public override string Name
		{
			get { return this.Address; }
			set { this.Address = value; }
		}

		[DataMember(Name = "legal_entities_at")]
		internal IEnumerable<SerializableAssociation> LegalEntitiesAt
		{
			get { return null; }
			set
			{
				if (value != null)
				{
					foreach (var e in value)
					{
						if (e.EntityId.IsPerson)
						{
							this.AddPersonAssociation(new PersonAssociation(e, this.ResponseDictionary));
						}
						else if (e.EntityId.IsBusiness)
						{
							this.AddBusinessAssociation(new BusinessAssociation(e, this.ResponseDictionary));
						}
						else if (e.EntityId.IsLocation)
						{
							this.AddLocationAssociation(new LocationAssociation(e, this.ResponseDictionary));
						}
						else if (e.EntityId.IsPhone)
						{
							this.AddPhoneAssociation(new PhoneAssociation(e, this.ResponseDictionary));
						}
					}
				}
			}
		}
	}
}
