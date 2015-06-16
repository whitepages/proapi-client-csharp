using System;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The root concrete class for all Person queries
	/// </summary>
	public class PersonQuery : WhereQuery
	{
		public PersonQuery()
		{
			
		}

		public PersonQuery(EntityId entityId) : base(entityId)
		{
			
		}

		public PersonQuery(string name, string city, string stateCode, string postalCode) : base(city, stateCode, postalCode)
		{
			this.Name = name;
		}

		public PersonQuery(string firstName, string middleName, string lastName, string city, string stateCode, string postalCode)
			: base(city, stateCode, postalCode)
		{
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
		}

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string Suffix { get; set; }
		public string Title { get; set; }
		public bool? UseHistorical { get; set; }
		public bool? UseMetro { get; set; }

		public override string ParamsToString()
		{
			string s = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
								 ParamToString("name", this.Name),
								 ParamToString("firstName", this.FirstName),
								 ParamToString("middleName", this.MiddleName),
								 ParamToString("lastName", this.LastName),
								 ParamToString("suffix", this.Suffix),
								 ParamToString("title", this.Title),
								 ParamToString("useHistorical", this.UseHistorical),
								 ParamToString("useMetro", this.UseMetro));

			return s + base.ParamsToString();

		}
	}
}
