using System.Collections.Generic;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Abstract base class representing any of the proxy classes
	/// </summary>
	/// <remarks>
	/// <p>The complete entity graph, traversed to its full extent, would
	/// be incredibly large, thus, in practice, only a subset of this graph
	/// is presented in the Response.
	/// As a result, in some cases you may encounter associations whose nodes
	/// are not available to you. When this occurs, an appropriate <seealso cref="EntityProxy"/>
	/// instance is put into its place. To test if an entity is a proxy, use
	/// the this.IsProxy accessor.</p>
	/// 
	/// <p>Entity proxies satisfy the appropriate entity interface, returning
	/// null for all the values -- acting as if the values were masked
	/// from you. The exception to this rule is the ID of the associated entity,
	/// which is always present on a proxy value.</p>
	/// 
	/// <p>To load an entity, call the this.Load() method. <em>This method
	/// will make a call to the remote service</em>, fetching information for
	/// the associated entity ID. To test if a value has been loaded, the
	/// this.IsLoaded accessor may be used.</p>
	/// 
	/// see IsProxy
	/// see IsLoaded
	/// see Load()
	/// <seealso cref="IEntity"/>
	/// </remarks>
	public abstract class EntityProxy : IEntity
	{
		private readonly EntityId _entityId;
		private readonly Client _client;
		private readonly ResponseDictionary _responseDictionary;

		protected EntityProxy(EntityId entityId, Client client, ResponseDictionary responseDictionary)
		{
			_entityId = entityId;
			_client = client;
			_responseDictionary = responseDictionary;
			this.IsLoaded = false;
		}

		protected Client Client
		{
			get { return _client; }
		}

		public ResponseDictionary ResponseDictionary { get { return _responseDictionary; } }

		public abstract IEntity Entity { get; }

		public EntityId Id
		{
			get { return _entityId; }
		}

		public string Name
		{
			get { return this.Entity == null ? null : this.Entity.Name; }
		}

		public abstract void Load();

		public bool IsLoaded { get; set; }
		public bool IsProxy
		{
			get { return true; }
		}

		public IEnumerable<IEntity> Entities { get { return this.Entity == null ? null : this.Entity.Entities; } }
		public IEnumerable<IPhone> Phones { get { return this.Entity == null ? null : this.Entity.Phones; } }
		public IEnumerable<IBusiness> Businesses { get { return this.Entity == null ? null : this.Entity.Businesses; } }
		public IEnumerable<IPerson> People { get { return this.Entity == null ? null : this.Entity.People; } }
		public IEnumerable<ILocation> Locations { get { return this.Entity == null ? null : this.Entity.Locations; } }

		public IEnumerable<Association> Associations
		{
			get { return this.Entity == null ? null : this.Entity.Associations; }
		}

		public IList<PersonAssociation> PersonAssociations
		{
			get { return this.Entity == null ? null : this.Entity.PersonAssociations; }
		}

		public IList<BusinessAssociation> BusinessAssociations
		{
			get { return this.Entity == null ? null : this.Entity.BusinessAssociations; }
		}

		public IList<LocationAssociation> LocationAssociations
		{
			get { return this.Entity == null ? null : this.Entity.LocationAssociations; }
		}

		public IList<PhoneAssociation> PhoneAssociations
		{
			get { return this.Entity == null ? null : this.Entity.PhoneAssociations; }
		}
	}
}
