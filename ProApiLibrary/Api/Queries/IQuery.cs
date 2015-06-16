namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The root type for all Queries. The following concrete Query classes are available for use
	/// </summary>
	/// <remarks>
	/// <![CDATA[
	/// <ul>
	///     <li><seealso cref="PersonQuery"/></li>
	///     <li><seealso cref="BusinessQuery"/></li>
	///     <li><seealso cref="PhoneQuery"/></li>
	///     <li><seealso cref="PhoneLiteQuery"/></li>
	///     <li><seealso cref="LocationQuery"/></li>
	/// </ul>
	/// 
	/// <h2>Example Queries</h2>
	/// 
	/// <p>Find a person by name and zip code:</p>
	/// <code>
	/// public PersonQuery queryByNameAndZip(String firstName, String lastName, String zip) {
	///     PersonQuery q = new PersonQuery(firstName, null, lastName);
	///     q.setPostalCode(zip);
	///     return q;
	/// }
	/// </code>
	/// 
	/// <p>Find a location by entity id:</p>
	/// <code>
	/// public LocationQuery queryByLocId(EntityId id) {
	///     return new LocationQuery(id);
	/// }
	/// </code>
	/// 
	/// <p>Find a phone number with a boolean switch between a full and a lite phone query:</p>
	/// <code>
	/// public PhoneQuery queryPhoneNumber(String number, boolean lite) {
	///     return lite ? new PhoneLiteQuery(number) : new PhoneQuery(number);
	/// }
	/// </code>
	/// 
	/// <seealso cref="PersonQuery"/>
	/// <seealso cref="BusinessQuery"/>
	/// <seealso cref="PhoneQuery"/>
	/// <seealso cref="PhoneLiteQuery"/>
	/// <seealso cref="LocationQuery"/>
	/// ]]>
	/// </remarks>
	public interface IQuery
	{
	}
}
