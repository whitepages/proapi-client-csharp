using System.Linq;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// Strongly typed <seealso cref="EntityProxy"/> for <seealso cref="IBusiness"/> entities
	/// </summary>
	/// <remarks>
	/// <seealso cref="EntityProxy"/>
	/// <seealso cref="IBusiness"/>
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public class BusinessProxy : EntityProxy, IBusiness
	{
		private IBusiness _business;

		public BusinessProxy(EntityId entityId, Client client, ResponseDictionary responseDictionary)
			: base(entityId, client, responseDictionary)
		{

		}

		public override IEntity Entity
		{
			get { return _business; }
		}

		public override void Load()
		{
			if (!IsLoaded)
			{
				var response = this.Client.FindBusinesses(new BusinessQuery(this.Id));
				var results = response.Results;
				_business = ((results == null || !results.Any()) ? null : results.First());
				this.IsLoaded = true;
			}
		}

	}
}
