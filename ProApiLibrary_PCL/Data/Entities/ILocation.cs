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
		string StandardAddressLine1 { get; }
		string StandardAddressLine2 { get; }
		string City { get; }
		string StateCode { get; }
		string PostalCode { get; }
		string CountryCode { get; }
		string Zip4 { get; }
		TimePeriod ValidFor { get; }
		bool IsHistorical { get; }
		bool? IsReceivingMail { get; }
		Location.LocationNotReceivingMailReason? NotReceivingMailReason { get; }
		Location.AddressUsage? Usage { get; }
		Location.LocationDeliveryPoint? DeliveryPoint { get; }
		Location.LocationAddressType? AddressType { get; }
		LatLong LatLong { get; }
		bool? IsDeliverable { get; }

	}
}
