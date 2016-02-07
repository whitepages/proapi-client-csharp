using System;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// An abstract superclass providing common methods for working with entity queries
	/// </summary>
	public abstract class EntityQuery : IQuery
	{
		protected EntityQuery()
		{
			
		}

		protected EntityQuery(EntityId id)
		{
			this.Id = id;
		}

		public EntityId Id { get; set; }

		public override string ToString() 
		{
			return this.GetType().Name + "( " +
                ParamToString("id", this.Id) +
                ParamsToString() + ")";
		}

		public abstract string ParamsToString();

		public virtual string ParamToString(String name, object value)
		{
			return String.Format("{0}={1}", name, value);
		}
	}
}
