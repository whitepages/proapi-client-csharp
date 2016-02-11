using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class Name
	{
		[DataMember(Name="salutation")]
		public string Salutation { get; set; }
		[DataMember(Name="first_name")]
		public string FirstName { get; set; }
		[DataMember(Name="middle_name")]
		public string MiddleName { get; set; }
		[DataMember(Name="last_name")]
		public string LastName { get; set; }
		[DataMember(Name="suffix")]
		public string Suffix { get; set; }
		[DataMember(Name="valid_for")]
		public string ValidFor { get; set; }

		public override string ToString()
		{
			return String.Format("Name{salutation='{0}', firstName='{1}', middleName='{2}', lastName='{3}', suffix='{4}', validFor={5}};", 
						this.Salutation, this.FirstName, this.MiddleName, this.LastName,
			                     this.Suffix, this.ValidFor).Trim();
		}
	}
}
