using System.Collections.Generic;
using System.Linq;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Associations;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Strongly typed <seealso cref="EntityProxy"/> for <seealso cref="IPerson"/> entities
	/// </summary>
	/// <remarks>
	/// <seealso cref="EntityProxy"/>
	/// <seealso cref="IPerson"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public class PersonProxy : EntityProxy, IPerson
	{
		private IPerson _person;
		private ILocation _bestLocation;
		private LocationAssociation _bestLocationAssociation;

		public PersonProxy(EntityId entityId, Client client, ResponseDictionary responseDictionary)
			: base(entityId, client, responseDictionary)
		{

		}

		public IPerson Person
		{
			get { return _person; }
		}

		public override IEntity Entity
		{
			get { return this.Person; }
		}

		public override void Load()
		{
			if (!IsLoaded)
			{
				var response = this.Client.FindPeople(new PersonQuery(this.Id));
				var results = response.Results;
				_person = ((results == null || !results.Any()) ? null : results.First());
				this.IsLoaded = true;
			}
		}

		public PersonType? Type
		{
			get { return _person == null ? null : _person.Type; }
		}

		public IEnumerable<Person.PersonName> Names { get; set; }
		public AgeRange AgeRange { get; set; }
		public Gender? Gender { get; set; }
		public string BestName { get; set; }
		public LocationAssociation BestLocationAssociation
		{
			get { return _bestLocationAssociation; }
			set
			{
				_bestLocationAssociation = value;
				_bestLocation = null;

			}
		}
		public ILocation BestLocation
		{
			get
			{
				if ((_bestLocation == null) && (_bestLocationAssociation != null))
				{
					return _bestLocationAssociation.Location;
				}
				return _bestLocation;
			}
		}

		public new string Name
		{
			get { return this.BestName; }
		}
	}


}
