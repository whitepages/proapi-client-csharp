using System.Collections.Generic;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Data.Associations;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The root interface for all Entities
	/// </summary>
	/// <remarks>
	/// (e.g. <seealso cref="IPerson"/>, <seealso cref="IBusiness"/>, <seealso cref="IPhone"/>, and <seealso cref="Location"/>).
	/// 
	/// <p>The Whitepages API presents its data in a directed graph form, whereby:</p>
	/// <ul>
	///     <li>Each node is an <seealso cref="IEntity"/>, and</li>
	///     <li>each Edge is an <seealso cref="Association"/>.</li>
	/// </ul>
	/// 
	/// Entities contain data intrinsic to the entity, whereas associations
	/// contain data pertaining to the relationship between its source and destination
	/// entities
	/// 
	/// <h2>Properties</h2>
	/// 
	/// <p>Entity properties are optionally filled in; factors include
	/// the query type and the API Key configuration. When a value is not
	/// available, its accessor is filled in with a {@code null} value,
	/// therefore it is a good idea to check the nullness of property
	/// values before using them.</p>
	/// 
	/// <h2>Traversal</h2>
	/// 
	/// <p>There are two ways to traverse the graph:</p>
	/// <ol>
	///     <li>Explicit traversal through the association, and</li>
	///     <li>Direct traversal to the associated entity.</li>
	/// </ol>
	/// <p>The former is useful when information on the association is desired;
	/// however, one is often interested only in the associated entity itself,
	/// in which case direct traversal is clearer.</p>
	/// 
	/// <p>For example, the following two lines have the same effect:</p>
	/// <pre>
	/// {@code
	/// Person p1 = phone.getPersonAssociations().get(0).getPerson();
	/// Person p2 = phone.getPeople().get(0);
	/// p1 == p2 //is true
	/// }
	/// </pre>
	/// <p>Careful readers of the above example will note that extra safety code is needed
	/// to check that the returned lists are non-null and non-empty before
	/// calling {@code get()}.</p>
	/// 
	/// <h2>Proxies</h2>
	/// 
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
	/// this.IsLoaded() method may be used.</p>
	/// 
	/// <seealso cref="IPerson"/>
	/// <seealso cref="IBusiness"/>
	/// <seealso cref="IPhone"/>
	/// <seealso cref="Location"/>
	/// <seealso cref="Association"/>
	/// <seealso cref="EntityProxy"/>
	/// </remarks>
	public interface IEntity
	{
		/// <summary>
		/// The EntityId associated with this entity
		/// </summary>
		EntityId Id { get; }

		/// <summary>
		/// A standardized method for getting the primary, human readable, formatted 
		/// string version of this entity.
		/// </summary>
		/// <returns>The human formatted string.</returns>
		string Name { get; }

		/// <summary>
		/// A convenience method for getting the concatenation of the association lists.
		/// </summary>
		/// <returns>A concatenated list of all associations</returns>
		IEnumerable<Association> Associations { get; }

		/// <summary>
		/// A convenience method for getting the concatenation of the entity lists.
		/// </summary>
		/// <returns>A concatenated list of all entities associated with this entity</returns>
		IEnumerable<IEntity> Entities { get; }
		IEnumerable<IPhone> Phones { get; }
		IEnumerable<IBusiness> Businesses { get; }
		IEnumerable<IPerson> People { get; }
		IEnumerable<ILocation> Locations { get; }

		IList<BusinessAssociation> BusinessAssociations { get; }
		IList<PersonAssociation> PersonAssociations { get; }
		IList<LocationAssociation> LocationAssociations { get; }
		IList<PhoneAssociation> PhoneAssociations { get; }

		ResponseDictionary ResponseDictionary { get; }

		/// <summary>
		/// Returns true if this entity instance is a proxy instance.
		/// </summary>
		/// <remarks>
		/// see this.IsLoaded
		/// see this.Load()
		/// <seealso cref="EntityProxy"/>
		/// </remarks>
		/// <returns>true if this entity instance is a proxy instance</returns>
		bool IsProxy { get; }

		/// <summary>
		/// If the called on a proxy, return true only
		/// if the backing entity has been fetched. If called
		/// on a concrete entity, then always return true.
		/// see this.IsProxy
		/// see this.Load()
		/// <seealso cref="EntityProxy"/>
		/// </summary>
		/// <returns>load status for this entity</returns>
		bool IsLoaded { get; }

		/// <summary>
		/// Causes this instance to load its data by contacting
		/// the remote service and requesting information.
		/// </summary>
		/// <remarks>
		/// Once loaded, subsequent calls to this method have
		/// no effect.
		/// 
		/// This method is useful for proxy entities found
		/// at the edge of the graph
		/// 
		/// see this.IsProxy
		/// see this.IsLoaded
		/// <seealso cref="EntityProxy"/>
		/// </remarks>
		void Load();
	}
}
