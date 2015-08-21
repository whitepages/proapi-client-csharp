using System.Linq;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Strongly typed <seealso cref="EntityProxy"/> for <seealso cref="Location"/> entities
	/// </summary>
	/// <remarks>
	/// <seealso cref="EntityProxy"/>
	/// <seealso cref="Location"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public class LocationProxy : EntityProxy, ILocation
	{
		private ILocation _location;

		public LocationProxy(EntityId entityId, Client client, ResponseDictionary responseDictionary)
			: base(entityId, client, responseDictionary)
		{

		}

		public override IEntity Entity
		{
			get { return _location; }
		}

		public override void Load()
		{
			if (!IsLoaded)
			{
				var response = this.Client.FindLocations(new LocationQuery(this.Id));
				var results = response.Results;
				_location = ((results == null || !results.Any()) ? null : results.First());
				this.IsLoaded = true;
			}
		}

		public Location.LocationType? Type
		{
			get { return _location == null ? null : _location.Type; }
		}

		public string Address
		{
			get { return _location == null ? null : _location.Address; }
		}

		public string StandardAddressLine1
		{
			get { return _location == null ? null : _location.StandardAddressLine1; }
		}

		public string StandardAddressLine2
		{
			get { return _location == null ? null : _location.StandardAddressLine2; }
		}

		public string StandardAddressLocation
		{
			get { return _location == null ? null : _location.StandardAddressLocation; }
		}

		public string City
		{
			get { return _location == null ? null : _location.City; }
		}

		public string StateCode
		{
			get { return _location == null ? null : _location.StateCode; }
		}

		public string PostalCode
		{
			get { return _location == null ? null : _location.PostalCode; }
		}

		public string CountryCode
		{
			get { return _location == null ? null : _location.CountryCode; }
		}

		public string AptType
		{
			get { return _location == null ? null : _location.AptType; }
		}

		public string Zip4
		{
			get { return _location == null ? null : _location.Zip4; }
		}

		public string House
		{
			get { return _location == null ? null : _location.House; }
		}

		public string StreetName
		{
			get { return _location == null ? null : _location.StreetName; }
		}

		public string StreetType
		{
			get { return _location == null ? null : _location.StreetType; }
		}

		public string PreDir
		{
			get { return _location == null ? null : _location.PreDir; }
		}

		public string PostDir
		{
			get { return _location == null ? null : _location.PostDir; }
		}

		public string AptNumber
		{
			get { return _location == null ? null : _location.AptNumber; }
		}

		public string BoxNumber
		{
			get { return _location == null ? null : _location.BoxNumber; }
		}

		public TimePeriod ValidFor
		{
			get { return _location == null ? null : _location.ValidFor; }
		}

		public bool IsHistorical
		{
			get { return _location != null && _location.IsHistorical; }
		}

		public bool? IsReceivingMail
		{
			get { return _location == null ? null : _location.IsReceivingMail; }
		}

		public Location.LocationNotReceivingMailReason? NotReceivingMailReason
		{
			get { return _location == null ? null : _location.NotReceivingMailReason; }
		}

		public Location.AddressUsage? Usage
		{
			get { return _location == null ? null : _location.Usage; }
		}

		public Location.LocationDeliveryPoint? DeliveryPoint
		{
			get { return _location == null ? null : _location.DeliveryPoint; }
		}

		public Location.LocationBoxType? BoxType
		{
			get { return _location == null ? null : _location.BoxType; }
		}

		public Location.LocationAddressType? AddressType
		{
			get { return _location == null ? null : _location.AddressType; }
		}

		public LatLong LatLong
		{
			get { return _location == null ? null : _location.LatLong; }
		}

		public bool? IsDeliverable
		{
			get { return _location == null ? null : _location.IsDeliverable; }
		}



	}


}
