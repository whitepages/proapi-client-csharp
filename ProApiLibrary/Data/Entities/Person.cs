using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The standard concrete implementation of the <seealso cref="IPerson"/> <seealso cref="IEntity"/>
	/// </summary>
	/// <remarks>
	/// <seealso cref="IPerson"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	[DataContract]
	public class Person : BaseEntity, IPerson
	{
		private LocationAssociation _bestLocationAssociation;
		private ILocation _bestLocation;

		private string _bestName;
		private string _name;

		public Person()
		{

		}

		public Person(EntityId entityId)
			: base(entityId)
		{

		}

		[DataMember(Name = "name")]
		public override string Name
		{
			get { return _name ?? _bestName; }
			set { _name = value; }
		}

		[DataMember(Name = "type")]
		public PersonType? Type { get; set; }
		[DataMember(Name = "names")]
		public IEnumerable<PersonName> Names { get; set; }
		[DataMember(Name = "age_range")]
		public AgeRange AgeRange { get; set; }
		[DataMember(Name = "gender")]
		public Gender? Gender { get; set; }

		public ILocation BestLocation
		{
			get
			{
				if ((_bestLocation == null) && (_bestLocationAssociation != null))
				{
					_bestLocationAssociation.ResponseDictionary = this.ResponseDictionary;
					_bestLocation = _bestLocationAssociation.Location;
				}
				return _bestLocation;
			}
		}

		[DataMember(Name = "best_location_association")]
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

		[DataMember(Name = "best_location")]
		protected internal LocationAssociation SerializedBestLocation
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

		[DataMember(Name = "best_name")]
		public string BestName
		{
			get { return _bestName ?? _name; }
			set { _bestName = value; }
		}

		public new string ToString()
		{
			return this.Name;
		}

		#region Internal classes

		[DataContract]
		public class PersonName
		{
			[DataMember(Name = "salutation")]
			public string Salutation { get; set; }
			[DataMember(Name = "first_name")]
			public string FirstName { get; set; }
			[DataMember(Name = "middle_name")]
			public string MiddleName { get; set; }
			[DataMember(Name = "last_name")]
			public string LastName { get; set; }
			[DataMember(Name = "suffix")]
			public string Suffix { get; set; }
			[DataMember(Name = "valid_for")]
			public TimePeriod ValidFor { get; set; }

			public override string ToString()
			{
				return String.Format("[Name{{salutation={0}, firstName='{1}', middleName='{2}', lastName='{3}', suffix='{4}'}}]", 
					String.IsNullOrWhiteSpace(this.Salutation) ? "null" : this.Salutation, 
					String.IsNullOrWhiteSpace(this.FirstName) ? "null" : this.FirstName, 
					String.IsNullOrWhiteSpace(this.MiddleName) ? "null" : this.MiddleName, 
					String.IsNullOrWhiteSpace(this.LastName) ? "null" : this.LastName,
					String.IsNullOrWhiteSpace(this.Suffix) ? "null" : this.Suffix.Trim()
					);
			}
		}

		#endregion
	}
}
