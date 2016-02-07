using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Abstract class for implementation of common behaviors between all
	/// <seealso cref="IEntity"/> types
	/// </summary>
	/// <seealso cref="IEntity"/>
	[DataContract]
	public abstract class BaseEntity : IEntity
	{
		protected IEnumerable<IPerson> _persons;
		protected IEnumerable<IBusiness> _businesses;
		protected IEnumerable<ILocation> _locations;
		protected IEnumerable<IPhone> _phones;
		protected IList<BusinessAssociation> _businessAssociations;
		protected IList<PhoneAssociation> _phoneAssociations;
		protected IList<LocationAssociation> _locationAssociations;
		protected IList<PersonAssociation> _personAssociations;

		protected BaseEntity()
		{

		}

		protected BaseEntity(EntityId entityId)
		{
			this.Id = entityId;
		}

		[DataMember(Name = "id")]
		public EntityId Id { get; set; }

		[DataMember(Name = "name")]
		public abstract string Name { get; set; }

		public virtual bool IsProxy { get { return false; } }

		public virtual bool IsLoaded { get { return true; } }

		#region Entities

		public IEnumerable<IEntity> Entities
		{
			get
			{
				var list = new List<IEntity>();
				AddAllIfNotNull(list, this.People);
				AddAllIfNotNull(list, this.Businesses);
				AddAllIfNotNull(list, this.Locations);
				AddAllIfNotNull(list, this.Phones);
				return list;
			}
		}

		public IEnumerable<IPhone> Phones
		{
			get
			{
				if ((_phones == null) && (this.PhoneAssociations != null))
				{
					return this.PhoneAssociations.Select(x => x.Phone);
				}
				return _phones;
			}
			set { _phones = value; }
		}

		public IEnumerable<IBusiness> Businesses
		{
			get
			{
				if ((_businesses == null) && (this.BusinessAssociations != null))
				{
					return this.BusinessAssociations.Select(x => x.Business);
				}
				return _businesses;
			}
			set { _businesses = value; }
		}

		public IEnumerable<IPerson> People
		{
			get
			{
				if ((_persons == null) && (this.PersonAssociations != null))
				{
					return this.PersonAssociations.Select(x => x.Person);
				}
				return _persons;
			}
			set { _persons = value; }
		}

		public IEnumerable<ILocation> Locations
		{
			get
			{
				if ((_locations == null) && (this.LocationAssociations != null))
				{
					return this.LocationAssociations.Select(x => x.Location);
				}
				return _locations;
			}
			set { _locations = value; }
		}

		#endregion

		#region Serialization Helpers

		[IgnoreDataMember]
		public ResponseDictionary ResponseDictionary { get; set; }

		[DataMember(Name = "locations")]
		protected internal virtual IList<LocationAssociation> SerializedLocations
		{
			get { return null; }
			set { _locationAssociations = value; }
		}

		[DataMember(Name = "phones")]
		protected internal IList<PhoneAssociation> SerializedPhones
		{
			get { return null; }
			set { _phoneAssociations = value; }
		}

		[DataMember(Name = "businesses")]
		protected internal IList<BusinessAssociation> SerializedBusinesses
		{
			get { return null; }
			set { _businessAssociations = value; }
		}

		[DataMember(Name = "persons")]
		protected internal IList<PersonAssociation> SerializedPersons
		{
			get { return null; }
			set { _personAssociations = value; }
		}

		#endregion

		#region Associations

		public IEnumerable<Association> Associations
		{
			get
			{
				var list = new List<Association>();
				AddAllIfNotNull(list, _personAssociations);
				AddAllIfNotNull(list, _businessAssociations);
				AddAllIfNotNull(list, _locationAssociations);
				AddAllIfNotNull(list, _phoneAssociations);
				return list;
			}
		}

		public IList<BusinessAssociation> BusinessAssociations
		{
			get
			{
				if (_businessAssociations != null)
				{
					foreach (var ba in _businessAssociations.Where(x => x.ResponseDictionary == null))
					{
						ba.ResponseDictionary = this.ResponseDictionary;
					}
				}
				return _businessAssociations;
			}
			set
			{
				_businessAssociations = value;
				_businesses = null;
			}
		}

		public IList<PhoneAssociation> PhoneAssociations
		{
			get
			{
				if (_phoneAssociations != null)
				{
					foreach (var pa in _phoneAssociations.Where(x => x.ResponseDictionary == null))
					{
						pa.ResponseDictionary = this.ResponseDictionary;
					}
				}
				return _phoneAssociations;
			}
			set
			{
				_phoneAssociations = value;
				_phones = null;
			}
		}

		public IList<LocationAssociation> LocationAssociations
		{
			get
			{
				if (_locationAssociations != null)
				{
					foreach (var la in _locationAssociations.Where(x => x.ResponseDictionary == null))
					{
						la.ResponseDictionary = this.ResponseDictionary;
					}
				}
				return _locationAssociations;
			}
			set
			{
				_locationAssociations = value;
				_locations = null;
			}
		}

		public IList<PersonAssociation> PersonAssociations
		{
			get
			{
				if (_personAssociations != null)
				{
					foreach (var pa in _personAssociations.Where(x => x.ResponseDictionary == null))
					{
						pa.ResponseDictionary = this.ResponseDictionary;
					}
				}

				return _personAssociations;
			}
			set
			{
				_personAssociations = value;
				_persons = null;
			}
		}

		#endregion


		public virtual void Load()
		{
			// no implementation here
		}

		public override string ToString()
		{
			return String.Format("{0}: {1}", this.Id.Type, this.Id.Key);
		}

		private static void AddAllIfNotNull<T1, T2>(List<T1> coll, IEnumerable<T2> c) where T2 : T1
		{
			if (c != null)
			{
				coll.AddRange((IEnumerable<T1>)c);
			}
		}

		protected void AddPersonAssociation(PersonAssociation personAssociation)
		{
			if (personAssociation != null)
			{
				if (_personAssociations == null)
				{
					_personAssociations = new List<PersonAssociation>();
				}
				personAssociation.ResponseDictionary = this.ResponseDictionary;
				_personAssociations.Add(personAssociation);
			}
		}

		protected void AddBusinessAssociation(BusinessAssociation businessAssociation)
		{
			if (businessAssociation != null)
			{
				if (_businessAssociations == null)
				{
					_businessAssociations = new List<BusinessAssociation>();
				}
				businessAssociation.ResponseDictionary = this.ResponseDictionary;
				_businessAssociations.Add(businessAssociation);
			}
		}

		protected void AddLocationAssociation(LocationAssociation locationAssociation)
		{
			if (locationAssociation != null)
			{
				if (_locationAssociations == null)
				{
					_locationAssociations = new List<LocationAssociation>();
				}
				locationAssociation.ResponseDictionary = this.ResponseDictionary;
				_locationAssociations.Add(locationAssociation);
			}
		}

		protected void AddPhoneAssociation(PhoneAssociation phoneAssociation)
		{
			if (phoneAssociation != null)
			{
				if (_phoneAssociations == null)
				{
					_phoneAssociations = new List<PhoneAssociation>();
				}
				phoneAssociation.ResponseDictionary = this.ResponseDictionary;
				_phoneAssociations.Add(phoneAssociation);
			}
		}
	}
}
