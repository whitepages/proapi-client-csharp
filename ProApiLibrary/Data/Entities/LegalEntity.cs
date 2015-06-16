using System.Runtime.Serialization;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public abstract class LegalEntity : BaseEntity
	{
		protected LegalEntity()
		{
			
		}

		protected LegalEntity(EntityId entityId) : base(entityId)
		{
			
		}
		
	}
}
