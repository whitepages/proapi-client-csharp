using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The interface for Person <seealso cref="IEntity"/> classes
	/// </summary>
	/// <remarks>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public interface IPerson : ILegalEntity
	{
		IEnumerable<Person.PersonName> Names { get; }
		AgeRange AgeRange { get; }
		Gender? Gender { get; }
		
	}
}
