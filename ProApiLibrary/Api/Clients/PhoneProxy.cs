using System.Linq;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Associations;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Strongly typed <seealso cref="EntityProxy"/> for <seealso cref="IPhone"/> entities
	/// </summary>
	/// <remarks>
	/// <seealso cref="EntityProxy"/>
	/// <seealso cref="IPhone"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public class PhoneProxy : EntityProxy, IPhone
	{
		private IPhone _phone;

		public PhoneProxy(EntityId entityId, Client client, ResponseDictionary responseDictionary)
			: base(entityId, client, responseDictionary)
		{

		}

		public override IEntity Entity
		{
			get { return _phone; }
		}

		public override void Load()
		{
			if (!IsLoaded)
			{
				var response = this.Client.FindPhones(new PhoneQuery(this.Id));
				var results = response.Results;
				_phone = ((results == null || !results.Any()) ? null : results.First());
				this.IsLoaded = true;
			}
		}

		public LineType? LineType { get { return _phone == null ? null : _phone.LineType; } }
		public string PhoneNumber { get { return _phone == null ? null : _phone.PhoneNumber; } }
		public string CountryCallingCode { get { return _phone == null ? null : _phone.CountryCallingCode; } }
		public string Extension { get { return _phone == null ? null : _phone.Extension; }}
		public string Carrier { get { return _phone == null ? null : _phone.Carrier; } }
		public Reputation Reputation { get { return _phone == null ? null : _phone.Reputation; } }
		public bool? DoNotCall { get { return _phone == null ? null : _phone.DoNotCall; } }
		public bool? IsPrepaid { get { return _phone == null ? null : _phone.IsPrepaid; }}
		public bool? IsValid { get { return _phone == null ? null : _phone.IsValid; } }
		public LocationAssociation BestLocationAssociation { get { return _phone == null ? null : _phone.BestLocationAssociation; } }
		public ILocation BestLocation { get { return _phone == null ? null : _phone.BestLocation; } }

		

	}


}
