using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The standard concrete implementation of the <seealso cref="IBusiness"/> <seealso cref="IEntity"/>
	/// <seealso cref="IBusiness"/>
	/// <seealso cref="IEntity"/>
	/// </summary>
	[DataContract]
	public class Business : LegalEntity, IBusiness
	{
		public Business()
		{

		}

		public Business(EntityId entityId)
			: base(entityId)
		{

		}


		[DataMember(Name = "Name")]
		public override string Name { get; set; }

		public override string ToString()
		{
			return String.Format("{0}", this.Name).Trim();
		}

	}
}
