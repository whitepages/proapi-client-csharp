using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The interface for Phone <seealso cref="IEntity"/> classes
	/// </summary>
	/// <remarks>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public interface IPhone : IEntity
	{
		LineType? LineType { get; }
		string PhoneNumber { get; }
		string CountryCallingCode { get; }
		string Extension { get; }
		string Carrier { get; }
		Reputation Reputation { get; }
		bool? DoNotCall { get; }
		bool? IsPrepaid { get; }
		bool? IsValid { get; }
		bool? IsConnected { get; }

		LocationAssociation BestLocationAssociation { get; }
		ILocation BestLocation { get; }

	}
}
