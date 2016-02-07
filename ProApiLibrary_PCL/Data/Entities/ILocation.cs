using System.Runtime.Serialization;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The interface for Location <seealso cref="IEntity"/> classes
	/// </summary>
	/// <remarks>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public interface ILocation : IEntity
	{
		Location.LocationType? Type { get; }
		string Address { get; }
		string StandardAddressLine1 { get; }
		string StandardAddressLine2 { get; }
		string StandardAddressLocation { get; }
		string City { get; }
		string StateCode { get; }
		string PostalCode { get; }
		string CountryCode { get; }
		string AptType { get; }
		string Zip4 { get; }
		string House { get; }
		string StreetName { get; }
		string StreetType { get; }
		string PreDir { get; }
		string PostDir { get; }
		string AptNumber { get; }
		string BoxNumber { get; }
		TimePeriod ValidFor { get; }
		bool IsHistorical { get; }
		bool? IsReceivingMail { get; }
		Location.LocationNotReceivingMailReason? NotReceivingMailReason { get; }
		Location.AddressUsage? Usage { get; }
		Location.LocationDeliveryPoint? DeliveryPoint { get; }
		Location.LocationBoxType? BoxType { get; }
		Location.LocationAddressType? AddressType { get; }
		LatLong LatLong { get; }
		bool? IsDeliverable { get; }

	}
}
